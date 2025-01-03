namespace ExtrairTextosPDF
{
    partial class ExtractTextFromPdf
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            btnFile = new Button();
            txtBox = new RichTextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnFile, 0, 0);
            tableLayoutPanel1.Controls.Add(txtBox, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.594937F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.40506F));
            tableLayoutPanel1.Size = new Size(946, 474);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnFile
            // 
            btnFile.Dock = DockStyle.Fill;
            btnFile.Location = new Point(3, 3);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(940, 30);
            btnFile.TabIndex = 0;
            btnFile.Text = "Escolha o arquivo PDF";
            btnFile.UseVisualStyleBackColor = true;
            btnFile.Click += btnFile_Click;
            // 
            // txtBox
            // 
            txtBox.Dock = DockStyle.Fill;
            txtBox.Location = new Point(3, 39);
            txtBox.Name = "txtBox";
            txtBox.ReadOnly = true;
            txtBox.Size = new Size(940, 432);
            txtBox.TabIndex = 1;
            txtBox.Text = "";
            // 
            // ExtractTextFromPdf
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 474);
            Controls.Add(tableLayoutPanel1);
            Name = "ExtractTextFromPdf";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Extair Texto de PDF";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnFile;
        private RichTextBox txtBox;
    }
}
