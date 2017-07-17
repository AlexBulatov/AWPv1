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
    public partial class ShowCard : Form
    {
        public ShowCard(int id)
        {
            this.Text = "Карта № " + id;
            InitializeComponent();
            NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
            sCon.Open();
            var strSQL = string.Format("SELECT * FROM clientbase WHERE id={0}", id);
            NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataReader myDataReader2 = myCommand.ExecuteReader();
            int[] ArrToFound = new int[1];
            while (myDataReader2.Read())
            {
                BreederLabel.Text = myDataReader2["breeder"].ToString().Trim();
                AddressLabel.Text = myDataReader2["address"].ToString().Trim();
                NumLabel.Text = myDataReader2["phone"].ToString().Trim();
                KindOfAnimal.Text = myDataReader2["kindofanimal"].ToString().Trim();
                Breed.Text = myDataReader2["breed"].ToString().Trim();
                PetName.Text = myDataReader2["petname"].ToString().Trim();
                DateTime birth = ((DateTime)(myDataReader2["dateofbirth"]));
                if (birth == new DateTime(1812, 1, 1)) Birth.Visible = false;
                else Birth.Text = birth.ToLongDateString();
                Age.Text = myDataReader2["textdate"].ToString().Trim();
                IsMale.Text = myDataReader2["gender"].ToString().Trim();
                if((int)myDataReader2["numofrecords"]!=0)   ArrToFound = (int[])myDataReader2["records"];
                sCon.Close();
            }
            
            string ForSearch = "";
            if (ArrToFound.Length == 0) return;
            for (int i=0; i<ArrToFound.Length; i++)
            {
                if(i!=ArrToFound.Length-1)
                ForSearch += ArrToFound[i] + ", ";
                else ForSearch += ArrToFound[i];
            }
            
            strSQL = string.Format("SELECT * FROM recordincard WHERE idbase IN ({0});", ForSearch);
            myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataAdapter da= new NpgsqlDataAdapter(strSQL, sCon);
            System.Data.Common.DataTableMapping BaseMap = da.TableMappings.Add("recordincard", "Амбулаторные записи");
            BaseMap.ColumnMappings.Add("idbase", "Номер записи");
            BaseMap.ColumnMappings.Add("tocard", "К карте");
            BaseMap.ColumnMappings.Add("anamnesis", "Анамнез");
            BaseMap.ColumnMappings.Add("assignment", "Назначение");
            BaseMap.ColumnMappings.Add("epicrisis", "Эпикриз");
            BaseMap.ColumnMappings.Add("payment", "Оплата");
            BaseMap.ColumnMappings.Add("dateofvisit", "Дата приема");
            DataSet ds2 = new DataSet();
            da.Fill(ds2, "recordincard");
            BaseGrid.DataSource = ds2.Tables["Амбулаторные записи"].DefaultView;
            foreach (DataGridViewColumn column in BaseGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ShowBut_Click(object sender, EventArgs e)
        {
            if (this.BaseGrid.SelectedRows.Count > 0 &&
               this.BaseGrid.SelectedRows[0].Index !=
               this.BaseGrid.Rows.Count - 1)
            {
                int a = (int)BaseGrid.SelectedRows[0].Cells[0].Value;
                ShowRecord frm = new ShowRecord(a);
                frm.Show();
            }
        }
    }
}
