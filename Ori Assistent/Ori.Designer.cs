namespace Ori_Assistent
{
    partial class OriAssistentStartForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OriAssistentStartForm));
            this.LeftSideBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.IconImageBox = new System.Windows.Forms.PictureBox();
            this.GreetingsLabel = new System.Windows.Forms.Label();
            this.SystemMessageListBox = new System.Windows.Forms.ListBox();
            this.Settings = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TimerForShotDown = new System.Windows.Forms.TextBox();
            this.isAutoRunCheckBox = new System.Windows.Forms.CheckBox();
            this.CommandsList = new System.Windows.Forms.ListBox();
            this.TimerSpeaking = new System.Windows.Forms.Timer(this.components);
            this.MessageErrorLabel = new System.Windows.Forms.Label();
            this.CurrentDateTime = new System.Windows.Forms.Label();
            this.CurrentDate = new System.Windows.Forms.Timer(this.components);
            this.LeftSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconImageBox)).BeginInit();
            this.Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftSideBar
            // 
            this.LeftSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.LeftSideBar.Controls.Add(this.label1);
            this.LeftSideBar.Controls.Add(this.IconImageBox);
            this.LeftSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSideBar.Location = new System.Drawing.Point(0, 0);
            this.LeftSideBar.Name = "LeftSideBar";
            this.LeftSideBar.Size = new System.Drawing.Size(200, 450);
            this.LeftSideBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // IconImageBox
            // 
            this.IconImageBox.Image = ((System.Drawing.Image)(resources.GetObject("IconImageBox.Image")));
            this.IconImageBox.Location = new System.Drawing.Point(23, 12);
            this.IconImageBox.Name = "IconImageBox";
            this.IconImageBox.Size = new System.Drawing.Size(151, 85);
            this.IconImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconImageBox.TabIndex = 0;
            this.IconImageBox.TabStop = false;
            // 
            // GreetingsLabel
            // 
            this.GreetingsLabel.AutoSize = true;
            this.GreetingsLabel.BackColor = System.Drawing.Color.Transparent;
            this.GreetingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GreetingsLabel.Location = new System.Drawing.Point(206, 9);
            this.GreetingsLabel.Name = "GreetingsLabel";
            this.GreetingsLabel.Size = new System.Drawing.Size(278, 42);
            this.GreetingsLabel.TabIndex = 1;
            this.GreetingsLabel.Text = "Good afternoon";
            this.GreetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SystemMessageListBox
            // 
            this.SystemMessageListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(0)))), ((int)(((byte)(119)))));
            this.SystemMessageListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SystemMessageListBox.ColumnWidth = 1;
            this.SystemMessageListBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.SystemMessageListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SystemMessageListBox.ForeColor = System.Drawing.Color.White;
            this.SystemMessageListBox.FormattingEnabled = true;
            this.SystemMessageListBox.ItemHeight = 15;
            this.SystemMessageListBox.Location = new System.Drawing.Point(632, 0);
            this.SystemMessageListBox.MultiColumn = true;
            this.SystemMessageListBox.Name = "SystemMessageListBox";
            this.SystemMessageListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.SystemMessageListBox.Size = new System.Drawing.Size(168, 450);
            this.SystemMessageListBox.TabIndex = 2;
            // 
            // Settings
            // 
            this.Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Settings.Controls.Add(this.label2);
            this.Settings.Controls.Add(this.TimerForShotDown);
            this.Settings.Controls.Add(this.isAutoRunCheckBox);
            this.Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Settings.Location = new System.Drawing.Point(308, 168);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(219, 145);
            this.Settings.TabIndex = 7;
            this.Settings.TabStop = false;
            this.Settings.Text = "Settings";
            this.Settings.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(44, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Shot down timer";
            // 
            // TimerForShotDown
            // 
            this.TimerForShotDown.Location = new System.Drawing.Point(12, 66);
            this.TimerForShotDown.Name = "TimerForShotDown";
            this.TimerForShotDown.Size = new System.Drawing.Size(26, 26);
            this.TimerForShotDown.TabIndex = 3;
            this.TimerForShotDown.Text = "5";
            this.TimerForShotDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TimerForShotDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimerForShotDown_KeyPress);
            // 
            // isAutoRunCheckBox
            // 
            this.isAutoRunCheckBox.AutoSize = true;
            this.isAutoRunCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.isAutoRunCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isAutoRunCheckBox.Location = new System.Drawing.Point(21, 38);
            this.isAutoRunCheckBox.Name = "isAutoRunCheckBox";
            this.isAutoRunCheckBox.Size = new System.Drawing.Size(132, 20);
            this.isAutoRunCheckBox.TabIndex = 2;
            this.isAutoRunCheckBox.Text = "Start with windows";
            this.isAutoRunCheckBox.UseVisualStyleBackColor = true;
            this.isAutoRunCheckBox.CheckedChanged += new System.EventHandler(this.IsAutoRunCheckBox_CheckedChanged);
            // 
            // CommandsList
            // 
            this.CommandsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(57)))), ((int)(((byte)(211)))));
            this.CommandsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CommandsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CommandsList.ForeColor = System.Drawing.Color.White;
            this.CommandsList.FormattingEnabled = true;
            this.CommandsList.ItemHeight = 20;
            this.CommandsList.Location = new System.Drawing.Point(236, 132);
            this.CommandsList.Name = "CommandsList";
            this.CommandsList.Size = new System.Drawing.Size(366, 220);
            this.CommandsList.TabIndex = 6;
            this.CommandsList.Visible = false;
            // 
            // TimerSpeaking
            // 
            this.TimerSpeaking.Enabled = true;
            this.TimerSpeaking.Interval = 1000;
            this.TimerSpeaking.Tick += new System.EventHandler(this.TimerSpeaking_Tick);
            // 
            // MessageErrorLabel
            // 
            this.MessageErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.MessageErrorLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MessageErrorLabel.Location = new System.Drawing.Point(206, 414);
            this.MessageErrorLabel.Name = "MessageErrorLabel";
            this.MessageErrorLabel.Size = new System.Drawing.Size(420, 27);
            this.MessageErrorLabel.TabIndex = 8;
            this.MessageErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentDateTime
            // 
            this.CurrentDateTime.AutoSize = true;
            this.CurrentDateTime.BackColor = System.Drawing.Color.Transparent;
            this.CurrentDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.CurrentDateTime.Location = new System.Drawing.Point(210, 51);
            this.CurrentDateTime.Name = "CurrentDateTime";
            this.CurrentDateTime.Size = new System.Drawing.Size(67, 16);
            this.CurrentDateTime.TabIndex = 9;
            this.CurrentDateTime.Text = "DateTime";
            // 
            // CurrentDate
            // 
            this.CurrentDate.Enabled = true;
            this.CurrentDate.Interval = 1000;
            this.CurrentDate.Tick += new System.EventHandler(this.CurrentDate_Tick);
            // 
            // OriAssistentStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CurrentDateTime);
            this.Controls.Add(this.MessageErrorLabel);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.CommandsList);
            this.Controls.Add(this.SystemMessageListBox);
            this.Controls.Add(this.GreetingsLabel);
            this.Controls.Add(this.LeftSideBar);
            this.Name = "OriAssistentStartForm";
            this.Text = "Ori assistent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OriAssistentStartForm_FormClosing);
            this.Load += new System.EventHandler(this.OriAssistentStartForm_Load);
            this.Click += new System.EventHandler(this.OriAssistentStartForm_Click);
            this.LeftSideBar.ResumeLayout(false);
            this.LeftSideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconImageBox)).EndInit();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LeftSideBar;
        private System.Windows.Forms.PictureBox IconImageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox SystemMessageListBox;
        private System.Windows.Forms.GroupBox Settings;
        private System.Windows.Forms.CheckBox isAutoRunCheckBox;
        public System.Windows.Forms.ListBox CommandsList;
        private System.Windows.Forms.Timer TimerSpeaking;
        private System.Windows.Forms.TextBox TimerForShotDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MessageErrorLabel;
        public System.Windows.Forms.Label GreetingsLabel;
        private System.Windows.Forms.Label CurrentDateTime;
        private System.Windows.Forms.Timer CurrentDate;
    }
}

