using System;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;
namespace Tyreu
{
    namespace Documents
    {
        //public class TyreuWord
        //{
        //    public string fileDocx, filePdf;
        //    private Word.Application application;
        //    private Word.Document document;
        //    private Word.Paragraph paragraph;
        //    private Word.Table table;
        //    public int TableCount { get; set; } = 0;
        //    public Word.Table Table { get => table; set => table = value; }
        //    public Word.Document Document { get => document; set => document = value; }
        //    public Word.Paragraph Paragraph { get => paragraph; set => paragraph = value; }
        //    public Word.Application Application { get => application; set => application = value; }
        //    public TyreuWord()
        //    {
        //        Application = new Word.Application();
        //        Document = Application.Documents.Add();
        //    }
        //    //создаём новый документ Word и задаём параметры листа
        //    public TyreuWord(string path, int centimetersMargin = 2)
        //    {
        //        Application = new Word.Application();
        //        Document = Application.Documents.Add();
        //        fileDocx = $"{path}.docx";
        //        filePdf = $"{path}.pdf";
        //        Document.PageSetup.LeftMargin = Application.CentimetersToPoints(1);
        //        Document.PageSetup.RightMargin = Application.CentimetersToPoints(1);
        //    }
        //    /// <summary>
        //    /// Добавить заголовок по центру документа
        //    /// </summary>
        //    /// <param name="text">Текст заголовка</param>
        //    /// <param name="size">Размер шрифта</param>
        //    /// <param name="FontName">Название шрифта</param>
        //    /// <param name="bold">Жирный? 1 - да, 0 - нет</param>
        //    public void AddCaption(string text, int size = 14, string FontName = "Times New Roman", int bold = 1)
        //    {
        //        AddParagraph();//создали параграф
        //        Paragraph.Range.Font.Name = FontName;//название шрифта
        //        Paragraph.Range.Font.Size = size;//размер
        //        Paragraph.Range.Font.Bold = bold;//жирность
        //        Paragraph.Range.Text = text; //текст
        //        Paragraph.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;//выравнивание по центру
        //    }
        //    /// <summary>
        //    /// Добавить таблицу в позицию курсора
        //    /// </summary>
        //    /// <param name="RowCount">Количество строк</param>
        //    /// <param name="ColumnCount"></param>
        //    /// <param name="size"></param>
        //    /// <param name="FontName"></param>
        //    /// <returns></returns>
        //    public Word.Table AddTable(int RowCount, int ColumnCount, int size = 12, string FontName = "Times New Roman")
        //    {
        //        if (RowCount < 1 || ColumnCount < 1) throw new ArgumentException("Кол-во строк и столбцов должно быть не меньше 1");
        //        TableCount++;
        //        Document.Paragraphs.Add(Type.Missing);
        //        Paragraph.Range.Tables.Add(Paragraph.Range, RowCount, ColumnCount, Word.WdDefaultTableBehavior.wdWord9TableBehavior, Word.WdAutoFitBehavior.wdAutoFitContent);
        //        Table = Document.Tables[TableCount];
        //        Table.Range.Font.Name = FontName;//название шрифта
        //        Table.Range.Font.Size = size;//размер текста
        //        Table.Columns.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPoints;
        //        Table.Rows.SetHeight(25f, Word.WdRowHeightRule.wdRowHeightAuto);//высота строк
        //        Table.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;//выравнивание строк (по центру)
        //        Table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;//выравнивание в ячейках (вертикальное центрирование)
        //        Table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
        //        return Table;
        //    }
        //    /// <summary>
        //    /// Объединение ячеек
        //    /// </summary>
        //    /// <param name="cellStart">Начальная ячейка</param>
        //    /// <param name="cellEnd">Конечная ячейка</param>
        //    public void MergeCells(object cellStart, object cellEnd)
        //    {
        //        Document.Range(ref cellStart, ref cellEnd).Select();
        //        Application.Selection.Cells.Merge();
        //    }
        //    /// <summary>
        //    /// Добавить текст в позицию курсора
        //    /// </summary>
        //    /// <param name="text">Текст, вставляемый в документ</param>
        //    /// <param name="size">Размер шрифта</param>
        //    /// <param name="FontName">Название шрифта</param>
        //    /// <param name="bold">Жирный? 1 - да, 0 - нет</param>
        //    public void AddText(string text, int size = 14, string FontName = "Times New Roman", int bold = 0)
        //    {
        //        AddParagraph();//создали параграф
        //        Paragraph.Range.Font.Name = FontName;//название шрифта
        //        Paragraph.Range.Font.Size = size;//размер
        //        Paragraph.Range.Font.Bold = bold;//жирность
        //        Paragraph.Range.Text = text; //текст
        //        Paragraph.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;//выравнивание по левому краю
        //    }
        //    /// <summary>
        //    /// Добавить новую строку
        //    /// </summary>
        //    /// <param name="count"></param>
        //    public void AddParagraph(int count = 1)
        //    {
        //        do Paragraph = Document.Paragraphs.Add(Type.Missing); while (count-- > 0);
        //    }
        //    public void AddPicture(string path)
        //        => Application.Selection.InlineShapes.AddPicture(path, true, false, Paragraph.Range);
        //    /// <summary>
        //    /// Вставить разрыв страницы
        //    /// </summary>
        //    public void InsertBreak() => Document.Paragraphs.Add(Type.Missing).Range.InsertBreak(Word.WdBreakType.wdPageBreak);
        //    /// <summary>
        //    /// Посчитать сумму чисел в ячейках
        //    /// </summary>
        //    /// <param name="cellValue">Массив ячеек</param>
        //    /// <returns></returns>
        //    public static double GetSumFromCells(params string[] cellValue) => cellValue.ToArray().Sum(cell => cell.Length > 0 ? double.Parse(cell.Substring(0, cell.Length - 1)) : 0);
        //    /// <summary>
        //    /// Сохранить и закрыть документ
        //    /// </summary>
        //    /// <param name="exit"></param>
        //    /// <param name="visible"></param>
        //    /// <param name="saveAsPdf"></param>
        //    public void CloseDocument(bool exit = false, bool visible = true, bool saveAsPdf = false)
        //    {
        //        //сохраняем документ, закрываем документ, выходим из Word
        //        Application.Visible = visible;
        //        Document.SaveAs(fileDocx);
        //        if (saveAsPdf) Document.SaveAs(filePdf, Word.WdSaveFormat.wdFormatPDF);
        //        Document.Close();
        //        if (exit) Application.Quit();
        //    }
        //}
    }
}