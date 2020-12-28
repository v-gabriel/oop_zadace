using System;
using System.ComponentModel;

namespace ClassLibrary
{
    public class Episode
    {

        //--------------------------
        private int viewers;  
        private double score_sum; 
        private double max_score;
        private Description description;

        public Description Description => description;
        public int Viewers => viewers;
        public double MaxScore => max_score;
        public double ScoreSum => score_sum;
        //--------------------------
        public Episode()
        {
            viewers = 0;
            score_sum = 0;
            max_score = 0;
            description = new Description(0,new TimeSpan(0,0,0),"");
        }

        public Episode(int viewers_,double score_sum_,double max_score_)
        {
            viewers = viewers_;
            score_sum = score_sum_;
            max_score = max_score_;
            description = new Description(0, new TimeSpan(0, 0, 0), "");
        }

        public Episode(int viewers_, double score_sum_, double max_score_,Description description)
        {
            viewers = viewers_;
            score_sum = score_sum_;
            max_score = max_score_;
            this.description = description;
        }

        //--------------------------

        public void AddView(int views)
        {
            this.viewers = views;
        }

        public void AddView(double score) 
        { 
            this.viewers += 1;
            if (score > max_score)
                max_score = score;

            this.score_sum += score;
        }

        public double GetMaxScore()
        { return max_score; }

        public int GetViewerCount()
        { return this.viewers;  }

        public double GetScoreSum() 
        { return this.score_sum;}

        public double GetAverageScore()
        { return (score_sum / viewers); }

        //--------------------------
        public static bool operator >=(Episode ep1, Episode ep2)
        {
            if (ep1.GetScoreSum() >= ep2.GetScoreSum())
                return true;
            else
                return false;
        }
        public static bool operator <=(Episode ep1, Episode ep2)
        {
            if (ep1.GetScoreSum() <= ep2.GetScoreSum())
                return true;
            else
                return false;
        }
        public static bool operator <(Episode ep1, Episode ep2)
        {
            if (ep1.GetScoreSum() < ep2.GetScoreSum())
                return true;
            else
                return false;
        }
        public static bool operator >(Episode ep1, Episode ep2)
        {
            if (ep1.GetScoreSum() > ep2.GetScoreSum())
                return true;
            else
                return false;
        }
        //-----------------------------
        public override string ToString()
        {
            return this.GetViewerCount()+","+this.GetScoreSum()+","+this.GetMaxScore()+","+this.description;
            //or return $"{this.GetViewerCount()},{this.GetScoreSum()},{this.GetMaxScore()},{this.description};
        }
        //----------------------------
        public TimeSpan GetDuration()
        {
            return description.Duration;
        }
        //----------------------------
    }
}


