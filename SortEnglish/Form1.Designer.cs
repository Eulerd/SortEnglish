namespace SortEnglish
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuestionListBox = new System.Windows.Forms.ListBox();
            this.Questlabel = new System.Windows.Forms.Label();
            this.Anserlabel = new System.Windows.Forms.Label();
            this.AnserListBox = new System.Windows.Forms.ListBox();
            this.Japlabel = new System.Windows.Forms.Label();
            this.JapListBox = new System.Windows.Forms.ListBox();
            this.NumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.全削除ToolStripMenuItem,
            this.終了ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EngToolStripMenuItem,
            this.JapToolStripMenuItem,
            this.NumbersToolStripMenuItem});
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.OpenToolStripMenuItem.Text = "開く";
            // 
            // EngToolStripMenuItem
            // 
            this.EngToolStripMenuItem.Name = "EngToolStripMenuItem";
            this.EngToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.EngToolStripMenuItem.Text = "英文";
            this.EngToolStripMenuItem.Click += new System.EventHandler(this.EngToolStripMenuItem_Click);
            // 
            // JapToolStripMenuItem
            // 
            this.JapToolStripMenuItem.Name = "JapToolStripMenuItem";
            this.JapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.JapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.JapToolStripMenuItem.Text = "和訳";
            this.JapToolStripMenuItem.Click += new System.EventHandler(this.JapToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.SaveToolStripMenuItem.Text = "保存";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // 全削除ToolStripMenuItem
            // 
            this.全削除ToolStripMenuItem.Name = "全削除ToolStripMenuItem";
            this.全削除ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.全削除ToolStripMenuItem.Text = "全削除";
            this.全削除ToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.EndToolStripMenuItem_Click);
            // 
            // QuestionListBox
            // 
            this.QuestionListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionListBox.FormattingEnabled = true;
            this.QuestionListBox.ItemHeight = 12;
            this.QuestionListBox.Location = new System.Drawing.Point(12, 39);
            this.QuestionListBox.Name = "QuestionListBox";
            this.QuestionListBox.Size = new System.Drawing.Size(610, 148);
            this.QuestionListBox.TabIndex = 1;
            this.QuestionListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // Questlabel
            // 
            this.Questlabel.AutoSize = true;
            this.Questlabel.Location = new System.Drawing.Point(12, 24);
            this.Questlabel.Name = "Questlabel";
            this.Questlabel.Size = new System.Drawing.Size(41, 12);
            this.Questlabel.TabIndex = 2;
            this.Questlabel.Text = "問題文";
            // 
            // Anserlabel
            // 
            this.Anserlabel.AutoSize = true;
            this.Anserlabel.Location = new System.Drawing.Point(12, 190);
            this.Anserlabel.Name = "Anserlabel";
            this.Anserlabel.Size = new System.Drawing.Size(41, 12);
            this.Anserlabel.TabIndex = 4;
            this.Anserlabel.Text = "解答文";
            // 
            // AnserListBox
            // 
            this.AnserListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnserListBox.FormattingEnabled = true;
            this.AnserListBox.ItemHeight = 12;
            this.AnserListBox.Location = new System.Drawing.Point(12, 205);
            this.AnserListBox.Name = "AnserListBox";
            this.AnserListBox.Size = new System.Drawing.Size(610, 148);
            this.AnserListBox.TabIndex = 3;
            // 
            // Japlabel
            // 
            this.Japlabel.AutoSize = true;
            this.Japlabel.Location = new System.Drawing.Point(12, 356);
            this.Japlabel.Name = "Japlabel";
            this.Japlabel.Size = new System.Drawing.Size(29, 12);
            this.Japlabel.TabIndex = 6;
            this.Japlabel.Text = "和訳";
            // 
            // JapListBox
            // 
            this.JapListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JapListBox.FormattingEnabled = true;
            this.JapListBox.ItemHeight = 12;
            this.JapListBox.Location = new System.Drawing.Point(12, 371);
            this.JapListBox.Name = "JapListBox";
            this.JapListBox.Size = new System.Drawing.Size(610, 148);
            this.JapListBox.TabIndex = 5;
            // 
            // NumbersToolStripMenuItem
            // 
            this.NumbersToolStripMenuItem.Name = "NumbersToolStripMenuItem";
            this.NumbersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NumbersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NumbersToolStripMenuItem.Text = "番号";
            this.NumbersToolStripMenuItem.Click += new System.EventHandler(this.NumbersToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 528);
            this.Controls.Add(this.Japlabel);
            this.Controls.Add(this.JapListBox);
            this.Controls.Add(this.Anserlabel);
            this.Controls.Add(this.AnserListBox);
            this.Controls.Add(this.Questlabel);
            this.Controls.Add(this.QuestionListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SortEnglish";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ListBox QuestionListBox;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.Label Questlabel;
        private System.Windows.Forms.Label Anserlabel;
        private System.Windows.Forms.ListBox AnserListBox;
        private System.Windows.Forms.Label Japlabel;
        private System.Windows.Forms.ListBox JapListBox;
        private System.Windows.Forms.ToolStripMenuItem EngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NumbersToolStripMenuItem;
    }
}

