using System.Text;
using Tesseract;

namespace ExtairTextosDeImagens
{
    public partial class FormImageToText : Form
    {
        public FormImageToText()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bd = new FolderBrowserDialog();
            if (bd.ShowDialog() == DialogResult.OK)
            {
                txtBox.Text = string.Empty;
                this.Cursor = Cursors.WaitCursor;

                Task.Run(() =>
                {
                    try
                    {
                        ExtracaoTextos a = new();
                        string result = a.Extract(bd.SelectedPath);

                        // Atualizar o UI thread com os resultados
                        this.Invoke(() =>
                        {
                            txtBox.Text = result;
                            this.Cursor = Cursors.Default;
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
    }

}

public class ExtracaoTextos
{
    private readonly object sbLock = new();
    private readonly StringBuilder sb = new();
    private string[] PalavrasChaves = ["Nome de usuário", "Telefone", "Email", "Qual cirurgia deseja realizar?"];
    private string breakline = "\n";
    private string space = "\t";

    public string Extract(string path)
    {
        var files = Directory.GetFiles(path);

        Parallel.ForEach(files, filepath =>
        {
            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "por", EngineMode.Default))
                using (var load_img = Pix.LoadFromFile(filepath))
                {
                    var img = load_img.Invert().ConvertRGBToGray();

                    using (var page = engine.Process(img))
                    {
                        string temp_text = page.GetText();
                        var interesse = temp_text.Split(breakline, StringSplitOptions.RemoveEmptyEntries).ToList();

                        StringBuilder localSb = new();
                        for (int i = 0; i < PalavrasChaves.Length; i++)
                        {
                            var idx_ = interesse.IndexOf(PalavrasChaves[i]);
                            if (idx_ != -1)
                            {
                                var tgt = interesse[idx_ + 1];

                                if (i == 0) tgt = interesse[1];
                                if (i == 2) tgt = tgt.Replace("Q", "@");
                                if (i == 3)
                                {
                                    if (interesse[idx_ + 2] != "Conhece tecnologias e técnicas cirúrgicas como")
                                        tgt = $"{tgt} {interesse[idx_ + 2]}";
                                }
                                localSb.Append(tgt + space);
                            }
                        }
                        localSb.AppendLine();

                        // Adiciona o texto extraído ao StringBuilder principal de forma thread-safe
                        lock (sbLock)
                        {
                            sb.Append(localSb.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Trate erros específicos de cada arquivo, se necessário
                lock (sbLock)
                {
                    sb.AppendLine($"Erro ao processar {filepath}: {ex.Message}");
                }
            }
        });

        return sb.ToString();
    }
}
