namespace SPPO_Analysis
{
    partial class Form1
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
            this.RB_Example = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.анализироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LB_Ident = new System.Windows.Forms.ListBox();
            this.LB_Const = new System.Windows.Forms.ListBox();
            this.LB_Key = new System.Windows.Forms.ListBox();
            this.LB_Lim = new System.Windows.Forms.ListBox();
            this.LB_Conv = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RB_Example
            // 
            this.RB_Example.Location = new System.Drawing.Point(12, 31);
            this.RB_Example.Name = "RB_Example";
            this.RB_Example.Size = new System.Drawing.Size(294, 407);
            this.RB_Example.TabIndex = 0;
            this.RB_Example.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.анализироватьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // анализироватьToolStripMenuItem
            // 
            this.анализироватьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.анализироватьToolStripMenuItem.Name = "анализироватьToolStripMenuItem";
            this.анализироватьToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.анализироватьToolStripMenuItem.Text = "Анализировать";
            this.анализироватьToolStripMenuItem.Click += new System.EventHandler(this.анализироватьToolStripMenuItem_Click);
            // 
            // LB_Ident
            // 
            this.LB_Ident.FormattingEnabled = true;
            this.LB_Ident.Location = new System.Drawing.Point(327, 31);
            this.LB_Ident.Name = "LB_Ident";
            this.LB_Ident.Size = new System.Drawing.Size(224, 121);
            this.LB_Ident.TabIndex = 2;
            // 
            // LB_Const
            // 
            this.LB_Const.FormattingEnabled = true;
            this.LB_Const.Location = new System.Drawing.Point(564, 31);
            this.LB_Const.Name = "LB_Const";
            this.LB_Const.Size = new System.Drawing.Size(224, 121);
            this.LB_Const.TabIndex = 3;
            // 
            // LB_Key
            // 
            this.LB_Key.FormattingEnabled = true;
            this.LB_Key.Location = new System.Drawing.Point(327, 167);
            this.LB_Key.Name = "LB_Key";
            this.LB_Key.Size = new System.Drawing.Size(224, 121);
            this.LB_Key.TabIndex = 4;
            // 
            // LB_Lim
            // 
            this.LB_Lim.FormattingEnabled = true;
            this.LB_Lim.Location = new System.Drawing.Point(564, 167);
            this.LB_Lim.Name = "LB_Lim";
            this.LB_Lim.Size = new System.Drawing.Size(224, 121);
            this.LB_Lim.TabIndex = 5;
            // 
            // LB_Conv
            // 
            this.LB_Conv.FormattingEnabled = true;
            this.LB_Conv.Location = new System.Drawing.Point(449, 308);
            this.LB_Conv.Name = "LB_Conv";
            this.LB_Conv.Size = new System.Drawing.Size(224, 121);
            this.LB_Conv.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LB_Conv);
            this.Controls.Add(this.LB_Lim);
            this.Controls.Add(this.LB_Key);
            this.Controls.Add(this.LB_Const);
            this.Controls.Add(this.LB_Ident);
            this.Controls.Add(this.RB_Example);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Лексический Анализатор";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RB_Example;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem анализироватьToolStripMenuItem;
        private System.Windows.Forms.ListBox LB_Ident;
        private System.Windows.Forms.ListBox LB_Const;
        private System.Windows.Forms.ListBox LB_Key;
        private System.Windows.Forms.ListBox LB_Lim;
        private System.Windows.Forms.ListBox LB_Conv;
    }
}

