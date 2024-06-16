using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WalkingWeatherWpf.ViewModel
{
    public class SearchCommand : ICommand
    {
        public WeatherViewModel WeatherViewModel { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SearchCommand(WeatherViewModel weatherViewModel)
        {
            WeatherViewModel = weatherViewModel;
        }

        public bool CanExecute(object parameter)
        {
            string query = parameter as string;
            return !string.IsNullOrWhiteSpace(query);
        }

        public void Execute(object parameter)
        {
            WeatherViewModel.MakeQuery();
        }
    }
}
