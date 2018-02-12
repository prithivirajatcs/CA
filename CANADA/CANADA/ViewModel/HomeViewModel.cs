using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using CANADA.Interface;
using CANADA.Model;
using Xamarin.Forms;

namespace CANADA.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public INavigationService navigationService;

        bool ascending;

        bool _isPullToRefreshEnabled;
        public bool IsPullToRefreshEnabled
        {
            get { return this._isPullToRefreshEnabled; }
            set
            {
                this._isPullToRefreshEnabled = value;
                OnPropertyChanged("IsPullToRefreshEnabled");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HomeViewModel(INavigationService navService, AboutCanandaListModel args)
        {
            navigationService = navService;

            List = new ObservableCollection<CAList>(args.calist);


            this.RemovePhotoCommand = new Command((obj) =>
            {


                if (!ascending)
                {
                    ascending = true;
                    var lo = List.OrderBy(X => X.title).ToList();
                    List = new ObservableCollection<CAList>(lo);


                }

                else
                {

                    ascending = false;

                    var lo = List.OrderByDescending(X => X.title).ToList();
                    List = new ObservableCollection<CAList>(lo);

                }

            });

            this.RefreshBestPracticesCommand = new Command( () =>
            {
                AboutCanandaListModel resposeList = App.MyApplicationDataSource.GetAboutList().Result;
                    IsPullToRefreshEnabled = false;


            });

        }

        ObservableCollection<CAList> _list;

        public ObservableCollection<CAList> List
        {
            get { return this._list; }
            set
            {
                this._list = value;
                OnPropertyChanged("List");
            }
        }



        public ICommand RemovePhotoCommand { get; set; }
        public ICommand RefreshBestPracticesCommand { get; set; }
    }
}
