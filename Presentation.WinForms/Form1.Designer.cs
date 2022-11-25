namespace Presentation.WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Field_Name = new System.Windows.Forms.TextBox();
            this.Field_Idade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Field_Result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Field_Name
            // 
            this.Field_Name.Location = new System.Drawing.Point(55, 12);
            this.Field_Name.Name = "Field_Name";
            this.Field_Name.Size = new System.Drawing.Size(100, 20);
            this.Field_Name.TabIndex = 0;
            // 
            // Field_Idade
            // 
            this.Field_Idade.Location = new System.Drawing.Point(56, 38);
            this.Field_Idade.Name = "Field_Idade";
            this.Field_Idade.Size = new System.Drawing.Size(100, 20);
            this.Field_Idade.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Idade";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Valida";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Field_Result
            // 
            this.Field_Result.AutoSize = true;
            this.Field_Result.Location = new System.Drawing.Point(53, 103);
            this.Field_Result.Name = "Field_Result";
            this.Field_Result.Size = new System.Drawing.Size(0, 13);
            this.Field_Result.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 126);
            this.Controls.Add(this.Field_Result);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Field_Idade);
            this.Controls.Add(this.Field_Name);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Field_Name;
        private System.Windows.Forms.TextBox Field_Idade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Field_Result;
    }
}

