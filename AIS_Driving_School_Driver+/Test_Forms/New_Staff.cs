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
    public partial class New_Staff : Form
    {
        public New_Staff()
        {
            InitializeComponent();
        }

        Dobavlenue dobavlenue_inf = new Dobavlenue();
        class Dobavlenue
        {
            MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password =75855345;port =33333");
            public void Add_Function(TextBox textBox1, ComboBox comboBox1)
            {

                conn.Open();
                try
                {
                    string sql = "INSERT INTO Staff (FIO, Post) VALUES ('" + textBox1.Text + "', '" + comboBox1.Text + "')";
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
                conn.Close();
            }

            // Заполнение combobox1 Должность
            public void GetComboBoxList1(ComboBox comboBox1)
            {
                //Формирование списка статусов
                DataTable list_dolg_table = new DataTable();

                MySqlCommand list_dolg_command = new MySqlCommand();

                //Открываем соединение
                conn.Open();
                //Формируем столбцы для комбобокса списка 

                list_dolg_table.Columns.Add(new DataColumn("Place", System.Type.GetType("System.String")));
                //Настройка видимости полей комбобокса

                comboBox1.DataSource = list_dolg_table;

                comboBox1.ValueMember = "Place";


                //Формируется строка запроса на отображение списка 
                string sql_list_users = "SELECT Place FROM Post";
                list_dolg_command.CommandText = sql_list_users;
                list_dolg_command.Connection = conn;


                MySqlDataReader reader_list_FIO;
                try
                {
                    reader_list_FIO = list_dolg_command.ExecuteReader();

                    while (reader_list_FIO.Read())
                    {
                        DataRow rowToAdd = list_dolg_table.NewRow();

                        rowToAdd["Place"] = reader_list_FIO[0].ToString();
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

            // Заполнение combobox1 Должность
            public void GetList1(string id_cp, Label label3)
            {
                //Открываем соединение
                conn.Open();
                //Строка запроса
                string commandStr = "SELECT * FROM Post Place";
                //Команда для получения списка
                MySqlCommand cmd_get_list = new MySqlCommand(commandStr, conn);
                //Ридер для хранения списка строк
                MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
                //Читаем ридер

                while (reader_list.Read())
                {
                    label3.Text.Length.ToString(" " + reader_list[0].ToString());
                }
                reader_list.Close();
                conn.Close();
            }

        }

        // Добавление нового сотрудника
        private void button1_Click(object sender, EventArgs e)
        {
            dobavlenue_inf.Add_Function(textBox1, comboBox1);
        }
        // Назад на прошлую форму
        private void button2_Click(object sender, EventArgs e)
        {
            Transition_from_staff back = new Transition_from_staff();
            back.Show();
            Hide();
        }

        private void New_Staff_Load(object sender, EventArgs e)
        {
            dobavlenue_inf.GetComboBoxList1(comboBox1);
            textBox2.Visible = false;
            textBox3.Visible = false;
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label1.Text = "Логин";
            label2.Text = "Пароль";
            textBox1.Visible = false;
            comboBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }
    }
}
