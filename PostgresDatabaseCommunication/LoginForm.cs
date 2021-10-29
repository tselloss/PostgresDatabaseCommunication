using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgresDatabaseCommunication
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

     
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Database=postgres;Username=postgres;Password=!@#qweASD;Persist Security Info=True");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "INSERT INTO public.LoginValues(username_, pass_) VALUES ('" + UserText.Text + "','" + PassText.Text + "')";
            NpgsqlDataReader dr = comm.ExecuteReader();
            MessageBox.Show($"Added Successfully");
            comm.Dispose();
            conn.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Database=postgres;Username=postgres;Password=!@#qweASD;Persist Security Info=True");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM LoginValues WHERE username_ = @'"+UserText.Text +"'";
            NpgsqlCommand comm1 = new NpgsqlCommand();
            comm1.CommandText= "SELECT * FROM LoginValues WHERE username_ = @'" + PassText.Text + "'";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (UserText.Text == comm.CommandText && PassText.Text == comm1.CommandText )
             {
                MessageBox.Show($"Login Successful");
                EnterEntries Entries = new EnterEntries();
                Entries.Show();
             }
            comm.Dispose();
            conn.Close();
        }
    }
}
