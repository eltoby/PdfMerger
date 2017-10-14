namespace PdfMerger.Logic
{
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    using System;
    using System.Linq;

    public class Merger
    {
        public void Merge(string outPutPath, params string[] pdfPaths)
        {
            using (PdfDocument outPdf = new PdfDocument())
            {
                var itemNumber = 0;
                PdfPage actualPage = null;

                foreach (var path in pdfPaths)
                {
                    if (itemNumber % 2 == 0)
                        actualPage = AddFirstPagePart(outPdf, path);
                    else
                        DrawSecondPart(actualPage, path);
                    itemNumber++;
                }
                outPdf.Save(outPutPath);
            }
        }

        private static PdfPage AddFirstPagePart(PdfDocument outPdf, string path)
        {
            PdfPage actualPage;
            using (PdfDocument pdf = PdfReader.Open(path, PdfDocumentOpenMode.Import))
            {
                var page = pdf.Pages[0];
                actualPage = outPdf.AddPage(page);
            }

            return actualPage;
        }

        private static void DrawSecondPart(PdfPage actualPage, string path)
        {
            var gfx = XGraphics.FromPdfPage(actualPage);
            var image = XImage.FromFile(path);
            gfx.DrawImage(image, new System.Drawing.Point(0, Convert.ToInt32(actualPage.Height.Point) / 2));
        }
    }
}
