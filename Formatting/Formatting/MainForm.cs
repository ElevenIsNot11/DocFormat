using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Метод переноса документа
        public static void Creating(string SourceFileName, string NewFileName) 
        {
                using (var mainDoc = WordprocessingDocument.Open(@SourceFileName, false))
                using (var resultDoc = WordprocessingDocument.Create(@NewFileName, WordprocessingDocumentType.Document))
                {
                        foreach (var part in mainDoc.Parts)
                        {
                            resultDoc.AddPart(part.OpenXmlPart, part.RelationshipId);

                        }
                }
        }
        #endregion

        #region Метод форматирования документа
        public static void Formating1(string SourceFileName, string CyrilFont, string FontSize, string FontColour1, DocumentFormat.OpenXml.Wordprocessing.JustificationValues Justification, 
            DocumentFormat.OpenXml.Wordprocessing.JustificationValues JustificationHeader, string Line1, string Before1, string BeforeHeader1, string After1, string AfterHeader1,
            string Indentation1, string IndentationLeft1, string IndentationLeftHeader1, string IndentationRight1, string IndentationRightHeader1, string doctype)
        {
            bool FirstListEnd = false;
            using (var doc = WordprocessingDocument.Open(SourceFileName, true))
            {
                
                Body body = doc.MainDocumentPart.Document.Body;
                var lstParagrahps = body.Descendants<Paragraph>().ToList();
                foreach (var para in lstParagrahps)
                {
                    if (FirstListEnd == true || doctype == "default") 
                    {
                        #region Создание атрибутов абзаца
                    SpacingBetweenLines SpacingBetweenLines1 = new SpacingBetweenLines() { Line = Line1, After = After1, Before = Before1, AfterAutoSpacing = false, 
                        BeforeAutoSpacing = false, LineRule = LineSpacingRuleValues.Auto }; //междустрочный интервал
                    SpacingBetweenLines SpacingBetweenLinesHeader1 = new SpacingBetweenLines() { Line = Line1, After = AfterHeader1, Before = BeforeHeader1, AfterAutoSpacing = false, 
                        BeforeAutoSpacing = false, LineRule = LineSpacingRuleValues.Auto }; //междустрочный интервал
                    Indentation indentation1 = new Indentation() { FirstLine = Indentation1, Left=IndentationLeft1, Right=IndentationRight1 }; //отступы
                    Indentation indentationheader1 = new Indentation() { FirstLine = "0", Left = IndentationLeftHeader1, Right = IndentationRightHeader1 }; //отступы
                    Justification justification1 = new Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center
                    };
                    Justification justificationheader1 = new Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center
                    };
                    DocumentFormat.OpenXml.Wordprocessing.Color HeaderFontColour = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = FontColour1 };
                    DocumentFormat.OpenXml.Wordprocessing.Color MarkColour = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = FontColour1 };
                    DocumentFormat.OpenXml.Wordprocessing.Color FontColour0 = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = FontColour1 };
                    ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
                    paragraphMarkRunProperties1.AppendChild<DocumentFormat.OpenXml.Wordprocessing.Color>(FontColour0);
                    NumberingProperties numbprop = new NumberingProperties() {  };
                    #endregion

                    #region Создание шрифта 1
                    var newFont0 = new RunFonts
                    {
                        Ascii = CyrilFont,
                        EastAsia = CyrilFont,
                        HighAnsi = CyrilFont
                    };
                    #endregion

                    #region Работа с абзацами
                    var ParProp1 = new ParagraphProperties(); //Новые свойства
                    var parprop = para.Descendants<ParagraphProperties>().FirstOrDefault(); //Старые свойства
                    if (parprop != null) //Если свойства параграфа существуют
                    {
                        #region Изменение абзацев
                        if (parprop.ParagraphStyleId != null) //Если у параграфа присутствует ID стиля
                        {
                            #region Изменение абзацев заголовков
                            if (parprop.ParagraphStyleId.Val == "1" || parprop.ParagraphStyleId.Val == "2" || parprop.ParagraphStyleId.Val == "3" || parprop.ParagraphStyleId.Val == "4" ||
                                parprop.ParagraphStyleId.Val == "5" || parprop.ParagraphStyleId.Val == "a9" || parprop.ParagraphStyleId.Val == "ab" || parprop.ParagraphStyleId.Val == "11" 
                                || parprop.ParagraphStyleId.Val == "a4" || parprop.ParagraphStyleId.Val == "af0") //Сравнение с ID заголовков
                            {
                                parprop.ParagraphStyleId.Val = "a4";
                                var color0 = paragraphMarkRunProperties1.Descendants<DocumentFormat.OpenXml.Wordprocessing.Color>().FirstOrDefault();
                                parprop.AppendChild<Justification>(justificationheader1);
                                parprop.AppendChild<SpacingBetweenLines>(SpacingBetweenLinesHeader1);
                                parprop.AppendChild<Indentation>(indentationheader1);
                                parprop.AppendChild<DocumentFormat.OpenXml.Wordprocessing.Color>(HeaderFontColour);
                                parprop.ParagraphMarkRunProperties.AppendChild<DocumentFormat.OpenXml.Wordprocessing.Color>(MarkColour);
                                parprop.ParagraphMarkRunProperties.AppendChild<FontSize>(new FontSize() {Val = FontSize});
                                parprop.ParagraphMarkRunProperties.AppendChild<RunFonts>(newFont0);
                            }
                            #endregion
                            #region Изменение абзацев текста
                            else //Если не заголовок
                            {
                                parprop.AppendChild<Justification>(justification1);
                                parprop.AppendChild<SpacingBetweenLines>(SpacingBetweenLines1);
                                parprop.AppendChild<Indentation>(indentation1);
                                try
                                {
                                    parprop.ParagraphMarkRunProperties.AppendChild<DocumentFormat.OpenXml.Wordprocessing.Color>(MarkColour);
                                    parprop.ParagraphMarkRunProperties.AppendChild<FontSize>(new FontSize() { Val = FontSize });
                                    parprop.ParagraphMarkRunProperties.AppendChild<RunFonts>(newFont0);
                                }
                                catch
                                {
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region Добавление параметров, в случае отсутствия ID стиля
                        else //Если ID отсутствует
                        {
                            var spacingbetweenlines0 = parprop.Descendants<SpacingBetweenLines>().FirstOrDefault();
                            var indentation0 = parprop.Descendants<Indentation>().FirstOrDefault();
                            var paragraphmarkrunprop0 = parprop.Descendants<ParagraphMarkRunProperties>().FirstOrDefault();
                            var color0 = parprop.Descendants<DocumentFormat.OpenXml.Wordprocessing.Color>().FirstOrDefault();
                            parprop.ReplaceChild<SpacingBetweenLines>(SpacingBetweenLines1, spacingbetweenlines0);
                            parprop.ReplaceChild<Indentation>(indentation1, indentation0);
                            parprop.ReplaceChild<ParagraphMarkRunProperties>(paragraphMarkRunProperties1, paragraphmarkrunprop0);
                            ParagraphStyleId psID = parprop.ParagraphStyleId; 
                        }
                        #endregion
                    }
                    #region Создание параметров, если они не существуют
                    else 
                    {
                        ParProp1.Append(SpacingBetweenLines1);
                        ParProp1.Append(indentation1);
                        ParProp1.Append(paragraphMarkRunProperties1);
                        para.AppendChild<ParagraphProperties>(ParProp1);
                    }
                    #endregion



                    #endregion

                    var subRuns = para.Descendants<Run>().ToList();
                    foreach (var run in subRuns)
                    {
                        var subRunProp = run.Descendants<RunProperties>().ToList().FirstOrDefault();

                        #region Создание атрибутов текста
                        FontSize FontSize1 = new FontSize() { Val = FontSize };
                        DocumentFormat.OpenXml.Wordprocessing.Color FontColour = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = FontColour1};
                        #endregion

                        #region Создание шрифта 2
                        var newFont = new RunFonts
                        {
                            Ascii = CyrilFont,
                            EastAsia = CyrilFont,
                            HighAnsi = CyrilFont
                        };
                        #endregion


                        #region Изменение атрибутов текста
                        if (subRunProp != null) //Если существует
                        {
                            var fontcolour = subRunProp.Descendants<DocumentFormat.OpenXml.Wordprocessing.Color>().FirstOrDefault();
                            subRunProp.Append(newFont);
                            subRunProp.Append(FontSize1);
                            subRunProp.ReplaceChild<DocumentFormat.OpenXml.Wordprocessing.Color>(FontColour, fontcolour);
                            subRunProp.Color = FontColour;
                        }
                        #endregion
                        #region Добавление атрибутов текста в случае их отсутствия 
                        else
                        { 
                            var tmpSubRunProp = new RunProperties();
                            tmpSubRunProp.AppendChild<RunFonts>(newFont);
                            tmpSubRunProp.AppendChild(FontSize1);
                            tmpSubRunProp.AppendChild<DocumentFormat.OpenXml.Wordprocessing.Color>(FontColour);
                            run.AppendChild<RunProperties>(tmpSubRunProp);
                        }
                        #endregion
                    }
                    }
                    #region Условие, определяющее, что цикл прошел через титульный лист и содержание
                    if (para.ParagraphProperties != null && para.ParagraphProperties.ParagraphStyleId != null)
                    {
                        if (para.ParagraphProperties.ParagraphStyleId.Val == "12" || para.ParagraphProperties.ParagraphStyleId.Val == "a3")
                            {
                                FirstListEnd = true;
                                continue;

                            }
                        
                    }
                    #endregion
                }
                doc.MainDocumentPart.Document.Save();
                doc.Close();

            }
        }
        #endregion


        string [] Paths = new string [100]; // Пути к файлам для загрузки
        #region Обработка нажатия по кнопке "Загрузить"
        private void button1_Click(object sender, EventArgs e)
        {
            
            var fileContent = string.Empty;
            var filePath = string.Empty;

            #region Диалоговое окно для выбора текстового документа
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "text files (.docx)|*.docx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            #endregion

            int StrInd = filePath.LastIndexOf('\\')+1; // Индекс для выделения названия файла из пути к нему
            FilesLB.Items.Add(filePath.Substring(StrInd)); // Выделение названия файла и добавление в листбокс

            #region Присвоение пустому элементу массива пути до файла
            for (int i = 0; i < Paths.Length-1; i++)
            {
                if (Paths[i] == null)
                {
                    Paths[i] = filePath;
                    break;
                }
            }
            #endregion
        }
        #endregion

        #region Закрытие формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Обработка нажатия по кнопке "Форматировать"
        private void button2_Click_1(object sender, EventArgs e)
        {

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
            string logtext = ""; //переменная для хранения данных о выполнении для журнала
            bool problems = false; //true = найдены ошибки, false = ошибок не найдено (стандарт)
            int counter = 0;
            string outputpath = FBD.SelectedPath+@"\";
            string filename = "";
            #region Цикл, вызывающий метод форматирования для каждого файла из списка
            for (int i = 0; i < FilesLB.Items.Count; i++)
            {
                problems = false;
                if (Paths[i] != null && FilesLB.Items[i].ToString() != "")
                {
                    counter++;
                    filename = FilesLB.Items[i].ToString();
                    logtext += DateTime.Now+" [log] Файл: "+filename+"\n";
                    try
                    {
                        Creating(Paths[i], outputpath + FilesLB.Items[i]);
                    }
                    catch
                    {
                        logtext += DateTime.Now + " [log] Ошибка при создании копии файла\n";
                        problems = true;
                    }
                    try
                    {
                        Formating1(outputpath + FilesLB.Items[i], OptionsForm.Options.Font, OptionsForm.Options.FontSize, OptionsForm.Options.FontColour, OptionsForm.Options.Justification, OptionsForm.Options.JustificationHeader, OptionsForm.Options.Line,
                            OptionsForm.Options.Before, OptionsForm.Options.BeforeHeader, OptionsForm.Options.After, OptionsForm.Options.AfterHeader, OptionsForm.Options.Indentation, OptionsForm.Options.IndentationLeft, OptionsForm.Options.IndentationLeftHeader,
                            OptionsForm.Options.IndentationRight, OptionsForm.Options.IndentationRightHeader, OptionsForm.Options.doctype);
                    }
                    catch
                    {
                        problems = true;
                        logtext += DateTime.Now + " [log] Ошибка при форматировании файла\n";
                    }
                }
                if (problems != true)
                {
                    logtext += DateTime.Now + " [log] Файл " + filename + " успешно отформатирован\n";
                }
            }
            logtext += DateTime.Now + " [log] Форматирование завершено \nПапка для вывода документов: "+outputpath;

            if (counter > 0)
            {
                try
                {
                    SqlCeCommand command = new SqlCeCommand("INSERT INTO Logs (Date, Text) VALUES (@Date, @Text)", logsTableAdapter.Connection);
                    command.Parameters.Add("@Date", DateTime.Now);
                    command.Parameters.Add("@Text", logtext);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch
                {
                    MessageBox.Show("Возникли проблемы при создании логов");
                }
            }

            #endregion
            #region Вывод сообщения о результате
            if (counter > 0 && problems == false)
            {
                MessageBox.Show("Форматирование успешно завершено! \n" + "Количество обработанных файлов: " + counter + "\n" + "Файлы можно найти по следующему пути: \n" + outputpath, "Результат");
            }
            else if (counter > 0 && problems == true)
            {
                MessageBox.Show("Во время форматирования возникли ошибки! \n" + "Количество обработанных файлов: " + counter + "\n" + "Файлы можно найти по следующему пути: \n" + outputpath, "Результат");
            }
            else
            {
                MessageBox.Show("Не выбраны файлы для форматирования", "Результат");
            }
            #endregion
            }

        }
        #endregion

        #region Обработка нажатия по кнопке "Настройки"
        private void Options_Click(object sender, EventArgs e)
        {
            OptionsForm newForm = new OptionsForm();
            newForm.Show();
        }
        #endregion

        #region Обработка нажатия по кнопке "Журнал"
        private void LogButton_Click(object sender, EventArgs e)
        {
            Log log1 = new Log();
            log1.Show();
        }
        #endregion

        #region Обработка двойного нажатия по файлу в списке
        private void FilesLB_DoubleClick(object sender, EventArgs e)
        {
            if (FilesLB.SelectedIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show("Удалить файл из списка?", "Удаление", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Paths[FilesLB.SelectedIndex] = null;
                    FilesLB.Items.RemoveAt(FilesLB.SelectedIndex);
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }
        #endregion

        #region Методы переноса файлов из проводника
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string fileExt;
            bool wrongtype = false;
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < objects.Length; i++)
                {
                    for (int j = 0; j < Paths.Length - 1; j++)
                    {
                        if (Paths[j] == null)
                        {
                            if (FilesLB.FindString(objects[i]) == -1)
                            {
                                if (objects[i].Split('.').Length > 1)
                                {
                                    fileExt = objects[i].Substring(objects[i].LastIndexOf('.'));
                                    if (fileExt == ".docx")
                                    {
                                        Paths[j] = objects[i];
                                        FilesLB.Items.Add(objects[i].Substring(objects[i].LastIndexOf('\\') + 1));
                                    }
                                    else
                                    {
                                        wrongtype = true;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                if (wrongtype == true)
                {
                    Application.OpenForms[0].TopMost = true;
                    MessageBox.Show(MainForm.ActiveForm, "Один или несколько файлов имеют расширение отличное от .docx");
                    Application.OpenForms[0].TopMost = false;

                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
    ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        #endregion




    }
}
