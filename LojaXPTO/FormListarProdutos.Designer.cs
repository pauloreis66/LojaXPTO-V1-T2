namespace LojaXPTO
{
    partial class FormListarProdutos
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
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.grelha = new System.Windows.Forms.DataGridView();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.status.SuspendLayout();
            this.tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grelha)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMsg});
            this.status.Location = new System.Drawing.Point(0, 388);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(767, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // statusMsg
            // 
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.Size = new System.Drawing.Size(66, 17);
            this.statusMsg.Text = "mensagem";
            // 
            // tools
            // 
            this.tools.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSair});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(767, 39);
            this.tools.TabIndex = 1;
            this.tools.Text = "toolStrip1";
            // 
            // grelha
            // 
            this.grelha.AllowUserToAddRows = false;
            this.grelha.AllowUserToDeleteRows = false;
            this.grelha.AllowUserToResizeRows = false;
            this.grelha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grelha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grelha.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grelha.Location = new System.Drawing.Point(0, 39);
            this.grelha.Name = "grelha";
            this.grelha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grelha.Size = new System.Drawing.Size(767, 349);
            this.grelha.TabIndex = 2;
            // 
            // btnSair
            // 
            this.btnSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSair.Image = global::LojaXPTO.Properties.Resources.Windows_Close_Program_icon;
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(36, 36);
            this.btnSair.Text = "Fechar";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FormListarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 410);
            this.ControlBox = false;
            this.Controls.Add(this.grelha);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.status);
            this.Name = "FormListarProdutos";
            this.Load += new System.EventHandler(this.FormListarProdutos_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grelha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusMsg;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.DataGridView grelha;
    }
}