namespace OnlineShop
{
    partial class frmShowListProducts
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
            this.ctrlProducts1 = new OnlineShop.ctrlProducts();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlProducts1
            // 
            this.ctrlProducts1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ctrlProducts1.CategoryID = 0;
            this.ctrlProducts1.Location = new System.Drawing.Point(0, 0);
            this.ctrlProducts1.Name = "ctrlProducts1";
            this.ctrlProducts1.Size = new System.Drawing.Size(1356, 982);
            this.ctrlProducts1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1083, 879);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 59);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowListProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1358, 985);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlProducts1);
            this.Name = "frmShowListProducts";
            this.Text = "frmCookware";
            this.Load += new System.EventHandler(this.frmCookware_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlProducts ctrlProducts1;
        private System.Windows.Forms.Button btnClose;
    }
}