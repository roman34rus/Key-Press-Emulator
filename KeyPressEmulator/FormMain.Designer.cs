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
            this.StatusCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.TextFreq = new System.Windows.Forms.TextBox();
            this.LabelFreq = new System.Windows.Forms.Label();
            this.TextKey = new System.Windows.Forms.TextBox();
            this.LabelKey = new System.Windows.Forms.Label();
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
            this.StatusCopyright});
            this.Status.Location = new System.Drawing.Point(0, 148);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(227, 22);
            this.Status.TabIndex = 9;
            this.Status.Text = "statusStrip1";
            // 
            // StatusCopyright
            // 
            this.StatusCopyright.Name = "StatusCopyright";
            this.StatusCopyright.Size = new System.Drawing.Size(114, 17);
            this.StatusCopyright.Text = "© Любимов Роман";
            // 
            // BtnStop
            // 
            this.BtnStop.Enabled = false;
            this.BtnStop.Location = new System.Drawing.Point(107, 112);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 4;
            this.BtnStop.Text = "Стоп";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(12, 112);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 3;
            this.BtnStart.Text = "Старт";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // TextFreq
            // 
            this.TextFreq.Location = new System.Drawing.Point(12, 76);
            this.TextFreq.Name = "TextFreq";
            this.TextFreq.Size = new System.Drawing.Size(111, 20);
            this.TextFreq.TabIndex = 2;
            this.TextFreq.Text = "200";
            // 
            // LabelFreq
            // 
            this.LabelFreq.AutoSize = true;
            this.LabelFreq.Location = new System.Drawing.Point(12, 60);
            this.LabelFreq.Name = "LabelFreq";
            this.LabelFreq.Size = new System.Drawing.Size(111, 13);
            this.LabelFreq.TabIndex = 13;
            this.LabelFreq.Text = "Частота повторения";
            // 
            // TextKey
            // 
            this.TextKey.AcceptsReturn = true;
            this.TextKey.AcceptsTab = true;
            this.TextKey.Location = new System.Drawing.Point(12, 28);
            this.TextKey.Multiline = true;
            this.TextKey.Name = "TextKey";
            this.TextKey.Size = new System.Drawing.Size(200, 20);
            this.TextKey.TabIndex = 1;
            this.TextKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKey_KeyDown);
            this.TextKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKey_KeyUp);
            // 
            // LabelKey
            // 
            this.LabelKey.AutoSize = true;
            this.LabelKey.Location = new System.Drawing.Point(12, 12);
            this.LabelKey.Name = "LabelKey";
            this.LabelKey.Size = new System.Drawing.Size(156, 13);
            this.LabelKey.TabIndex = 11;
            this.LabelKey.Text = "Клавиша / сочетание клавиш";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 170);
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
            this.Text = "Key Press Emulator";
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
    }
}

