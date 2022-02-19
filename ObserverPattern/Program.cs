using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WeatherStation ws = new WeatherStation();
            NewsAgency na = new NewsAgency("ABN News");
            NewsAgency nb = new NewsAgency("ABB News");
            ws.Register(na);
            ws.Register(nb);

            ws.Temperature = 32.4f;
            ws.Temperature = 28.5f;
            Console.ReadLine();
        }
    }
}
