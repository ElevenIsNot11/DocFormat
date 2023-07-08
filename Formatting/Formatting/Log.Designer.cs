namespace WindowsFormsApplication4
{
    partial class Log
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            this.LogList = new System.Windows.Forms.ListBox();
            this.logsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formatDBDataSet = new WindowsFormsApplication4.FormatDBDataSet();
            this.LogRTB = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.logsTableAdapter = new WindowsFormsApplication4.FormatDBDataSetTableAdapters.LogsTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // LogList
            // 
            this.LogList.BackColor = System.Drawing.Color.CadetBlue;
            this.LogList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogList.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogList.ForeColor = System.Drawing.SystemColors.Info;
            this.LogList.FormattingEnabled = true;
            this.LogList.ItemHeight = 21;
            this.LogList.Location = new System.Drawing.Point(24, 69);
            this.LogList.Margin = new System.Windows.Forms.Padding(5);
            this.LogList.Name = "LogList";
            this.LogList.Size = new System.Drawing.Size(181, 275);
            this.LogList.TabIndex = 0;
            this.LogList.SelectedIndexChanged += new System.EventHandler(this.LogList_SelectedIndexChanged);
            // 
            // logsBindingSource
            // 
            this.logsBindingSource.DataMember = "Logs";
            this.logsBindingSource.DataSource = this.formatDBDataSet;
            // 
            // formatDBDataSet
            // 
            this.formatDBDataSet.DataSetName = "FormatDBDataSet";
            this.formatDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LogRTB
            // 
            this.LogRTB.BackColor = System.Drawing.Color.CadetBlue;
            this.LogRTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogRTB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogRTB.ForeColor = System.Drawing.SystemColors.Info;
            this.LogRTB.Location = new System.Drawing.Point(241, 69);
            this.LogRTB.Margin = new System.Windows.Forms.Padding(5);
            this.LogRTB.Name = "LogRTB";
            this.LogRTB.Size = new System.Drawing.Size(724, 457);
            this.LogRTB.TabIndex = 1;
            this.LogRTB.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(76, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Список";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.CadetBlue;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitButton.Location = new System.Drawing.Point(43, 487);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(125, 39);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // logsTableAdapter
            // 
            this.logsTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(495, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Информация в журнале";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::WindowsFormsApplication4.Properties.Resources.maxresdefault;
            this.ClientSize = new System.Drawing.Size(982, 533);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogRTB);
            this.Controls.Add(this.LogList);
            this.Font = new System.Drawing.Font("NewsGoth BT", 14.25F);
            this.ForeColor = System.Drawing.SystemColors.Info;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Log";
            this.Text = "Журнал";
            this.Load += new System.EventHandler(this.Log_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LogList;
        private System.Windows.Forms.RichTextBox LogRTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private FormatDBDataSet formatDBDataSet;
        private System.Windows.Forms.BindingSource logsBindingSource;
        private FormatDBDataSetTableAdapters.LogsTableAdapter logsTableAdapter;
        private System.Windows.Forms.Label label2;
    }
}