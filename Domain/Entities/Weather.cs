using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Weather
    {
        public Coord Coords { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public float Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Sys Sys { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public  int COD { get; set; }
        public long LastUpdate { get; set; }
    }

    public class Coord
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }

    public class Sys
    {
        public string Country { get; set; }
        public float Sunrise { get; set; }
        public float Sunset { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public float Temp_Main { get; set; }
        public float Temp_Max { get; set; }
    }

    public class Wind
    {
        public float Speed { get; set; }
        public float Deg { get; set; }
    }

    public class Rain
    {
        public float H {get; set;}
    }
    public class Clouds
    {
        public float All { get; set; }
        public float DT { get; set; }
    }
}
