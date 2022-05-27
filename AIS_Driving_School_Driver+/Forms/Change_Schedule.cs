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
    public partial class Change_Schedule : Form
    {
        public Change_Schedule()
        {
            InitializeComponent();
        }

        Function_Change change = new Function_Change();
        class Function_Change
        {
            MySqlConnection conn = new MySqlConnection("server =chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password=75855345;port=33333");

            public void GetList(TextBox textBox1, TextBox textBox2, ComboBox comboBox1, ComboBox comboBox2, TextBox textBox5)
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
                    comboBox1.Text = (reader_list[3].ToString());
                    comboBox2.Text = (reader_list[4].ToString());
                    textBox5.Text = (reader_list[5].ToString());
                }
                reader_list.Close();
                conn.Close();
            }

            public void CName(TextBox textBox1, TextBox textBox2, ComboBox comboBox1, ComboBox comboBox2, TextBox textBox5)
            {
                string connStr = "server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sql = "UPDATE Schedule SET Data = '" + textBox1.Text + "', Time = '" + textBox2.Text + "', Grup = '" + comboBox1.Text + "', Teacher = '" + comboBox2.Text + "', Cabinet = '" + textBox5.Text + "' WHERE id =  " + lell.id;

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

            // Заполнение combobox1 группы
            public void GetComboBoxList1(ComboBox comboBox1)
            {
                //Формирование списка статусов
                DataTable list_dolg_table = new DataTable();

                MySqlCommand list_dolg_command = new MySqlCommand();

                //Открываем соединение
                conn.Open();
                //Формируем столбцы для комбобокса списка 

                list_dolg_table.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
                //Настройка видимости полей комбобокса

                comboBox1.DataSource = list_dolg_table;

                comboBox1.ValueMember = "Name";


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

            // Заполнение combobox1 группы
            public void GetList1(string id_cp, Label label6)
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
                    label6.Text.Length.ToString(" " + reader_list[0].ToString());

                }
                reader_list.Close();
                conn.Close();
            }

            // Заполнение combobox2 преподаватели
            public void GetComboBoxList2(ComboBox comboBox2)
            {
                //Формирование списка статусов
                DataTable list_dolg_table = new DataTable();

                MySqlCommand list_dolg_command = new MySqlCommand();

                //Открываем соединение
                conn.Open();
                //Формируем столбцы для комбобокса списка 

                list_dolg_table.Columns.Add(new DataColumn("FIO", System.Type.GetType("System.String")));
                //Настройка видимости полей комбобокса

                comboBox2.DataSource = list_dolg_table;

                comboBox2.ValueMember = "FIO";


                //Формируется строка запроса на отображение списка 
                string sql_list_users = "SELECT FIO FROM Teachers";
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


            // Заполнение combobox2 преподаватели
            public void GetList2(string id_cp, Label label6)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Teachers FIO";
                //Команда для получения списка
                MySqlCommand cmd_get_list = new MySqlCommand(commandStr, conn);
                //Ридер для хранения списка строк
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                //Читаем ридер

                while (reader_list.Read())
                {
                    label6.Text.Length.ToString(" " + reader_list[0].ToString());

                }
                reader_list.Close();
                conn.Close();
            }


        }

        private void Change_Form1_Load(object sender, EventArgs e)
        {
            change.GetList(textBox1, textBox2, comboBox1, comboBox2, textBox5);
            change.GetComboBoxList1(comboBox1);
            change.GetComboBoxList2(comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            change.CName(textBox1, textBox2, comboBox1, comboBox2, textBox5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Schedule f1 = new Schedule();
            f1.Show();
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox1.SelectedValue);
            change.GetList1(id_cpu_selected, label6);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox2.SelectedValue);
            change.GetList2(id_cpu_selected, label6);
        }
    }
}
