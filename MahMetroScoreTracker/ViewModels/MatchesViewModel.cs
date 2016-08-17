using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace MahMetroScoreTracker.ViewModels
{
    class MatchesViewModel : ViewModelBase
    {
        public RelayCommand NewMatch { get; set; }
        public RelayCommand EditMatch { get; set; }
        public RelayCommand DeleteMatch { get; set; }
        private MatchViewModel selectedMatch;      

        public MatchesViewModel(ObservableCollection<MatchViewModel> matches, RelayCommand newMatch, RelayCommand editMatch)
        {
            NewMatch = newMatch;
            EditMatch = editMatch;
            DeleteMatch = new RelayCommand(DeleteSelectedMatch, o => o != null);
            Matches = matches;
        }

        private void DeleteSelectedMatch(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this match record?", "Delete Match", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Matches.Remove(selectedMatch);
                selectedMatch = null;
            }
        }

        public ObservableCollection<MatchViewModel> Matches { get; private set; }

        public MatchViewModel SelectedMatch
        {
            get { return selectedMatch; }
            set
            {
                if (Equals(value, selectedMatch))
                    return;
                selectedMatch = value;
                OnPropertyChanged();
            }
        }
    }
}