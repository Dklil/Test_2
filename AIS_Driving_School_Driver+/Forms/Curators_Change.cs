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
    public partial class Curators_Change : Form
    {
        public Curators_Change()
        {
            InitializeComponent();
        }

        Change_Inform change_Inform = new Change_Inform();

        class Change_Inform
        {
            MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password =75855345;port =33333");

            public void GetList(TextBox textBox1, ComboBox comboBox1, ComboBox comboBox2, TextBox textBox2, TextBox textBox3, TextBox textBox4)
            {

                string sql = "SELECT * FROM Curators WHERE id =" + lell.id;
                MySqlCommand comm = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlCommand cmd_get_list = new MySqlCommand(sql, conn);
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                while (reader_list.Read())
                {
                    textBox1.Text = (reader_list[1].ToString());
                    comboBox1.Text = (reader_list[2].ToString());
                    comboBox2.Text = (reader_list[3].ToString());
                    textBox2.Text = (reader_list[4].ToString());
                    textBox3.Text = (reader_list[5].ToString());
                    textBox4.Text = (reader_list[6].ToString());
                }
                reader_list.Close();
                conn.Close();
            }

            public void CName(TextBox textBox1, ComboBox comboBox1, ComboBox comboBox2, TextBox textBox2, TextBox textBox3, TextBox textBox4)
            {
                string connStr = "server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sql = "UPDATE Curators SET FIO= '" + textBox1.Text + "', Grups= '" + comboBox1.Text + "', Cabinet= '" + comboBox2.Text + "', Adres = '" + textBox2.Text + "', Phone = '" + textBox3.Text + "', Mail = '" + textBox4.Text + "' WHERE id = " + lell.id;

                MySqlCommand comm = new MySqlCommand(sql, conn);
                try
                {
                    conn.Open();
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

            // Заполнение combobox1 Группы
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

            // Заполнение combobox1 Группы
            public void GetList1(string id_cp, Label label7)
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

            // Заполнение combobox2 Кабинет
            public void GetComboBoxList2(ComboBox comboBox2)
            {
                //Формирование списка статусов
                DataTable list_dolg_table = new DataTable();

                MySqlCommand list_dolg_command = new MySqlCommand();

                //Открываем соединение
                conn.Open();
                //Формируем столбцы для комбобокса списка 

                list_dolg_table.Columns.Add(new DataColumn("Numbers", System.Type.GetType("System.String")));
                //Настройка видимости полей комбобокса

                comboBox2.DataSource = list_dolg_table;

                comboBox2.ValueMember = "Numbers";


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


            // Заполнение combobox2 Кабинет
            public void GetList2(string id_cp, Label label7)
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

        private void Curators_Change_Load(object sender, EventArgs e)
        {
            change_Inform.GetList(textBox1, comboBox1, comboBox2, textBox2, textBox3, textBox4);
            change_Inform.GetComboBoxList1(comboBox1);
            change_Inform.GetComboBoxList2(comboBox2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox1.SelectedValue);
            change_Inform.GetList1(id_cpu_selected, label7);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_cpu_selected = Convert.ToString(comboBox2.SelectedValue);
            change_Inform.GetList1(id_cpu_selected, label7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            change_Inform.CName(textBox1, comboBox1, comboBox2, textBox2, textBox3, textBox4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Curators back_form = new Curators();
            back_form.Show();
            Hide();
        }

        
    }
}
