namespace EstudandoC_Sharp
{
    partial class Agenda
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.structurePanel = new System.Windows.Forms.TableLayoutPanel();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.btnPanel = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.cbFiltrar = new System.Windows.Forms.ComboBox();
            this.structurePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.btnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // structurePanel
            // 
            this.structurePanel.ColumnCount = 1;
            this.structurePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.structurePanel.Controls.Add(this.gridData, 0, 0);
            this.structurePanel.Controls.Add(this.btnPanel, 0, 1);
            this.structurePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.structurePanel.Location = new System.Drawing.Point(0, 0);
            this.structurePanel.Name = "structurePanel";
            this.structurePanel.RowCount = 2;
            this.structurePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.structurePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.structurePanel.Size = new System.Drawing.Size(794, 450);
            this.structurePanel.TabIndex = 1;
            // 
            // gridData
            // 
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.Location = new System.Drawing.Point(3, 3);
            this.gridData.Name = "gridData";
            this.gridData.Size = new System.Drawing.Size(788, 399);
            this.gridData.TabIndex = 1;
            this.gridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.alterarDadosGrid);
            // 
            // btnPanel
            // 
            this.btnPanel.ColumnCount = 3;
            this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.61889F));
            this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.14984F));
            this.btnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.23127F));
            this.btnPanel.Controls.Add(this.button2, 0, 0);
            this.btnPanel.Controls.Add(this.lblFiltrar, 1, 0);
            this.btnPanel.Controls.Add(this.cbFiltrar, 2, 0);
            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel.Location = new System.Drawing.Point(3, 408);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.RowCount = 1;
            this.btnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.btnPanel.Size = new System.Drawing.Size(788, 39);
            this.btnPanel.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Adicionar Novo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiltrar.Location = new System.Drawing.Point(244, 0);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(168, 39);
            this.lblFiltrar.TabIndex = 2;
            this.lblFiltrar.Text = "Filtrar por:";
            this.lblFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbFiltrar
            // 
            this.cbFiltrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFiltrar.FormattingEnabled = true;
            this.cbFiltrar.Location = new System.Drawing.Point(418, 3);
            this.cbFiltrar.Name = "cbFiltrar";
            this.cbFiltrar.Size = new System.Drawing.Size(367, 21);
            this.cbFiltrar.TabIndex = 3;
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.structurePanel);
            this.Name = "Agenda";
            this.Text = "Agenda de Contatos";
            this.structurePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.btnPanel.ResumeLayout(false);
            this.btnPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel structurePanel;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.TableLayoutPanel btnPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.ComboBox cbFiltrar;
    }
}

