using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_09NavrhoveVzory2
{
    abstract class DataProcessor // abstraktní nedokončená třída (jakási šablona)
    {
        public void ProcessData()
        {
            OpenFile();
            LoadData();
            Process();
            SaveResults();
        }

        protected abstract void LoadData(); // metoda bez definice

        protected abstract void Process();

        protected virtual void OpenFile()
        {
            Console.WriteLine("Opening file...");
        }

        protected virtual void SaveResults()
        {
            Console.WriteLine("Saving results...");
        }
    }

    class CsvDataProcessor : DataProcessor
    {
        protected override void LoadData() // metodu definuje až potomek
        {
            Console.WriteLine("Loading CSV data...");
        }

        protected override void Process()
        {
            Console.WriteLine("Processing CSV data...");
        }
    }

    class ExcelDataProcessor : DataProcessor
    {
        protected override void LoadData()
        {
            Console.WriteLine("Loading Excel data...");
        }

        protected override void Process()
        {
            Console.WriteLine("Processing Excel data...");
        }

        protected override void OpenFile()
        {
            Console.WriteLine("Opening Excel file...");
        }
    }

}