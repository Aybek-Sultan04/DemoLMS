using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoLMS
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private bool checkUser()
        {
            using (StreamReader reader = new StreamReader("Students.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] field;
                    field = reader.ReadLine().Split(",");
                    string login = dataGridView1[5, 0].Value.ToString();
                    if (field[0] == login)
                    {
                        MessageBox.Show("Такой пользователь уже есть!!!");
                        return false;
                    }
                }
            }
            using (StreamReader reader = new StreamReader("Teachers.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] field;
                    field = reader.ReadLine().Split(",");
                    string login = dataGridView1[5, 0].Value.ToString();
                    if (field[0] == login)
                    {
                        MessageBox.Show("Такой пользователь уже есть!!!");
                        return false;
                    }
                }
            }
            string s;
            if (this.checkStudent.Checked)
                s = "Student";
            else
                s = "Teacher";
            using (StreamWriter writer = new StreamWriter(dataGridView1[5, 0].Value + ".txt", true))
            {
                writer.WriteLine("First name:" + dataGridView1[0, 0].Value);
                writer.WriteLine("Last name:" + dataGridView1[1, 0].Value);
                writer.WriteLine("Paspord Id:" + dataGridView1[2, 0].Value);
                writer.WriteLine("Date of birth:" + dataGridView1[3, 0].Value);
                writer.WriteLine("Gender:" + dataGridView1[4, 0].Value);
                writer.WriteLine("Login:" + dataGridView1[5, 0].Value);
                writer.WriteLine("Password:" + dataGridView1[6, 0].Value);
                writer.WriteLine("Password:" + s);
                writer.Close();
            }
            return true;
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            if(this.checkStudent.Checked&& this.checkTeacher.Checked)
            {
                MessageBox.Show("Выберите один параметр!!!");
                return;
            }
            else if(this.checkStudent.Checked)
            {
                if (!checkUser())
                    return;
                using (StreamWriter writer = new StreamWriter("Students.txt", true))
                {
                    writer.WriteLine(dataGridView1[5, 0].Value.ToString()+","+ dataGridView1[6, 0].Value.ToString());
                    writer.Close();
                    dataGridView1.Rows.Clear();
                    MessageBox.Show("Пользователь успешно добавлен!");
                }
            }
            else if(this.checkTeacher.Checked)
            {
                if (!checkUser())
                    return;
                using (StreamWriter writer = new StreamWriter("Teachers.txt", true))
                {
                    writer.WriteLine(dataGridView1[5, 0].Value.ToString() + "," + dataGridView1[6, 0].Value.ToString());
                    writer.Close();
                    dataGridView1.Rows.Clear();
                    MessageBox.Show("Пользователь успешно добавлен!");
                }
            }
            else
            {
                MessageBox.Show("Выберите один параметр!!!");
                return;
            }

        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("Students.txt"))
            {
            List<string>  userinfo = new List<string>();
                string[] s = new string[2];
                while(!reader.EndOfStream)
                {
                    s=reader.ReadLine().Split(",");
                    if (s[0] !=this.textBoxforDelete.Text)
                        userinfo.Add(s[0] + "," + s[1]);
                }
                reader.Close();
                using (StreamWriter writer = new StreamWriter("Students.txt",false))
                {
                    foreach(var s1 in userinfo)
                    {
                        writer.WriteLine(s1);
                    }
                    writer.Close();
                }
            }
            using (StreamReader reader = new StreamReader("Teachers.txt"))
            {
                List<string> userinfo = new List<string>();
                string[] s = new string[2];
                while (!reader.EndOfStream)
                {
                    s = reader.ReadLine().Split(","); 
                    if (s[0] != this.textBoxforDelete.Text)
                        userinfo.Add(s[0] + "," + s[1]);
                }
                reader.Close ();
                using (StreamWriter writer = new StreamWriter("Teachers.txt", false))
                {
                    foreach (var s1 in userinfo)
                    {
                        writer.WriteLine(s1);
                    }
                    writer.Close(); 
                }
            }
        }

        private void buttonGetInfo_Click(object sender, EventArgs e)
        {
            try
            {
                using(StreamReader reader = new StreamReader(this.textBoxGetInfo.Text+".txt"))
                {
                    string info=null;
                    while(!reader.EndOfStream)
                    {
                        info += reader.ReadLine() +"\n";
                    }
                    reader.Close();
                    MessageBox.Show(info);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Такой пользователь не найден!");
            }
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Red;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        

        

        private void panel3_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
