using System;
using CSLibrary;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {

            //used for testing

            string jsonInput = "";
            string title = "friends";
            jsonInput = new WebClient().DownloadString("http://api.tvmaze.com/singlesearch/shows?q=" + title); //get main data and ID(used for later data 'catching'

            Show mainshow = JsonConvert.DeserializeObject<Show>(jsonInput);


            mainshow.Summary = mainshow.Summary.Replace("<p>", ""); //trim/replace
            mainshow.Summary = mainshow.Summary.Replace("</p>", "");
            mainshow.Summary = mainshow.Summary.Replace("<b>", "");
            mainshow.Summary = mainshow.Summary.Replace("</b>", "");

            jsonInput = new WebClient().DownloadString($"http://api.tvmaze.com/shows/" + $"{mainshow.Id}/seasons"); //get seasons
            mainshow.Seasons = JsonConvert.DeserializeObject<List<Season>>(jsonInput);

            jsonInput = new WebClient().DownloadString($"http://api.tvmaze.com/shows/" + $"{mainshow.Id}/episodes"); //get episodes
            List<Episode> list = JsonConvert.DeserializeObject<List<Episode>>(jsonInput);
            //Console.WriteLine(string.Join("\n", mainshow.Seasons));

            //Console.WriteLine(string.Join("\n", mainshow.Seasons));
            
            foreach (Episode value in list)
            {
                value.Summary = value.Summary.Trim('<', 'p', '>', '/'); // use replace**
            }

            mainshow.EpisodesNSeasons.AddRange(list);


            Console.WriteLine(mainshow.EpisodesNSeasons[0]);
            //Console.WriteLine(string.Join("\n", mainshow.EpisodesNSeasons));
        }
    }
}
