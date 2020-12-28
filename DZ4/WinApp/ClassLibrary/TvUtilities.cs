using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
using System.IO;

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
        public static List<Episode> LoadEpisodesFromFile(string fileName)
        {
            //reads complete file --> each row represents an episode
            string[] episodesInput = File.ReadAllLines(fileName);

            //creates episode field equal to total episodes read from the file
            Episode[] episodes = new Episode[episodesInput.Length];

            //using length of array and Parse() method data is saved to needed places
            for (int i = 0; i < episodes.Length; i++)
            {
                episodes[i] = TvUtilities.Parse(episodesInput[i]);
            }
            List<Episode> list = new List<Episode>();
            foreach (Episode value in episodes)
            {
                list.Add(value); //++ return as List<Episode>
            }
            return list; 
        }







    }
}
