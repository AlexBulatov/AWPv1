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
    public partial class RedactVisit : Form
    {
        public int visID;

        public DialogResult result = DialogResult.No;
        public RedactVisit(int id)
        {
            visID = id;
            InitializeComponent();

            NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1");
            string sql = string.Format("SELECT day, timeof, fio, idnum, event, payment FROM calendar WHERE id = {0};", id);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, sCon);
            sCon.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dateTimePicker1.Value = (DateTime)dr["day"];
                FioBox.Text = dr["fio"].ToString().Trim();
                idBox.Text = dr["idnum"].ToString().Trim();
                eventBox.Text = dr["event"].ToString().Trim();
                PayBox.Text = dr["payment"].ToString().Trim();
                string toDateTime = dr["timeof"].ToString().Trim();
                dateTimePicker2.Value = Convert.ToDateTime(toDateTime);
            }
            sCon.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы действительно хотите отредактировать эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
                string strSQL = string.Format("UPDATE calendar SET day=@Day, timeof=@Time, fio=@FIO, idnum=@IDNum, event=@Event, payment=@Pay WHERE id={0}", visID);
                NpgsqlCommand cmd = new NpgsqlCommand(strSQL, sCon);

                sCon.Open();
                cmd.Parameters.Add("@Day", NpgsqlTypes.NpgsqlDbType.Date).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("@Time", NpgsqlTypes.NpgsqlDbType.Time).Value = dateTimePicker2.Value.ToLongTimeString();
                cmd.Parameters.Add("@FIO", NpgsqlTypes.NpgsqlDbType.Varchar).Value = FioBox.Text;
                cmd.Parameters.Add("@IDNum", NpgsqlTypes.NpgsqlDbType.Varchar).Value = idBox.Text;
                cmd.Parameters.Add("@Event", NpgsqlTypes.NpgsqlDbType.Varchar).Value = eventBox.Text;
                cmd.Parameters.Add("@Pay", NpgsqlTypes.NpgsqlDbType.Integer).Value = Int32.Parse(PayBox.Text);
                cmd.ExecuteNonQuery();

                result = DialogResult.Yes;
                sCon.Close();
                Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
