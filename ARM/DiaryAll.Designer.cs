namespace ARM
{
    partial class DiaryAll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SheduleGrid = new System.Windows.Forms.DataGridView();
            this.RecBox = new System.Windows.Forms.GroupBox();
            this.EventLabel = new System.Windows.Forms.Label();
            this.PayLabel = new System.Windows.Forms.Label();
            this.NumLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DataLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddBut = new System.Windows.Forms.Button();
            this.DeleteBut = new System.Windows.Forms.Button();
            this.EditBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SheduleGrid)).BeginInit();
            this.RecBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SheduleGrid
            // 
            this.SheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SheduleGrid.Location = new System.Drawing.Point(140, 12);
            this.SheduleGrid.MultiSelect = false;
            this.SheduleGrid.Name = "SheduleGrid";
            this.SheduleGrid.ReadOnly = true;
            this.SheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SheduleGrid.Size = new System.Drawing.Size(476, 377);
            this.SheduleGrid.TabIndex = 0;
            this.SheduleGrid.SelectionChanged += new System.EventHandler(this.SheduleGrid_SelectionChanged);
            // 
            // RecBox
            // 
            this.RecBox.Controls.Add(this.EventLabel);
            this.RecBox.Controls.Add(this.PayLabel);
            this.RecBox.Controls.Add(this.NumLabel);
            this.RecBox.Controls.Add(this.NameLabel);
            this.RecBox.Controls.Add(this.TimeLabel);
            this.RecBox.Controls.Add(this.DataLabel);
            this.RecBox.Controls.Add(this.label6);
            this.RecBox.Controls.Add(this.label5);
            this.RecBox.Controls.Add(this.label4);
            this.RecBox.Controls.Add(this.label3);
            this.RecBox.Controls.Add(this.label2);
            this.RecBox.Controls.Add(this.label1);
            this.RecBox.Location = new System.Drawing.Point(636, 12);
            this.RecBox.Name = "RecBox";
            this.RecBox.Size = new System.Drawing.Size(426, 377);
            this.RecBox.TabIndex = 1;
            this.RecBox.TabStop = false;
            this.RecBox.Text = "Выбранный прием";
            // 
            // EventLabel
            // 
            this.EventLabel.AutoSize = true;
            this.EventLabel.Location = new System.Drawing.Point(187, 178);
            this.EventLabel.MaximumSize = new System.Drawing.Size(180, 103);
            this.EventLabel.Name = "EventLabel";
            this.EventLabel.Size = new System.Drawing.Size(13, 13);
            this.EventLabel.TabIndex = 28;
            this.EventLabel.Text = "--";
            // 
            // PayLabel
            // 
            this.PayLabel.AutoSize = true;
            this.PayLabel.Location = new System.Drawing.Point(202, 293);
            this.PayLabel.Name = "PayLabel";
            this.PayLabel.Size = new System.Drawing.Size(13, 13);
            this.PayLabel.TabIndex = 26;
            this.PayLabel.Text = "--";
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.Location = new System.Drawing.Point(163, 144);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(13, 13);
            this.NumLabel.TabIndex = 24;
            this.NumLabel.Text = "--";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(163, 108);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(13, 13);
            this.NameLabel.TabIndex = 23;
            this.NameLabel.Text = "--";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(163, 70);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(13, 13);
            this.TimeLabel.TabIndex = 22;
            this.TimeLabel.Text = "--";
            // 
            // DataLabel
            // 
            this.DataLabel.AutoSize = true;
            this.DataLabel.Location = new System.Drawing.Point(163, 33);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Size = new System.Drawing.Size(13, 13);
            this.DataLabel.TabIndex = 21;
            this.DataLabel.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Предварительная стоимость";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Планируемое мероприятие";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Номер карты/телефона";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Время";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Дата";
            // 
            // AddBut
            // 
            this.AddBut.Location = new System.Drawing.Point(15, 226);
            this.AddBut.Name = "AddBut";
            this.AddBut.Size = new System.Drawing.Size(119, 43);
            this.AddBut.TabIndex = 2;
            this.AddBut.Text = "Добавить прием";
            this.AddBut.UseVisualStyleBackColor = true;
            this.AddBut.Click += new System.EventHandler(this.AddBut_Click);
            // 
            // DeleteBut
            // 
            this.DeleteBut.Location = new System.Drawing.Point(15, 286);
            this.DeleteBut.Name = "DeleteBut";
            this.DeleteBut.Size = new System.Drawing.Size(119, 43);
            this.DeleteBut.TabIndex = 3;
            this.DeleteBut.Text = "Удалить прием";
            this.DeleteBut.UseVisualStyleBackColor = true;
            this.DeleteBut.Click += new System.EventHandler(this.DeleteBut_Click);
            // 
            // EditBut
            // 
            this.EditBut.Location = new System.Drawing.Point(15, 345);
            this.EditBut.Name = "EditBut";
            this.EditBut.Size = new System.Drawing.Size(119, 43);
            this.EditBut.TabIndex = 4;
            this.EditBut.Text = "Редактировать прием";
            this.EditBut.UseVisualStyleBackColor = true;
            this.EditBut.Click += new System.EventHandler(this.EditBut_Click);
            // 
            // DiaryAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 411);
            this.Controls.Add(this.EditBut);
            this.Controls.Add(this.DeleteBut);
            this.Controls.Add(this.AddBut);
            this.Controls.Add(this.RecBox);
            this.Controls.Add(this.SheduleGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DiaryAll";
            this.Text = "Расписание";
            ((System.ComponentModel.ISupportInitialize)(this.SheduleGrid)).EndInit();
            this.RecBox.ResumeLayout(false);
            this.RecBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SheduleGrid;
        private System.Windows.Forms.GroupBox RecBox;
        private System.Windows.Forms.Button AddBut;
        private System.Windows.Forms.Button DeleteBut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditBut;
        private System.Windows.Forms.Label PayLabel;
        private System.Windows.Forms.Label NumLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label DataLabel;
        private System.Windows.Forms.Label EventLabel;
    }
}