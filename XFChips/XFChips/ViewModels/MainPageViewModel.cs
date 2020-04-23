using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XFChips.Fonts;
using XFChips.Models;
using XFChips.ViewModel;

namespace XFChips.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            CountItems = "0";
            IconOrderBy = FontIcons.SortAZ;
            Games = new ObservableCollection<Game>();
            SelectedGames = new ObservableCollection<Game>();
            SelectGameCommand = new Command<Game>((param) => ExecuteSelectGameCommand(param));
            SortGamesCommand = new Command<string>(ExecuteSortGamesCommand);
            GetListGames();
        }

        public Command SelectGameCommand { get; }
        public Command SortGamesCommand { get; }
        public ObservableCollection<Game> Games { get; }
        public ObservableCollection<Game> SelectedGames { get; }

        private string _selectdGamesText;
        public string SelectedGamesText
        {
            get { return _selectdGamesText; }
            set { SetProperty(ref _selectdGamesText, value); }
        }

        private string _countItems;
        public string CountItems
        {
            get { return _countItems; }
            set { SetProperty(ref _countItems, value); }
        }

        private string _iconOrderBy;
        public string IconOrderBy
        {
            get { return _iconOrderBy; }
            set { SetProperty(ref _iconOrderBy, value); }
        }

        private bool _isVisibleSort;
        public bool IsVisibleSort
        {
            get { return _isVisibleSort; }
            set { SetProperty(ref _isVisibleSort, value); }
        }

        void GetListGames()
        {
            Games.Add(new Game()
            {
                gameId = 1,
                name = "Resident Evil",
                image = "resident_evil7.png"
            });
            Games.Add(new Game()
            {
                gameId = 2,
                name = "Horizon Zero Dawn",
                image = "horizon_zero_dawn.png"
            });
            Games.Add(new Game()
            {
                gameId = 3,
                name = "God Of War",
                image = "god_of_war.png"
            });
            Games.Add(new Game()
            {
                gameId = 4,
                name = "The Witcher III",
                image = "the_witcher_3.png"
            });
            Games.Add(new Game()
            {
                gameId = 5,
                name = "The Last Of Us Part II",
                image = "the_last_of_us_2_mini.png"
            });
            Games.Add(new Game()
            {
                gameId = 6,
                name = "DOOM Eternal",
                image = "doom_eternal.png"
            });
            Games.Add(new Game()
            {
                gameId = 7,
                name = "Dying Light",
                image = "dying_light.png"
            });
            Games.Add(new Game()
            {
                gameId = 8,
                name = "Mortal Kombat 11",
                image = "mortal_kombat_11.png"
            });
            Games.Add(new Game()
            {
                gameId = 9,
                name = "Red Dead Redemption II",
                image = "red_dead_redemption_2.png"
            });
            Games.Add(new Game()
            {
                gameId = 10,
                name = "Bloodborne",
                image = "bloodborne.png"
            });
        }

        private void ExecuteSelectGameCommand(Game param)
        {
            var game = Games.FirstOrDefault(p => p.gameId == param.gameId);
            if (game != null)
            {
                if (!game.selected)
                {
                    game.selected = true;
                    game.colorBackground = "#333E3A";
                    game.colorText = "#FFFFFF";

                    SelectedGames.Add(game);
                }
                else
                {
                    game.selected = false;
                    game.colorBackground = "#FFFFFF";
                    game.colorText = "#000000";

                    SelectedGames.Remove(game);
                }

                CountItems = SelectedGames.Count.ToString();
                IsVisibleSort = SelectedGames.Count > 0;
            }
        }

        private void ExecuteSortGamesCommand(string param)
        {
            bool orderByAZ = param.Contains(FontIcons.SortAZ);
            IconOrderBy = orderByAZ ? FontIcons.SortZA : FontIcons.SortAZ;
            IEnumerable<Game> items;

            if (orderByAZ)
                items = SelectedGames.OrderBy(p => p.name).ToList();
            else
                items = SelectedGames.OrderByDescending(p => p.name).ToList();

            SelectedGames.Clear();
            foreach (var item in items)
                SelectedGames.Add(item);
        }
    }
}
