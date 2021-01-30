using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSLibrary;
using Newtonsoft.Json;

namespace AppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Show mainshow = new Show();
        public MainWindow()
        {
 
            InitializeComponent();
        
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string title = NameInput.Text; //string entered next to "TV series name"
            string jsonInput = "";
                
            jsonInput = new WebClient().DownloadString("http://api.tvmaze.com/singlesearch/shows?q=" + title); //get main data and ID(used for later data 'catching'
    
            Show mainshow = JsonConvert.DeserializeObject<Show>(jsonInput);

            mainshow.Summary = mainshow.Summary.Replace("<p>", ""); //trim/replace
            mainshow.Summary = mainshow.Summary.Replace("</p>", "");
            mainshow.Summary = mainshow.Summary.Replace("<b>", ""); 
            mainshow.Summary = mainshow.Summary.Replace("</b>", "");

            jsonInput = new WebClient().DownloadString($"http://api.tvmaze.com/shows/"+ $"{mainshow.Id}/seasons"); //get seasons
            mainshow.Seasons= JsonConvert.DeserializeObject<List<Season>>(jsonInput);

            jsonInput = new WebClient().DownloadString($"http://api.tvmaze.com/shows/" + $"{mainshow.Id}/episodes"); //get episodes
            List<Episode> list= JsonConvert.DeserializeObject<List<Episode>>(jsonInput);


            foreach (Episode value in list)
            {
                value.Summary = value.Summary.Replace("<p>", "");
                value.Summary = value.Summary.Replace("</p>", "");
                value.Summary = value.Summary.Replace("<b>", "");
                value.Summary = value.Summary.Replace("</b>", "");
            }
            mainshow.EpisodesNSeasons.AddRange(list); //for display in list box



            GeneralInfo.Text = mainshow.ToString();
            SeasonsInfoList.ItemsSource = mainshow.EpisodesNSeasons;

            SeasonsInfoList.Items.Refresh();
            
        }

    }
}
