﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SingleResponsibilityPrincipleNS
{
    public class Journal {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int Addentry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }

    class SingleResponsibilityPrinciple
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.Addentry("1re entrée");
            j.Addentry("Nouvelle page");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"C:\Users\mzeha\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);

            Read();
        }
    }
}
