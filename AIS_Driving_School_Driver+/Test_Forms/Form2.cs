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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Dobavlenue dobav = new Dobavlenue();
        class Dobavlenue
        {
            MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password =75855345;port =33333");
            public void Add_Function(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5)
            {
                conn.Open();
                try
                {

                    string sql = "INSERT INTO Schedule (Data,Time, Grup, Teacher, Cabinet) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();

                }
                catch
                {

                    MessageBox.Show("Ошибка!");

                }
                conn.Close();
            }

           

            

            


           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dobav.Add_Function(textBox1, textBox2, textBox3, textBox4, textBox5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FForm1 back_ff1 = new FForm1();
            back_ff1.Show();
            Hide();
        }
    }
}
