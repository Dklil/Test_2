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
    public partial class Form67 : Form
    {
        public Form67()
        {
            InitializeComponent();
        }

        static MySqlConnection conn = new MySqlConnection("server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333");
        static DataTable List_users = new DataTable();
        static BindingSource List = new BindingSource();
        static MySqlDataAdapter Users_add_bd = new MySqlDataAdapter();
        string index_selecet_rows;
        string id_selected_rows;
        Otobrajenue Door = new Otobrajenue();

        interface Otobraj
        {
            void read_list1();
        }

        class Otobrajenue : Otobraj
        {
            // Конструткор с sql запросам на отображение всех записей из таблицы кураторы
            public Otobrajenue()
            {
                conn.Open();
                string sql = "SELECT * FROM Staff";
                MySqlDataAdapter abp_list_cl = new MySqlDataAdapter(sql, conn);
                List.DataSource = List_users;
                abp_list_cl.Fill(List_users);
                conn.Close();
            }

            public void read_list1()
            {
                List_users.Clear();
                Otobrajenue otobrajenue = new Otobrajenue();
                Users_add_bd.Update((DataTable)List.DataSource);
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.Update();
            }

            // Создание уделение и удаление при выборе записей 
            public void Removal(int id)
            {
                string connStr = "server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sql_del = "DELETE FROM Staff WHERE id=" + id.ToString();
                MySqlCommand del_user = new MySqlCommand(sql_del, conn);
                try
                {
                    conn.Open();
                    del_user.ExecuteNonQuery();
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

        private void approveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
            lell.id = Convert.ToInt32(id_selected_rows);
            Test_Staff form_staff = new Test_Staff();
            form_staff.Show();
            Hide();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Curators back_to_curators = new Curators();
            back_to_curators.Show();
            Hide();
        }

        private void Form67_Load(object sender, EventArgs e)
        {
            Otobrajenue ot = new Otobrajenue();
            ot.read_list1();

            dataGridView1.DataSource = List;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Заполняет пустую ширину датагрида
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Уберает заголовки в датагриде
            dataGridView1.RowHeadersVisible = false;
            // Делает надписи из БД на русском
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Должность";

        }

        private void curatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Curators form_curators = new Curators();
            form_curators.Show();
            Hide();
        }
    }
}
