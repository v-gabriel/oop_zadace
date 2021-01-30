using System;
using System.Collections.Generic;
using System.Text;

namespace CSLibrary
{
    public class Season
    {
        private List<Episode> episodes;
        private string summary;
        private string name;
        private string type;
        private int number;
        private string url;
        private int id;

        public int Id { get => id; set => id = value; }
        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public int Number { get => number; set => number = value; }
        public string Type { get => type; set => type = value; }
        public string Summary { get => summary; set => summary = value; }


        public List<Episode> Episodes { get => episodes; set => episodes = value; }

        public override string ToString()
        {
            string output = "";
            foreach(Episode value in episodes)
            {
                output+=$"Season: {Number} | Episode: {value.Number}";
             }
            return output;
        }
    }
}
