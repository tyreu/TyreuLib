using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tyreu
{
    namespace Documents
    {
        //class TyreuExcel
        //{
        //    Excel.Application app;
        //    Excel.Worksheet sheet;
        //    Excel.ChartObjects myCharts;
        //    Excel.ChartObject myChart;
        //    Excel.Chart chart;
        //    Excel.SeriesCollection seriesCollection;
        //    Excel.Series series;
        //    public TyreuExcel()
        //    {
        //        Excel.Application app = new Excel.Application();
        //        app.Workbooks.Add(Type.Missing);
        //        Excel.Worksheet sheet = (Excel.Worksheet)app.Sheets[1];
        //    }
        //    private Excel.Chart CreateChart(Excel.XlChartType type, string BeginCell = "A1", string EndCell = "B5", bool HasLegend = false, bool HasTitle = true)
        //    {
        //        Excel.ChartObjects xlCharts = (Excel.ChartObjects)sheet.ChartObjects(Type.Missing);//создали диаграмму
        //        Excel.ChartObject myChart = xlCharts.Add(110, 0, 350, 250); //координаты диаграммы
        //        Excel.Chart chart = myChart.Chart;
        //        chart.HasLegend = HasLegend;//легенда диаграммы
        //        chart.HasTitle = HasTitle;//заголовок
        //        chart.ChartType = type;
        //        //Название оси Х
        //        ((Excel.Axis)chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
        //        ((Excel.Axis)chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Подпись оси Х";
        //        //Название оси Y
        //        ((Excel.Axis)chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).HasTitle = true;
        //        ((Excel.Axis)chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary)).AxisTitle.Text = "Подпись оси Y";
        //        seriesCollection = (Excel.SeriesCollection)chart.SeriesCollection(Type.Missing);
        //        series = seriesCollection.NewSeries();//для подписи осей
        //        series.Values = sheet.get_Range("A1", "E1");//ось Y
        //        series.XValues = sheet.get_Range("A2", "E2");//ось X
        //        chart.SetSourceData(sheet.Range[BeginCell, EndCell], Excel.XlRowCol.xlRows);//источник данных диаграммы
        //        return chart;
        //    }
        //    private void SaveChartAsPng(Excel.Chart chart, string path) => chart.Export("Диаграмма.png", "PNG", false);
        //    private void CloseBook(bool SaveChanges = true, bool exit = true)
        //    {
        //        app.ActiveWorkbook.Close(SaveChanges);
        //        if (exit) app.Quit();
        //    }
        //}
    }
}
