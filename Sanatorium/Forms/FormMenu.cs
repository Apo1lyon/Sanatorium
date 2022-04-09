using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanatorium
{
    public partial class FormMenu : Form
    {
        //Поля
        private Button currentButton; //Текущая кнопка
        private Random random; 
        private int tempIndex; //Текущий цветовой индекс
        private Form activeForm; //Текущая активная форма

        //Конструктор
        public FormMenu()
        {
            InitializeComponent();
            random = new Random();
            btnBackMenu.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Методы
        private Color SelectTehemeColor() 
        {
            int index = random.Next(ThemeColor.ColorList.Count);//Получение индекса рандомной цветовой темы
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index]; //Получение цвета
            return ColorTranslator.FromHtml(color); //Переводит представление цвета HTML в GDI + System.Drawing.Color структуры.
        }//Выбор цветовой темы для основной формы

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton(); //Диактивирует все кнопки
                    Color color = SelectTehemeColor(); //Выбирает цвет
                    currentButton = (Button)btnSender; //Делает её текущей кнопкой
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))); //Присваивает шрифт
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3); //Изменяет цвет логотипа на более тёмный
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3); //Присваивает более тёмный цвет
                    btnBackMenu.Visible = true; //Отображение кнопки закрытия дочерней формы
                } //Проверка на повторное нажатие 
            }
        }//Активация кнопки

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(67, 34, 58);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            } //Перебирает все кнопки
        } //Диактивирует все кнопки

        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            if (currentButton != (Button)btnSender)
            {
                ActivateButton(btnSender);
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                this.panelDesktop.Controls.Add(childForm);
                this.panelDesktop.Tag = childForm;

                childForm.BringToFront();
                childForm.Show();
                lblTitle.Text = childForm.Text;
            }
            else Reset();
        }//Открытие дочерней формы

        //Дочерние формы
        private void btnPersonnel_Click(object sender, EventArgs e) => OpenChildForm(new Forms.FormListPersonnel(), sender);//Вызов формы при нажатии кнопки

        private void btnPatient_Click(object sender, EventArgs e) => OpenChildForm(new Forms.FormListPatient(), sender);//Вызов формы при нажатии кнопки
        
        private void btnServices_Click(object sender, EventArgs e) => OpenChildForm(new Forms.FormListServices(), sender);//Вызов формы при нажатии кнопки

        private void btnReporting_Click(object sender, EventArgs e) => OpenChildForm(new Forms.FormListReporting(), sender);

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();

        } //Закрытие дочерней формы

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Главная";
            panelTitleBar.BackColor = Color.FromArgb(89, 30, 74);
            panelLogo.BackColor = Color.FromArgb(58, 10, 46);
            currentButton = null;
            btnBackMenu.Visible = false;
        }//Вернутся к начальному виду основной формы

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        } //Перемещение формы

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } //Нажата кнопка закрытия

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        } //Нажата кнопка максимальный размер

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        } //Нажата кнопка минимальный размер
    }
}
