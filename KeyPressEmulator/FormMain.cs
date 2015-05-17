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

        // конструктор
        public FormMain()
        {
            InitializeComponent();
            
            // инициализация элементов интерфейса
            StatusEmuState.Text = STR_EMU_STOPPED;
            StatusPaused.Text = STR_EMPTY;
            StatusCopyright.Text = STR_COPYRIGHT;
            ComboHotKey.SelectedIndex = 10;
            LabelHotKey2.Text = STR_EMPTY;

            // инициализация переменных
            paused = false;
            hotkey_id = 0;
            hWnd = Handle;
        }

        #region КОНСТАНТЫ

        const int WM_HOTKEY = 0x0312;
        const string STR_USER32_DLL = "user32.dll";
        const string STR_EMU_STOPPED = "Эмуляция остановлена";
        const string STR_EMU_STARTED = "Эмуляция запущена";
        const string STR_PAUSED = "Пауза";
        const string STR_COPYRIGHT = "          © Любимов Роман";
        const string STR_EMPTY = "";
        const string STR_ALT_PLUS = "Alt + ";
        const string STR_CTRL_PLUS = "Ctrl + ";
        const string STR_SHIFT_PLUS = "Shift + ";
        const string STR_ERR = "Ошибка!";
        const string STR_ERR_KEY = "Необходимо задать клавишу или сочетание клавиш";
        const string STR_ERR_FREQ = "Недопустимое значение частоты";
        const string STR_ERR_HOTKEY_REM = "Ошибка удаления горячей клавиши";
        const string STR_ERR_HOTKEY_ADD = "Ошибка установки горячей клавиши";

        #endregion
        
        #region ПЕРЕМЕННЫЕ

        // сюда запоминаем нажатую клавишу
        byte k;
        // сюда запоминаем состояние Alt, Ctrl, Shift при нажатии клавиши
        bool k_alt, k_ctrl, k_shift;
        // флаг паузы эмуляции
        bool paused;
        // идентификатор горячей клавиши паузы
        int hotkey_id;
        // дескриптор окна
        IntPtr hWnd;

        #endregion

        #region ИМПОРТ ФУНКЦИЙ

        // импорт функции для эмуляции нажатия клавиш
        [DllImport(STR_USER32_DLL)]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        // импорт функции для установки горячей клавиши
        [DllImport(STR_USER32_DLL)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        
        // импорт функции для удаления горячей клавиши
        [DllImport(STR_USER32_DLL)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        
        #endregion

        // срабатывание таймера
        private void Timer_Tick(object sender, EventArgs e)
        {
            // эмуляция выполняется если не пауза
            if (!paused)
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
            TextKey.Text = STR_EMPTY;
           
            // проверяем комбинацию Alt + клавиша
            if (e.Alt && (e.KeyCode != Keys.Menu))
            {
                k_alt = true;
                TextKey.Text += STR_ALT_PLUS;
            }
           
            // проверяем комбинацию Ctrl + клавиша
            if (e.Control && (e.KeyCode != Keys.ControlKey))
            {
                k_ctrl = true;
                TextKey.Text += STR_CTRL_PLUS;
            }
           
            // проверяем комбинацию Shift + клавиша
            if (e.Shift && (e.KeyCode != Keys.ShiftKey))
            {
                k_shift = true;
                TextKey.Text += STR_SHIFT_PLUS;
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
                MessageBox.Show(STR_ERR_KEY, STR_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // задаем интервал таймера
            try
            {
                Timer.Interval = Convert.ToInt32(TextFreq.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(STR_ERR_FREQ, STR_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show(STR_ERR_FREQ, STR_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // текст в строке статуса
            StatusEmuState.Text = STR_EMU_STARTED;
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

            // текст в строке статуса
            StatusEmuState.Text = STR_EMU_STOPPED;
        }
        
        // нажатие на кнопку "Назначить"
        private void BtnMapHotKey_Click(object sender, EventArgs e)
        {
            // если горячая клавиша установлена - удаляем ее
            if (hotkey_id > 0)
            {
                if (UnregisterHotKey(hWnd, hotkey_id))
                    LabelHotKey2.Text = "";
                else
                    MessageBox.Show(STR_ERR_HOTKEY_REM, STR_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            // определяем код новой горячей клавиши
            // коды виртуальных клавиш: F1=70=112 - F12=7B=123
            // индексы в ComboBox: 0 - 11
            uint VK = (uint)ComboHotKey.SelectedIndex + 112;
            
            // регистрируем новую горячую клавишу
            hotkey_id = 10;
            if (RegisterHotKey(hWnd, hotkey_id, 0, VK))
                LabelHotKey2.Text = "(F" + (VK - 111) + ")";
            else
                MessageBox.Show(STR_ERR_HOTKEY_ADD, STR_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        // переопределение оконной процедуры
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            // если окном получено сообщение WM_HOTKEY
            // значит нажата горячая клавиша
            if (m.Msg == WM_HOTKEY)
            {
                // переключить флаг паузы
                paused = !paused;

                // текст в строке статуса
                if (paused)
                    StatusPaused.Text = STR_PAUSED;
                else
                    StatusPaused.Text = STR_EMPTY;
            }                           
        }   

    }
}