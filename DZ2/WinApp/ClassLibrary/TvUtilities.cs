using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace ClassLibrary
{
    public class TvUtilities
    {

        //-----------------------------------------------
        public static double GenerateRandomScore()
        {
            Random rnd = new Random();
            int x;
            double y;

            //++
            //quick fix from DZ1-> 'do while' not needed
            //interval under .Next() DOES NOT include upper value so it will never exceed 10 


            x = rnd.Next(0, 10);
            y = rnd.NextDouble();


            //--> or rnd.NextDouble()*10
            
            double rnd1 = x + y;
            return rnd1;
        }
        //-----------------------------------------------
        public static Episode Parse(string episodesInput)
        {
            //splits into substrings so it can save data to needed places
            //(parses each element)
           

            string[] data = episodesInput.Split(',');

            //data for episode
            int viewers = int.Parse(data[0]);
            double scoresum = double.Parse(data[1]);
            double maxscore = double.Parse(data[2]);

            //data for episode description
            int ep_no = int.Parse(data[3]);
            TimeSpan duration = TimeSpan.Parse(data[4]);
            string name = data[5];

            Description description = new Description(ep_no, duration, name);


            return new Episode(viewers, scoresum, maxscore, description);

        }
        //-----------------------------------------------
        public static void Sort(Episode[] episodes) //sorts from highest to lowest
        {

            Episode tempep = new Episode(); 
            int i;
            int j;
            for (i = 0; i < episodes.Length; i++) 
            {
                for (j = 0; j < episodes.Length; j++)
                {
                    if (episodes[i] > episodes[j])

                    {
                        tempep = episodes[i];
                        episodes[i] = episodes[j];
                        episodes[j] = tempep;
                    }  
                }
            }
        }
        //-----------------------------------------------








    }
}
