using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class FilterForm : Form
    {
        public string FilterCommandString = null; 

        public FilterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BreederText.Text != "") BreederText.Text="%"+BreederText.Text+"%";
            int id=0;
            Int32.TryParse(idText.Text, out id);
            if (PetName.Text != "") PetName.Text = "%" + PetName.Text + "%";
            if (PhoneText.Text != "") PhoneText.Text = "%" + PhoneText.Text + "%";
            FilterCommandString = string.Format("SELECT * FROM clientbase WHERE id={0} OR breeder ILIKE '{1}' OR petname ILIKE '{2}' OR phone ILIKE '{3}';", id, BreederText.Text, PetName.Text, PhoneText.Text);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilterCommandString = string.Format("SELECT * FROM clientbase;");
            Close();
        }
    }
}
