using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassLibrary
{
    public class FilePrinter : IPrinter
    {
        private string directory;
        //-----------------------------------------------
        public FilePrinter(string directory)
        {
            this.directory = directory;
        }
        //-----------------------------------------------
        public void Print(string message)
        {
            using (StreamWriter writer = new StreamWriter(directory))
            {
                writer.WriteLine($"{message}");
            }
        }
        //-----------------------------------------------


    }
}
