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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        Function_Change change = new Function_Change();
        class Function_Change
        {
            MySqlConnection conn = new MySqlConnection("server =chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password=75855345;port=33333");

            public void GetList(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5)
            {

                string sql = "SELECT * FROM Schedule WHERE id =" + lell.id;
                MySqlCommand comm = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlCommand cmd_get_list = new MySqlCommand(sql, conn);
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                while (reader_list.Read())
                {
                    textBox1.Text = (reader_list[1].ToString());
                    textBox2.Text = (reader_list[2].ToString());
                    textBox3.Text = (reader_list[3].ToString());
                    textBox4.Text = (reader_list[4].ToString());
                    textBox5.Text = (reader_list[5].ToString());
                }
                reader_list.Close();
                conn.Close();
            }

            public void CName(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5)
            {
                string connStr = "server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sql = "UPDATE Schedule SET Data = '" + textBox1.Text + "', Time = '" + textBox2.Text + "', Grup = '" + textBox3.Text + "', Teacher = '" + textBox4.Text + "', Cabinet = '" + textBox5.Text + "' WHERE id =  " + lell.id;

                MySqlCommand comm = new MySqlCommand(sql, conn);
                conn.Open();
                try
                {
                    comm.ExecuteNonQuery();
                }

                catch (Exception)
                {
                    MessageBox.Show("Ошибка");

                }
                finally
                {
                    conn.Close();
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            change.CName(textBox1, textBox2, textBox3, textBox4, textBox5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FForm1 back_fform1 = new FForm1();
            back_fform1.Show();
            Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            change.GetList(textBox1, textBox2, textBox3, textBox4, textBox5);
        }
    }
}
