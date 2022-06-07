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
    public partial class Groups : Form
    {
        public Groups()
        {
            InitializeComponent();

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

            // Функция изменение
            void changeMenuItem_Click(object sender, EventArgs e)
            {
                index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
                lell.id = Convert.ToInt32(id_selected_rows);

                Group_Change changegrup = new Group_Change();
                changegrup.Show();
                Hide();

            }
            // Предупреждающая надпись об удалии конкретной информации
            void deleteMenuItem_Click(object sender, EventArgs e)
            {
                // Если пользоваетль вызвал контекстное меню и нажал кнопку удалить перед ним появится надпись о предупреждении в которой он выберет удалить информацию или нет
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

        static MySqlConnection conn = new MySqlConnection("server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333");
        static DataTable List_users = new DataTable();
        static BindingSource List = new BindingSource();
        static MySqlDataAdapter Users_add_bd = new MySqlDataAdapter();
        string index_selecet_rows;
        string id_selected_rows;
        Otobrajenue_grup Door = new Otobrajenue_grup();

        interface Otobraj
        {
            void read_list1();
        }

        class Otobrajenue_grup : Otobraj
        {
            public Otobrajenue_grup()
            {
                conn.Open();
                string sql = "SELECT * FROM Grups";
                MySqlDataAdapter abp_list_cl = new MySqlDataAdapter(sql, conn);
                List.DataSource = List_users;
                abp_list_cl.Fill(List_users);
                conn.Close();
            }

            public void read_list1()
            {
                List_users.Clear();
                Otobrajenue_grup otobraj_grup = new Otobrajenue_grup();
                Users_add_bd.Update((DataTable)List.DataSource);
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.Update();
            }


            // Создание уделение и удаление при выборе записей 
            public void Removal(int id)
            {
                string connStr = "server = chuc.caseum.ru; user = st_2_18_4; database = is_2_18_st4_VKR; password = 75855345; port = 33333";
                MySqlConnection conn = new MySqlConnection(connStr);
                string sql_del = "DELETE FROM Grups WHERE id=" + id.ToString();
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

        private void Groups_Load(object sender, EventArgs e)
        {
            Otobrajenue_grup ot = new Otobrajenue_grup();
            ot.read_list1();

            dataGridView1.DataSource = List;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            // Ширина изменяется так, чтобы вместить содержимое всех ячеек
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Заполняет пустую ширину датагрида
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Уберает заголовки в датагриде
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[3].HeaderText = "Категория";
            dataGridView1.Columns[4].HeaderText = "Преподаватель";
            dataGridView1.Columns[5].HeaderText = "Куратор";

           
            // Когда пользователь выбреает да или нет форма не сварачивается а остается на прждем месте
            this.TopMost = true;


        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Groups_Add dobavlenue_grup = new Groups_Add();
            dobavlenue_grup.Show();
            Hide();
        }

        private void chaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index_selecet_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selecet_rows)].Cells[0].Value.ToString();
            lell.id = Convert.ToInt32(id_selected_rows);

            Group_Change Change_Form = new Group_Change();
            Change_Form.Show();
            Hide();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule Go_back = new Schedule();
            Go_back.Show();
            Hide();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher tea_back = new Teacher();
            tea_back.Show();
            Hide();
        }
    }
}
