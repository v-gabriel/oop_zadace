using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Season : IEnumerable<Episode>, IEnumerator //needs to implement given interface methods in order to use foreach statement(to iterate) --> IEnumerable uses foreach but needs IEnumerator to function
    {                                                       //<Episode> needed because we iterate trough our field of Episode types so that var can be used --> ex. foreach(var value in episodes) - if not stated, instead of var Episode needs to be added --> ex. foreach(Episode value in episodes) ...
        public int Length { get; private set; }
        private int seasonNo;
        private List<Episode> episodes;

        private int position = -1;//needed for IEnumerator methods
        //-----------------------------------------------
        public Season(int seasonNo, List<Episode> episodes)
        {
            this.seasonNo = seasonNo;
            this.episodes = new List<Episode>();
            this.episodes.AddRange(episodes);
            Length = episodes.Count;

            //or instead of this.episodes.AddRange(episodes)
            /*
             foreach (Episode value in episodes)
            {
                this.episodes.Add(new Episode(value.Viewers, value.ScoreSum, value.GetMaxScore(), value.Description));
            }  
            */
        }
        //-----------------------------------------------
        public Season(Season season)
        {
            this.seasonNo = season.seasonNo;
            this.Length = season.episodes.Count;
            //deep copy
            this.episodes = new List<Episode>();
            foreach (Episode value in season.episodes)
            {
                this.episodes.Add(new Episode(value.Viewers, value.ScoreSum, value.GetMaxScore(), value.Description));
            }
        }
        //-----------------------------------------------
        public Episode this[int index]
        {
            get { return episodes[index]; }
            set { episodes[index] = value; }
        }
        //-----------------------------------------------
        public override string ToString()
        {
            string season_display = "";
            season_display += $"Season {seasonNo}:\n";
            season_display += "=================================================\n";
            foreach(Episode value in episodes)
            {
                season_display += value;
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
            foreach (Episode value in episodes) 
                total_viewers += value.GetViewerCount();

            return total_viewers;
        }
        //-----------------------------------------------
        private TimeSpan GetTotalDuration()
        {
            TimeSpan total_duration = new TimeSpan(0, 0, 0);
            foreach (Episode value in episodes) 
                total_duration += value.GetDuration();

            return total_duration;
        }
        //-----------------------------------------------
        //needed for IEnumerator interface
        public bool MoveNext() //moves trough and indicates whether the collection came to an end
        {
            position++;
            return (position < episodes.Count);
        }
        public void Reset() //resets position
        {
            position = -1;
        }
        public object Current //returns object at current position
        {
            get { return episodes[position]; }
        }
        //needed for iterating using foreach(IEnumerable interface)
        public IEnumerator<Episode> GetEnumerator()
        {
            return ((IEnumerable<Episode>)episodes).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)episodes).GetEnumerator();
        }
        //-----------------------------------------------
        //Add/Remove methods
        public void Add(Episode episode)
        {
            if(episodes.Contains(episode))
            { throw new TvException("Episode already exists.",episode.Description.Name); }

            episodes.Add(episode);
        }
        public void Remove(string name)
        { 
            Episode episode = new Episode();
            foreach(Episode value in episodes)
            {
                if (value.Description.Name == name)
                {
                    episode = value;
                }
            }
            if (!episodes.Contains(episode))
            { throw new TvException("No such episode found.", "Nope"); }

            episodes.Remove(episode);
        }
        //-----------------------------------------------

    }
}
