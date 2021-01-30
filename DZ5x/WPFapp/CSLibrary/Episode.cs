using System;
using System.Collections.Generic;
using System.Text;

namespace CSLibrary
{
    public class Episode
    {
        private string summary;
        private string type;
        private int number; 
        private int season;
        private string name;
        private int id;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Season { get => season; set => season = value; }
        public int Number { get => number; set => number = value; }
        public string Type { get => type; set => type = value; }
        public string Summary { get => summary; set => summary = value; }

        public override string ToString()
        {
            return $"Season: {season} | Episode: {number}\nSummary: {summary}";
        }

    }
}
