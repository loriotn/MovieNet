using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetApiWcf;
using MovieNetDbProject;

namespace MovieNet.ViewModel
{
    public class FilmViewModel : MainViewModel
    {
        private bool isFormValid;

        public bool IsFormValid
        {
            get { return isFormValid; }
            set
            {
                if (string.IsNullOrEmpty(Film?.titre_film) || Film == null)
                    isFormValid = false;
                else
                    isFormValid = true;
                RaisePropertyChanged();
            }
        }

        private Film film;

        public Film Film
        {
            get { return film; }
            set { film = value; RaisePropertyChanged(); }
        }

        public FilmService   filmService;
        private List<Film> films;

        public List<Film> Films
        {
            get { return films; }
            set { films = value; RaisePropertyChanged(); }
        }

        public FilmViewModel()
        {
            Film = new Film();
            Films = Facade.filmService.GetAll();
        }
    }
}
