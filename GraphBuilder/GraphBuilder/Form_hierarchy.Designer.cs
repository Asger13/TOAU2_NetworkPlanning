namespace GraphBuilder
{
    partial class Form_hierarchy
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
            this.pictureBox_hierarchy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hierarchy)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_hierarchy
            // 
            this.pictureBox_hierarchy.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_hierarchy.Name = "pictureBox_hierarchy";
            this.pictureBox_hierarchy.Size = new System.Drawing.Size(1019, 658);
            this.pictureBox_hierarchy.TabIndex = 0;
            this.pictureBox_hierarchy.TabStop = false;
            this.pictureBox_hierarchy.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_hierarchy_Paint);
            // 
            // Form_hierarchy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 682);
            this.Controls.Add(this.pictureBox_hierarchy);
            this.Name = "Form_hierarchy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Иерархия";
            this.Load += new System.EventHandler(this.Form_hierarchy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hierarchy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_hierarchy;
    }
}