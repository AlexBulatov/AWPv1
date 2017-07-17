namespace ARM
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AmbulanceGroup = new System.Windows.Forms.GroupBox();
            this.AddRecord = new System.Windows.Forms.Button();
            this.ShowRecord = new System.Windows.Forms.Button();
            this.EditRecord = new System.Windows.Forms.Button();
            this.DeleteRecord = new System.Windows.Forms.Button();
            this.BaseGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowDiary = new System.Windows.Forms.Button();
            this.SheduleGrid = new System.Windows.Forms.DataGridView();
            this.CardsBox = new System.Windows.Forms.GroupBox();
            this.AddCard = new System.Windows.Forms.Button();
            this.ShowCard = new System.Windows.Forms.Button();
            this.FilterCards = new System.Windows.Forms.Button();
            this.EditCard = new System.Windows.Forms.Button();
            this.DeleteCard = new System.Windows.Forms.Button();
            this.CardsGrid = new System.Windows.Forms.DataGridView();
            this.AmbulanceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheduleGrid)).BeginInit();
            this.CardsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AmbulanceGroup
            // 
            this.AmbulanceGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AmbulanceGroup.Controls.Add(this.AddRecord);
            this.AmbulanceGroup.Controls.Add(this.ShowRecord);
            this.AmbulanceGroup.Controls.Add(this.EditRecord);
            this.AmbulanceGroup.Controls.Add(this.DeleteRecord);
            this.AmbulanceGroup.Controls.Add(this.BaseGrid);
            this.AmbulanceGroup.Location = new System.Drawing.Point(505, 12);
            this.AmbulanceGroup.Name = "AmbulanceGroup";
            this.AmbulanceGroup.Size = new System.Drawing.Size(477, 626);
            this.AmbulanceGroup.TabIndex = 2;
            this.AmbulanceGroup.TabStop = false;
            this.AmbulanceGroup.Text = "Амбулаторные записи";
            // 
            // AddRecord
            // 
            this.AddRecord.Location = new System.Drawing.Point(336, 549);
            this.AddRecord.Name = "AddRecord";
            this.AddRecord.Size = new System.Drawing.Size(124, 39);
            this.AddRecord.TabIndex = 6;
            this.AddRecord.Text = "Добавить запись";
            this.AddRecord.UseVisualStyleBackColor = true;
            this.AddRecord.Click += new System.EventHandler(this.AddRecord_Click);
            // 
            // ShowRecord
            // 
            this.ShowRecord.Location = new System.Drawing.Point(336, 504);
            this.ShowRecord.Name = "ShowRecord";
            this.ShowRecord.Size = new System.Drawing.Size(124, 39);
            this.ShowRecord.TabIndex = 5;
            this.ShowRecord.Text = "Просмотреть запись";
            this.ShowRecord.UseVisualStyleBackColor = true;
            this.ShowRecord.Click += new System.EventHandler(this.ShowRecord_Click);
            // 
            // EditRecord
            // 
            this.EditRecord.Location = new System.Drawing.Point(24, 549);
            this.EditRecord.Name = "EditRecord";
            this.EditRecord.Size = new System.Drawing.Size(135, 39);
            this.EditRecord.TabIndex = 2;
            this.EditRecord.Text = "Редактировать запись";
            this.EditRecord.UseVisualStyleBackColor = true;
            this.EditRecord.Click += new System.EventHandler(this.EditRecord_Click);
            // 
            // DeleteRecord
            // 
            this.DeleteRecord.Location = new System.Drawing.Point(24, 504);
            this.DeleteRecord.Name = "DeleteRecord";
            this.DeleteRecord.Size = new System.Drawing.Size(135, 39);
            this.DeleteRecord.TabIndex = 1;
            this.DeleteRecord.Text = "Удалить запись";
            this.DeleteRecord.UseVisualStyleBackColor = true;
            this.DeleteRecord.Click += new System.EventHandler(this.DeleteRecord_Click);
            // 
            // BaseGrid
            // 
            this.BaseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BaseGrid.Location = new System.Drawing.Point(24, 19);
            this.BaseGrid.MultiSelect = false;
            this.BaseGrid.Name = "BaseGrid";
            this.BaseGrid.ReadOnly = true;
            this.BaseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BaseGrid.Size = new System.Drawing.Size(436, 470);
            this.BaseGrid.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ShowDiary);
            this.groupBox1.Controls.Add(this.SheduleGrid);
            this.groupBox1.Location = new System.Drawing.Point(988, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 626);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расписание процедур и приемов";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(82, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Расписание на сегодня";
            // 
            // ShowDiary
            // 
            this.ShowDiary.Location = new System.Drawing.Point(208, 504);
            this.ShowDiary.Name = "ShowDiary";
            this.ShowDiary.Size = new System.Drawing.Size(124, 39);
            this.ShowDiary.TabIndex = 6;
            this.ShowDiary.Text = "Посмотреть все приемы";
            this.ShowDiary.UseVisualStyleBackColor = true;
            this.ShowDiary.Click += new System.EventHandler(this.ShowDiary_Click);
            // 
            // SheduleGrid
            // 
            this.SheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SheduleGrid.Location = new System.Drawing.Point(20, 55);
            this.SheduleGrid.MultiSelect = false;
            this.SheduleGrid.Name = "SheduleGrid";
            this.SheduleGrid.ReadOnly = true;
            this.SheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SheduleGrid.Size = new System.Drawing.Size(312, 434);
            this.SheduleGrid.TabIndex = 0;
            // 
            // CardsBox
            // 
            this.CardsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsBox.Controls.Add(this.AddCard);
            this.CardsBox.Controls.Add(this.ShowCard);
            this.CardsBox.Controls.Add(this.FilterCards);
            this.CardsBox.Controls.Add(this.EditCard);
            this.CardsBox.Controls.Add(this.DeleteCard);
            this.CardsBox.Controls.Add(this.CardsGrid);
            this.CardsBox.Location = new System.Drawing.Point(12, 12);
            this.CardsBox.Name = "CardsBox";
            this.CardsBox.Size = new System.Drawing.Size(487, 626);
            this.CardsBox.TabIndex = 4;
            this.CardsBox.TabStop = false;
            this.CardsBox.Text = "Амбулаторные карты";
            // 
            // AddCard
            // 
            this.AddCard.Location = new System.Drawing.Point(182, 549);
            this.AddCard.Name = "AddCard";
            this.AddCard.Size = new System.Drawing.Size(124, 39);
            this.AddCard.TabIndex = 12;
            this.AddCard.Text = "Добавить новую карту";
            this.AddCard.UseVisualStyleBackColor = true;
            this.AddCard.Click += new System.EventHandler(this.AddCard_Click);
            // 
            // ShowCard
            // 
            this.ShowCard.Location = new System.Drawing.Point(182, 504);
            this.ShowCard.Name = "ShowCard";
            this.ShowCard.Size = new System.Drawing.Size(124, 39);
            this.ShowCard.TabIndex = 11;
            this.ShowCard.Text = "Просмотреть карту";
            this.ShowCard.UseVisualStyleBackColor = true;
            this.ShowCard.Click += new System.EventHandler(this.ShowCard_Click);
            // 
            // FilterCards
            // 
            this.FilterCards.Location = new System.Drawing.Point(334, 504);
            this.FilterCards.Name = "FilterCards";
            this.FilterCards.Size = new System.Drawing.Size(124, 39);
            this.FilterCards.TabIndex = 9;
            this.FilterCards.Text = "Фильтрация/Поиск";
            this.FilterCards.UseVisualStyleBackColor = true;
            this.FilterCards.Click += new System.EventHandler(this.FilterCards_Click);
            // 
            // EditCard
            // 
            this.EditCard.Location = new System.Drawing.Point(22, 549);
            this.EditCard.Name = "EditCard";
            this.EditCard.Size = new System.Drawing.Size(135, 39);
            this.EditCard.TabIndex = 8;
            this.EditCard.Text = "Редактировать карту";
            this.EditCard.UseVisualStyleBackColor = true;
            this.EditCard.Click += new System.EventHandler(this.EditCard_Click);
            // 
            // DeleteCard
            // 
            this.DeleteCard.Location = new System.Drawing.Point(22, 504);
            this.DeleteCard.Name = "DeleteCard";
            this.DeleteCard.Size = new System.Drawing.Size(135, 39);
            this.DeleteCard.TabIndex = 7;
            this.DeleteCard.Text = "Удалить карту";
            this.DeleteCard.UseVisualStyleBackColor = true;
            this.DeleteCard.Click += new System.EventHandler(this.DeleteCard_Click);
            // 
            // CardsGrid
            // 
            this.CardsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CardsGrid.Location = new System.Drawing.Point(11, 19);
            this.CardsGrid.MultiSelect = false;
            this.CardsGrid.Name = "CardsGrid";
            this.CardsGrid.ReadOnly = true;
            this.CardsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CardsGrid.Size = new System.Drawing.Size(462, 469);
            this.CardsGrid.TabIndex = 0;
            this.CardsGrid.SelectionChanged += new System.EventHandler(this.CardsGrid_SelectionChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 650);
            this.Controls.Add(this.CardsBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AmbulanceGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АРМ Ветеринара";
            this.AmbulanceGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BaseGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheduleGrid)).EndInit();
            this.CardsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CardsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AmbulanceGroup;
        private System.Windows.Forms.Button AddRecord;
        private System.Windows.Forms.Button ShowRecord;
        private System.Windows.Forms.Button EditRecord;
        private System.Windows.Forms.Button DeleteRecord;
        private System.Windows.Forms.DataGridView BaseGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView SheduleGrid;
        private System.Windows.Forms.Button ShowDiary;
        private System.Windows.Forms.GroupBox CardsBox;
        private System.Windows.Forms.Button AddCard;
        private System.Windows.Forms.Button ShowCard;
        private System.Windows.Forms.Button FilterCards;
        private System.Windows.Forms.Button EditCard;
        private System.Windows.Forms.Button DeleteCard;
        private System.Windows.Forms.DataGridView CardsGrid;
        private System.Windows.Forms.Label label1;
    }
}

