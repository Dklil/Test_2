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
    public partial class test_dell : Form
    {
        public test_dell()
        {
            InitializeComponent();
        }

        static MySqlConnection conn = new MySqlConnection("server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333");
        static DataTable List_users = new DataTable();
        static BindingSource List = new BindingSource();
        static MySqlDataAdapter Users_add_bd = new MySqlDataAdapter();
        string index_selecet_rows;
        string id_selected_rows;

        class General_Schedule
        {

             

            // Конструткор с sql запросам на отображение всех записей из таблицы кураторы
            public void Otobrajenue()
            {
                conn.Open();
                string sql = "SELECT * FROM Schedule";
                MySqlDataAdapter abp_list_cl = new MySqlDataAdapter(sql, conn);
                List.DataSource = List_users;
                abp_list_cl.Fill(List_users);
                conn.Close();
            }

            public void read_list1()
            {
                List_users.Clear();
                Otobrajenue();
                Users_add_bd.Update((DataTable)List.DataSource);
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.Update();
            }



        }

        private void curatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Curators curators = new Curators();
            curators.Show();
            Hide();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Show();
            Hide();
        }

        private void referenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test_reference test_Reference = new test_reference();
            test_Reference.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Hide();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void test_dell_Load(object sender, EventArgs e)
        {
            General_Schedule GS = new General_Schedule();
            GS.read_list1();

            dataGridView1.DataSource = List;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Заполняет пустую ширину датагрида
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Уберает заголовки в датагриде
            dataGridView1.RowHeadersVisible = false;
            // Делает надписи из БД на русском
            dataGridView1.Columns[1].HeaderText = "Дата";
            dataGridView1.Columns[2].HeaderText = "Время";
            dataGridView1.Columns[3].HeaderText = "Группа";
            dataGridView1.Columns[4].HeaderText = "Преподаватель";
            dataGridView1.Columns[5].HeaderText = "Кабинет";
        }

        

        
    }
}
