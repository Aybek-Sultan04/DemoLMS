using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoLMS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            bool work = false;
            bool entery = false;
            InitializeComponent();
            panel3.MouseEnter += async (a, b) =>
            {
                while (!work && panel3.Size.Width < 215)
                {
                    work = true;
                    await Task.Delay(1);
                    panel3.Size = new Size(panel3.Size.Width + panel3.Size.Width / 25, panel3.Size.Height);
                    work = false;
                }
            };
            labelSchedule.MouseEnter += async (a, b) =>
            {

                while (panel3.Size.Width < 215)
                {
                    work = true;
                    entery = false;
                    await Task.Delay(1);
                    panel3.Size = new Size(panel3.Size.Width + panel3.Size.Width / 25, panel3.Size.Height);
                    work = false;
                }
            };
            labelSchedule.MouseLeave += (a, b) =>
            {
                entery = true;
            };
            labelTask.MouseLeave += (a, b) =>
            {
                entery = true;
            };
            labelTask.MouseEnter += async (a, b) =>
            {
                while (panel3.Size.Width < 215)
                {
                    work = true;
                    entery = false;
                    await Task.Delay(1);
                    panel3.Size = new Size(panel3.Size.Width + panel3.Size.Width / 25, panel3.Size.Height);
                    work = false;
                }
            };
            panel3.MouseLeave += async (a, b) =>
            {
                while (!work && panel3.Size.Width > 25 && entery)
                {
                    work = true;
                    await Task.Delay(1);
                    panel3.Size = new Size(panel3.Width - panel3.Width / 25, panel3.Size.Height);
                    work = false;
                }
            };

        }


        private void labelClose_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labelTime.Text = DateTime.Now.ToString("dd.MM.yyyy|hh:mm");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("dd.MM.yyyy | hh:mm");
            timer1.Start();
        }
        Point lastPoint;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void labelSchedule_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Время", typeof(string));
            table.Columns.Add("Понидельник", typeof(string));
            table.Columns.Add("Вторник", typeof(string));
            table.Columns.Add("Среда", typeof(string));
            table.Columns.Add("Четверг", typeof(string));
            table.Columns.Add("Пятница", typeof(string));
            table.Columns.Add("Суббота", typeof(string));
            table.Rows.Add("9:00", "", "Религиоведение", "Английский язык", "", "Дифферен-урав", "Английский язык");
            table.Rows.Add("11:00", "", "", "Физика", "Физика", "Программирование", "Дифферен-урав");
            table.Rows.Add("12:30", "", "Религиоведение", "Академическое письмо", "Линейная алгебра", "Физика/Програмирование", "Програмирование");
            table.Rows.Add("14:30", "", "", "Линейная алгебра", "", "", " ");
            dataGridView1.DataSource = table;
            
            while (panel4.Size.Width < 685)
            {
                Thread.Sleep(10);
                panel4.Size = new Size(panel4.Size.Width + panel4.Size.Width / 10, panel4.Size.Height);
            }
            while (panel5.Size.Width > 20)
            {
                Thread.Sleep(10);
                panel5.Size = new Size(panel5.Size.Width - panel4.Size.Width / 10, panel5.Size.Height);
            }

        }

        private void labelTask_Click(object sender, EventArgs e)
        {
            while (panel4.Size.Width > 10)
            {
                Thread.Sleep(10);
                panel4.Size = new Size(panel4.Size.Width - panel4.Size.Width / 10, panel4.Size.Height);
            }
            while (panel5.Size.Width < 685)
            {
                Thread.Sleep(10);
                panel5.Size = new Size(panel5.Size.Width + panel5.Size.Width / 10, panel5.Size.Height);
            }
        }
    }
}
