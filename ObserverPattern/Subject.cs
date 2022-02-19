using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    //Step1 : Create observable interface with register, deregister and notify methods to add, remove and notify in case of change in propety(temperature)
    public interface Observable
    {
        void Register(Observer Obs);//register new observer
        void Notify();//notify all observers in case of change in temperature

    }

    //Step 2 : CReate an observer interface with Update method
    public interface Observer
    {
        void Update(Observable ovbl); // update the observer based on value provided.
    }

    //Step 3: Create a weatherstation observable implementing observable interface.
    public class WeatherStation : Observable
    {
        public List<Observer> stations;
        private float _temperature;

        //Ste4: Implementing setter methods so that all observers are notified on change in property.
        //Notify is called in setter method of property(temperature)
        public float Temperature 
            { 
                get { return _temperature; } 
                set 
                {
                    _temperature = value;
                    Notify();
                } 
            }
        //constructor initializing weather station.
        public WeatherStation()
        {
            stations = new List<Observer>();
        }

        //Step 5: Notify method updates each observer by passing "this" weather station object as parameter
        public void Notify()
        {
            stations.ForEach(o => { o.Update(this); });
        }

        //Register method resgisters the provided observer.
        public void Register(Observer Obs)
        {
            stations.Add(Obs);
        }

         
    }
    //Step 6: Create observer that implement the update method
    public class NewsAgency:Observer
    {
        public string AgencyName { get; set; }
        public NewsAgency(string agencyName)
        {
            AgencyName = agencyName;
        }

        public void Update(Observable ovbl)
        {
            if(ovbl is WeatherStation weatherStation)
            Console.WriteLine("The temperateure recoded is {0}", weatherStation.Temperature);
        }
    }
}
