using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Description
    {
       //--------------------------
       private int ep_no;
       private TimeSpan duration;
       private string name;
       //--------------------------
       public Description(int ep_no,TimeSpan duration, string name)
       {
            this.ep_no = ep_no;
            this.duration = duration;
            this.name = name;
       }
       //-------------------------
       public override string ToString()
       {
       //or return ep_no+","+duration+","+name; 
            return $"{ep_no},{duration},{name}";
       }
       //-------------------------
       public TimeSpan Duration => duration; //property for getting duration





    }
}
