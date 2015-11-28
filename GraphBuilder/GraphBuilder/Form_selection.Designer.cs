namespace GraphBuilder
{
    partial class Form_selection
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
            this.button_orientir = new System.Windows.Forms.Button();
            this.button_notOrientir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_orientir
            // 
            this.button_orientir.Location = new System.Drawing.Point(12, 12);
            this.button_orientir.Name = "button_orientir";
            this.button_orientir.Size = new System.Drawing.Size(139, 52);
            this.button_orientir.TabIndex = 0;
            this.button_orientir.Text = "Ориентированный";
            this.button_orientir.UseVisualStyleBackColor = true;
            this.button_orientir.Click += new System.EventHandler(this.button_orientir_Click);
            // 
            // button_notOrientir
            // 
            this.button_notOrientir.Location = new System.Drawing.Point(157, 12);
            this.button_notOrientir.Name = "button_notOrientir";
            this.button_notOrientir.Size = new System.Drawing.Size(139, 52);
            this.button_notOrientir.TabIndex = 1;
            this.button_notOrientir.Text = "Неориентированный";
            this.button_notOrientir.UseVisualStyleBackColor = true;
            this.button_notOrientir.Click += new System.EventHandler(this.button_notOrientir_Click);
            // 
            // Form_selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 76);
            this.Controls.Add(this.button_notOrientir);
            this.Controls.Add(this.button_orientir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_selection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор графа";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_orientir;
        private System.Windows.Forms.Button button_notOrientir;
    }
}