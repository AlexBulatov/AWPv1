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
    public partial class RedactRecordForm : Form
    {
        public int id;
        public int cardID;
        public DialogResult result = DialogResult.No;

        public RedactRecordForm(int id)
        {
            InitializeComponent();
            NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
            sCon.Open();
            this.id = id;
            string strSQL = string.Format("Select tocard from recordincard where idbase={0}", id);
            NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
            cardID = (int)myCommand.ExecuteScalar();

            strSQL = string.Format("SELECT breeder, address, phone, kindofanimal, breed, petname, dateofbirth, textdate, gender FROM clientbase WHERE id={0}", cardID);
            myCommand = new NpgsqlCommand(strSQL, sCon);
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
            myDataReader.Close();
            strSQL = string.Format("SELECT * FROM recordincard WHERE idbase={0}", id);
            myCommand = new NpgsqlCommand(strSQL, sCon);
            myDataReader = myCommand.ExecuteReader();
            while (myDataReader.Read())
            {
                DateOfVisit.Value = ((DateTime)(myDataReader["dateofvisit"]));
                Anamnesis.Text = myDataReader["anamnesis"].ToString().Trim();
                Clinic.Text = myDataReader["assignment"].ToString().Trim();
                Epicrisis.Text = myDataReader["epicrisis"].ToString().Trim();
                PayBox.Text = myDataReader["payment"].ToString().Trim();
            }

            sCon.Close();
        }

        private void EnterRecord_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes==MessageBox.Show("Вы действительно хотите отредактировать эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
                string strSQL = string.Format("UPDATE recordincard SET dateofvisit=@DateOfVisit, payment=@Pay, anamnesis=@Anamnesis, assignment=@Clinic, epicrisis=@Epicrisis WHERE idbase={0}", id);
                NpgsqlCommand cmd = new NpgsqlCommand(strSQL, sCon);
                sCon.Open();
                cmd.Parameters.Add("@Pay", NpgsqlTypes.NpgsqlDbType.Integer).Value = Int32.Parse(this.PayBox.Text);
                cmd.Parameters.Add("@DateOfVisit", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = this.DateOfVisit.Value;
                cmd.Parameters.Add("@Anamnesis", NpgsqlTypes.NpgsqlDbType.Text).Value = this.Anamnesis.Text;
                cmd.Parameters.Add("@Clinic", NpgsqlTypes.NpgsqlDbType.Text).Value = this.Clinic.Text;
                cmd.Parameters.Add("@Epicrisis", NpgsqlTypes.NpgsqlDbType.Text).Value = this.Epicrisis.Text;
                cmd.ExecuteNonQuery();

                result = DialogResult.Yes;
                sCon.Close();
                Close();
            }
        }

        private void RecordCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
