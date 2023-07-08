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
using System.Security.Cryptography;

namespace WindowsFormsApplication4
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            Reg reg1 = new Reg();
            reg1.Show();
        }

        #region Обработка нажатия по кнопке "Вход"
        private void LogButton_Click(object sender, EventArgs e)
        {
            #region Поиск пользователя
            bool findAcc = false;
            string password = GetHash(PassTB.Text);
            SqlCeCommand command = new SqlCeCommand("SELECT * FROM Users WHERE Login = @Login AND Pass = @Password", logsTableAdapter1.Connection);
            command.Parameters.Add("@Login", LoginTB.Text);
            command.Parameters.Add("@Password", password);
            command.Connection.Open();
            SqlCeDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                findAcc = true;
            }
            command.Connection.Close();
            reader.Close();
            #endregion

            //Если пользователь найден, то произвести вход, иначе вывести сообщение
            if (findAcc == true)
            {
                try
                {
                    ActiveForm.Hide();
                }
                finally
                {
                    MainForm main1 = new MainForm();
                    main1.Show();
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }
        #endregion

        private string GetHash(string pass)
        {
            var md5 = MD5.Create();
            return Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(pass)));
        }
    }
}
