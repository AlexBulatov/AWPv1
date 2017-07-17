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
    public partial class RedactCardForm : Form
    {
        public int cardID;

        bool isMaleBool = true;

        public DialogResult result=DialogResult.No;

        public RedactCardForm(int id)
        {
            InitializeComponent();
            cardID = id;

            NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
            sCon.Open();
            var strSQL = string.Format("SELECT * FROM clientbase WHERE id={0}", id);
            NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataReader myDataReader2 = myCommand.ExecuteReader();
            while (myDataReader2.Read())
            {
                BreedName.Text = myDataReader2["breeder"].ToString().Trim();
                Address.Text = myDataReader2["address"].ToString().Trim();
                Telephone.Text = myDataReader2["phone"].ToString().Trim();
                TypeAnimal.Text = myDataReader2["kindofanimal"].ToString().Trim();
                Breed.Text = myDataReader2["breed"].ToString().Trim();
                NamePet.Text = myDataReader2["petname"].ToString().Trim();
                dateTimePicker2.Value = ((DateTime)(myDataReader2["dateofbirth"]));
                AgeBox.Text = myDataReader2["textdate"].ToString().Trim();
                string Male = myDataReader2["gender"].ToString().Trim();
                if (Male == "Мужская") { IsMale.Checked = true; IsFemale.Checked = false; isMaleBool = true; }
                else { IsFemale.Checked = true; IsMale.Checked = false; isMaleBool = false; }
            }
            if (dateTimePicker2.Value == new DateTime(1812, 1, 1)) DontHaveBD.Checked = true;
            sCon.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы действительно хотите отредактировать эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
                sCon.Open();
                var strSQL = string.Format("UPDATE clientbase SET breeder=@Breeder, address=@Address, phone=@Phone, kindofanimal=@kindofanimal, breed=@Breed, petname=@Name, dateofbirth=@DateOfBirth, textdate=@TextDate, gender=@IsMale WHERE id={0};", cardID);

                NpgsqlCommand cmd = new NpgsqlCommand(strSQL, sCon);
                cmd.Parameters.Add("@Breeder", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.BreedName.Text;
                cmd.Parameters.Add("@Address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.Address.Text;
                cmd.Parameters.Add("@Phone", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.Telephone.Text;
                cmd.Parameters.Add("@kindofanimal", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.TypeAnimal.Text;
                cmd.Parameters.Add("@Breed", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.Breed.Text;
                cmd.Parameters.Add("@Name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.NamePet.Text;
                cmd.Parameters.Add("@DateOfBirth", NpgsqlTypes.NpgsqlDbType.Date).Value = DontHaveBD.Checked ? new DateTime(1, 1, 1) : this.dateTimePicker2.Value;
                cmd.Parameters.Add("@TextDate", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.AgeBox.Text;
                cmd.Parameters.Add("@IsMale", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.isMaleBool ? "Мужская" : "Женская";
                cmd.Parameters.Add("@First", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = DateTime.Now;
                cmd.ExecuteNonQuery();

                DialogResult = DialogResult.Yes;
                sCon.Close();
                Close();
            }
        }

        private void IsMale_CheckedChanged(object sender, EventArgs e)
        {
            isMaleBool = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            DateTime selected = dateTimePicker2.Value;
            TimeSpan diff = Now - selected;
            AgeBox.Text = (diff.Days / 365) + " лет " + ((diff.Days / 30) % 12) + " мес. " + (diff.Days % 30) + " дней";
        }

        private void IsFemale_CheckedChanged(object sender, EventArgs e)
        {
            isMaleBool = false;
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
