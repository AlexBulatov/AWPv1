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
    public partial class DiaryAll : Form
    {
        public DiaryAll()
        {
            NpgsqlConnection sCon = new NpgsqlConnection();
            sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1";
            InitializeComponent();
            var strSQL = "SELECT id, day, timeof, fio, idnum, event, payment FROM calendar WHERE day>=current_date;";
            NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, sCon.ConnectionString);
            System.Data.Common.DataTableMapping shedMap = da.TableMappings.Add("calendar", "Расписание процедур");
            shedMap.ColumnMappings.Add("id", "Номер приема");
            shedMap.ColumnMappings.Add("day", "Дата");
            shedMap.ColumnMappings.Add("timeof", "Время");
            shedMap.ColumnMappings.Add("fio", "ФИО");
            shedMap.ColumnMappings.Add("idnum", "Номер амбулаторной карты");
            shedMap.ColumnMappings.Add("event", "Процедура");
            shedMap.ColumnMappings.Add("payment", "Предварительная оплата");
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "calendar");
            SheduleGrid.DataSource = ds1.Tables["Расписание процедур"].DefaultView;
            foreach (DataGridViewColumn column in SheduleGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            NewVisit frm = new NewVisit();
            frm.ShowDialog();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            string ConnectionString = "Server=localhost;Port=5432;Username=postgres;Password=1;Database=postgres;";
            string strSQL = "SELECT id, day, timeof, fio, idnum, event, payment FROM calendar WHERE day>=current_date;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, ConnectionString);
            DataSet ds = new DataSet();
            System.Data.Common.DataTableMapping shedMap = da.TableMappings.Add("calendar", "Амбулаторные записи");
            shedMap.ColumnMappings.Add("id", "Номер приема");
            shedMap.ColumnMappings.Add("day", "Дата");
            shedMap.ColumnMappings.Add("timeof", "Время");
            shedMap.ColumnMappings.Add("fio", "ФИО");
            shedMap.ColumnMappings.Add("idnum", "Номер амбулаторной карты");
            shedMap.ColumnMappings.Add("event", "Процедура");
            shedMap.ColumnMappings.Add("payment", "Предварительная оплата");
            da.Fill(ds, "calendar");
            SheduleGrid.DataSource = ds.Tables["Амбулаторные записи"].DefaultView;
            foreach (DataGridViewColumn column in SheduleGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void SheduleGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (this.SheduleGrid.SelectedRows.Count > 0 &&
               this.SheduleGrid.SelectedRows[0].Index !=
               this.SheduleGrid.Rows.Count - 1)
            {
                int a = (int)SheduleGrid.SelectedRows[0].Cells[0].Value;
                NpgsqlConnection sCon = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;Password=1;Username=postgres;");
                string strSQL = string.Format("SELECT day, timeof, fio, idnum, event, payment FROM calendar WHERE id={0}", a);
                sCon.Open();
                NpgsqlDataReader dr = new NpgsqlCommand(strSQL, sCon).ExecuteReader();
                while (dr.Read())
                {
                    DataLabel.Text = ((DateTime)dr["day"]).ToLongDateString();
                    TimeLabel.Text = dr["timeof"].ToString().Trim();
                    NameLabel.Text = dr["fio"].ToString().Trim();
                    NumLabel.Text = dr["idnum"].ToString().Trim();
                    EventLabel.Text = dr["event"].ToString().Trim();
                    PayLabel.Text = dr["payment"].ToString().Trim();
                }
                sCon.Close();
            }
        }

        private void DeleteBut_Click(object sender, EventArgs e)
        {
            if (this.SheduleGrid.SelectedRows.Count > 0 &&
               this.SheduleGrid.SelectedRows[0].Index !=
               this.SheduleGrid.Rows.Count - 1)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы точно хотите удалить эту карту?\nНеобходимо подтверждение паролем", "Внимание!", MessageBoxButtons.YesNo))
                {
                    Password frm = new Password();
                    frm.ShowDialog();
                    if (frm.dr == DialogResult.OK)
                    {
                        NpgsqlConnection sCon = new NpgsqlConnection();
                        sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1";
                        var strSQL = string.Format("DELETE FROM calendar WHERE id={0};", (int)SheduleGrid.SelectedRows[0].Cells[0].Value);
                        sCon.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand(strSQL, sCon);
                        cmd.ExecuteNonQuery();
                        sCon.Close();
                        UpdateGrid();
                        MessageBox.Show("Запись удалена", "Подтверждение", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void EditBut_Click(object sender, EventArgs e)
        {
            if (this.SheduleGrid.SelectedRows.Count > 0 && this.SheduleGrid.SelectedRows[0].Index != this.SheduleGrid.Rows.Count - 1)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы точно хотите удалить эту запись?\nНеобходимо подтверждение паролем", "Внимание!", MessageBoxButtons.YesNo))
                {
                    Password frm = new Password();
                    frm.ShowDialog();
                    if (frm.dr == DialogResult.OK)
                    {
                        int a = (int)SheduleGrid.SelectedRows[0].Cells[0].Value;
                        RedactVisit frm1 = new RedactVisit(a);
                        frm1.ShowDialog();
                        UpdateGrid();
                        if (frm1.result == DialogResult.Yes) MessageBox.Show("Запись изменена", "Подтверждение", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }
}
