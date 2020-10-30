using System;

namespace ClassLibrary
{
    public class Episode
    {

                       
            private int viewers; //total viewers of an episode 
            private double score_sum; //total sum of all scores per viewer
            private double max_score; //maximum score traced from all the viewer scores



            // default construct
            public Episode() { }

        //custom construct
        public Episode(int viewers_,double score_sum_,double max_score_)
        {
            viewers = viewers_;
            score_sum = score_sum_;
            max_score = max_score_;
        }

                                    // getters & setters //

        //adding viewers without score(as if they all voted 0)
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


        //method for average score for each episode object
        public double GetAverageScore()
        { return (score_sum / viewers); }


        


    }
    }


