using buildxact_supplies.Services.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System;

namespace buildxact_supplies.Services
{
    public class CsvService : ICsvService
    {
        public void PrintHumphries()
        {
            string startupPath = Path.GetFullPath(@"..\..\..\");
            string csvPath = @"" + startupPath + "humphries.csv";

            using (TextFieldParser parser = new TextFieldParser(csvPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        Console.WriteLine(field);
                    }
                }
            }
        }
    }
}
