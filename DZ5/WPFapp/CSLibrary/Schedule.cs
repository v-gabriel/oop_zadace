using System;
using System.Collections.Generic;
using System.Text;

namespace CSLibrary
{
    public class Schedule
    {
        private string time;
        private List<string> days;

        public string Time { get => time; set => time = value; }
        public List<string> Days { get => days; set => days = value; }
        public Schedule()
        {
            Time = "";
            Days = new List<string>();
        }
        public override string ToString()
        {
            return $"{Time} {string.Join(",",Days)}";
        }
    }

}
