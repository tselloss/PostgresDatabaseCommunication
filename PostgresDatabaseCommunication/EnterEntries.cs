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
    public partial class Entries : Form
    {
        public Entries()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Name.Text = "";
            Phone.Text = "";
            Address.Text = "";
            PostalCode.Text = "";
            AFM.Text = "";
            Surname.Text = "";
            AMKA.Text = "";
            Birth.Text = "";
            Email.Text = "";
            SocialNet.Text = "";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Database=postgres;Username=postgres;Password=!@#qweASD;Persist Security Info=True");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "INSERT INTO public.entries_data(entry_name, surname_, birth, afm, amka, address_, phone_, postal_code, email_, social_networks) VALUES ('" + Name.Text + "','" + Surname.Text + "','" + Birth.Text + "','" + AFM.Text + "','" + AMKA.Text + "','" + Address.Text + "','" + Phone.Text + "','" + PostalCode.Text + "','" + Email.Text + "','" + SocialNet.Text + "')";
            NpgsqlDataReader dr = comm.ExecuteReader();
            MessageBox.Show($"Added Successfully");
            comm.Dispose();
            conn.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string message = "Do you want to Update the user with AFM='" + AFM.Text + "'";
            string BoxTitle = "Delete User";
            MessageBoxButtons MessageBoxWithButs = new MessageBoxButtons();
            DialogResult result = MessageBox.Show(message, BoxTitle, MessageBoxWithButs);
            if (result == DialogResult.Yes)
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Database=postgres;Username=postgres;Password=!@#qweASD;Persist Security Info=True");
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "UPDATE public.entries_data SET (entry_name='" + Name.Text + "',  surname_='" + Surname.Text + "', birth='" + Birth.Text + "', afm='" + AFM.Text + "', amka='" + AMKA.Text + "', address_='" + Address.Text + "', phone_='" + Phone.Text + "', postal_code='" + PostalCode.Text + "', email_='" + Email.Text + "', social_networks='" + SocialNet.Text + "') WHERE afm='" + AFM.Text + "'";
                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show($"Successfully Update");
                comm.Dispose();
                conn.Close();
            }
            else
            {
                return;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string message = "Do you want to Update the user with AFM='" + AFM.Text + "'";
            string BoxTitle = "Delete User";
            MessageBoxButtons MessageBoxWithButs = new MessageBoxButtons();
            DialogResult result = MessageBox.Show(message, BoxTitle, MessageBoxWithButs);
            if (result == DialogResult.Yes)
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Database=postgres;Username=postgres;Password=!@#qweASD;Persist Security Info=True");
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "DELETE FROM public.entries_data (entry_name='" + Name.Text + "',  surname_='" + Surname.Text + "', birth='" + Birth.Text + "', afm='" + AFM.Text + "', amka='" + AMKA.Text + "', address_='" + Address.Text + "', phone_='" + Phone.Text + "', postal_code='" + PostalCode.Text + "', email_='" + Email.Text + "', social_networks='" + SocialNet.Text + "') WHERE afm='" + AFM.Text + "'";
                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show($"Successfully Delete");
                comm.Dispose();
                conn.Close();
            }
            else
            {
                return;
            }

        }
    }
}
