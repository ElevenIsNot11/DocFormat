using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            
        }

        #region Обработка нажатия по кнопке "ОК"
        private void button1_Click(object sender, EventArgs e)
        {
            double x1;
            #region Шрифт (название шрифта, размер, цвет)
            if (FontNameCB.SelectedItem != null)
            {
                Options.Font = FontNameCB.SelectedItem.ToString();
            }
            if (double.TryParse(FontSizeCB.Text, out x1))
            {
                if (Double.Parse(FontSizeCB.Text) >= 8)
                {
                    if ((Double.Parse(FontSizeCB.Text) % 0.5) == 0)
                    {
                        Options.FontSize = Convert.ToString(Double.Parse(FontSizeCB.Text) * 2);
                    }
                    else
                    {
                        Options.FontSize = Convert.ToString(Math.Floor(Double.Parse(FontSizeCB.Text) * 2));
                    }
                }
            }
            if (FontColourCB.SelectedItem != null)
            {
                if (FontColourCB.SelectedItem.ToString() == "Черный")
                {
                    Options.FontColour = "000000";
                }
                if (FontColourCB.SelectedItem.ToString() == "Красный")
                {
                    Options.FontColour = "FF0000";
                }
                if (FontColourCB.SelectedItem.ToString() == "Зеленый")
                {
                    Options.FontColour = "00FF00";
                }
                if (FontColourCB.SelectedItem.ToString() == "Серый")
                {
                    Options.FontColour = "7F7F7F";
                }
                if (FontColourCB.SelectedItem.ToString() == "Желтый")
                {
                    Options.FontColour = "FFFF00";
                }
            }
            #endregion
            #region Выравнивание (текст и заголовки)
            if (JustificationCB.SelectedItem != null)
            {
                if (JustificationCB.SelectedItem.ToString() == "По ширине")
                {
                    Options.Justification = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Both;
                }
                else
                if (JustificationCB.SelectedItem.ToString() == "По центру")
                {
                    Options.Justification = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center;
                }
                else
                if (JustificationCB.SelectedItem.ToString() == "По правому краю")
                {
                    Options.Justification = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Right;
                }
                else
                if (JustificationCB.SelectedItem.ToString() == "По левому краю")
                {
                    Options.Justification = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left;
                }
            }
            if (JustificationHeaderCB.SelectedItem != null)
            {
                if (JustificationHeaderCB.SelectedItem.ToString() == "По ширине")
                {
                    Options.JustificationHeader = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Both;
                }
                else
                if (JustificationHeaderCB.SelectedItem.ToString() == "По центру")
                {
                    Options.JustificationHeader = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center;
                }
                else
                if (JustificationHeaderCB.SelectedItem.ToString() == "По правому краю")
                {
                    Options.JustificationHeader = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Right;
                }
                else
                if (JustificationHeaderCB.SelectedItem.ToString() == "По левому краю")
                {
                    Options.JustificationHeader = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left;
                }
            }
            #endregion
            #region Интервалы (заголовки и текст)
            if (IntervalComboBox.SelectedItem != null)
            {
                if (IntervalComboBox.SelectedItem.ToString() == "Одинарный")
                {
                    Options.Line = "240";
                }
                else
                if (IntervalComboBox.SelectedItem.ToString() == "1,5 строки")
                {
                    Options.Line = "360";
                }
                else
                if (IntervalComboBox.SelectedItem.ToString() == "Двойной")
                {
                    Options.Line = "480";
                }
            }
            if (Double.TryParse(IntervalBeforeCB.Text, out x1))
            {
                Options.Before = Convert.ToString(Double.Parse(IntervalBeforeCB.Text) * 20).Replace(',', '.');
            }
            if (Double.TryParse(IntervalBeforeHeaderCB.Text, out x1))
            {
                Options.BeforeHeader = Convert.ToString(Double.Parse(IntervalBeforeHeaderCB.Text) * 20).Replace(',', '.');
            }
            if (double.TryParse(IntervalAfterCB.Text, out x1))
            {
                Options.After = Convert.ToString(Double.Parse(IntervalAfterCB.Text) * 20).Replace(',','.');
            }
            if (double.TryParse(IntervalAfterHeaderCB.Text, out x1))
            {
                Options.AfterHeader = Convert.ToString(Double.Parse(IntervalAfterHeaderCB.Text) * 20).Replace(',', '.');
            }
            #endregion
            #region Отступы слева, справа, первая строка (заголовки и текст)
            if (double.TryParse(IndentationCB.Text, out x1))
            {
                Options.Indentation = Convert.ToString(Math.Round(Double.Parse(IndentationCB.Text) * 567.2)).Replace(',', '.');
            }
            if (double.TryParse(IndentationLeftCB.Text, out x1))
            {
                Options.IndentationLeft = Convert.ToString(Math.Round(Double.Parse(IndentationLeftCB.Text) * 567.2)).Replace(',', '.');
            }
            if (double.TryParse(IndentationLeftHeaderCB.Text, out x1))
            {
                Options.IndentationLeftHeader = Convert.ToString(Math.Round(Double.Parse(IndentationLeftHeaderCB.Text) * 567.2)).Replace(',', '.');
            }
            if (double.TryParse(IndentationRightCB.Text, out x1))
            {
                Options.IndentationRight = Convert.ToString(Math.Round(Double.Parse(IndentationRightCB.Text) * 567.2)).Replace(',', '.');
            }
            if (double.TryParse(IndentationRightHeaderCB.Text, out x1))
            {
                Options.IndentationRightHeader = Convert.ToString(Math.Round(Double.Parse(IndentationRightHeaderCB.Text) * 567.2)).Replace(',', '.');
            }
            #endregion
            #region Тип документа (формат реферата и обычный)
            if (DocTypeCB1.Checked)
            {
                Options.doctype = "ref";
            }
            else
            {
                Options.doctype = "default";
            }
            #endregion
            MessageBox.Show("Изменения сохранены");
            Form.ActiveForm.Close();
        }
        #endregion
        #region Класс с настройками
        public static class Options
        {
            public static string Font = "Times New Roman";
            public static string FontSize = "28";
            public static string FontColour = "000000";
            public static DocumentFormat.OpenXml.Wordprocessing.JustificationValues Justification = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Both;
            public static string Line = "240";
            public static string After = "0";
            public static string AfterHeader = "0";
            public static string Before = "0";
            public static string BeforeHeader = "0";
            public static string Indentation = "709";
            public static DocumentFormat.OpenXml.Wordprocessing.JustificationValues JustificationHeader = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center;
            public static string IndentationLeft = "0";
            public static string IndentationLeftHeader = "0";
            public static string IndentationRight = "0";
            public static string IndentationRightHeader = "0";
            public static string doctype = "default";
            public static string design = "standart";
        }
        #endregion
        
        #region Методы проверки введенных символов

        private void CheckPlus (object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == 8) return;
            else
            e.Handled = true;
        }

        private void Check(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == 8 || e.KeyChar == '-') return;
            else
                e.Handled = true;
        }
        #endregion

        #region Изменение дизайна формы

        #region Проверка значения переключателя и вызов метода изменения цвета
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                OptionsForm.Options.design = "standart";
                foreach (var form in Application.OpenForms)
                {
                    ReColour(SystemColors.Info, Color.CadetBlue, (Form)form, true);
                }
            }
            else if (radioButton2.Checked)
            {
                OptionsForm.Options.design = "simple";
                foreach (var form in Application.OpenForms)
                {
                    ReColour(Color.Black, Color.White, (Form)form, false);
                }
            }
        }
        #endregion

        #region Метод изменения цвета элементов определенной формы
        public void ReColour(Color forecolor, Color backcolor, Form Form, bool change)
        {
            if (change == true)
            {
                Form.BackgroundImage = WindowsFormsApplication4.Properties.Resources.maxresdefault;
            }
            else if (change == false)
            {
                Form.BackgroundImage = null;
            }
            

            Form.ForeColor = forecolor;
            foreach (var control1 in Form.Controls)
            {
                if (control1 is Panel)
                {
                    foreach (var control2 in ((Panel)control1).Controls)
                    {
                        if (control2 is ComboBox)
                        {
                            ((ComboBox)control2).BackColor = backcolor;
                            ((ComboBox)control2).ForeColor = forecolor;

                        }
                        else if (control2 is CheckBox)
                        {
                            ((CheckBox)control2).ForeColor = forecolor;
                        }
                        else if (control2 is TextBox)
                        {
                            ((TextBox)control2).BackColor = backcolor;
                            ((TextBox)control2).ForeColor = forecolor;
                        }
                        else if (control2 is Button)
                        {
                            ((Button)control2).BackColor = backcolor;
                            ((Button)control2).ForeColor = forecolor;
                        }
                    }
                }
                else
                {
                    if (control1 is Button)
                    {
                        ((Button)control1).BackColor = backcolor;
                    }
                    else if (control1 is ListBox)
                    {
                        ((ListBox)control1).BackColor = backcolor;
                        ((ListBox)control1).ForeColor = forecolor; 
                    }
                    else if (control1 is RichTextBox)
                    {
                        ((RichTextBox)control1).BackColor = backcolor;
                        ((RichTextBox)control1).ForeColor = forecolor;
                    }
                }
            }
        }
        #endregion

        #region Проверка переменной дизайна при загрузке формы
        private void Form2_Load(object sender, EventArgs e)
        {
            if (Options.design == "standart")
            {
                    ReColour(SystemColors.Info, Color.CadetBlue, ActiveForm, true);
                radioButton1.Checked = true;
            }
            else if (Options.design == "simple")
            {
                    ReColour(Color.Black, Color.White, ActiveForm, false);
                radioButton2.Checked = true;
            }

            string filename = "";
            string[] allFoundFiles = Directory.GetFiles("../Debug/Templates/", "*", SearchOption.AllDirectories);
            if (allFoundFiles.Length > 0)
            {
                foreach (var file in allFoundFiles)
                {
                    if (file.LastIndexOf(".txt") != -1)
                    {
                        filename = file.Substring(file.LastIndexOf("/") + 1);
                        filename = filename.Substring(0, filename.LastIndexOf("."));
                    }

                    TemplateCB.Items.Add(filename);
                }
            }
        }
        #endregion

        #region Сохранение шаблона
        private void SaveOptionsButton_Click(object sender, EventArgs e)
        {
            double test;
            string filename = TemplateNameTB.Text + ".txt";
            string[] allFoundFiles = Directory.GetFiles("../Debug/Templates/", filename, SearchOption.AllDirectories);

            if (allFoundFiles.Length > 0)
            {
                MessageBox.Show("Шаблон с таким названием уже существует");
            }
            else
            {
                string savestring = "../Debug/Templates/" + filename;
                string savecontent = "";

                string fontname = "", fontSize = "", fontColour = "", intAfterText = "", intBeforeText = "", ind = "", indLeftText = "", indRightText = "", interval = "", intAfterHeader = "", 
                    intBeforeHeader = "", indLeftHeader = "", indRightHeader = "", justText = "", justHeader = "", doctype = "";

                #region Получение значений настроек
                if (FontNameCB.SelectedItem != null)
                {
                    fontname = FontNameCB.SelectedItem.ToString();   
                }
                if (double.TryParse(FontSizeCB.Text, out test))
                {
                    fontSize = FontSizeCB.Text;
                }
                if (FontColourCB.SelectedItem != null)
                {
                    fontColour = FontColourCB.SelectedItem.ToString();
                }
                if (double.TryParse(IntervalAfterCB.Text, out test))
                {
                    intAfterText = IntervalAfterCB.Text;
                }
                if (double.TryParse(IntervalBeforeCB.Text, out test))
                {
                    intBeforeText = IntervalBeforeCB.Text;
                }
                if (double.TryParse(IndentationCB.Text, out test))
                {
                    ind = IndentationCB.Text;
                }
                if (double.TryParse(IndentationLeftCB.Text, out test))
                {
                    indLeftText = IndentationLeftCB.Text;
                }
                if (double.TryParse(IndentationRightCB.Text, out test))
                {
                    indRightText = IndentationRightCB.Text;
                }
                if (IntervalComboBox.SelectedItem != null)
                {
                    interval = IntervalComboBox.SelectedItem.ToString();
                }
                if (double.TryParse(IntervalAfterHeaderCB.Text, out test))
                {
                    intAfterHeader = IntervalAfterHeaderCB.Text;
                }
                if (double.TryParse(IntervalBeforeHeaderCB.Text, out test))
                {
                    intBeforeHeader = IntervalBeforeHeaderCB.Text;
                }
                if (double.TryParse(IndentationLeftHeaderCB.Text, out test))
                {
                    indLeftHeader = IndentationLeftHeaderCB.Text;
                }
                if (double.TryParse(IndentationRightHeaderCB.Text, out test))
                {
                    indRightHeader = IndentationRightHeaderCB.Text;
                }

                if (JustificationCB.SelectedItem != null)
                {
                    justText = JustificationCB.SelectedItem.ToString();
                }
                if (JustificationHeaderCB.SelectedItem != null)
                {
                    justHeader = JustificationHeaderCB.SelectedItem.ToString();
                }
                if (DocTypeCB1.Checked)
                {
                    doctype = "Да";
                }
                else
                {
                    doctype = "Нет";
                }
                #endregion

                #region Создание текстового файла с настройками
                savecontent += "Название шрифта: " + fontname +";\r\n";
                savecontent += "Размер шрифта: " + fontSize + ";\r\n";
                savecontent += "Цвет текста: " + fontColour + ";\r\n";

                savecontent += "Интервал после (текст): " + intAfterText + ";\r\n";
                savecontent += "Интервал перед (текст): " + intBeforeText + ";\r\n";
                savecontent += "Первая строка (текст): " + ind + ";\r\n";
                savecontent += "Отступ слева (текст): " + indLeftText + ";\r\n";
                savecontent += "Отступ справа (текст): " + indRightText + ";\r\n";
                savecontent += "Междустрочный интервал (текст): " + interval + ";\r\n";

                savecontent += "Интервал после (заголовок): " + intAfterHeader + ";\r\n";
                savecontent += "Интервал перед (заголовок): " + intBeforeHeader + ";\r\n";
                savecontent += "Отступ слева (заголовок): " + indLeftHeader + ";\r\n";
                savecontent += "Отступ справа (заголовок): " + indRightHeader + ";\r\n";

                savecontent += "Выравнивание (текст): " + justText + ";\r\n";
                savecontent += "Выравнивание (заголовок): " + justHeader + ";\r\n";
                savecontent += "Есть титульник и содержание: " + doctype + ";\r\n";
                File.WriteAllText(savestring, savecontent);
                MessageBox.Show("Шаблон сохранен");
                TemplateCB.Items.Add(TemplateNameTB.Text);
                #endregion
            }
        }
        #endregion

        #region Изменение настроек при выборе шаблона
        private void TemplateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = TemplateCB.SelectedItem.ToString() + ".txt";
            string[] FoundFile = Directory.GetFiles("../Debug/Templates/", filename, SearchOption.AllDirectories);
            if (FoundFile.Length > 0)
            {
                try
                {
                    string[] TextLines = File.ReadAllLines("../Debug/Templates/" + filename);

                    for (int i = 0; i < TextLines.Length; i++)
                    {
                        TextLines[i] = TextLines[i].Substring(TextLines[i].LastIndexOf(":") + 1).TrimEnd(';').TrimStart(' ');
                    }

                    FontNameCB.SelectedIndex = FindIndex(FontNameCB, TextLines[0]);
                    FontSizeCB.Text = TextLines[1];
                    FontColourCB.SelectedIndex = FindIndex(FontColourCB, TextLines[2]);

                    IntervalAfterCB.Text = TextLines[3];
                    IntervalBeforeCB.Text = TextLines[4];
                    IndentationCB.Text = TextLines[5];
                    IndentationLeftCB.Text = TextLines[6];
                    IndentationRightCB.Text = TextLines[7];
                    IntervalComboBox.SelectedIndex = FindIndex(IntervalComboBox, TextLines[8]);

                    IntervalAfterHeaderCB.Text = TextLines[9];
                    IntervalBeforeHeaderCB.Text = TextLines[10];
                    IndentationLeftHeaderCB.Text = TextLines[11];
                    IndentationRightHeaderCB.Text = TextLines[12];

                    JustificationCB.SelectedIndex = FindIndex(JustificationCB, TextLines[13]);
                    JustificationHeaderCB.SelectedIndex = FindIndex(JustificationHeaderCB, TextLines[14]);
                    if (TextLines[15] == "Да")
                    {
                        DocTypeCB1.Checked = true;
                    }
                    else if (TextLines[15] == "Нет")
                    {
                        DocTypeCB1.Checked = false;
                    }
                }
                catch
                {
                }

            }
        }
        #endregion

        #region Получение индекса в combobox по значению
        private int FindIndex(ComboBox cb1, string Value)
        {
            for (int i = 0; i < cb1.Items.Count; i++)
            {
                if (cb1.Items[i].ToString() == Value)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #endregion

    }
}
