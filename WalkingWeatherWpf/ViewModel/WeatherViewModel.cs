using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WalkingWeatherWpf.Model;

namespace WalkingWeatherWpf.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string query;

        private CurrentConditions currentConditions;

        private City selectedCity;

        public WeatherViewModel()
        {
            SearchCommand = new SearchCommand(this);

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City()
                {
                    LocalizedName = "Taipei"
                };
                CurrentConditions = new CurrentConditions()
                {
                    WeatherText = "Partly cloudy",
                    Temperature = new Temperature()
                    {
                        Metric = new Units()
                        {
                            Value = 25
                        }
                    }
                };
            }
        }

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnPropertyChanged(nameof(CurrentConditions));
            }
        }

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }

        public SearchCommand SearchCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MakeQuery()
        {
            List<City> cities = AccuWeatherHelper.GetCities(Query.Trim());
        }
    }
}
