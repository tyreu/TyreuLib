using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Tyreu
{
    class TyreuPdf
    {
        /// <summary>
        /// Конвертация файла с расширением docx в файл с расширением pdf
        /// </summary>
        /// <param name="fileNames">Массив путей к файлам</param>
        private void ConvertToPdf(string[] fileNames)
        {
            TyreuWord word = new TyreuWord();
            foreach (string file in fileNames)
            {
                word.Document = word.Application.Documents.Open(file);
                word.Document.Activate();
                word.CloseDocument(true, false, true);
            }
        }
        public static void MergeFiles(string destinationFile, string[] sourceFiles)
        {
            int f = 0;
            // we create a reader for a certain document
            PdfReader reader = new PdfReader(sourceFiles[f]);
            // we retrieve the total number of pages
            int n = reader.NumberOfPages;
            //Console.WriteLine("There are " + n + " pages in the original file.");
            // step 1: creation of a document-object
            Document document = new Document(reader.GetPageSizeWithRotation(1));
            // step 2: we create a writer that listens to the document
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
            // step 3: we open the document
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage page;
            int rotation;
            // step 4: we add content
            while (f < sourceFiles.Length)
            {
                int i = 0;
                while (i < n)
                {
                    i++;
                    document.SetPageSize(reader.GetPageSizeWithRotation(i));
                    document.NewPage();
                    page = writer.GetImportedPage(reader, i);
                    rotation = reader.GetPageRotation(i);
                    if (rotation == 90 || rotation == 270)
                        cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                    else
                        cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                }
                f++;
                if (f < sourceFiles.Length)
                {
                    reader = new PdfReader(sourceFiles[f]);
                    // we retrieve the total number of pages
                    n = reader.NumberOfPages;
                }
            }
            // step 5: we close the document
            document.Close();
        }
        public static int CountPageNo(string strFileName) => new PdfReader(strFileName).NumberOfPages;

    }
}