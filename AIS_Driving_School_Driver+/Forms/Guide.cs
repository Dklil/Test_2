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
    public partial class Guide : Form
    {
        public Guide()
        {
            InitializeComponent();
        }

        // Сравчоник Групп
        private void button1_Click(object sender, EventArgs e)
        {
            Guide_Groups guid_Groups = new Guide_Groups();
            guid_Groups.Show();
            Hide();
        }

        // Возвращение на главную форму
        private void button2_Click(object sender, EventArgs e)
        {
            Schedule back_form = new Schedule();
            back_form.Show();
            Hide();
        }
        // Кураторы 
        private void button3_Click(object sender, EventArgs e)
        {

        }
        // Преподаватели
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
