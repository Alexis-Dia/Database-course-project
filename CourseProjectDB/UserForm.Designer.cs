namespace CourseProjectDB
{
    partial class UserForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мояИнформацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.задачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свободныеЗадачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текущаяЗадачаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеОтчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиToolStripMenuItem,
            this.мояИнформацияToolStripMenuItem,
            this.задачиToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // мояИнформацияToolStripMenuItem
            // 
            this.мояИнформацияToolStripMenuItem.Name = "мояИнформацияToolStripMenuItem";
            this.мояИнформацияToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.мояИнформацияToolStripMenuItem.Text = "Моя информация";
            this.мояИнформацияToolStripMenuItem.Click += new System.EventHandler(this.мояИнформацияToolStripMenuItem_Click);
            // 
            // задачиToolStripMenuItem
            // 
            this.задачиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.свободныеЗадачиToolStripMenuItem,
            this.текущаяЗадачаToolStripMenuItem});
            this.задачиToolStripMenuItem.Name = "задачиToolStripMenuItem";
            this.задачиToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.задачиToolStripMenuItem.Text = "Задачи";
            // 
            // свободныеЗадачиToolStripMenuItem
            // 
            this.свободныеЗадачиToolStripMenuItem.Name = "свободныеЗадачиToolStripMenuItem";
            this.свободныеЗадачиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.свободныеЗадачиToolStripMenuItem.Text = "Мои задачи";
            this.свободныеЗадачиToolStripMenuItem.Click += new System.EventHandler(this.свободныеЗадачиToolStripMenuItem_Click);
            // 
            // текущаяЗадачаToolStripMenuItem
            // 
            this.текущаяЗадачаToolStripMenuItem.Name = "текущаяЗадачаToolStripMenuItem";
            this.текущаяЗадачаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.текущаяЗадачаToolStripMenuItem.Text = "Текущая задача";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всеОтчетыToolStripMenuItem,
            this.добавитьОтчетToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // всеОтчетыToolStripMenuItem
            // 
            this.всеОтчетыToolStripMenuItem.Name = "всеОтчетыToolStripMenuItem";
            this.всеОтчетыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.всеОтчетыToolStripMenuItem.Text = "Все отчеты";
            // 
            // добавитьОтчетToolStripMenuItem
            // 
            this.добавитьОтчетToolStripMenuItem.Name = "добавитьОтчетToolStripMenuItem";
            this.добавитьОтчетToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавитьОтчетToolStripMenuItem.Text = "Добавить отчет";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(581, 398);
            this.dataGridView1.TabIndex = 1;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserForm";
            this.Text = "Окно пользователя";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мояИнформацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem задачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свободныеЗадачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текущаяЗадачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеОтчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьОтчетToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}