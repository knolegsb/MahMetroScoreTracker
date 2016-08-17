
using MahMetroScoreTracker.Model;

namespace MahMetroScoreTracker.ViewModels
{
    class MatchViewModel
    {
        private Match match;

        public MatchViewModel(Match match)
        {
            this.match = match;
        }

        public Match Match { get { return match; } }
    }
}