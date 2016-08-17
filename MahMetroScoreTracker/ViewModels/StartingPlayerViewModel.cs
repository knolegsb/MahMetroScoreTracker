using System.Collections.Generic;

namespace MahMetroScoreTracker.ViewModels
{
    class StartingPlayerViewModel : ViewModelBase
    {
        private readonly List<string> startingList;
        private readonly int index;

        public StartingPlayerViewModel(List<string> staringList, int index)
        {
            this.startingList = staringList;
            this.index = index;
        }

        public int Number { get { return index + 1; } }

        public string Name
        {
            get { return startingList[index]; }
            set
            {
                if (startingList[index] == value) return;
                startingList[index] = value;
                OnPropertyChanged();
            }
        }
    }
}