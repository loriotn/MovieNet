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
        public FilmService filmService;
        private List<Film> films;

        public List<Film> Films
        {
            get { return films; }
            set { films = value; RaisePropertyChanged(); }
        }

        public FilmViewModel()
        {
            filmService = new FilmService(ModelMovieNet.GetContext());
            Films = filmService.GetAll();
        }
    }
}
