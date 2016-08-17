using MahMetroScoreTracker.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace MahMetroScoreTracker.ViewModels
{
    internal class EditMatchViewModel : ViewModelBase
    {
        public ObservableCollection<string> AllPlayers { get; private set; }
        public VenueType[] ValueTypes { get; private set; }
        public CompetitionType[] CompetitonTypes { get; private set; }
        public StartingPlayerViewModel[] StartingEleven { get; private set; }
        public ObservableCollection<Goal> Goals { get; private set; }
        public RelayCommand AddGoal { get; private set; }
        public RelayCommand RemoveGoal { get; private set; }
        public ObservableCollection<Substitution> Substitutions { get; private set; }
        public RelayCommand AddSub { get; private set; }
        public RelayCommand RemoveSub { get; private set; }

        private readonly Match match;
        private readonly ScoreViewModel halfTimeScore;
        private readonly ScoreViewModel fullTimeScore;
        private readonly ScoreViewModel extraTimeScore;
        private readonly ScoreViewModel penaltiesScore;
        private readonly ScoreViewModel aggregateScore;
        private Goal selectedGoal;
        private Substitution selectedSubstitution;

        public EditMatchViewModel(Match match, ObservableCollection<string> allPlayers)
        {
            AllPlayers = allPlayers;
            this.match = match;
            ValueTypes = new[]
            {
                VenueType.Home,
                VenueType.Away,
                VenueType.Neutral
            };
            CompetitonTypes = new[]
            {
                CompetitionType.League,
                CompetitionType.FaCup,
                CompetitionType.LeagueCup,
                CompetitionType.ChampionsLeague,
                CompetitionType.Friendly,
            };
            StartingEleven = match.StartingEleven.Select((p, n) => new StartingPlayerViewModel(match.StartingEleven, n)).ToArray();

            halfTimeScore = new ScoreViewModel(GetMatchScore(match, ScoreType.HalfTime));
            fullTimeScore = new ScoreViewModel(GetMatchScore(match, ScoreType.FullTime));
            extraTimeScore = new ScoreViewModel(GetMatchScore(match, ScoreType.AfterExtraTime));
            penaltiesScore = new ScoreViewModel(GetMatchScore(match, ScoreType.Penalties));
            aggregateScore = new ScoreViewModel(GetMatchScore(match, ScoreType.Aggregate));

            Goals = new ObservableCollection<Goal>(match.Goals);
            AddGoal = new RelayCommand(OnAddGoal);
            RemoveGoal = new RelayCommand(OnRemoveGoal, o => o != null);

            Substitutions = new ObservableCollection<Substitution>(match.Substitutions);
            AddSub = new RelayCommand(OnAddSub);
            RemoveSub = new RelayCommand(OnRemoveSub, o => o != null);
        }

        private void OnRemoveSub(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnAddSub(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnRemoveGoal(object obj)
        {
            throw new NotImplementedException();
        }

        private void OnAddGoal(object obj)
        {
            throw new NotImplementedException();
        }

        private static Score GetMatchScore(Match match, ScoreType halfTime)
        {
            throw new NotImplementedException();
        }
    }
}