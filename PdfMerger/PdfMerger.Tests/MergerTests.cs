namespace PdfMerger.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PdfMerger.Logic;
    using System.Collections.Generic;
    using System.IO;

    [TestClass]
    public class MergerTests
    {
        private Merger sut;
        private string outputPath;
        private string samplePdf;

        [TestInitialize]
        public void Setup()
        {
            this.sut = new Merger();
            this.outputPath = @"C:\tmp\results\result.pdf";
            this.samplePdf = @"C:\tmp\sample\1.pdf";

            if (File.Exists(this.outputPath))
                File.Delete(this.outputPath);
        }

        [TestMethod]
        public void MergeSingleFile()
        {
            this.Merge(1);
            Assert.IsTrue(File.Exists(this.outputPath));
        }

        [TestMethod]
        public void MergeTwoFiles()
        {
            this.Merge(2);
            Assert.IsTrue(File.Exists(this.outputPath));
        }

        [TestMethod]
        public void Merge3()
        {
            this.Merge(3);
            Assert.IsTrue(File.Exists(this.outputPath));
        }

        private void Merge(int times)
        {
            var input = new List<string>();
            for (int i = 0; i < times; i++)
                input.Add(this.samplePdf);

            this.sut.Merge(this.outputPath, input.ToArray());
        }
    }
}
