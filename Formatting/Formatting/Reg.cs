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
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        #region Обработка нажатия по кнопке "Зарегистрироваться"
        private void RegButton_Click(object sender, EventArgs e)
        {
            #region Поиск пользователя в БД
            bool findAcc = false;
            string password = GetHash(PassTB.Text);
            SqlCeCommand command = new SqlCeCommand("SELECT * FROM Users WHERE Login = @Login", logsTableAdapter1.Connection);
            command.Parameters.Add("@Login", LoginTB.Text);
            command.Connection.Open();
            SqlCeDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                findAcc = true;
            }
            command.Connection.Close();
            reader.Close();
            if (findAcc == true)
            {
                MessageBox.Show("Пользователь с таким именем уже существует");
            }
            #endregion
            #region Добавление нового пользователя
            else
            {
                try
                {
                  
                    SqlCeCommand command1 = new SqlCeCommand("INSERT INTO Users (Login, Pass) VALUES (@Login, @Password)", logsTableAdapter1.Connection);
                    command1.Parameters.Add("@Login", LoginTB.Text);
                    command1.Parameters.Add("@Password", password);
                    command1.Connection.Open();
                    command1.ExecuteNonQuery();
                    command1.Connection.Close();
                }
                finally
                {
                    ActiveForm.Close();
                }
            }
            #endregion
        }
        #endregion

        private string GetHash (string pass)
        {
            var md5 = MD5.Create();
            return Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(pass)));
        }
    }
}
