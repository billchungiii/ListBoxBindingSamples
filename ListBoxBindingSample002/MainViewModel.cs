using BindingLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ListBoxBindingSample002
{
    public class MainViewModel : NotifyPropertyBase
    {
        public MainViewModel()
        {
            People = GetFakePeople();
        }

        private ObservableCollection<PersonViewModel> _people;
        public ObservableCollection<PersonViewModel> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }


        private ICommand _showCommand;
        public ICommand ShowCommand
        {
            get
            {
                _showCommand = _showCommand ?? new RelayCommand((x) =>
                {
                    var builder = new StringBuilder();

                    foreach (var p in People.Where((y) => y.IsSelected))
                    {
                        builder.AppendLine($"{p.Name} 是 {p.Age} 住在 {p.City}");
                    }

                    MessageBox.Show(builder.ToString());

                });
                return _showCommand;
            }
        }

        private ICommand _changeCommand;
        public ICommand ChangeCommand
        {
            get
            {
                _changeCommand = _changeCommand ?? new RelayCommand((x) => People[0].IsSelected = !People[0].IsSelected);
                return _changeCommand;
            }
        }

        private static ObservableCollection<PersonViewModel> GetFakePeople()
        {

            var people = new ObservableCollection<PersonViewModel>()
            {
                new PersonViewModel {Name = "小叮噹", Age = 21, City = "台北"},
                new PersonViewModel {Name = "葉大雄", Age = 23, City = "台北"},
                new PersonViewModel {Name = "胖虎", Age = 22, City = "台中"},
                new PersonViewModel {Name = "阿福", Age = 21, City = "高雄"},
                new PersonViewModel {Name = "魯夫", Age = 17, City = "桃園"},
                new PersonViewModel {Name = "索隆", Age = 37, City = "桃園"},
                new PersonViewModel {Name = "香吉士", Age = 28, City = "台南"},
                new PersonViewModel {Name = "羅賓", Age = 25, City = "新北"},
                new PersonViewModel {Name = "喬巴", Age = 11, City = "新北"},
                new PersonViewModel {Name = "娜美", Age = 24, City = "高雄"},
            };
            return people;
        }
    }
}
