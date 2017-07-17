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
using NpgsqlTypes;

namespace ARM
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            NpgsqlConnection sCon = new NpgsqlConnection();
            sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1";

            #region Обновление расписания
            {
                var strSQL = "SELECT timeof, event FROM calendar WHERE date_part('year', day) = date_part('year', current_timestamp) AND date_part('month', day)= date_part('month', current_timestamp) AND date_part('day', day)= date_part('day', current_timestamp)";
                NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, sCon.ConnectionString);
                System.Data.Common.DataTableMapping shedMap = da.TableMappings.Add("calendar", "Расписание процедур");
                shedMap.ColumnMappings.Add("day", "Дата");
                shedMap.ColumnMappings.Add("timeof", "Время");
                shedMap.ColumnMappings.Add("fio", "ФИО");
                shedMap.ColumnMappings.Add("idnum", "Номер амбулаторной карты");
                shedMap.ColumnMappings.Add("event", "Процедура");
                shedMap.ColumnMappings.Add("payment", "Предварительная оплата");
                DataSet ds1 = new DataSet();
                da.Fill(ds1, "calendar");
                da.Dispose();
                SheduleGrid.DataSource = ds1.Tables["Расписание процедур"].DefaultView;
                foreach (DataGridViewColumn column in SheduleGrid.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            #endregion

            #region Обновление базы карт
            {
                var strSQL = "Select id, breeder, address, phone, kindofanimal, breed, petname, dateofbirth, textdate, gender From clientbase ORDER BY id";
                NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, sCon.ConnectionString);
                System.Data.Common.DataTableMapping BaseMap = da.TableMappings.Add("clientbase", "Амбулаторные карты");
                BaseMap.ColumnMappings.Add("id", "Учетный номер");
                BaseMap.ColumnMappings.Add("breeder", "Владелец");
                BaseMap.ColumnMappings.Add("address", "Адрес");
                BaseMap.ColumnMappings.Add("phone", "Телефон");
                BaseMap.ColumnMappings.Add("kindofanimal", "Вид животного");
                BaseMap.ColumnMappings.Add("breed", "Порода");
                BaseMap.ColumnMappings.Add("petname", "Кличка");
                BaseMap.ColumnMappings.Add("dateofbirth", "Дата рождения");
                BaseMap.ColumnMappings.Add("textdate", "Возраст");
                BaseMap.ColumnMappings.Add("gender", "Особь");
                DataSet ds2 = new DataSet();
                da.Fill(ds2, "clientbase");
                CardsGrid.DataSource = ds2.Tables["Амбулаторные карты"].DefaultView;
                foreach (DataGridViewColumn column in CardsGrid.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            #endregion

            #region Обновление базы записей
            {
                var strSQL = "Select * From recordincard ORDER BY idbase;";
                NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, sCon.ConnectionString);
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
            #endregion
        }

        void UpdateCrid()
        {
            string ConnectionString = "Server=localhost;Port=5432;Username=postgres;Password=1;Database=postgres;";
            string strSQL = "Select id, breeder, address, phone, kindofanimal, breed, petname, dateofbirth, textdate, gender From clientbase ORDER BY id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, ConnectionString);
            DataSet ds = new DataSet();
            System.Data.Common.DataTableMapping custMap = da.TableMappings.Add("clientbase", "Амбулаторные карты");
            custMap.ColumnMappings.Add("id", "Номер");
            custMap.ColumnMappings.Add("breeder", "Владелец");
            custMap.ColumnMappings.Add("address", "Адрес");
            custMap.ColumnMappings.Add("phone", "Телефон");
            custMap.ColumnMappings.Add("kindofanimal", "Вид животного");
            custMap.ColumnMappings.Add("breed", "Порода");
            custMap.ColumnMappings.Add("petname", "Кличка");
            custMap.ColumnMappings.Add("dateofbirth", "Дата рождения");
            custMap.ColumnMappings.Add("textdate", "Возраст");
            custMap.ColumnMappings.Add("gender", "Особь");
            da.Fill(ds, "clientbase");
            CardsGrid.DataSource = ds.Tables["Амбулаторные карты"].DefaultView;
            foreach (DataGridViewColumn column in CardsGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        void UpdateBaseGrid()
        {
            string ConnectionString = "Server=localhost;Port=5432;Username=postgres;Password=1;Database=postgres;";
            string strSQL = "Select * From recordincard ORDER BY idbase;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, ConnectionString);
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

        private void AddRecord_Click(object sender, EventArgs e)
        {
            if (this.CardsGrid.SelectedRows.Count > 0 &&
               this.CardsGrid.SelectedRows[0].Index !=
               this.CardsGrid.Rows.Count - 1)
            {
                NewRecordForm frm = new NewRecordForm((int)CardsGrid.SelectedRows[0].Cells[0].Value);
                frm.ShowDialog();
                UpdateCrid();
            }
            else
            {
                MessageBox.Show("Выберите карту для прикрепления к ней записи", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void ShowRecord_Click(object sender, EventArgs e)
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

        private void AddCard_Click(object sender, EventArgs e)
        {
            NewCardForm frm = new NewCardForm();
            frm.ShowDialog();
            UpdateCrid();
        }

        private void ShowDiary_Click(object sender, EventArgs e)
        {
            DiaryAll frm = new DiaryAll();
            frm.Show();
        }

        private void ShowCard_Click(object sender, EventArgs e)
        {
            if (CardsGrid.SelectedRows.Count > 0 && CardsGrid.Rows.Count - 1 != CardsGrid.SelectedRows[0].Index)
            {
                ShowCard frm = new ShowCard((int) CardsGrid.SelectedRows[0].Cells[0].Value);
                frm.ShowDialog();
            }
        }

        private void CardsGrid_SelectionChanged(object sender, EventArgs e)
        {
            NpgsqlConnection sCon = new NpgsqlConnection();
            sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1";
            if (CardsGrid.SelectedRows.Count > 0 && CardsGrid.Rows.Count - 1 != CardsGrid.SelectedRows[0].Index)
            {
                int selector = (int)CardsGrid.SelectedRows[0].Cells[0].Value;
                
                var strSQL = string.Format("Select * From recordincard WHERE tocard={0} ORDER BY idbase; ", selector);
                NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, sCon.ConnectionString);
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
            else
            {
                var strSQL = string.Format("Select * From recordincard ORDER BY idbase; ");
                NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, sCon);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, sCon.ConnectionString);
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
        }

        private void FilterCards_Click(object sender, EventArgs e)
        {
            FilterForm frm = new FilterForm();
            frm.ShowDialog();
            var strSQL = frm.FilterCommandString;

            if (strSQL == null) return;

            NpgsqlConnection sCon = new NpgsqlConnection();
            sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSQL, sCon);
            DataSet ds = new DataSet();
            System.Data.Common.DataTableMapping custMap = da.TableMappings.Add("clientbase", "Амбулаторные записи");
            custMap.ColumnMappings.Add("id", "Номер");
            custMap.ColumnMappings.Add("breeder", "Владелец");
            custMap.ColumnMappings.Add("address", "Адрес");
            custMap.ColumnMappings.Add("phone", "Телефон");
            custMap.ColumnMappings.Add("kindofanimal", "Вид животного");
            custMap.ColumnMappings.Add("breed", "Порода");
            custMap.ColumnMappings.Add("petname", "Кличка");
            custMap.ColumnMappings.Add("dateofbirth", "Дата рождения");
            custMap.ColumnMappings.Add("textdate", "Возраст");
            custMap.ColumnMappings.Add("gender", "Особь");
            da.Fill(ds, "clientbase");
            CardsGrid.DataSource = ds.Tables["Амбулаторные записи"].DefaultView;
            foreach (DataGridViewColumn column in CardsGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DeleteCard_Click(object sender, EventArgs e)
        {
            if (CardsGrid.SelectedRows.Count > 0 && CardsGrid.Rows.Count - 1 != CardsGrid.SelectedRows[0].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы точно хотите удалить эту карту?\nНеобходимо подтверждение паролем", "Внимание!", MessageBoxButtons.YesNo))
                {
                    Password frm = new Password();
                    frm.ShowDialog();
                    if (frm.dr == DialogResult.OK)
                    {
                        NpgsqlConnection sCon = new NpgsqlConnection();
                        sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1";
                        int[] ForDelete;
                        var strSQL= string.Format("SELECT numofrecords FROM clientbase WHERE id={0};", (int)CardsGrid.SelectedRows[0].Cells[0].Value);
                        NpgsqlCommand cmd = new NpgsqlCommand(strSQL, sCon);
                        sCon.Open();
                        int len = (int)cmd.ExecuteScalar();
                        if (len != 0)
                        {
                            strSQL = string.Format("SELECT records FROM clientbase WHERE id={0};", (int)CardsGrid.SelectedRows[0].Cells[0].Value);
                            cmd = new NpgsqlCommand(strSQL, sCon);
                            sCon.Open();
                            ForDelete = (int[])cmd.ExecuteScalar();
                            if (ForDelete.Length != 0)
                            {
                                string ForSearch = "";
                                for (int i = 0; i < ForDelete.Length; i++)
                                {
                                    if (i != ForDelete.Length - 1)
                                        ForSearch += ForDelete[i] + ", ";
                                    else ForSearch += ForDelete[i];
                                }
                                strSQL = string.Format("DELETE FROM recordincard WHERE idbase IN({0});", ForSearch);
                                cmd = new NpgsqlCommand(strSQL, sCon);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        strSQL = string.Format("DELETE FROM clientbase WHERE id={0};", (int)CardsGrid.SelectedRows[0].Cells[0].Value);

                        cmd = new NpgsqlCommand(strSQL, sCon);
                        cmd.ExecuteNonQuery();
                        UpdateCrid();
                        UpdateBaseGrid();
                        sCon.Close();
                        MessageBox.Show("Запись удалена", "Подтверждение", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void DeleteRecord_Click(object sender, EventArgs e)
        {
            if (BaseGrid.SelectedRows.Count > 0 && BaseGrid.Rows.Count - 1 != BaseGrid.SelectedRows[0].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы точно хотите удалить эту запись?\nНеобходимо подтверждение паролем", "Внимание!", MessageBoxButtons.YesNo))
                {
                    Password frm = new Password();
                    frm.ShowDialog();
                    if (frm.dr == DialogResult.OK)
                    {
                        NpgsqlConnection sCon = new NpgsqlConnection();
                        sCon.ConnectionString = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=1";
                        int tocard = 0;

                        var strSQL = string.Format("SELECT tocard FROM recordincard WHERE idbase={0};", (int) BaseGrid.SelectedRows[0].Cells[0].Value);
                        NpgsqlCommand cmd = new NpgsqlCommand(strSQL, sCon);
                        sCon.Open();
                        tocard = (int) cmd.ExecuteScalar();

                        strSQL = string.Format("UPDATE clientbase SET numofrecords = numofrecords - 1, records = array_remove(records, {0}) WHERE id = {1};", (int)BaseGrid.SelectedRows[0].Cells[0].Value, tocard);
                        cmd = new NpgsqlCommand(strSQL, sCon);
                        cmd.ExecuteNonQuery();

                        strSQL = string.Format("DELETE FROM recordincard WHERE idbase={0};", (int)BaseGrid.SelectedRows[0].Cells[0].Value);
                        cmd = new NpgsqlCommand(strSQL, sCon);
                        cmd.ExecuteNonQuery();
                        sCon.Close();
                        //---------------------------------------------------------------------------
                        UpdateBaseGrid();
                        MessageBox.Show("Запись удалена", "Подтверждение", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void EditRecord_Click(object sender, EventArgs e)
        {
            if (this.BaseGrid.SelectedRows.Count > 0 && this.BaseGrid.SelectedRows[0].Index != this.BaseGrid.Rows.Count - 1)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы точно хотите отредактировать эту запись?\nНеобходимо подтверждение паролем", "Внимание!", MessageBoxButtons.YesNo))
                {
                    Password frm = new Password();
                    frm.ShowDialog();
                    if (frm.dr == DialogResult.OK)
                    {
                        int a = (int)BaseGrid.SelectedRows[0].Cells[0].Value;
                        RedactRecordForm frm1 = new RedactRecordForm(a);
                        frm1.ShowDialog();
                        UpdateBaseGrid();

                        if (frm1.result == DialogResult.Yes) MessageBox.Show("Запись изменена", "Подтверждение", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void EditCard_Click(object sender, EventArgs e)
        {
            if (CardsGrid.SelectedRows.Count > 0 && CardsGrid.Rows.Count - 1 != CardsGrid.SelectedRows[0].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы точно хотите удалить эту запись?\nНеобходимо подтверждение паролем", "Внимание!", MessageBoxButtons.YesNo))
                {
                    Password frm = new Password();
                    frm.ShowDialog();
                    if (frm.dr == DialogResult.OK)
                    {
                        int a = (int)CardsGrid.SelectedRows[0].Cells[0].Value;
                        RedactCardForm frm1 = new RedactCardForm(a);
                        frm1.ShowDialog();
                        UpdateCrid();

                        if(frm1.result==DialogResult.Yes) MessageBox.Show("Запись изменена", "Подтверждение", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }
}