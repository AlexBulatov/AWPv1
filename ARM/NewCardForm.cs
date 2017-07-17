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
    public partial class NewCardForm : Form
    {
        public NewCardForm()
        {
            InitializeComponent();
        }

        public bool isMaleBool = true;

        private void IsMale_CheckedChanged(object sender, EventArgs e)
        {
            isMaleBool = true;
        }

        private void IsFemale_CheckedChanged(object sender, EventArgs e)
        {
            isMaleBool = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            DateTime selected = dateTimePicker2.Value;
            TimeSpan diff = Now - selected;
            AgeBox.Text = (diff.Days / 365) + " лет " + ((diff.Days / 30) % 12) + " мес. " + (diff.Days % 30) + " дней";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sCon = new NpgsqlConnection();
            sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;";
            sCon.Open();
            string sql = "INSERT INTO clientbase (breeder, address, phone, kindofanimal, breed, petname, dateofbirth, textdate, gender, dateoffirst, numofrecords) " +
                         "VALUES(@Breeder, @Address, @Phone, @kindofanimal, @Breed, @Name, @DateOfBirth, @TextDate, @IsMale, @First, @Num);";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, sCon);

            cmd.Parameters.Add("@Breeder", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.BreedName.Text;
            cmd.Parameters.Add("@Address", NpgsqlTypes.NpgsqlDbType.Varchar).Value = String.Format("{0}, улица {1}, дом {2}, квартира {3}", this.City.Text, this.Street.Text, this.Home.Text, this.Room.Text);
            cmd.Parameters.Add("@Phone", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.Telephone.Text;
            cmd.Parameters.Add("@kindofanimal", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.TypeAnimal.Text;
            cmd.Parameters.Add("@Breed", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.Breed.Text;
            cmd.Parameters.Add("@Name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.NamePet.Text;
            cmd.Parameters.Add("@DateOfBirth", NpgsqlTypes.NpgsqlDbType.Date).Value = DontHaveBD.Checked ? new DateTime(1812, 1, 1): this.dateTimePicker2.Value;
            cmd.Parameters.Add("@TextDate", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.AgeBox.Text;
            cmd.Parameters.Add("@IsMale", NpgsqlTypes.NpgsqlDbType.Varchar).Value = this.isMaleBool ? "Мужская" : "Женская";
            cmd.Parameters.Add("@First", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = DateTime.Now;
            cmd.Parameters.Add("@Num", NpgsqlTypes.NpgsqlDbType.Integer).Value = 0;
            cmd.ExecuteNonQuery();

            sCon.Close();
            Close();
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
