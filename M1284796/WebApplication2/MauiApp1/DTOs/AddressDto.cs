using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.DTOs
{
    public class AddressDto:INotifyPropertyChanged
    {
        private string city;
        private string street;

        public string City { get => city; set { city = value; NPC(); } }
        public string Street { get => street; set { street = value; NPC(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NPC([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
