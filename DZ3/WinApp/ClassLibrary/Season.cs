using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Season
    {
        public int Length { get; private set; }
        private int seasonNo;
        private Episode[] episodes;
        //-----------------------------------------------
        public Season(int seasonNo, Episode[] episodes)
        {
            this.seasonNo = seasonNo;
            this.episodes = episodes;
            Length = episodes.Length;
        }
        //-----------------------------------------------
        //gets episode trough index --> season[0]==episodes[0]
        public Episode this[int index]
        {
            get { return episodes[index]; }
            set { episodes[index] = value; }
        }
        //-----------------------------------------------
        public override string ToString()
        {   
            //creates a display of all episodes in form of a string//

            string season_display = ""; //initialize empty string
            int i;
            season_display += $"Season {seasonNo}:\n";
            season_display += "=================================================\n";
            for (i = 0; i < Length; i++)
            {
                season_display += episodes[i]; //episodes[i] uses own ToString() method
                season_display += '\n';
            }
            season_display += "Report:\n";
            season_display += "=================================================\n";

            season_display += $"Total viewers: {this.GetTotalViewers()}\n";
            season_display += $"Total duration: {this.GetTotalDuration()}\n";
            season_display += "=================================================\n";
            
            return season_display;
        }
        //-----------------------------------------------
        private int GetTotalViewers()
        {
            int total_viewers = 0;
            foreach (Episode value in episodes) //for each episode get views and sum into total number of viewers
                total_viewers += value.GetViewerCount();

            return total_viewers;
        }
        //-----------------------------------------------
        private TimeSpan GetTotalDuration()
        {
            TimeSpan total_duration=new TimeSpan(0,0,0);
            foreach (Episode value in episodes) //for each episode get duration and sum into total duration
                total_duration += value.GetDuration();

            return total_duration;
        }
        //-----------------------------------------------
        //or replace last 2 methods with data atributes that are initialized in the constructor as shown below
        //(they would be implemented in the constructor)
        /*
        (...)

        private TimeSpan total_duration;
        private int total_viewers;

        public TimeSpan TotalDuration=> total_duration;
        public int TotalViewers=> total_viewers;
        (...)

         public Season(int seasonNo, Episode[] episodes)
        {
            this.seasonNo = seasonNo;
            this.episodes = episodes;
            Length = episodes.Length;


            int total_viewers = 0;
            foreach (Episode value in episodes)
                total_viewers += value.GetViewerCount();

            this.total_viewers=total_viewers;

    
            TimeSpan total_duration=new TimeSpan(0,0,0);
            foreach (Episode value in episodes) 
                total_duration += value.GetDuration();

            this.total_duration=total_duration;
        }

        (...)
        */
        //-----------------------------------------------


    }
}
