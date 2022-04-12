
namespace Sanatorium.Forms
{
    partial class FormSpecialist
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTextTitleForm = new System.Windows.Forms.Label();
            this.panelDataGrid = new System.Windows.Forms.Panel();
            this.dgvSelectDataBase = new System.Windows.Forms.DataGridView();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDataBase = new System.Windows.Forms.DataGridView();
            this.panelSetValue = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelTitleBar.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectDataBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).BeginInit();
            this.panelSetValue.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitleBar.BackColor = System.Drawing.Color.White;
            this.panelTitleBar.Controls.Add(this.btnBack);
            this.panelTitleBar.Controls.Add(this.lblTextTitleForm);
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(948, 40);
            this.panelTitleBar.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Montserrat", 15F);
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Image = global::Sanatorium.Properties.Resources.icons8_двойная_стрелка_влево_24;
            this.btnBack.Location = new System.Drawing.Point(3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(33, 35);
            this.btnBack.TabIndex = 3;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTextTitleForm
            // 
            this.lblTextTitleForm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTextTitleForm.AutoSize = true;
            this.lblTextTitleForm.Font = new System.Drawing.Font("Montserrat", 12F);
            this.lblTextTitleForm.Location = new System.Drawing.Point(42, 8);
            this.lblTextTitleForm.Name = "lblTextTitleForm";
            this.lblTextTitleForm.Size = new System.Drawing.Size(128, 22);
            this.lblTextTitleForm.TabIndex = 0;
            this.lblTextTitleForm.Text = "Data Grid View";
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelDataGrid.BackColor = System.Drawing.Color.White;
            this.panelDataGrid.Controls.Add(this.dgvSelectDataBase);
            this.panelDataGrid.Controls.Add(this.dtpEndDate);
            this.panelDataGrid.Controls.Add(this.label9);
            this.panelDataGrid.Controls.Add(this.dtpStartDate);
            this.panelDataGrid.Controls.Add(this.label8);
            this.panelDataGrid.Controls.Add(this.btnDate);
            this.panelDataGrid.Controls.Add(this.btnUpdate);
            this.panelDataGrid.Controls.Add(this.label2);
            this.panelDataGrid.Controls.Add(this.dgvDataBase);
            this.panelDataGrid.Location = new System.Drawing.Point(12, 45);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(674, 435);
            this.panelDataGrid.TabIndex = 1;
            // 
            // dgvSelectDataBase
            // 
            this.dgvSelectDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelectDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectDataBase.Location = new System.Drawing.Point(12, 260);
            this.dgvSelectDataBase.Name = "dgvSelectDataBase";
            this.dgvSelectDataBase.Size = new System.Drawing.Size(651, 119);
            this.dgvSelectDataBase.TabIndex = 13;
            this.dgvSelectDataBase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectDataBase_CellDoubleClick);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.CustomFormat = "dd MMM, yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(402, 399);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(85, 20);
            this.dtpEndDate.TabIndex = 18;
            this.dtpEndDate.Value = new System.DateTime(2022, 4, 9, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "До";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.CustomFormat = "dd MMM, yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(281, 399);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(87, 20);
            this.dtpStartDate.TabIndex = 16;
            this.dtpStartDate.Value = new System.DateTime(2022, 4, 9, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "От";
            // 
            // btnDate
            // 
            this.btnDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDate.Font = new System.Drawing.Font("Montserrat", 11F);
            this.btnDate.Location = new System.Drawing.Point(136, 394);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(113, 25);
            this.btnDate.TabIndex = 14;
            this.btnDate.Text = "По дате";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Font = new System.Drawing.Font("Montserrat", 11F);
            this.btnUpdate.Location = new System.Drawing.Point(17, 394);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(113, 25);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 14F);
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Область таблиц";
            // 
            // dgvDataBase
            // 
            this.dgvDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataBase.Location = new System.Drawing.Point(12, 46);
            this.dgvDataBase.Name = "dgvDataBase";
            this.dgvDataBase.Size = new System.Drawing.Size(651, 208);
            this.dgvDataBase.TabIndex = 0;
            this.dgvDataBase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataBase_CellClick);
            this.dgvDataBase.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataBase_CellValueChanged);
            this.dgvDataBase.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDataBase_UserDeletingRow);
            // 
            // panelSetValue
            // 
            this.panelSetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSetValue.BackColor = System.Drawing.Color.White;
            this.panelSetValue.Controls.Add(this.textBox6);
            this.panelSetValue.Controls.Add(this.label10);
            this.panelSetValue.Controls.Add(this.textBox5);
            this.panelSetValue.Controls.Add(this.label1);
            this.panelSetValue.Controls.Add(this.btnDelete);
            this.panelSetValue.Controls.Add(this.btnAdd);
            this.panelSetValue.Controls.Add(this.label7);
            this.panelSetValue.Controls.Add(this.textBox4);
            this.panelSetValue.Controls.Add(this.label6);
            this.panelSetValue.Controls.Add(this.textBox3);
            this.panelSetValue.Controls.Add(this.label5);
            this.panelSetValue.Controls.Add(this.textBox2);
            this.panelSetValue.Controls.Add(this.label4);
            this.panelSetValue.Controls.Add(this.textBox1);
            this.panelSetValue.Controls.Add(this.label3);
            this.panelSetValue.Location = new System.Drawing.Point(691, 45);
            this.panelSetValue.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.panelSetValue.MinimumSize = new System.Drawing.Size(235, 0);
            this.panelSetValue.Name = "panelSetValue";
            this.panelSetValue.Size = new System.Drawing.Size(245, 435);
            this.panelSetValue.TabIndex = 2;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(128, 259);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(105, 22);
            this.textBox6.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 10F);
            this.label10.Location = new System.Drawing.Point(18, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "ID Кабинета";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(128, 226);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(105, 22);
            this.textBox5.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 10F);
            this.label1.Location = new System.Drawing.Point(18, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "ID Специальн.";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("Montserrat", 11F);
            this.btnDelete.Location = new System.Drawing.Point(23, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(210, 29);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Очистить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Montserrat", 11F);
            this.btnAdd.Location = new System.Drawing.Point(22, 297);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(211, 29);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 10F);
            this.label7.Location = new System.Drawing.Point(17, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Отчество";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(128, 193);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(105, 22);
            this.textBox4.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 10F);
            this.label6.Location = new System.Drawing.Point(18, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Имя";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(128, 160);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(105, 22);
            this.textBox3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 10F);
            this.label5.Location = new System.Drawing.Point(18, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Фамилия";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(128, 127);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(105, 22);
            this.textBox2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 10F);
            this.label4.Location = new System.Drawing.Point(18, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID Специали.";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(128, 94);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 14F);
            this.label3.Location = new System.Drawing.Point(17, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Область заполнения";
            // 
            // panelDesktop
            // 
            this.panelDesktop.Controls.Add(this.panelTitleBar);
            this.panelDesktop.Controls.Add(this.panelSetValue);
            this.panelDesktop.Controls.Add(this.panelDataGrid);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(948, 492);
            this.panelDesktop.TabIndex = 3;
            // 
            // FormSpecialist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 492);
            this.Controls.Add(this.panelDesktop);
            this.Name = "FormSpecialist";
            this.Text = "База данных специалистов";
            this.Load += new System.EventHandler(this.FormSpecialist_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDataGrid.ResumeLayout(false);
            this.panelDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectDataBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).EndInit();
            this.panelSetValue.ResumeLayout(false);
            this.panelSetValue.PerformLayout();
            this.panelDesktop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTextTitleForm;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelDataGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.Panel panelSetValue;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.DataGridView dgvSelectDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
    }
}