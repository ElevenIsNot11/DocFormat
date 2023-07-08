using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            OptionsForm options0 = new OptionsForm();
            if (OptionsForm.Options.design == "standart")
            {
                foreach (var form in Application.OpenForms)
                {
                    options0.ReColour(SystemColors.Info, Color.CadetBlue, (Form)form, true);
                }
            }
            else if (OptionsForm.Options.design == "simple")
            {
                foreach (var form in Application.OpenForms)
                {
                    options0.ReColour(Color.Black, Color.White, (Form)form, false);
                }
            }
            options0.Close();
            RefreshList();
        }

        string [] LogText;
        int i = 0;
        private void RefreshList()
        {
            LogList.Items.Clear();
            SqlCeCommand command = new SqlCeCommand("SELECT Date FROM Logs", logsTableAdapter.Connection);
            command.Connection.Open();
            SqlCeDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LogList.Items.Add(reader[0]);
            }
            command.Connection.Close();

            LogText = new string[LogList.Items.Count];
            SqlCeCommand command1 = new SqlCeCommand("SELECT Text FROM Logs", logsTableAdapter.Connection);
            command1.Connection.Open();
            reader = command1.ExecuteReader();
            while (reader.Read())
            {
                LogText[i] = reader[0].ToString();
                i++;
            }
            reader.Close();

        }

        private void LogList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LogList.SelectedIndex != -1)
            {
                LogRTB.Text = LogText[LogList.SelectedIndex];
            }
        }


    }
}
