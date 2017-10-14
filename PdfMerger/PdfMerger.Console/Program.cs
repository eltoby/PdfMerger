namespace PdfMerger.Console
{
    using PdfMerger.Logic;
    using System.Diagnostics;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var merger = new Merger();
            var fiResult = new FileInfo("result.pdf");
            merger.Merge(fiResult.FullName, args);

            Process.Start(fiResult.FullName);
        }
    }
}
