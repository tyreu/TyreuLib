using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;

namespace Tyreu
{
    namespace Documents
    {
        //class TyreuPdf
        //{
        //    /// <summary>
        //    /// Имя кодировки для корректного отображения кириллицы
        //    /// </summary>
        //    const string ENCODING = "cp1251";
        //    public enum Alignment { Left = 0, Center = 1, Right = 2, Justify = 3 }
        //    /// <summary>
        //    /// Путь для сохранения файла
        //    /// </summary>
        //    public string PathToSave { get; set; }
        //    /// <summary>
        //    /// PDF-документ
        //    /// </summary>
        //    public Document Doc { get; set; }
        //    /// <summary>
        //    /// Текущий шрифт документа
        //    /// </summary>
        //    public Font Font { get; set; }
        //    /// <summary>
        //    /// Базовый шрифт документа
        //    /// </summary>
        //    public BaseFont BFont { get; set; } = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //    /// <summary>
        //    /// Количество страниц документа
        //    /// </summary>
        //    public int CountPageNo => new PdfReader(PathToSave).NumberOfPages;
        //    /// <summary>
        //    /// Конвертация файла с расширением docx в файл с расширением pdf
        //    /// </summary>
        //    /// <param name="fileNames">Массив путей к файлам</param>
        //    private void ConvertToPdf(string[] fileNames)
        //    {
        //        TyreuWord word = new TyreuWord();
        //        foreach (string file in fileNames)
        //        {
        //            word.Document = word.Application.Documents.Open(file);
        //            word.Document.Activate();
        //            word.CloseDocument(true, false, true);
        //        }
        //    }
        //    /// <summary>
        //    /// Объединяет несколько pdf-файлов в один
        //    /// </summary>
        //    /// <param name="destinationFile">Путь к конечному pdf-файлу</param>
        //    /// <param name="sourceFiles">Пути к исходным pdf-файлам</param>
        //    public static void MergeFiles(string destinationFile, string[] sourceFiles)
        //    {
        //        int f = 0;
        //        // we create a reader for a certain document
        //        PdfReader reader = new PdfReader(sourceFiles[f]);
        //        // we retrieve the total number of pages
        //        int n = reader.NumberOfPages;
        //        Document document = new Document(reader.GetPageSizeWithRotation(1));// step 1: creation of a document-object
        //        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create)); // step 2: we create a writer that listens to the document
        //        document.Open();// step 3: we open the document
        //        PdfContentByte cb = writer.DirectContent;
        //        PdfImportedPage page;
        //        int rotation;
        //        // step 4: we add content
        //        while (f < sourceFiles.Length)
        //        {
        //            int i = 0;
        //            while (i < n)
        //            {
        //                i++;
        //                document.SetPageSize(reader.GetPageSizeWithRotation(i));
        //                document.NewPage();
        //                page = writer.GetImportedPage(reader, i);
        //                rotation = reader.GetPageRotation(i);
        //                if (rotation == 90 || rotation == 270)
        //                    cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
        //                else
        //                    cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
        //            }
        //            f++;
        //            if (f < sourceFiles.Length)
        //            {
        //                reader = new PdfReader(sourceFiles[f]);
        //                // we retrieve the total number of pages
        //                n = reader.NumberOfPages;
        //            }
        //        }
        //        // step 5: we close the document
        //        document.Close();
        //    }
        //    /// <summary>
        //    /// Конструктор класса MagmaPDF
        //    /// </summary>
        //    /// <param name="savePath">Путь к файлу</param>
        //    public TyreuPdf(string savePath)
        //    {
        //        Doc = new Document();
        //        Font = new Font(BFont, 12, Font.NORMAL, BaseColor.BLACK);
        //        PathToSave = savePath;
        //    }
        //    /// <summary>
        //    /// Создает PDF-документ
        //    /// </summary>
        //    /// <param name="pageSize">Размер страницы</param>
        //    /// <param name="marginLeft">Отступ слева</param>
        //    /// <param name="marginRight">Отступ справа</param>
        //    /// <param name="marginTop">Отступ сверху</param>
        //    /// <param name="marginBottom">Отступ снизу</param>
        //    public TyreuPdf CreatePdfDocument(Rectangle pageSize = null, float marginLeft = 0f, float marginRight = 0f, float marginTop = 2f, float marginBottom = 1f)
        //    {
        //        Doc = new Document(pageSize ?? PageSize.A4, marginLeft, marginRight, marginTop, marginBottom);//Объект документа пдф
        //        Doc.SetMarginMirroring(true);
        //        PdfWriter.GetInstance(Doc, new FileStream(PathToSave, FileMode.Create));//Создаем объект записи пдф-документа в файл
        //        Doc.Open();//Открываем документ
        //        return this;
        //    }
        //    /// <summary>
        //    /// Сохраняет и закрывает документ
        //    /// </summary>
        //    public TyreuPdf ClosePdfDocument()
        //    {
        //        Doc.Close();//Закрываем документ
        //        return this;
        //    }
        //    /// <summary>
        //    /// Создает таблицу в документе
        //    /// </summary>
        //    /// <param name="dataTable">Таблица с данными</param>
        //    /// <param name="caption">Заголовок</param>
        //    /// <param name="font">Шрифт</param>
        //    /// <returns></returns>
        //    public PdfPTable CreatePdfTable(DataTable dataTable, string caption, Font font = null)
        //    {
        //        //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
        //        PdfPTable table = new PdfPTable(dataTable.Columns.Count);
        //        //Добавим в таблицу общий заголовок
        //        PdfPCell cell = new PdfPCell(new Phrase(caption, font ?? Font));
        //        cell.Colspan = dataTable.Columns.Count;
        //        cell.HorizontalAlignment = 1;
        //        cell.Border = 0;
        //        table.AddCell(cell);
        //        //Сначала добавляем заголовки таблицы
        //        for (int i = 0; i < dataTable.Columns.Count; i++)
        //        {
        //            cell = new PdfPCell(new Phrase(dataTable.Columns[i].ColumnName, font ?? Font));
        //            //Фоновый цвет (необязательно, просто сделаем по красивее)
        //            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        //            table.AddCell(cell);
        //        }
        //        //Добавляем все остальные ячейки
        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //            for (int j = 0; j < dataTable.Columns.Count; j++)
        //                table.AddCell(new Phrase(dataTable.Rows[i][j].ToString(), font ?? Font));
        //        Doc.Add(table);
        //        return table;
        //    }
        //    /// <summary>
        //    /// Добавляет текст (параграф) в документ
        //    /// </summary>
        //    /// <param name="text">Текст параграфа</param>
        //    /// <param name="paragraphAlign">0 - по левому краю, 1 - по центру, 2 - по правому, 3 - по ширине листа</param>
        //    /// <param name="font">Шрифт текста</param>
        //    /// <returns></returns>
        //    public TyreuPdf AddParagraph(string text = "", Alignment paragraphAlign = Alignment.Left, Font font = null)
        //    {
        //        Paragraph paragraph = new Paragraph(text != "" ? text : Environment.NewLine, font ?? Font) { Alignment = (int)paragraphAlign };
        //        Doc.Add(paragraph);
        //        return this;
        //    }
        //}
    }
}