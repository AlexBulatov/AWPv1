using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace ARM
{
    public partial class NewVisit : Form
    {
        public NewVisit()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            NpgsqlConnection scon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1");
            string sql = "INSERT INTO calendar (day, timeof, fio, idnum, event, payment) " +
                                        "VALUES(@Day, @Time, @FIO, @IDNum, @Event, @Pay);";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, scon);
            scon.Open();
            cmd.Parameters.Add("@Day", NpgsqlTypes.NpgsqlDbType.Date).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("@Time", NpgsqlTypes.NpgsqlDbType.Time).Value = dateTimePicker2.Value.ToLongTimeString();
            cmd.Parameters.Add("@FIO", NpgsqlTypes.NpgsqlDbType.Varchar).Value = FioBox.Text;
            cmd.Parameters.Add("@IDNum", NpgsqlTypes.NpgsqlDbType.Varchar).Value = idBox.Text;
            cmd.Parameters.Add("@Event", NpgsqlTypes.NpgsqlDbType.Varchar).Value = eventBox.Text;
            cmd.Parameters.Add("@Pay", NpgsqlTypes.NpgsqlDbType.Integer).Value = Int32.Parse(PayBox.Text);

            cmd.ExecuteNonQuery();
            scon.Close();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
