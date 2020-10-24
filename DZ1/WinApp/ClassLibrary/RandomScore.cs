using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary
{
   
    public class RandomScore
    {
        public static double GenerateRandomScore() 
        { Random rnd = new Random(); 
            int x;
                double y;
            do 
            { 
                x = rnd.Next(0, 10);
                y = rnd.NextDouble();
            }
            while ( (x + y) > 10); 
            //there is a possibility of generating x=10 and y>0, in that case new numbers are generated
            double rnd1 = x + y;
            //rnd.Next(0,10) creates a random int from [1,10];
            //rnd.NextDouble() creates a random double from 0.0-1.0
            //--> their combination is equal to a interval [0.0,10.0]
        
            return rnd1; 
        }

        //bonus
        public static int GenerateRandomView()
        {
            Random rnd = new Random();
            int rnd1;
            rnd1 = rnd.Next(1, 10);
            
            return rnd1;
        }
    }


    }

