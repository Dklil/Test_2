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
    public partial class Guide_Groups : Form
    {
        public Guide_Groups()
        {
            InitializeComponent();
        }

        static MySqlConnection conn = new MySqlConnection("server=chuc.caseum.ru;user=st_2_18_4;database=is_2_18_st4_VKR;password=75855345;port=33333");
        static DataTable List_prep1 = new DataTable();
        static DataTable List_prep2 = new DataTable();

        static BindingSource List_1 = new BindingSource();
        static BindingSource List_2 = new BindingSource();

        static MySqlDataAdapter Users_add_bd = new MySqlDataAdapter();
        string index_selecet_rows;
        string id_selected_rows;

        interface Otobrajenue
        {
            void Teacher_list1();
        }

        class Raspisanue : Otobrajenue
        {
            // Выбор групп из 1-го датагрида
            public void Teacher()
            {
                conn.Open();
                string sql = "SELECT * FROM Grups";
                MySqlDataAdapter abp_list_cl = new MySqlDataAdapter(sql, conn);
                List_1.DataSource = List_prep1;
                abp_list_cl.Fill(List_prep1);
                conn.Close();

            }
            // Чтение ридера для 1-го датагрида
            public void Teacher_list1()
            {
                List_prep1.Clear();
                Teacher();
                Users_add_bd.Update((DataTable)List_1.DataSource);
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.Update();
            }

            // Выбор информация из БД для 2-го датагрида
            public void Raspisanue_pred2(string zapros)
            {
                conn.Open();
                string sql = zapros;
                MySqlDataAdapter abp_list_cl = new MySqlDataAdapter(sql, conn);
                List_2.DataSource = List_prep2;
                abp_list_cl.Fill(List_prep2);
                conn.Close();
            }
            // Чтение ридера для 2-го датагрида
            public void read_list2(string zapros)
            {
                List_prep2.Clear();
                Raspisanue_pred2(zapros);
                Users_add_bd.Update((DataTable)List_2.DataSource);
                DataGridView dataGridView2 = new DataGridView();
                dataGridView2.Update();
            }

            public void dtgV2(DataGridView dataGridView2, string zapros)
            {
                Raspisanue guide_raspis = new Raspisanue();

                guide_raspis.read_list2(zapros);

                dataGridView2.DataSource = List_2;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = true;
                dataGridView2.Columns[1].ReadOnly = true;
                dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               

                // Заполняет пустую ширину датагрида
                dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
              

                // Уберает заголовки в датагриде
                dataGridView2.RowHeadersVisible = false;

               
                dataGridView2.Columns[1].HeaderText = "Количество";
                dataGridView2.Columns[2].HeaderText = "Категория";
                dataGridView2.Columns[3].HeaderText = "Преподаватель";
                dataGridView2.Columns[4].HeaderText = "Куратор";
            }


        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guide form_guide = new Guide();
            form_guide.Show();
            Hide();
        }

        private void Guide_Groups_Load(object sender, EventArgs e)
        {
            Raspisanue guide_raspis = new Raspisanue();

            guide_raspis.Teacher_list1();

            dataGridView1.DataSource = List_1;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;

            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // заполняет пустоту датагрида
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // Уберает заголовки в датагриде
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[1].HeaderText = "Наименование";

            if (Users_Role.role == "A")
            {
                functionToolStripMenuItem.Visible = false;

            }
            else if (Users_Role.role == "U")
            {
                functionToolStripMenuItem.Visible = false;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
            tea.id = Convert.ToInt32(id_selected_rows);
            Raspisanue ras = new Raspisanue();

            switch (tea.id)
            {
                case 1:
                    string a = "SELECT * FROM Grups_GA_1_22";
                    ras.dtgV2(dataGridView2, a);
                    break;
                case 2:
                    string b = "SELECT * FROM Grups_GA_2_22";
                    ras.dtgV2(dataGridView2, b);
                    break;
                case 3:
                    string c = "SELECT * FROM Grups_GB_1_22";
                    ras.dtgV2(dataGridView2, c);
                    break;
                case 4:
                    string d = "SELECT * FROM Grups_GD_1_22";
                    ras.dtgV2(dataGridView2, d);
                    break;
               
            }
        }
    }
}
