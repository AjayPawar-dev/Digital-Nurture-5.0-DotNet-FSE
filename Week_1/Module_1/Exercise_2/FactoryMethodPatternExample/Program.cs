using System;

namespace FactoryMethodPatternExample
{
    // Interface for all document types
    public interface IDocument
    {
        void DisplayType();
    }

    // Concrete Product 1
    public class WordDocument : IDocument
    {
        public void DisplayType()
        {
            Console.WriteLine("Created a Word Document ");
        }
    }

    // Concrete Product 2
    public class PdfDocument : IDocument
    {
        public void DisplayType()
        {
            Console.WriteLine("Created a PDF Document ");
        }
    }

    // Concrete Product 3
    public class ExcelDocument : IDocument
    {
        public void DisplayType()
        {
            Console.WriteLine("Created an Excel Document ");
        }
    }

    // Abstract Factory
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    // Concrete Factory 1
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    // Concrete Factory 2
    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    // Concrete Factory 3
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }

    // Test Class
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory Method Pattern Example\n");

            DocumentFactory wordFactory = new WordDocumentFactory();
            IDocument wordDoc = wordFactory.CreateDocument();
            wordDoc.DisplayType();

            DocumentFactory pdfFactory = new PdfDocumentFactory();
            IDocument pdfDoc = pdfFactory.CreateDocument();
            pdfDoc.DisplayType();

            DocumentFactory excelFactory = new ExcelDocumentFactory();
            IDocument excelDoc = excelFactory.CreateDocument();
            excelDoc.DisplayType();

            Console.WriteLine("\nAll document types were created successfully.");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}