namespace Game
{
    partial class Checkers
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checkers));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameWithAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameWithHumanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumLevelAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardLevelAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameWithAIToolStripMenuItem,
            this.newGameWithHumanToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameWithAIToolStripMenuItem
            // 
            this.newGameWithAIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowLevelToolStripMenuItem,
            this.mediumLevelAIToolStripMenuItem,
            this.hardLevelAIToolStripMenuItem});
            this.newGameWithAIToolStripMenuItem.Name = "newGameWithAIToolStripMenuItem";
            this.newGameWithAIToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.newGameWithAIToolStripMenuItem.Text = "New game with AI";
            this.newGameWithAIToolStripMenuItem.Click += new System.EventHandler(this.newGameWithAIToolStripMenuItem_Click);
            // 
            // newGameWithHumanToolStripMenuItem
            // 
            this.newGameWithHumanToolStripMenuItem.Name = "newGameWithHumanToolStripMenuItem";
            this.newGameWithHumanToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.newGameWithHumanToolStripMenuItem.Text = "New game with human";
            this.newGameWithHumanToolStripMenuItem.Click += new System.EventHandler(this.newGameWithHumanToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lowLevelToolStripMenuItem
            // 
            this.lowLevelToolStripMenuItem.Name = "lowLevelToolStripMenuItem";
            this.lowLevelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.lowLevelToolStripMenuItem.Text = "Low level AI";
            this.lowLevelToolStripMenuItem.Click += new System.EventHandler(this.lowLevelToolStripMenuItem_Click);
            // 
            // mediumLevelAIToolStripMenuItem
            // 
            this.mediumLevelAIToolStripMenuItem.Name = "mediumLevelAIToolStripMenuItem";
            this.mediumLevelAIToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.mediumLevelAIToolStripMenuItem.Text = "Medium level AI";
            this.mediumLevelAIToolStripMenuItem.Click += new System.EventHandler(this.mediumLevelAIToolStripMenuItem_Click);
            // 
            // hardLevelAIToolStripMenuItem
            // 
            this.hardLevelAIToolStripMenuItem.Name = "hardLevelAIToolStripMenuItem";
            this.hardLevelAIToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hardLevelAIToolStripMenuItem.Text = "Hard level AI";
            this.hardLevelAIToolStripMenuItem.Click += new System.EventHandler(this.hardLevelAIToolStripMenuItem_Click);
            // 
            // Checkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 397);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Checkers";
            this.Text = "Checkers game";
            this.Load += new System.EventHandler(this.Checkers_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameWithAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameWithHumanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumLevelAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardLevelAIToolStripMenuItem;
    }
}

