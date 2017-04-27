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
            News.Add(new NewsDwarfModel("Bombe in München", "In Schwabing wurde eine Bombe gefunden", img, "Süddeutsche"));
            News.Add(new NewsDwarfModel("Lol ist schlechter als Dota", "Dota ist awesome, dass bestätigt das Fraunhofer institute", img, "Giga"));
            News.Add(new NewsDwarfModel("Morgen ist Donnerstag", "Studien beweisen das nach Dienstag Donnerstag kommt", img, "Bild"));
            News.Add(new NewsDwarfModel("Schalf ist geil", "Viele Menschen sind vom Schlaf sexuel erregt, so das Frauenhofer Institute", img, "Bild"));


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
