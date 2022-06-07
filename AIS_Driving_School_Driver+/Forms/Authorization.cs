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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();        
        }
      
       internal class Pro
        {
            
            public static bool exit;
            delegate void Call_athoriz(TextBox textBox1, TextBox textBox2);
            Call_athoriz call;

            public void Prisvoenue_delegate(TextBox textBox1, TextBox textBox2)
            {
                call = Proverka;
                call(textBox1, textBox2);
            }

            // Метод для подлючения к БД и который проверяет логин и пароль 
            public static void Proverka(TextBox textBox1, TextBox textBox2)
            {
                // Проверка текстобоксов на пустоту если текстбоксы пустые то появлется надпись если все текстбоксы заполнены то выполняется else  
                if(textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                }
                else
                {
                    try
                    {
                        string connStr = "server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333";
                        MySqlConnection conn = new MySqlConnection(connStr);
                        conn.Open();
                        string sql = "SELECT * FROM Authorization WHERE Login = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'";

                        try
                        {
                            MySqlCommand comm = new MySqlCommand(sql, conn);
                            MySqlDataReader reader = comm.ExecuteReader();
                            reader.Read();

                            string Login = textBox1.Text;
                            string Password = textBox2.Text;

                            // Присовение переменным значений из БД таблицы Authorization
                            Login = reader[1].ToString();
                            Password = reader[2].ToString();


                            if (reader.HasRows)
                            {
                                reader.Read();
                                // Роли для администратора и пользователя
                                if (reader[3].ToString() == "Admin")
                                {
                                    Users_Role.role = "A";
                                    exit = true;
                                }
                                else if (reader[3].ToString() == "Users")
                                {
                                    Users_Role.role = "U";
                                    exit = true;
                                }
                                Schedule f1 = new Schedule();
                                f1.Show();
                                if (exit == true)
                                {
                                    Authorization auth = new Authorization();
                                    auth.Hide();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Ошибка!");
                            }
                             
                        }

                        catch
                        {
                            MessageBox.Show("Не правильный логин или пароль!");
                        }
                        conn.Close();

                    }
                    catch
                    {
                        MessageBox.Show("Не удалось подключится к серверу!");
                    }
                     
                }

            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == textBox1.Text || textBox2.Text == textBox2.Text)
            {
                Pro.Proverka(textBox1, textBox2);
                if(Pro.exit == true)
                {
                    Hide();
                }
            }
             
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Скрывает или показывает пароль в зависимости вкл или выкл "показать пароль"
        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
