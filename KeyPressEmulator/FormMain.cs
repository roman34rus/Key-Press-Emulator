using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KeyPressEmulator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // сюда запоминаем нажатую клавишу
        byte k;
        // сюда запоминаем состояние Alt, Ctrl, Shift
        bool k_alt, k_ctrl, k_shift;

        // импорт функции keybd_event для эмуляции нажатия клавиш
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        // срабатывание таймера
        private void Timer_Tick(object sender, EventArgs e)
        {
            // эмулируем нажатие Alt, Ctrl, Shift
            if (k_alt)
                keybd_event((byte)Keys.Menu, 0, 0, 0);
            if (k_ctrl)
                keybd_event((byte)Keys.ControlKey, 0, 0, 0);
            if (k_shift)
                keybd_event((byte)Keys.ShiftKey, 0, 0, 0);
            // эмулируем нажатие и отпускание клавиши
            keybd_event(k, 0, 0, 0);
            keybd_event(k, 0, 2, 0);
            // эмулируем отпускание Alt, Ctrl, Shift
            if (k_alt)
                keybd_event((byte)Keys.Menu, 0, 2, 0);
            if (k_ctrl)
                keybd_event((byte)Keys.ControlKey, 0, 2, 0);
            if (k_shift)
                keybd_event((byte)Keys.ShiftKey, 0, 2, 0);
        }

        // нажатие клавиши в поле "Клавиша"
        private void TextKey_KeyDown(object sender, KeyEventArgs e)
        {
            // запрещаем передачу события элементу управления
            e.SuppressKeyPress = true;
            // сбрасываем предыдущую сохраненную комбинацию клавиш
            k = 0;
            k_alt = false;
            k_ctrl = false;
            k_shift = false;
            TextKey.Text = "";
            // проверяем комбинацию Alt + клавиша
            if (e.Alt && (e.KeyCode != Keys.Menu))
            {
                k_alt = true;
                TextKey.Text += "Alt + ";
            }
            // проверяем комбинацию Ctrl + клавиша
            if (e.Control && (e.KeyCode != Keys.ControlKey))
            {
                k_ctrl = true;
                TextKey.Text += "Ctrl + ";
            }
            // проверяем комбинацию Shift + клавиша
            if (e.Shift && (e.KeyCode != Keys.ShiftKey))
            {
                k_shift = true;
                TextKey.Text += "Shift + ";
            }
            // запоминаем нажатую клавишу
            k = (byte)e.KeyCode;
            TextKey.Text += e.KeyCode.ToString();
        }

        // отпускание клавиши в поле "Клавиша"
        private void TextKey_KeyUp(object sender, KeyEventArgs e)
        {
            // запрещаем передачу события элементу управления
            e.SuppressKeyPress = true;
        }

        // нажатие на кнопку "Старт"
        private void BtnStart_Click(object sender, EventArgs e)
        {
            // проверяем задана ли комбинация клавиш
            if (TextKey.Text == "")
            {
                MessageBox.Show("Необходимо задать клавишу или сочетание клавиш", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // задаем интервал таймера
            try
            {
                Timer.Interval = Convert.ToInt32(TextFreq.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Недопустимое значение частоты", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Недопустимое значение частоты", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // запускаем таймер
            Timer.Start();
            // блокируем элементы управления для запуска эмуляции
            TextKey.Enabled = false;
            TextFreq.Enabled = false;
            BtnStart.Enabled = false;
            // разблокируем элементы управления для остановки эмуляции
            BtnStop.Enabled = true;
        }

        // нажатие на кнопку "Стоп"
        private void BtnStop_Click(object sender, EventArgs e)
        {
            // останавливаем таймер
            Timer.Stop();
            // блокируем элементы управления для остановки эмуляции
            BtnStop.Enabled = false;
            // разблокируем элементы управления для запуска эмуляции
            TextKey.Enabled = true;
            TextFreq.Enabled = true;
            BtnStart.Enabled = true;
        }
    }
}