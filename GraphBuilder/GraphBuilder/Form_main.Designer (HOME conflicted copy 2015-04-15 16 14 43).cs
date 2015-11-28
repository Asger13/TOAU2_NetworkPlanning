namespace GraphBuilder
{
    partial class Form_main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_node = new System.Windows.Forms.PictureBox();
            this.pictureBox_link = new System.Windows.Forms.PictureBox();
            this.pictureBox_smegnost = new System.Windows.Forms.PictureBox();
            this.pictureBox_incendentnoct = new System.Windows.Forms.PictureBox();
            this.pictureBox_about = new System.Windows.Forms.PictureBox();
            this.pictureBox_elemCepi = new System.Windows.Forms.PictureBox();
            this.label_stepen = new System.Windows.Forms.Label();
            this.pictureBox_hierarchy = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.поискКратчайшегоПутиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зЛПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.транспортнаяЗадачаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмФлойдаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделениеПодсистемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_node)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_link)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_smegnost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_incendentnoct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_about)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_elemCepi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hierarchy)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 156);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1019, 514);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox_node
            // 
            this.pictureBox_node.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_node.Image")));
            this.pictureBox_node.Location = new System.Drawing.Point(12, 27);
            this.pictureBox_node.Name = "pictureBox_node";
            this.pictureBox_node.Size = new System.Drawing.Size(123, 123);
            this.pictureBox_node.TabIndex = 1;
            this.pictureBox_node.TabStop = false;
            this.pictureBox_node.Click += new System.EventHandler(this.pictureBox_node_Click);
            // 
            // pictureBox_link
            // 
            this.pictureBox_link.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_link.Image")));
            this.pictureBox_link.Location = new System.Drawing.Point(141, 27);
            this.pictureBox_link.Name = "pictureBox_link";
            this.pictureBox_link.Size = new System.Drawing.Size(123, 123);
            this.pictureBox_link.TabIndex = 2;
            this.pictureBox_link.TabStop = false;
            this.pictureBox_link.Click += new System.EventHandler(this.pictureBox_link_Click);
            // 
            // pictureBox_smegnost
            // 
            this.pictureBox_smegnost.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_smegnost.Image")));
            this.pictureBox_smegnost.Location = new System.Drawing.Point(270, 27);
            this.pictureBox_smegnost.Name = "pictureBox_smegnost";
            this.pictureBox_smegnost.Size = new System.Drawing.Size(123, 123);
            this.pictureBox_smegnost.TabIndex = 3;
            this.pictureBox_smegnost.TabStop = false;
            this.pictureBox_smegnost.Click += new System.EventHandler(this.pictureBox_smegnost_Click);
            // 
            // pictureBox_incendentnoct
            // 
            this.pictureBox_incendentnoct.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_incendentnoct.Image")));
            this.pictureBox_incendentnoct.Location = new System.Drawing.Point(399, 27);
            this.pictureBox_incendentnoct.Name = "pictureBox_incendentnoct";
            this.pictureBox_incendentnoct.Size = new System.Drawing.Size(123, 123);
            this.pictureBox_incendentnoct.TabIndex = 4;
            this.pictureBox_incendentnoct.TabStop = false;
            this.pictureBox_incendentnoct.Click += new System.EventHandler(this.pictureBox_incendentnoct_Click);
            // 
            // pictureBox_about
            // 
            this.pictureBox_about.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_about.Image")));
            this.pictureBox_about.Location = new System.Drawing.Point(907, 27);
            this.pictureBox_about.Name = "pictureBox_about";
            this.pictureBox_about.Size = new System.Drawing.Size(123, 123);
            this.pictureBox_about.TabIndex = 6;
            this.pictureBox_about.TabStop = false;
            this.pictureBox_about.Click += new System.EventHandler(this.pictureBox_about_Click);
            // 
            // pictureBox_elemCepi
            // 
            this.pictureBox_elemCepi.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_elemCepi.Image")));
            this.pictureBox_elemCepi.Location = new System.Drawing.Point(649, 27);
            this.pictureBox_elemCepi.Name = "pictureBox_elemCepi";
            this.pictureBox_elemCepi.Size = new System.Drawing.Size(123, 123);
            this.pictureBox_elemCepi.TabIndex = 7;
            this.pictureBox_elemCepi.TabStop = false;
            this.pictureBox_elemCepi.Click += new System.EventHandler(this.pictureBox_elemCepi_Click);
            // 
            // label_stepen
            // 
            this.label_stepen.AutoSize = true;
            this.label_stepen.Font = new System.Drawing.Font("Microsoft Sans Serif", 83.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_stepen.Location = new System.Drawing.Point(528, 24);
            this.label_stepen.Name = "label_stepen";
            this.label_stepen.Size = new System.Drawing.Size(0, 126);
            this.label_stepen.TabIndex = 9;
            // 
            // pictureBox_hierarchy
            // 
            this.pictureBox_hierarchy.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_hierarchy.Image")));
            this.pictureBox_hierarchy.Location = new System.Drawing.Point(778, 27);
            this.pictureBox_hierarchy.Name = "pictureBox_hierarchy";
            this.pictureBox_hierarchy.Size = new System.Drawing.Size(123, 123);
            this.pictureBox_hierarchy.TabIndex = 10;
            this.pictureBox_hierarchy.TabStop = false;
            this.pictureBox_hierarchy.Click += new System.EventHandler(this.pictureBox_hierarchy_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискКратчайшегоПутиToolStripMenuItem,
            this.выделениеПодсистемToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1043, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // поискКратчайшегоПутиToolStripMenuItem
            // 
            this.поискКратчайшегоПутиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зЛПToolStripMenuItem,
            this.транспортнаяЗадачаToolStripMenuItem,
            this.fkToolStripMenuItem,
            this.алгоритмФлойдаToolStripMenuItem});
            this.поискКратчайшегоПутиToolStripMenuItem.Name = "поискКратчайшегоПутиToolStripMenuItem";
            this.поискКратчайшегоПутиToolStripMenuItem.Size = new System.Drawing.Size(158, 20);
            this.поискКратчайшегоПутиToolStripMenuItem.Text = "Поиск кратчайшего пути";
            // 
            // зЛПToolStripMenuItem
            // 
            this.зЛПToolStripMenuItem.Name = "зЛПToolStripMenuItem";
            this.зЛПToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.зЛПToolStripMenuItem.Text = "ЗЛП";
            this.зЛПToolStripMenuItem.Click += new System.EventHandler(this.зЛПToolStripMenuItem_Click);
            // 
            // транспортнаяЗадачаToolStripMenuItem
            // 
            this.транспортнаяЗадачаToolStripMenuItem.Name = "транспортнаяЗадачаToolStripMenuItem";
            this.транспортнаяЗадачаToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.транспортнаяЗадачаToolStripMenuItem.Text = "Транспортная задача";
            // 
            // fkToolStripMenuItem
            // 
            this.fkToolStripMenuItem.Name = "fkToolStripMenuItem";
            this.fkToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.fkToolStripMenuItem.Text = "Алгоритм Дейкстры";
            this.fkToolStripMenuItem.Click += new System.EventHandler(this.fkToolStripMenuItem_Click);
            // 
            // алгоритмФлойдаToolStripMenuItem
            // 
            this.алгоритмФлойдаToolStripMenuItem.Name = "алгоритмФлойдаToolStripMenuItem";
            this.алгоритмФлойдаToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.алгоритмФлойдаToolStripMenuItem.Text = "Алгоритм Флойда";
            this.алгоритмФлойдаToolStripMenuItem.Click += new System.EventHandler(this.алгоритмФлойдаToolStripMenuItem_Click);
            // 
            // выделениеПодсистемToolStripMenuItem
            // 
            this.выделениеПодсистемToolStripMenuItem.Name = "выделениеПодсистемToolStripMenuItem";
            this.выделениеПодсистемToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.выделениеПодсистемToolStripMenuItem.Text = "Выделение подсистем";
            this.выделениеПодсистемToolStripMenuItem.Click += new System.EventHandler(this.выделениеПодсистемToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 83.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Magenta;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 126);
            this.label1.TabIndex = 12;
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 682);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_hierarchy);
            this.Controls.Add(this.label_stepen);
            this.Controls.Add(this.pictureBox_elemCepi);
            this.Controls.Add(this.pictureBox_about);
            this.Controls.Add(this.pictureBox_incendentnoct);
            this.Controls.Add(this.pictureBox_smegnost);
            this.Controls.Add(this.pictureBox_link);
            this.Controls.Add(this.pictureBox_node);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphBuilder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_node)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_link)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_smegnost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_incendentnoct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_about)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_elemCepi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hierarchy)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_node;
        private System.Windows.Forms.PictureBox pictureBox_link;
        private System.Windows.Forms.PictureBox pictureBox_smegnost;
        private System.Windows.Forms.PictureBox pictureBox_incendentnoct;
        private System.Windows.Forms.PictureBox pictureBox_about;
        private System.Windows.Forms.PictureBox pictureBox_elemCepi;
        private System.Windows.Forms.Label label_stepen;
        private System.Windows.Forms.PictureBox pictureBox_hierarchy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem поискКратчайшегоПутиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зЛПToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem транспортнаяЗадачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмФлойдаToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem выделениеПодсистемToolStripMenuItem;
    }
}

