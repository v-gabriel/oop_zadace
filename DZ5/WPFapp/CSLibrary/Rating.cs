using System;
using System.Collections.Generic;
using System.Text;

namespace CSLibrary
{
    public class Rating
    {
        private double average;

        public double Average { get => average; set => average = value; }
        public Rating()
        {
            Average = 0;
        }
        public override string ToString()
        {
            return $"{Average}";
        }
    }

}
