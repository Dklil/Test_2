using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AIS_Driving_School_Driver_
{
    public partial class Schedule : Form
    {
        
        public Schedule()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Transition_from_staff form_Selection = new Transition_from_staff();
            form_Selection.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Groups form_Groups = new Groups();
            form_Groups.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Guide form_Guide = new Guide();
            form_Guide.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Schedule_by_teachers form_Schedule_Teachers = new Schedule_by_teachers();
            form_Schedule_Teachers.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Authorization back_authorization = new Authorization();
            back_authorization.Show();
            // Если пользователь нажал на выход exit вместо true становится false это для авторизации чтобы при появлинни формы программа не считала его авторизированным  
            Authorization.Pro.exit = false;
            Hide();

        }

        private void Schedule_Load(object sender, EventArgs e)
        {
           
            if (Users_Role.role == "U")
            {
                button1.Visible = false;
                label1.Visible = false;
                button2.Visible = false;
                label2.Visible = false;

               
                button4.Location = new Point(20, 12);
                label4.Location = new Point(10, 171);
                Size = new Size(215, 249);

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Hide();
        }
    }
}
