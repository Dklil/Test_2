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
    public partial class Test_Staff : Form
    {
        public Test_Staff()
        {
            InitializeComponent();
        }

        Dobavlenue dobavlenue_inf = new Dobavlenue();
        class Dobavlenue
        {
            MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password =75855345;port =33333");
            public void Add_Function(ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3, TextBox textBox1, TextBox textBox2, TextBox textBox3)
            {

                conn.Open();
                try
                {
                    string sql = "INSERT INTO Curators (FIO, Grups, Cabinet, Adres, Phone, Mail) VALUES ('" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
                conn.Close();
            }

            // Заполнение combobox1 ФИО
            public void GetComboBoxList1(ComboBox comboBox1)
            {
                //Формирование списка статусов
                DataTable list_dolg_table = new DataTable();

                MySqlCommand list_dolg_command = new MySqlCommand();

                //Открываем соединение
                conn.Open();
                //Формируем столбцы для комбобокса списка 

                list_dolg_table.Columns.Add(new DataColumn("FIO", System.Type.GetType("System.String")));
                //Настройка видимости полей комбобокса

                comboBox1.DataSource = list_dolg_table;

                comboBox1.ValueMember = "FIO";


                //Формируется строка запроса на отображение списка 
                string sql_list_users = "SELECT FIO FROM Staff";
                list_dolg_command.CommandText = sql_list_users;
                list_dolg_command.Connection = conn;


                MySqlDataReader reader_list_FIO;
                try
                {
                    reader_list_FIO = list_dolg_command.ExecuteReader();

                    while (reader_list_FIO.Read())
                    {
                        DataRow rowToAdd = list_dolg_table.NewRow();

                        rowToAdd["FIO"] = reader_list_FIO[0].ToString();
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

            // Заполнение combobox1 ФИО
            public void GetList1(string id_cp, Label label7)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Staff FIO";
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

            // Заполнение combobox2 Группа
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


            // Заполнение combobox2 Группа
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


            // Заполнение combobox3 Кабинет
            public void GetComboBoxList3(ComboBox comboBox3)
            {
                //Формирование списка статусов
                DataTable list_dolg_table = new DataTable();

                MySqlCommand list_dolg_command = new MySqlCommand();

                //Открываем соединение
                conn.Open();
                //Формируем столбцы для комбобокса списка 

                list_dolg_table.Columns.Add(new DataColumn("Numbers", System.Type.GetType("System.String")));
                //Настройка видимости полей комбобокса

                comboBox3.DataSource = list_dolg_table;

                comboBox3.ValueMember = "Numbers";


                //Формируется строка запроса на отображение списка 
                string sql_list_users = "SELECT Numbers FROM Curators_Cabinet";
                list_dolg_command.CommandText = sql_list_users;
                list_dolg_command.Connection = conn;


                MySqlDataReader reader_list_FIO;
                try
                {
                    reader_list_FIO = list_dolg_command.ExecuteReader();

                    while (reader_list_FIO.Read())
                    {
                        DataRow rowToAdd = list_dolg_table.NewRow();

                        rowToAdd["Numbers"] = reader_list_FIO[0].ToString();
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


            // Заполнение combobox3 Кабинет
            public void GetList3(string id_cp, Label label7)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Curators_Cabinet Numbers";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox1.SelectedValue);
            dobavlenue_inf.GetList1(id_cpu_selected, label7);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox2.SelectedValue);
            dobavlenue_inf.GetList2(id_cpu_selected, label7);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox3.SelectedValue);
            dobavlenue_inf.GetList3(id_cpu_selected, label7);
        }

        private void Test_Staff_Load(object sender, EventArgs e)
        {
            dobavlenue_inf.GetComboBoxList1(comboBox1);
            dobavlenue_inf.GetComboBoxList2(comboBox2);
            dobavlenue_inf.GetComboBoxList3(comboBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dobavlenue_inf.Add_Function(comboBox1, comboBox2, comboBox3, textBox1, textBox2, textBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form67 f67 = new Form67();
            f67.Show();
            Hide();
        }
    }
}
