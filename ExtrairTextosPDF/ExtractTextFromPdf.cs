using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;

namespace ExtrairTextosPDF
{
    public partial class ExtractTextFromPdf : Form
    {
        public ExtractTextFromPdf()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Title = "Escolha o PDF";
            fileDialog.InitialDirectory = @"C:\";
            fileDialog.Filter = "All files (*.*)|*.*|PDF (*.pdf)|*.pdf";
            fileDialog.FilterIndex = 2;
            DialogResult result = fileDialog.ShowDialog();

            var stringBuilder = new StringBuilder();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                string filePath = Path.Combine(Path.GetTempPath(), fileDialog.FileName);
                string path = Path.Combine(AppContext.BaseDirectory, "tessdata");
                string image_path = Path.Combine(path, "test.jpeg");

                if (File.Exists(filePath))
                {
                    PdfReader pdfReader = new PdfReader(filePath); //Initialize PDF reader
                    PdfDocument pdfDoc = new PdfDocument(pdfReader);

                    for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                    {
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string data = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                        stringBuilder.Append(data);
                    }

                    txtBox.Text = stringBuilder.ToString();
                }
            }
        }
    }
}
