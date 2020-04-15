namespace CourseProjectDB
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.myInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myCurrentTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myInformationToolStripMenuItem,
            this.tasksToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // myInformationToolStripMenuItem
            // 
            this.myInformationToolStripMenuItem.Name = "myInformationToolStripMenuItem";
            this.myInformationToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.myInformationToolStripMenuItem.Text = "My information";
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freeTasksToolStripMenuItem,
            this.myTasksToolStripMenuItem,
            this.myCurrentTaskToolStripMenuItem});
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.tasksToolStripMenuItem.Text = "Tasks";
            // 
            // freeTasksToolStripMenuItem
            // 
            this.freeTasksToolStripMenuItem.Name = "freeTasksToolStripMenuItem";
            this.freeTasksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.freeTasksToolStripMenuItem.Text = "Free tasks";
            // 
            // myTasksToolStripMenuItem
            // 
            this.myTasksToolStripMenuItem.Name = "myTasksToolStripMenuItem";
            this.myTasksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.myTasksToolStripMenuItem.Text = "My tasks";
            // 
            // myCurrentTaskToolStripMenuItem
            // 
            this.myCurrentTaskToolStripMenuItem.Name = "myCurrentTaskToolStripMenuItem";
            this.myCurrentTaskToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.myCurrentTaskToolStripMenuItem.Text = "My current task";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addReportToolStripMenuItem,
            this.allReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // addReportToolStripMenuItem
            // 
            this.addReportToolStripMenuItem.Name = "addReportToolStripMenuItem";
            this.addReportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addReportToolStripMenuItem.Text = "Add report";
            // 
            // allReportsToolStripMenuItem
            // 
            this.allReportsToolStripMenuItem.Name = "allReportsToolStripMenuItem";
            this.allReportsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allReportsToolStripMenuItem.Text = "All reports";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem myInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myCurrentTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allReportsToolStripMenuItem;
    }
}

