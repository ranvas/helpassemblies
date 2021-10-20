﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.CommonExcel
{
    public class ExcelReader
    {
        public List<List<string>> GetRows(string fileName, char separator)
        {
            var rows = new List<List<string>>();
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = new List<string>();
                    rows.Add(line.Split(separator).ToList());
                }
            }
            return rows;
        }
    }
}
