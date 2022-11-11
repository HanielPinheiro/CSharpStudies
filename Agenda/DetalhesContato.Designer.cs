namespace EstudandoC_Sharp
{
    partial class DetalhesContato
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
            this.tbLayoutContatos = new System.Windows.Forms.TableLayoutPanel();
            this.Label_Organization = new System.Windows.Forms.Label();
            this.Label_Email = new System.Windows.Forms.Label();
            this.Label_Tel = new System.Windows.Forms.Label();
            this.Field_Name = new System.Windows.Forms.TextBox();
            this.Field_LastName = new System.Windows.Forms.TextBox();
            this.Field_Tel = new System.Windows.Forms.TextBox();
            this.Field_Email = new System.Windows.Forms.TextBox();
            this.Field_Organization = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Label_LastName = new System.Windows.Forms.Label();
            this.Field_FullName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Atualizar = new System.Windows.Forms.Button();
            this.tbLayoutContatos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLayoutContatos
            // 
            this.tbLayoutContatos.AutoSize = true;
            this.tbLayoutContatos.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tbLayoutContatos.ColumnCount = 2;
            this.tbLayoutContatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutContatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            this.tbLayoutContatos.Controls.Add(this.Field_FullName, 0, 5);
            this.tbLayoutContatos.Controls.Add(this.Label_Organization, 0, 4);
            this.tbLayoutContatos.Controls.Add(this.Label_Email, 0, 3);
            this.tbLayoutContatos.Controls.Add(this.Label_Tel, 0, 2);
            this.tbLayoutContatos.Controls.Add(this.Field_Name, 1, 0);
            this.tbLayoutContatos.Controls.Add(this.Field_LastName, 1, 1);
            this.tbLayoutContatos.Controls.Add(this.Field_Tel, 1, 2);
            this.tbLayoutContatos.Controls.Add(this.Field_Email, 1, 3);
            this.tbLayoutContatos.Controls.Add(this.Field_Organization, 1, 4);
            this.tbLayoutContatos.Controls.Add(this.Label_Name, 0, 0);
            this.tbLayoutContatos.Controls.Add(this.Label_LastName, 0, 1);
            this.tbLayoutContatos.Controls.Add(this.tableLayoutPanel1, 1, 5);
            this.tbLayoutContatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutContatos.Location = new System.Drawing.Point(0, 0);
            this.tbLayoutContatos.Name = "tbLayoutContatos";
            this.tbLayoutContatos.RowCount = 6;
            this.tbLayoutContatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbLayoutContatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbLayoutContatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbLayoutContatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbLayoutContatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbLayoutContatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tbLayoutContatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbLayoutContatos.Size = new System.Drawing.Size(377, 408);
            this.tbLayoutContatos.TabIndex = 0;
            // 
            // Label_Organization
            // 
            this.Label_Organization.AutoSize = true;
            this.Label_Organization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Organization.Location = new System.Drawing.Point(5, 270);
            this.Label_Organization.Name = "Label_Organization";
            this.Label_Organization.Size = new System.Drawing.Size(117, 65);
            this.Label_Organization.TabIndex = 11;
            this.Label_Organization.Text = "Organization";
            this.Label_Organization.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Email
            // 
            this.Label_Email.AutoSize = true;
            this.Label_Email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Email.Location = new System.Drawing.Point(5, 203);
            this.Label_Email.Name = "Label_Email";
            this.Label_Email.Size = new System.Drawing.Size(117, 65);
            this.Label_Email.TabIndex = 10;
            this.Label_Email.Text = "Email:";
            this.Label_Email.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Tel
            // 
            this.Label_Tel.AutoSize = true;
            this.Label_Tel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Tel.Location = new System.Drawing.Point(5, 136);
            this.Label_Tel.Name = "Label_Tel";
            this.Label_Tel.Size = new System.Drawing.Size(117, 65);
            this.Label_Tel.TabIndex = 9;
            this.Label_Tel.Text = "Tel Number:";
            this.Label_Tel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Field_Name
            // 
            this.Field_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Field_Name.Location = new System.Drawing.Point(130, 24);
            this.Field_Name.Name = "Field_Name";
            this.Field_Name.Size = new System.Drawing.Size(242, 20);
            this.Field_Name.TabIndex = 2;
            this.Field_Name.TextChanged += new System.EventHandler(this.Field_Name_TextChanged);
            // 
            // Field_LastName
            // 
            this.Field_LastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Field_LastName.Location = new System.Drawing.Point(130, 91);
            this.Field_LastName.Name = "Field_LastName";
            this.Field_LastName.Size = new System.Drawing.Size(242, 20);
            this.Field_LastName.TabIndex = 3;
            this.Field_LastName.TextChanged += new System.EventHandler(this.Field_LastName_TextChanged);
            // 
            // Field_Tel
            // 
            this.Field_Tel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Field_Tel.Location = new System.Drawing.Point(130, 158);
            this.Field_Tel.Name = "Field_Tel";
            this.Field_Tel.Size = new System.Drawing.Size(242, 20);
            this.Field_Tel.TabIndex = 4;
            this.Field_Tel.TextChanged += new System.EventHandler(this.Field_Tel_TextChanged);
            // 
            // Field_Email
            // 
            this.Field_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Field_Email.Location = new System.Drawing.Point(130, 225);
            this.Field_Email.Name = "Field_Email";
            this.Field_Email.Size = new System.Drawing.Size(242, 20);
            this.Field_Email.TabIndex = 5;
            this.Field_Email.TextChanged += new System.EventHandler(this.Field_Email_TextChanged);
            // 
            // Field_Organization
            // 
            this.Field_Organization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Field_Organization.Location = new System.Drawing.Point(130, 292);
            this.Field_Organization.Name = "Field_Organization";
            this.Field_Organization.Size = new System.Drawing.Size(242, 20);
            this.Field_Organization.TabIndex = 6;
            this.Field_Organization.TextChanged += new System.EventHandler(this.Field_Organization_TextChanged);
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Name.Location = new System.Drawing.Point(5, 2);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(117, 65);
            this.Label_Name.TabIndex = 7;
            this.Label_Name.Text = "Name:";
            this.Label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_LastName
            // 
            this.Label_LastName.AutoSize = true;
            this.Label_LastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_LastName.Location = new System.Drawing.Point(5, 69);
            this.Label_LastName.Name = "Label_LastName";
            this.Label_LastName.Size = new System.Drawing.Size(117, 65);
            this.Label_LastName.TabIndex = 8;
            this.Label_LastName.Text = "Last Name:";
            this.Label_LastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Field_FullName
            // 
            this.Field_FullName.AutoSize = true;
            this.Field_FullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Field_FullName.Location = new System.Drawing.Point(5, 337);
            this.Field_FullName.Name = "Field_FullName";
            this.Field_FullName.Size = new System.Drawing.Size(117, 69);
            this.Field_FullName.TabIndex = 13;
            this.Field_FullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_Cancelar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Atualizar, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(130, 340);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(242, 63);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cancelar.Location = new System.Drawing.Point(3, 3);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(115, 57);
            this.Btn_Cancelar.TabIndex = 13;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Atualizar
            // 
            this.Btn_Atualizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Atualizar.Location = new System.Drawing.Point(124, 3);
            this.Btn_Atualizar.Name = "Btn_Atualizar";
            this.Btn_Atualizar.Size = new System.Drawing.Size(115, 57);
            this.Btn_Atualizar.TabIndex = 14;
            this.Btn_Atualizar.Text = "Atualizar";
            this.Btn_Atualizar.UseVisualStyleBackColor = true;
            this.Btn_Atualizar.Click += new System.EventHandler(this.Btn_Atualizar_Click);
            // 
            // DetalhesContato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 408);
            this.Controls.Add(this.tbLayoutContatos);
            this.Name = "DetalhesContato";
            this.Text = "Detalhes do Contato";
            this.tbLayoutContatos.ResumeLayout(false);
            this.tbLayoutContatos.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbLayoutContatos;
        private System.Windows.Forms.Label Label_Organization;
        private System.Windows.Forms.Label Label_Email;
        private System.Windows.Forms.Label Label_Tel;
        private System.Windows.Forms.TextBox Field_Name;
        private System.Windows.Forms.TextBox Field_LastName;
        private System.Windows.Forms.TextBox Field_Tel;
        private System.Windows.Forms.TextBox Field_Email;
        private System.Windows.Forms.TextBox Field_Organization;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Label Label_LastName;
        private System.Windows.Forms.Label Field_FullName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Atualizar;
    }
}