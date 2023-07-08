namespace WindowsFormsApplication4
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.DoButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.FilesLB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogButton = new System.Windows.Forms.Button();
            this.logsTableAdapter = new WindowsFormsApplication4.FormatDBDataSetTableAdapters.LogsTableAdapter();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(41, 219);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить файл";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DoButton
            // 
            this.DoButton.BackColor = System.Drawing.Color.CadetBlue;
            this.DoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoButton.Location = new System.Drawing.Point(264, 156);
            this.DoButton.Name = "DoButton";
            this.DoButton.Size = new System.Drawing.Size(165, 40);
            this.DoButton.TabIndex = 5;
            this.DoButton.Text = "Форматировать";
            this.DoButton.UseVisualStyleBackColor = false;
            this.DoButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // OptionsButton
            // 
            this.OptionsButton.BackColor = System.Drawing.Color.CadetBlue;
            this.OptionsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OptionsButton.Location = new System.Drawing.Point(264, 119);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(165, 31);
            this.OptionsButton.TabIndex = 6;
            this.OptionsButton.Text = "Настройки";
            this.OptionsButton.UseVisualStyleBackColor = false;
            this.OptionsButton.Click += new System.EventHandler(this.Options_Click);
            // 
            // FilesLB
            // 
            this.FilesLB.BackColor = System.Drawing.Color.CadetBlue;
            this.FilesLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilesLB.ForeColor = System.Drawing.SystemColors.Info;
            this.FilesLB.FormattingEnabled = true;
            this.FilesLB.ItemHeight = 22;
            this.FilesLB.Location = new System.Drawing.Point(41, 40);
            this.FilesLB.Name = "FilesLB";
            this.FilesLB.Size = new System.Drawing.Size(148, 156);
            this.FilesLB.TabIndex = 8;
            this.FilesLB.DoubleClick += new System.EventHandler(this.FilesLB_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(37, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Файлы:";
            // 
            // LogButton
            // 
            this.LogButton.BackColor = System.Drawing.Color.CadetBlue;
            this.LogButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LogButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogButton.Location = new System.Drawing.Point(264, 82);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(165, 31);
            this.LogButton.TabIndex = 10;
            this.LogButton.Text = "Журнал";
            this.LogButton.UseVisualStyleBackColor = false;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // logsTableAdapter
            // 
            this.logsTableAdapter.ClearBeforeFill = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication4.Properties.Resources.maxresdefault;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 263);
            this.Controls.Add(this.LogButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilesLB);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.DoButton);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("NewsGoth BT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Info;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DocFormat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DoButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.ListBox FilesLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LogButton;
        private FormatDBDataSetTableAdapters.LogsTableAdapter logsTableAdapter;
    }
}

