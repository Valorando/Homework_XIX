using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_07_09
{
    public partial class Form1 : Form
    {
        private I_Provider_Factory_Wrapper wrapper;
        public Form1()
        {
            
            InitializeComponent();
            dataGridView1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        private string server_name;
        private string database_name;
        private string table_name;
        private string path;
        private string version;

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            label4.Visible = false;

            label1.Visible = true;
            label1.Text = "Введите имя сервера:";

            label2.Visible = true;
            label2.Text = "Введите имя базы данных:";

            label3.Visible = true;
            label3.Text = "Введите имя таблицы:";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;

            button1.Visible = true;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            label4.Visible = false;

            label1.Visible = true;
            label1.Text = "Введите путь к базе данных:";

            label2.Visible = true;
            label2.Text = "Введите имя таблицы:";

            label3.Visible = true;
            label3.Text = "Введите версию СУБД:";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;

            button2.Visible = true;
        }

        private void Load_Data()
        {
            try
            {
                using (var connection = wrapper.CreateConnection())
                {
                    connection.Open();

                    var query = $"SELECT * FROM {table_name}";
                    var command = connection.CreateCommand();
                    command.CommandText = query;

                    var dataTable = new DataTable();
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server_name = textBox1.Text;
            database_name = textBox2.Text;
            table_name = textBox3.Text;

            wrapper = new SSMS_Factory_Wrapper
            {
                Connection_string = $@"Data Source = {server_name}; Initial Catalog = {database_name}; Trusted_Connection=True; TrustServerCertificate = True"
            };

            Load_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            table_name = textBox2.Text;
            version = textBox3.Text;

            wrapper = new SQLite_Factory_Wrapper
            {
                Connection_string = $@"Data Source ={path};Version={version}"
            };

            Load_Data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
