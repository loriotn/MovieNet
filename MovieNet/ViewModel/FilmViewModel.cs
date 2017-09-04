using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetApiWcf;
using MovieNetDbProject;
using MovieNet.Tools;

namespace MovieNet.ViewModel
{
    public class FilmViewModel : MainViewModel
    {
        public double HeightGridMovie { get; set; }
        public double HeightTitle { get; set; }
        public double HeightComment { get; set; }
        public double HeightNewComment { get; set; }
        public double WidthGridMovie { get; set; }
        public double WidthGridMovieComment { get; set; }
        public double WidthButtons { get; set; }
        public double WidthAreaComment { get; set; }

        private double heightMovie;

        public double HeightMovie
        {
            get { return heightMovie; }
            set { heightMovie = value; RaisePropertyChanged(); }
        }

        private double widthMovie;

        public double WidthMovie
        {
            get { return widthMovie; }
            set { widthMovie = value; RaisePropertyChanged(); }
        }
        MainWindowProperties m = MainWindowProperties.mainWindowProperties;

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
            HeightMovie = m.Height * 0.85;
            WidthMovie = m.Width - 20;
            HeightGridMovie = HeightMovie - HeightMovie * 0.08;
            HeightTitle = HeightMovie * 0.08;
            HeightNewComment = HeightMovie * 1 / 3;
            HeightComment = HeightMovie * 2 / 3;
            WidthGridMovie = WidthMovie * 3 / 9;
            WidthGridMovieComment = WidthMovie * 4 / 9;
            WidthButtons = WidthMovie * 1 / 9;
            WidthAreaComment = WidthMovie - WidthGridMovie;
            Film = new Film();
            Films = Facade.filmService.GetAll();
        }
    }
}
