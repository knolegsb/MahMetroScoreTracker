using MahMetroScoreTracker.Model;
using MahMetroScoreTracker.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MahMetroScoreTracker.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private readonly Action<UserControl> navigateToView;
        private MatchesView matchesView;
        private StatsView statsView;
        private int selectedTabIndex;

        public RelayCommand NewMatch { get; private set; }
        public RelayCommand ViewMatches { get; private set; }
        public RelayCommand ViewStats { get; private set; }
        public RelayCommand Exit { get; private set; }
        public RelayCommand Publish { get; private set; }
        public RelayCommand Settings { get; private set; }
        public ObservableCollection<string> AllPlayers { get; private set; }

        public EditMatchViewModel EditMatchViewModel
        {
            get { return EditMatchViewModel; }
            set
            {
                if (Equals(value, EditMatchViewModel)) return;
                EditMatchViewModel = value;
                OnPropertyChanged();
            }
        }

        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set
            {
                if (value == selectedTabIndex) return;
                SelectedTabIndex = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(Action<UserControl> navigateToView)
        {
            this.navigateToView = navigateToView;
            
        }

        private void Initialize()
        {
            var matchesJson = File.ReadAllText("Matches.json");
            var matches = JsonConvert.DeserializeObject<List<Match>>(matchesJson, new StringEnumConverter());

            matchesView = new MatchesView();
            var matchViewModels = new ObservableCollection<MatchViewModel>(matches.Select(m => new MatchViewModel(m)));

            matchesView.DataContext = new MatchesViewModel(matchViewModels,
                new RelayCommand(_ => EditMatch(null)),
                new RelayCommand(m => EditMatch(((MatchViewModel)m).Match),
                    o => o != null));
        }

        private void EditMatch(Match m)
        {
            //var editMatchView = new EditMatchView();
            //editMatchView.DataContext = new EditMatchViewModel(m ?? Match.CreateNew(), AllPlayers);
            //navigateToView(editMatchView);
            EditMatchViewModel = new EditMatchViewModel(m ?? Match.CreateNew(), AllPlayers);
            SelectedTabIndex = 2;
        }
    }    
}
