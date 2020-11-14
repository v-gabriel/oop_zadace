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

        //--------------------------
        public Episode() { }

       
        public Episode(int viewers_,double score_sum_,double max_score_)
        {
            viewers = viewers_;
            score_sum = score_sum_;
            max_score = max_score_;
        }

        public Episode(int viewers_, double score_sum_, double max_score_,Description description) //++
        {
            viewers = viewers_;
            score_sum = score_sum_;
            max_score = max_score_;
            this.description = description;
        }

        //--------------------------

        
        // getters & setters //


        public void AddView(int views)
        {
            this.viewers = views;
       
        }

        //adds a viewer and his score; keeps track of max score and the total score
        public void AddView(double score) 
        { this.viewers += 1;
            if (score > max_score)
                max_score = score;
            this.score_sum += score;
            
        }

            public double GetMaxScore()
            { return max_score; }

            public int GetViewerCount()
            { return this.viewers;  }

        //gets total score given by the viewers(average)
        public double GetScoreSum() 
        { return this.score_sum;}


        //***gets average score per viewer
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
        }
        //-----------------------------

    }
}


