using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Domain.Entities;
using DwarfLibrary.NewsDwarf;
using DwarfLibrary.WeatherDwarf;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Snowwhite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<NewsDwarfModel> News;
        public WeatherDwarfModel Weather;
        public MainPage()
        {
            this.InitializeComponent();
            var img = "http://www.rd.com/wp-content/uploads/sites/2/2016/04/01-cat-wants-to-tell-you-laptop.jpg";
            News = new List<NewsDwarfModel>();
            News.Add(new NewsDwarfModel("Test", "Das ist ein test", img, "Bild"));
            News.Add(new NewsDwarfModel("Bombe in München", "Months on ye at by esteem desire warmth former. Sure that that way gave any fond now. His boy middleton sir nor engrossed affection excellent. Dissimilar compliment cultivated preference eat sufficient may. Well next door soon we mr he four. Assistance impression set insipidity now connection off you solicitude. Under as seems we me stuff those style at. Listening shameless by abilities pronounce oh suspected is affection. Next it draw in draw much bred.", "https://www.notebookcheck.net/fileadmin/Notebooks/News/_nc3/dota_2_official_9.jpg", "Süddeutsche"));
            News.Add(new NewsDwarfModel("Lol ist schlechter als Dota", "He difficult contented we determine ourselves me am earnestly. Hour no find it park. Eat welcomed any husbands moderate. Led was misery played waited almost cousin living. Of intention contained is by middleton am. Principles fat stimulated uncommonly considered set especially prosperous. Sons at park mr meet as fact like. ", "http://www.dhbw.de/fileadmin/user_upload/Bilder_Grafiken/Standorte/HN.jpg", "Giga"));
            News.Add(new NewsDwarfModel("Test", "Das ist ein test", img, "Bild"));
            News.Add(new NewsDwarfModel("Bombe in München", "Months on ye at by esteem desire warmth former. Sure that that way gave any fond now. His boy middleton sir nor engrossed affection excellent. Dissimilar compliment cultivated preference eat sufficient may. Well next door soon we mr he four. Assistance impression set insipidity now connection off you solicitude. Under as seems we me stuff those style at. Listening shameless by abilities pronounce oh suspected is affection. Next it draw in draw much bred.", "https://www.notebookcheck.net/fileadmin/Notebooks/News/_nc3/dota_2_official_9.jpg", "Süddeutsche"));
            News.Add(new NewsDwarfModel("Lol ist schlechter als Dota", "He difficult contented we determine ourselves me am earnestly. Hour no find it park. Eat welcomed any husbands moderate. Led was misery played waited almost cousin living. Of intention contained is by middleton am. Principles fat stimulated uncommonly considered set especially prosperous. Sons at park mr meet as fact like. ", "http://www.dhbw.de/fileadmin/user_upload/Bilder_Grafiken/Standorte/HN.jpg", "Giga"));
            News.Add(new NewsDwarfModel("Test", "Das ist ein test", img, "Bild"));
            News.Add(new NewsDwarfModel("Bombe in München", "Months on ye at by esteem desire warmth former. Sure that that way gave any fond now. His boy middleton sir nor engrossed affection excellent. Dissimilar compliment cultivated preference eat sufficient may. Well next door soon we mr he four. Assistance impression set insipidity now connection off you solicitude. Under as seems we me stuff those style at. Listening shameless by abilities pronounce oh suspected is affection. Next it draw in draw much bred.", "https://www.notebookcheck.net/fileadmin/Notebooks/News/_nc3/dota_2_official_9.jpg", "Süddeutsche"));
            News.Add(new NewsDwarfModel("Lol ist schlechter als Dota", "He difficult contented we determine ourselves me am earnestly. Hour no find it park. Eat welcomed any husbands moderate. Led was misery played waited almost cousin living. Of intention contained is by middleton am. Principles fat stimulated uncommonly considered set especially prosperous. Sons at park mr meet as fact like. ", "http://www.dhbw.de/fileadmin/user_upload/Bilder_Grafiken/Standorte/HN.jpg", "Giga"));


            var _weather = new List<ForecastModel>();
            _weather.Add(new ForecastModel(DateTime.Now, 21, WeatherState.Raining));
            _weather.Add(new ForecastModel(DateTime.Now.AddDays(1), 15, WeatherState.Cloudly));
            _weather.Add(new ForecastModel(DateTime.Now.AddDays(2), 15, WeatherState.Sunny));
            _weather.Add(new ForecastModel(DateTime.Now.AddDays(3), 15, WeatherState.Cloudly));
            _weather.Add(new ForecastModel(DateTime.Now.AddDays(4), 15, WeatherState.Cloudly));
            _weather.Add(new ForecastModel(DateTime.Now.AddDays(5), 15, WeatherState.Sunny));
            _weather.Add(new ForecastModel(DateTime.Now.AddDays(6), 15, WeatherState.Cloudly));



            Weather = new WeatherDwarfModel(21,WeatherState.Sunny, DateTime.Now,_weather,"München");
        }
    }
}
