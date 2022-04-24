
namespace Sanatorium.Forms
{
    partial class FormListSetting
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
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.btnChangeNameServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.panelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.White;
            this.panelDesktop.Controls.Add(this.lblConnectionString);
            this.panelDesktop.Controls.Add(this.label2);
            this.panelDesktop.Controls.Add(this.btnChangeNameServer);
            this.panelDesktop.Controls.Add(this.tbServerName);
            this.panelDesktop.Controls.Add(this.label1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.MinimumSize = new System.Drawing.Size(948, 492);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(948, 492);
            this.panelDesktop.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущая строка подключения";
            // 
            // tbServerName
            // 
            this.tbServerName.Location = new System.Drawing.Point(179, 65);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(188, 20);
            this.tbServerName.TabIndex = 1;
            // 
            // btnChangeNameServer
            // 
            this.btnChangeNameServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChangeNameServer.Font = new System.Drawing.Font("Montserrat", 11F);
            this.btnChangeNameServer.Location = new System.Drawing.Point(373, 65);
            this.btnChangeNameServer.Name = "btnChangeNameServer";
            this.btnChangeNameServer.Size = new System.Drawing.Size(107, 23);
            this.btnChangeNameServer.TabIndex = 2;
            this.btnChangeNameServer.Text = "Подключить";
            this.btnChangeNameServer.UseVisualStyleBackColor = true;
            this.btnChangeNameServer.Click += new System.EventHandler(this.btnChangeNameServer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название сервера";
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblConnectionString.Location = new System.Drawing.Point(267, 33);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(160, 13);
            this.lblConnectionString.TabIndex = 4;
            this.lblConnectionString.Text = "Текущая строка подключения";
            // 
            // FormListSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 492);
            this.Controls.Add(this.panelDesktop);
            this.Name = "FormListSetting";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.FormListSetting_Load);
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button btnChangeNameServer;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Label label2;
    }
}