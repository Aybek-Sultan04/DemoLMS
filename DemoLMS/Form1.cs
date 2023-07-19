using DemoLMS.Database;
using DemoLMS.Manager;
using System.Diagnostics;

namespace DemoLMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateAllFile createAllFile = new CreateAllFile();
            this.PassField.AutoSize = false;
            this.PassField.Size = new Size(this.LoginField.Width, this.LoginField.Height);
            this.LoginField.Text = "Loginni kiriting";
            LoginField.ForeColor = Color.Gray;
            PassField.UseSystemPasswordChar= false;
            PassField.ForeColor= Color.Gray;
            this.PassField.Text = "Parolni kiring";
        }
        private const string loginConst = "Teor";
        private const string passwordConst = "Aybek";

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if(PassField.Text!= "Parolni kiring" || LoginField.Text!= "Loginni kiriting")
            {
                if(PassField.Text==passwordConst&&loginConst==LoginField.Text)
                {
                    this.Hide();
                    Form3 form3 = new Form3();
                    form3.Show();
                }
                bool student = CheckUsers.CheckStudents(LoginField.Text, PassField.Text);
                if(student)
                {
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                bool teacher = CheckUsers.CheclTeacher(LoginField.Text, PassField.Text);
                if(teacher)
                {
                    MessageBox.Show("You are teacher");
                }
                if(!teacher&& !student&&LoginField.Text!="Teor"&&PassField.Text!="Aybek") 
                {
                    MessageBox.Show("Bunday maʼlumotlarga ega foydalanuvchi mavjud emas");
                }
            }
            else
            {
                MessageBox.Show("Login va parolni kiriting!"); 
            }
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            this.labelClose.ForeColor = Color.Red;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            this.labelClose.ForeColor = Color.Black;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void LoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Loginni kiriting")
                LoginField.Text = "";
            LoginField.ForeColor = Color.Black;
        }

        private void LoginField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "Loginni kiriting";
                LoginField.ForeColor = Color.Gray;
            }
        }

        private void PassField_Enter(object sender, EventArgs e)
        {
            if(PassField.Text== "Parolni kiring")
            {
                PassField.UseSystemPasswordChar= true;
                PassField.ForeColor = Color.Black;
                PassField.Text = "";
            }
        }

        private void PassField_Leave(object sender, EventArgs e)
        {
            if(PassField.Text=="")
            {
                PassField.UseSystemPasswordChar= false;
                PassField.Text = "Parolni kiring";
                PassField.ForeColor = Color.Gray;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {


        }

 

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picturePass_Click(object sender, EventArgs e)
        {

        }

        private void pictureLog_Click(object sender, EventArgs e)
        {

        }

        private void PassField_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}