using buildxact_supplies.Services.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System;
using System.Collections.Generic;
using buildxact_supplies.Domain.Entities;

namespace buildxact_supplies.Services
{
    public class CsvService : ICsvService
    {
        public List<Supply> GetSuppliesFromHumphries()
        {
            var supplies = new List<Supply>();
            var rows = ReadHumphries();
            foreach (var row in rows)
            {
                var supply = new Supply(
                    Guid.Parse(row[0]),
                    row[1],
                    row[2], 
                    costAud: double.Parse(row[3]),
                    costUsd: null,
                    providerId: null,
                    materialType: null
                    );

                supplies.Add(supply);
            }

            return supplies;
        }

        private List<String[]> ReadHumphries()
        {
            var startupPath = Path.GetFullPath(@"..\..\..\");
            var csvPath = @"" + startupPath + "humphries.csv";

            var fieldDescriptionString = "identifier";
            var rows = new List<String[]>();

            using (TextFieldParser parser = new TextFieldParser(csvPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    if (fields[0] == fieldDescriptionString)
                    {
                        continue;
                    }

                    rows.Add(fields);
                }
            }

            return rows;
        }
    }
}
