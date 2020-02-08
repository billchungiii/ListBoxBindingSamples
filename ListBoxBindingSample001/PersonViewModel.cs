using BindingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxBindingSample001
{
    public class PersonViewModel : NotifyPropertyBase
    {
        private int _age;
        public int Age
        {
            get { return _age; }

            set { SetProperty(ref _age, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
       
    }
}
