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
    public partial class Curators : Form
    {
        public Curators()
        {
            InitializeComponent();
            if (Users_Role.role == "A")
            {
                //Создание контекстного меню
                ToolStripMenuItem changeMenuItem = new ToolStripMenuItem("Изменить");
                ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Удалить");

                // добавляем элементы в меню
                contextMenuStrip1.Items.AddRange(new[] { changeMenuItem, deleteMenuItem });
                // ассоциируем контекстное меню с текстовым полем
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
                // устанавливаем обработчики событий для меню
                changeMenuItem.Click += changeMenuItem_Click;
                deleteMenuItem.Click += deleteMenuItem_Click;

                // Контекстное меню: Изменение
                void changeMenuItem_Click(object sender, EventArgs e)
                {
                    index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                    id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
                    lell.id = Convert.ToInt32(id_selected_rows);

                    Curators_Change form_change = new Curators_Change();
                    form_change.Show();
                    Hide();

                }
                // Контекстное меню: Удаление 
                void deleteMenuItem_Click(object sender, EventArgs e)
                {
                    // Предупреждающая надпись о удалении
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данную информацию?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    // Если пользователь нажал в контекстном меню удалить появляется предупреждающие окно которое спрашивает уверен ли пользователь что хочут удалить информацию 
                    if (result == DialogResult.Yes)
                    {
                        index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                        id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
                        Door.Removal(Convert.ToInt32(id_selected_rows));
                        conn.Close();
                        Door.read_list1();
                    }
                }
            }
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
                string sql = "SELECT * FROM Curators";
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
                string sql_del = "DELETE FROM Curators WHERE id=" + id.ToString();
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

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule f1 = new Schedule();
            f1.Show();
            Hide();
        }

        // Форма добавление куратора
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Curators_Add form_add = new Curators_Add();
            form_add.Show();
            Hide();
        }

        // Форма изменение куратора
        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
            lell.id = Convert.ToInt32(id_selected_rows);

            Curators_Change form_change = new Curators_Change();
            form_change.Show();
            Hide();


        }
        // Удаление куратора на кнопку 
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
            Door.Removal(Convert.ToInt32(id_selected_rows));
            conn.Close();
            Door.read_list1();
        }

        private void Curators_Load(object sender, EventArgs e)
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
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Заполняет пустую ширину датагрида
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Уберает заголовки в датагриде
            dataGridView1.RowHeadersVisible = false;
            // Делает надписи из БД на русском
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[2].HeaderText = "Группа";
            dataGridView1.Columns[3].HeaderText = "Кабинет";
            dataGridView1.Columns[4].HeaderText = "Адрес";
            dataGridView1.Columns[5].HeaderText = "Телефон";
            dataGridView1.Columns[6].HeaderText = "Почта";

            
            // Когда пользователь выбреает да или нет форма не сварачивается а остается на прждем месте
            this.TopMost = true;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transition_from_staff back = new Transition_from_staff();
            back.Show();
            Hide();
        }
    }
}
