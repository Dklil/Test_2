using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS_Driving_School_Driver_
{
    public partial class Transition_from_staff : Form
    {
        public Transition_from_staff()
        {
            InitializeComponent();
        }

        // Переход на форму с кураторами
        private void button1_Click(object sender, EventArgs e)
        {
            Curators form_Curators = new Curators();
            form_Curators.Show();
            Hide();
        }

        // Переход на форму с преподавателями
        private void button2_Click(object sender, EventArgs e)
        {
             

            Teacher form_Teacher = new Teacher();
            form_Teacher.Show();
            Hide();
        }
         

        private void button3_Click(object sender, EventArgs e)
        {
            Schedule form_back = new Schedule();
            form_back.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            New_Staff new_Staff = new New_Staff();
            new_Staff.Show();
            Hide();
        }
    }
}
