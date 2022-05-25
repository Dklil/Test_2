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
    public partial class Teacher_Change : Form
    {
        public Teacher_Change()
        {
            InitializeComponent();
        }

        Function_Change change = new Function_Change();
        class Function_Change
        {
            MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password =75855345;port =33333");

            public void GetList(TextBox textBox1, ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3,TextBox textBox4, TextBox textBox5, TextBox textBox6)
            {
               
                string sql = "SELECT * FROM Teachers WHERE id =" + lell.id;
                MySqlCommand comm = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlCommand cmd_get_list = new MySqlCommand(sql, conn);
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                while (reader_list.Read())
                {
                    textBox1.Text = (reader_list[1].ToString());
                    comboBox1.Text = (reader_list[2].ToString());
                    comboBox2.Text = (reader_list[3].ToString());
                    comboBox3.Text = (reader_list[4].ToString());
                    textBox4.Text = (reader_list[5].ToString());
                    textBox5.Text = (reader_list[6].ToString());
                    textBox6.Text = (reader_list[7].ToString());
                }
                reader_list.Close();
                conn.Close();

            }

            public void CName(TextBox textBox1, ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3,TextBox textBox4, TextBox textBox5, TextBox textBox6)
            {
                string connStr = "server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sql = "UPDATE Teachers SET FIO = '" + textBox1.Text + "', Curators = '" + comboBox1.Text + "', Grupa = '" + comboBox2.Text + "', Car = '" + comboBox3.Text + "', Adres = '" + textBox4.Text + "', Phone = '" + textBox5.Text + "', Mail= '" + textBox6.Text + "' WHERE id =  " + lell.id;

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

            // Заполнение combobox1 куратор
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
                string sql_list_users = "SELECT FIO FROM Curators";
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

            // Заполнение combobox1 куратор
            public void GetList1(string id_cp, Label label9)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Curators FIO";
                //Команда для получения списка
                MySqlCommand cmd_get_list = new MySqlCommand(commandStr, conn);
                //Ридер для хранения списка строк
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                //Чтение ридера

                while (reader_list.Read())
                {
                    label9.Text.Length.ToString(" " + reader_list[0].ToString());
                }
                reader_list.Close();
                conn.Close();
            }


            // Заполнение combobox2 группа
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

            // Заполнение combobox2 группа
            public void GetList2(string id_cp, Label label9)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Grups Name";
                //Команда для получения списка
                MySqlCommand cmd_get_list = new MySqlCommand(commandStr, conn);
                //Ридер для хранения списка строк
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                //Чтение ридера

                while (reader_list.Read())
                {
                    label9.Text.Length.ToString(" " + reader_list[0].ToString());
                }
                reader_list.Close();
                conn.Close();
            }

            // Заполнение combobox3 машины
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

            // Заполнение combobox3 машины
            public void GetList3(string id_cp, Label label9)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Car Marka";
                //Команда для получения списка
                MySqlCommand cmd_get_list = new MySqlCommand(commandStr, conn);
                //Ридер для хранения списка строк
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                //Чтение ридера

                while (reader_list.Read())
                {
                    label9.Text.Length.ToString(" " + reader_list[0].ToString());
                }
                reader_list.Close();
                conn.Close();
            }

        }

        private void Teacher_Change_Load(object sender, EventArgs e)
        {
            change.GetList(textBox1, comboBox1, comboBox2, comboBox3,textBox4, textBox5, textBox6);
            change.GetComboBoxList1(comboBox1);
            change.GetComboBoxList2(comboBox2);
            change.GetComboBoxList3(comboBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            change.CName(textBox1, comboBox1, comboBox2, comboBox3,textBox4, textBox5, textBox6);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher back_teacher = new Teacher();
            back_teacher.Show();
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox1.SelectedValue);
            change.GetList1(id_cpu_selected, label9);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox2.SelectedValue);
            change.GetList2(id_cpu_selected, label9);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox3.SelectedValue);
            change.GetList3(id_cpu_selected, label9);
        }
    }
}
