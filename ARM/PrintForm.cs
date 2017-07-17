using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word=Microsoft.Office.Interop.Word;
using Npgsql;

namespace ARM
{
    public partial class PrintForm : Form
    {
        public int id = 0;

        public PrintForm(int id)
        {
            this.id = id;
            InitializeComponent();
            NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
            sCon.Open();
            string strSQL = string.Format("SELECT * FROM recordincard WHERE idbase={0}", id);
            NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataReader myDataReader = myCommand.ExecuteReader();
            int card = 0;
            while (myDataReader.Read())
            {
                DateOfVisit.Text = ((DateTime)(myDataReader["dateofvisit"])).ToLongDateString();
                Assignment.Text = myDataReader["assignment"].ToString();
                Clinic.Text = myDataReader["anamnesis"].ToString();
                Diagnosis.Text = myDataReader["epicrisis"].ToString();
                card = (int)myDataReader["tocard"];
            }
            myDataReader.Close();
            strSQL = string.Format("SELECT * FROM clientbase WHERE id={0}", card);
            myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataReader myDataReader2 = myCommand.ExecuteReader();
            while (myDataReader2.Read())
            {
                Breeder.Text = myDataReader2["breeder"].ToString();
                TypeAnimal.Text = myDataReader2["kindofanimal"].ToString();
                Breed.Text = myDataReader2["breed"].ToString();
                PetName.Text = myDataReader2["petname"].ToString();
                DateTime birth = ((DateTime)(myDataReader2["dateofbirth"]));
                if (birth == new DateTime(1812, 1, 1)) DateOfBirth.Text = "Неизвестно";
                else DateOfBirth.Text = birth.ToLongDateString();
                IsMale.Text = myDataReader2["gender"].ToString();
            }
            sCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Word.Application word = new Word.Application();
            word.Visible = true;
            Word.Document doc = null;

            object fileName = "c:\\Resources\\Shablon.doc";
            object falseValue = false;
            object trueValue = true;
            object missing = Type.Missing;

            object findText = "<Что меняем>";
            object replaceWith = "<На что меняем>";
            object replace = Word.WdReplace.wdReplaceAll;

            doc = word.Documents.Open(ref fileName, ref missing, ref trueValue,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);

            string[] searches = { "Number", "Owner", "KindOfAnimal", "Breed", "Gender", "Name", "DateOfBirth", "DateOfVisit", "InClinic", "Diagnosis", "Assignment", "Doctor" };
            string[] datas = {id.ToString(), Breeder.Text, TypeAnimal.Text, Breed.Text, IsMale.Text, PetName.Text, DateOfBirth.Text, DateOfVisit.Text, Clinic.Text, Diagnosis.Text, Assignment.Text, Doctor.Text};

            for (int i = 0; i < datas.Length; i++)
            {
                replaceWith = datas[i];
                findText = "<" + searches[i] + ">";

                word.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith, ref replace, ref missing, ref missing, ref missing, ref missing);
            }

            object fileNew = string.Format(@"c:\Resources\print{0}.doc", id);
            doc.SaveAs2(ref fileNew, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);

            object copies = "1";
            object pages = "";
            object range = Word.WdPrintOutRange.wdPrintAllDocument;
            object items = Word.WdPrintOutItem.wdPrintDocumentContent;
            object pageType = Word.WdPrintOutPages.wdPrintAllPages;
            object oTrue = true;
            object oFalse = false;

            doc.PrintOut(ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
                            ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue, 
                            ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);

            word.Visible = true;
            Close();
        }
    }
}
