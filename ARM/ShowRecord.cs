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
    public partial class ShowRecord : Form
    {
        public int idRec;
        public ShowRecord(int id)
        {
            InitializeComponent();
            idRec = id;
            this.Text = "Запись №" + id;
            NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
            sCon.Open();
            string strSQL = string.Format("SELECT * FROM recordincard WHERE idbase={0}", id);
            NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataReader myDataReader = myCommand.ExecuteReader();
            int card=0;
            while (myDataReader.Read())
            {
                Visit.Text = ((DateTime)(myDataReader["dateofvisit"])).ToLongDateString();
                Anamnesis.Text = myDataReader["anamnesis"].ToString().Trim();
                Clinic.Text = myDataReader["assignment"].ToString().Trim();
                Epicrisis.Text = myDataReader["epicrisis"].ToString().Trim();
                PayBox.Text = myDataReader["payment"].ToString().Trim();
                card = (int)myDataReader["tocard"];
            }
            myDataReader.Close();
            strSQL = string.Format("SELECT * FROM clientbase WHERE id={0}", card);
            myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataReader myDataReader2 = myCommand.ExecuteReader();
            while (myDataReader2.Read())
            {
                Breeder.Text = myDataReader2["breeder"].ToString().Trim();
                Adress.Text = myDataReader2["address"].ToString().Trim();
                Phone.Text = myDataReader2["phone"].ToString().Trim();
                KindOfAnimal.Text = myDataReader2["kindofanimal"].ToString().Trim();
                Breed.Text = myDataReader2["breed"].ToString().Trim();
                PetName.Text = myDataReader2["petname"].ToString().Trim();
                DateTime birth = ((DateTime)(myDataReader2["dateofbirth"]));
                if (birth == new DateTime(1812, 1, 1)) Birth.Visible = false;
                else Birth.Text = birth.ToLongDateString();
                Age.Text = myDataReader2["textdate"].ToString().Trim();
                IsMale.Text = myDataReader2["gender"].ToString().Trim();
                sCon.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите распечатать эту запись?", "Внимание!", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                PrintForm frm = new PrintForm(idRec);
                frm.ShowDialog();
            }
        }
    }
}
