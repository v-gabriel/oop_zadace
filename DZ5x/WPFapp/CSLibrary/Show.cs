using System;
using System.Collections.Generic;
using CSLibrary;

namespace CSLibrary
{
    public class Show
    {
        private int id;
        private string url;
        private string name;
        private string type;
        private string language;
        private List<string> genres;
        private string status;
        private int runtime;
        private string premiered;
        private string officialSite;
        private Schedule schedule;
        private Rating rating;
        private string summary;
        private List<Season> seasons;

        private List<Episode> episodesNseasons;
        public List<Episode> EpisodesNSeasons { get=> episodesNseasons; set=> episodesNseasons=value; }

        public List<Season> Seasons { get=>seasons; set=>seasons=value; }
        public int Id { get => id; set => id = value; }
        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Language { get => language; set => language = value; }
        public List<string> Genres { get => genres; set => genres = value; }
        public string Status { get => status; set => status = value; }
        public int Runtime { get => runtime; set => runtime = value; }
        public string Premiered { get => premiered; set => premiered = value; }
        public string OfficialSite { get => officialSite; set => officialSite = value; }
        public Schedule Schedule { get => schedule; set => schedule = value; }
        public Rating Rating { get => rating; set => rating = value; }
        public string Summary { get => summary; set => summary = value; }
       

        public Show()
        {
            Id = 0;
            Url = "";
            Name = "";
            Type = "";
            Language = "";
            Genres = new List<string>();
            Status = "";
            Runtime = 0;
            Premiered = "";
            OfficialSite = "";
            Rating = new Rating();
            Summary = "";
            episodesNseasons = new List<Episode>();
        }

        public override string ToString()
        {
            return $"{Name}\n===========================\nType: {Type}\nPremiered: {Premiered}\nGenres: {string.Join(",",Genres)}\nOfficial site: {OfficialSite}\nLanguage: {Language}\nRating: {Rating}\nSchedule: {Schedule}\n\nSummary:\n{Summary}\n";
        }


    }
}
