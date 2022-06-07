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
    public partial class Schedule_by_teachers : Form
    {
        public Schedule_by_teachers()
        {
            InitializeComponent();
        }


        static MySqlConnection conn = new MySqlConnection("server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333");
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
            // Выбор преподавателей из 1-го датагрида
            public void Teacher()
            {
                conn.Open();
                string sql = "SELECT * FROM Teachers";
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
                dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Заполняет пустую ширину датагрида
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Уберает заголовки в датагриде
                dataGridView2.RowHeadersVisible = false;

                dataGridView2.Columns[1].HeaderText = "Число";
                dataGridView2.Columns[2].HeaderText = "День";
                dataGridView2.Columns[3].HeaderText = "Время";
                dataGridView2.Columns[4].HeaderText = "Группа";
                dataGridView2.Columns[5].HeaderText = "Кабинет";
            }
            

        }

        // Форма загрузки (информация загружается когда появляется форма)
        private void Guide_Curators_Load(object sender, EventArgs e)
        {
            Raspisanue guide_raspis = new Raspisanue();

            guide_raspis.Teacher_list1();
           
            dataGridView1.DataSource = List_1;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
           

            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           

            // Заполняет пустую ширину датагрида
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Уберает заголовки в датагриде
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[1].HeaderText = "ФИО";

            
            if (Users_Role.role == "U")
            {
                functionToolStripMenuItem.Visible = false;
            }

        }

        // нажимаю запись отображается инфа об этой записи во 2-м гриде
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule back_schedule = new Schedule();
            back_schedule.Show();
            Hide();
        }


        // Переход на форму с добавлением расписания на неделю для преподавателя
        private void ivanovaMauiNikitignaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Weekly_schedule_Ivanova_Maui_Nikitigna weekly_maui = new Add_Weekly_schedule_Ivanova_Maui_Nikitigna();
            weekly_maui.Show();
            Hide();
        }
        // Переход на форму с добавлением расписания на неделю для преподавателя
        private void sumonovaElizovetaPetrovnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Weekly_schedule_Sumonova_Elizoveta_Petrovna weekly_elizovate = new Add_Weekly_schedule_Sumonova_Elizoveta_Petrovna();
            weekly_elizovate.Show();
            Hide();
        }
        // Переход на форму с добавлением расписания на неделю для преподавателя
        private void tutovaVeraCavelievnaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Переход на форму с добавлением расписания на неделю для преподавателя
        private void ivanovaKsenuiAdamovnaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Переход на форму с добавлением расписания на неделю для преподавателя
        private void sudorovKurullMaksumovugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
            tea.id = Convert.ToInt32(id_selected_rows);
            Raspisanue ras = new Raspisanue();

            switch(tea.id)
            {
                case 1:
                    string a = "SELECT * FROM Teacher_Ivanova_Maui_Nikitigna";
                    ras.dtgV2(dataGridView2, a);
                    break;
                case 2:
                    string b = "SELECT * FROM Teacher_Sumonova_Elizoveta_Petrovna";
                    ras.dtgV2(dataGridView2, b);
                    break;
                case 3:
                    string c = "SELECT * FROM Teacher_Tutova_Vera_Cavelievna";
                    ras.dtgV2(dataGridView2, c);
                    break;
                case 4:
                    string d = "SELECT * FROM Teacher_Ivanova_Ksenui_Adamovna";
                    ras.dtgV2(dataGridView2, d);
                    break;
                case 5:
                    string zapros = "SELECT * FROM Teacher_Sudorov_Kurull_Maksumovug";
                    ras.dtgV2(dataGridView2, zapros);
                    break;
            }
        }

        private void functionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
