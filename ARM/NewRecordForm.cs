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
    public partial class NewRecordForm : Form
    {
        public int id;
        public NewRecordForm(int id)
        {
            InitializeComponent();
            NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
            sCon.Open();
            this.id = id;
            string strSQL = string.Format("SELECT breeder, address, phone, kindofanimal, breed, petname, dateofbirth, textdate, gender FROM clientbase WHERE id={0}", id);
            NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataReader myDataReader = myCommand.ExecuteReader();
            while (myDataReader.Read())
            {
                Breeder.Text = myDataReader["breeder"].ToString().Trim();
                Adress.Text = myDataReader["address"].ToString().Trim();
                Phone.Text = myDataReader["phone"].ToString().Trim();
                KindOfAnimal.Text = myDataReader["kindofanimal"].ToString().Trim();
                Breed.Text = myDataReader["breed"].ToString().Trim();
                PetName.Text = myDataReader["petname"].ToString().Trim();
                DateTime birth = ((DateTime)(myDataReader["dateofbirth"]));
                if (birth == new DateTime(1812, 1, 1)) Birth.Visible = false;
                else Birth.Text = birth.ToLongDateString();
                Age.Text = myDataReader["textdate"].ToString().Trim();
                IsMale.Text = myDataReader["gender"].ToString().Trim();
            }
            sCon.Close();
        }
        
        private void EnterRecord_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sCon = new NpgsqlConnection();
            sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;";
            sCon.Open();
            string sql = "INSERT INTO recordincard (tocard, dateofvisit, anamnesis, assignment, epicrisis, payment) " +
                         "VALUES(@ToCard, @DateOfVisit, @Anamnesis, @Clinic, @Epicrisis, @Pay);";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, sCon);

            cmd.Parameters.Add("@ToCard", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
            cmd.Parameters.Add("@Pay", NpgsqlTypes.NpgsqlDbType.Integer).Value = Int32.Parse(this.PayBox.Text);
            cmd.Parameters.Add("@DateOfVisit", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = this.DateOfVisit.Value;
            cmd.Parameters.Add("@Anamnesis", NpgsqlTypes.NpgsqlDbType.Text).Value = this.Anamnesis.Text;
            cmd.Parameters.Add("@Clinic", NpgsqlTypes.NpgsqlDbType.Text).Value = this.Clinic.Text;
            cmd.Parameters.Add("@Epicrisis", NpgsqlTypes.NpgsqlDbType.Text).Value = this.Epicrisis.Text;
            cmd.ExecuteNonQuery();

            string seridsql = "Select MAX(idbase) from recordincard;";
            NpgsqlCommand cmdid = new NpgsqlCommand(seridsql, sCon);
            NpgsqlDataReader myDataReader = cmdid.ExecuteReader();
            int recid = 0;
            while (myDataReader.Read()) {recid = (int)myDataReader["MAX"]; }
            myDataReader.Close();

            string sql2= string.Format("UPDATE clientbase SET numofrecords=numofrecords+1, records=array_append(records, {0}) WHERE id={1}", recid, id);
            NpgsqlCommand cmdtocard= new NpgsqlCommand(sql2,sCon);
            cmdtocard.ExecuteNonQuery();
            sCon.Close();
            Close();
        }

        private void RecordCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
