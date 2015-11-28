namespace GraphBuilder
{
    partial class Form_smegnost
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
            this.label_smegnost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_smegnost
            // 
            this.label_smegnost.AutoSize = true;
            this.label_smegnost.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_smegnost.Location = new System.Drawing.Point(12, 9);
            this.label_smegnost.Name = "label_smegnost";
            this.label_smegnost.Size = new System.Drawing.Size(0, 24);
            this.label_smegnost.TabIndex = 0;
            // 
            // Form_smegnost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.label_smegnost);
            this.Name = "Form_smegnost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Матрица смежности";
            this.Load += new System.EventHandler(this.Form_smegnost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_smegnost;

    }
}