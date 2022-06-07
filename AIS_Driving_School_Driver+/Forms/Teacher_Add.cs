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
    public partial class Teacher_Add : Form
    {
        public Teacher_Add()
        {
            InitializeComponent();
        }

        inf_dobav inf_do = new inf_dobav();
        class inf_dobav
        {
            MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password =75855345;port =33333");
            public void Dobavlenue(TextBox textBox1, ComboBox comboBox2, ComboBox comboBox3,TextBox textBox4, TextBox textBox5, TextBox textBox6)
            {           
                conn.Open();
                try
                {
                    string sql = "INSERT INTO Teachers (FIO, Grups, Car, Adres, Phone, Mail) VALUES ('" + textBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')";
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
                conn.Close();
            }

            
            // Заполнение combobox2 Группы
            public void GetComboBoxList2(ComboBox comboBox2)
            {
                //Формирование списка статусов
                DataTable list_dolg_table = new DataTable();

                MySqlCommand list_dolg_command = new MySqlCommand();

                //Открываем соединение
                conn.Open();
                //Формируем столбцы для комбобокса списка 

                list_dolg_table.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
                //Настройка видимости полей комбобокса

                comboBox2.DataSource = list_dolg_table;

                comboBox2.ValueMember = "Name";

                //Формируется строка запроса на отображение списка 
                string sql_list_users = "SELECT Name FROM Grups";
                list_dolg_command.CommandText = sql_list_users;
                list_dolg_command.Connection = conn;

                MySqlDataReader reader_list_FIO;
                try
                {
                    reader_list_FIO = list_dolg_command.ExecuteReader();

                    while (reader_list_FIO.Read())
                    {
                        DataRow rowToAdd = list_dolg_table.NewRow();

                        rowToAdd["Name"] = reader_list_FIO[0].ToString();
                        list_dolg_table.Rows.Add(rowToAdd);
                    }
                    reader_list_FIO.Close();
                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    conn.Close();
                }
            }


            // Заполнение combobox2 Группы
            public void GetList2(string id_cp, Label label7)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Grups Name";
                //Команда для получения списка
                MySqlCommand cmd_get_list = new MySqlCommand(commandStr, conn);
                //Ридер для хранения списка строк
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                //Читаем ридер

                while (reader_list.Read())
                {
                    label7.Text.Length.ToString(" " + reader_list[0].ToString());
                }
                reader_list.Close();
                conn.Close();
            }


            // Заполнение combobox3 Машины
            public void GetComboBoxList3(ComboBox comboBox3)
            {
                //Формирование списка статусов
                DataTable list_dolg_table = new DataTable();

                MySqlCommand list_dolg_command = new MySqlCommand();

                //Открываем соединение
                conn.Open();
                //Формируем столбцы для комбобокса списка 

                list_dolg_table.Columns.Add(new DataColumn("Marka", System.Type.GetType("System.String")));
                //Настройка видимости полей комбобокса

                comboBox3.DataSource = list_dolg_table;

                comboBox3.ValueMember = "Marka";

                //Формируется строка запроса на отображение списка 
                string sql_list_users = "SELECT Marka FROM Car";
                list_dolg_command.CommandText = sql_list_users;
                list_dolg_command.Connection = conn;

                MySqlDataReader reader_list_FIO;
                try
                {
                    reader_list_FIO = list_dolg_command.ExecuteReader();

                    while (reader_list_FIO.Read())
                    {
                        DataRow rowToAdd = list_dolg_table.NewRow();

                        rowToAdd["Marka"] = reader_list_FIO[0].ToString();
                        list_dolg_table.Rows.Add(rowToAdd);
                    }
                    reader_list_FIO.Close();
                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    conn.Close();
                }
            }


            // Заполнение combobox3 Машины
            public void GetList3(string id_cp, Label label7)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Car Marka";
                //Команда для получения списка
                MySqlCommand cmd_get_list = new MySqlCommand(commandStr, conn);
                //Ридер для хранения списка строк
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                //Читаем ридер

                while (reader_list.Read())
                {
                    label7.Text.Length.ToString(" " + reader_list[0].ToString());
                }
                reader_list.Close();
                conn.Close();
            }

        }

        // Загрузка формы (когда форма открывается комбобоксы заполняются информацией из определённых таблиц)
        private void Teacher_Add_Load(object sender, EventArgs e)
        {
            inf_do.GetComboBoxList2(comboBox2);
            inf_do.GetComboBoxList3(comboBox3);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            inf_do.Dobavlenue(textBox1, comboBox2, comboBox3, textBox4, textBox5, textBox6);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher back_teacher = new Teacher();
            back_teacher.Show();
            Hide();
        }

       
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox2.SelectedValue);
            inf_do.GetList2(id_cpu_selected, label7);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox3.SelectedValue);
            inf_do.GetList3(id_cpu_selected, label7);
        }
    }
}
