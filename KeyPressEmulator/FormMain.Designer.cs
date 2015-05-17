namespace KeyPressEmulator
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StatusEmuState = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusPaused = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.TextFreq = new System.Windows.Forms.TextBox();
            this.LabelFreq = new System.Windows.Forms.Label();
            this.TextKey = new System.Windows.Forms.TextBox();
            this.LabelKey = new System.Windows.Forms.Label();
            this.LabelHotKey = new System.Windows.Forms.Label();
            this.ComboHotKey = new System.Windows.Forms.ComboBox();
            this.BtnMapHotKey = new System.Windows.Forms.Button();
            this.LabelHotKey2 = new System.Windows.Forms.Label();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Interval = 200;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusEmuState,
            this.StatusPaused,
            this.StatusCopyright});
            this.Status.Location = new System.Drawing.Point(0, 218);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(343, 22);
            this.Status.TabIndex = 9;
            this.Status.Text = "statusStrip1";
            // 
            // StatusEmuState
            // 
            this.StatusEmuState.Name = "StatusEmuState";
            this.StatusEmuState.Size = new System.Drawing.Size(135, 17);
            this.StatusEmuState.Text = "Эмуляция остановлена";
            // 
            // StatusPaused
            // 
            this.StatusPaused.Name = "StatusPaused";
            this.StatusPaused.Size = new System.Drawing.Size(39, 17);
            this.StatusPaused.Text = "Пауза";
            // 
            // StatusCopyright
            // 
            this.StatusCopyright.Name = "StatusCopyright";
            this.StatusCopyright.Size = new System.Drawing.Size(114, 17);
            this.StatusCopyright.Text = "© Любимов Роман";
            this.StatusCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnStop
            // 
            this.BtnStop.Enabled = false;
            this.BtnStop.Location = new System.Drawing.Point(106, 93);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 23;
            this.BtnStop.Text = "Стоп";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(11, 93);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 22;
            this.BtnStart.Text = "Старт";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // TextFreq
            // 
            this.TextFreq.Location = new System.Drawing.Point(12, 67);
            this.TextFreq.Name = "TextFreq";
            this.TextFreq.Size = new System.Drawing.Size(111, 20);
            this.TextFreq.TabIndex = 21;
            this.TextFreq.Text = "200";
            // 
            // LabelFreq
            // 
            this.LabelFreq.AutoSize = true;
            this.LabelFreq.Location = new System.Drawing.Point(12, 51);
            this.LabelFreq.Name = "LabelFreq";
            this.LabelFreq.Size = new System.Drawing.Size(111, 13);
            this.LabelFreq.TabIndex = 25;
            this.LabelFreq.Text = "Частота повторения";
            // 
            // TextKey
            // 
            this.TextKey.AcceptsReturn = true;
            this.TextKey.AcceptsTab = true;
            this.TextKey.Location = new System.Drawing.Point(12, 25);
            this.TextKey.Multiline = true;
            this.TextKey.Name = "TextKey";
            this.TextKey.Size = new System.Drawing.Size(200, 20);
            this.TextKey.TabIndex = 20;
            this.TextKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKey_KeyDown);
            this.TextKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKey_KeyUp);
            // 
            // LabelKey
            // 
            this.LabelKey.AutoSize = true;
            this.LabelKey.Location = new System.Drawing.Point(12, 9);
            this.LabelKey.Name = "LabelKey";
            this.LabelKey.Size = new System.Drawing.Size(156, 13);
            this.LabelKey.TabIndex = 24;
            this.LabelKey.Text = "Клавиша / сочетание клавиш";
            // 
            // LabelHotKey
            // 
            this.LabelHotKey.AutoSize = true;
            this.LabelHotKey.Location = new System.Drawing.Point(11, 161);
            this.LabelHotKey.Name = "LabelHotKey";
            this.LabelHotKey.Size = new System.Drawing.Size(129, 13);
            this.LabelHotKey.TabIndex = 26;
            this.LabelHotKey.Text = "Горячая клавиша паузы";
            // 
            // ComboHotKey
            // 
            this.ComboHotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboHotKey.FormattingEnabled = true;
            this.ComboHotKey.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.ComboHotKey.Location = new System.Drawing.Point(11, 177);
            this.ComboHotKey.MaxDropDownItems = 12;
            this.ComboHotKey.Name = "ComboHotKey";
            this.ComboHotKey.Size = new System.Drawing.Size(74, 21);
            this.ComboHotKey.TabIndex = 27;
            // 
            // BtnMapHotKey
            // 
            this.BtnMapHotKey.Location = new System.Drawing.Point(105, 177);
            this.BtnMapHotKey.Name = "BtnMapHotKey";
            this.BtnMapHotKey.Size = new System.Drawing.Size(75, 23);
            this.BtnMapHotKey.TabIndex = 28;
            this.BtnMapHotKey.Text = "Назначить";
            this.BtnMapHotKey.UseVisualStyleBackColor = true;
            this.BtnMapHotKey.Click += new System.EventHandler(this.BtnMapHotKey_Click);
            // 
            // LabelHotKey2
            // 
            this.LabelHotKey2.AutoSize = true;
            this.LabelHotKey2.Location = new System.Drawing.Point(137, 161);
            this.LabelHotKey2.Name = "LabelHotKey2";
            this.LabelHotKey2.Size = new System.Drawing.Size(75, 13);
            this.LabelHotKey2.TabIndex = 29;
            this.LabelHotKey2.Text = "(HotKeyValue)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 240);
            this.Controls.Add(this.LabelHotKey2);
            this.Controls.Add(this.BtnMapHotKey);
            this.Controls.Add(this.ComboHotKey);
            this.Controls.Add(this.LabelHotKey);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.TextFreq);
            this.Controls.Add(this.LabelFreq);
            this.Controls.Add(this.TextKey);
            this.Controls.Add(this.LabelKey);
            this.Controls.Add(this.Status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Press Emulator 2";
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StatusCopyright;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox TextFreq;
        private System.Windows.Forms.Label LabelFreq;
        private System.Windows.Forms.TextBox TextKey;
        private System.Windows.Forms.Label LabelKey;
        private System.Windows.Forms.Label LabelHotKey;
        private System.Windows.Forms.ComboBox ComboHotKey;
        private System.Windows.Forms.Button BtnMapHotKey;
        private System.Windows.Forms.ToolStripStatusLabel StatusEmuState;
        private System.Windows.Forms.ToolStripStatusLabel StatusPaused;
        private System.Windows.Forms.Label LabelHotKey2;
    }
}

