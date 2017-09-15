using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetApiWcf;
using MovieNetDbProject;
using MovieNet.Tools;
using MovieNetDbProject.Dto;
using GalaSoft.MvvmLight.Command;

namespace MovieNet.ViewModel
{
    public class FilmViewModel : MainViewModel
    {
        public RelayCommand<int> ViewComment { get; private set; }
        public RelayCommand UpdateMovie { get; private set; }
        public RelayCommand NewMovie { get; private set; }
        public RelayCommand<string> UpdateNewMark { get; private set; }
        public RelayCommand UpdateComment { get; private set; }
        public double FontSize { get; set; }
        public double HeightGridMovie { get; set; }
        public double HeightTitle { get; set; }
        public double HeightComment { get; set; }
        public double HeightNewComment { get; set; }
        public double WidthNewComment { get; set; }
        public double WidthGridMovie { get; set; }
        public double WidthGridMovieComment { get; set; }
        public double WidthButtons { get; set; }
        public double WidthLittleButtons { get; set; }
        public double WidthAreaComment { get; set; }
        public double PosLineY{ get; set; }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; RaisePropertyChanged(); }
        }

        private StyleDto selectedStyle;

        public StyleDto SelectedStyle
        {
            get { return selectedStyle; }
            set { selectedStyle = value; RaisePropertyChanged(); SelectedMovie.genre = SelectedStyle; }
        }

        private static List<StyleDto> styles;

        public static List<StyleDto> Styles
        {
            get { return styles; }
            set { styles = value; }
        }

        private MovieDto selectedMovie;

        public MovieDto SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                RaisePropertyChanged();
            }
        }
        private List<CommentDto> commentsToShow;

        public List<CommentDto> CommentsToShow
        {
            get { return commentsToShow; }
            set { commentsToShow = value; RaisePropertyChanged(); }
        }

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
                if (string.IsNullOrEmpty(Film?.titre) || Film == null)
                    isFormValid = false;
                else
                    isFormValid = true;
                RaisePropertyChanged();
            }
        }

        private MovieDto film;

        public MovieDto Film
        {
            get { return film; }
            set { film = value; RaisePropertyChanged(); }
        }

        public FilmService   filmService;
        private List<MovieDto> films;

        public List<MovieDto> Films
        {
            get { return films; }
            set { films = value; RaisePropertyChanged(); }
        }

        public void initMovies()
        {
            if (this.Films == null)
                this.Films = ViewModelLocator.Facade.filmService.GetAll();
            if (Films != null)
            {
                foreach (MovieDto movie in Films)
                {
                    movie.newMark = ViewModelLocator.Facade.markService.GetMarkByUserIdAndMovieId(ViewModelLocator.MainVm.Utilisateur.id, movie.id);
                    movie.commentaire = ViewModelLocator.Facade.commentService.GetCommentByUserIdAndMovieId(ViewModelLocator.MainVm.Utilisateur.id, movie.id);
                }
            }
        }
        public FilmViewModel()
        {
            SelectedMovie = updateSelectedMovie(new MovieDto());
            HeightMovie = m.Height * 0.85;
            WidthMovie = m.Width - 20;
            HeightGridMovie = HeightMovie - HeightMovie * 0.05;
            HeightTitle = HeightMovie * 0.05;
            HeightNewComment = HeightGridMovie * 1 / 3;
            HeightComment = HeightGridMovie * 2 / 3;
            FontSize = (m.Height * m.Width) / 103680;
            WidthGridMovie = WidthMovie * 3 / 9;
            WidthGridMovieComment = WidthMovie * 4 / 9;
            WidthButtons = WidthMovie * 1 / 9;
            WidthLittleButtons = WidthButtons / 2;
            WidthAreaComment = WidthMovie - WidthGridMovie;
            WidthNewComment = WidthGridMovieComment + WidthButtons;
            PosLineY = HeightTitle + 3;
            ViewComment = new RelayCommand<int>(movie => { ViewCommentCan(movie); ViewCommentCanExecute(movie); });
            UpdateMovie = new RelayCommand(UpdateMovieCan, UpdateMovieCanExecute);
            UpdateNewMark = new RelayCommand<string>(operation => UpdateNewMarkCan(operation), UpdateNewMarkCanExecute);
            NewMovie = new RelayCommand(NewMovieCan, NewMovieCanExecute);
            UpdateComment = new RelayCommand(UpdateCommentCan, UpdateCommentCanExecute);
            Styles = ViewModelLocator.Facade.styleService.GetAll();
            initMovies();
        }

        public void UpdateCommentCan()
        {
            if (SelectedMovie == null)
                return;
            addOrUpdateComment(SelectedMovie);
            endUpdate();
        }
        private void addOrUpdateComment(MovieDto movie)
        {
            if (movie?.commentaire == null || ViewModelLocator.MainVm.Utilisateur == null)
            {
                return;
            }
            else
            {
                movie.commentaire.id_film = movie.id;
                movie.commentaire.id_utilisateur = ViewModelLocator.MainVm.Utilisateur.id;
            }
            if (movie?.commentaires == null)
            {
                movie.commentaires = new List<CommentDto>();
                movie.commentaires.Add(movie.commentaire);
            }
            else
            {
                bool inCommentList = false;
                foreach (CommentDto m in movie.commentaires)
                {
                    if (m.id_film == movie.id && m.id_utilisateur == ViewModelLocator.MainVm.Utilisateur.id)
                    {
                        m.commentaire = movie.commentaire.commentaire;
                        inCommentList = true;
                    }
                }
                if (!inCommentList)
                    movie.commentaires.Add(movie.commentaire);
            }
        }

        public bool UpdateCommentCanExecute() { return true; }
        public void NewMovieCan()
        {
            SelectedMovie = updateSelectedMovie(new MovieDto());
        }
        public bool NewMovieCanExecute() { return true; }
        public void UpdateNewMarkCan(string operation)
        {
            if (string.IsNullOrEmpty(operation) || SelectedMovie == null || SelectedMovie?.newMark == null)
                return;
            else if (operation.Equals("up") && SelectedMovie.newMark.mark < 20)
            {
                SelectedMovie.newMark.mark += 1;
            }
            else if (operation.Equals("down") && SelectedMovie.newMark.mark > 0)
            {
                SelectedMovie.newMark.mark -= 1;
            }
            SelectedMovie = updateSelectedMovie(SelectedMovie);
        }

        private MovieDto updateSelectedMovie(MovieDto toUpdate)
          {

            MovieDto temp = new MovieDto();
            temp = toUpdate;
            if (temp?.newMark == null)
                temp.newMark = new MarkDto();
            if (temp.commentaire == null)
                temp.commentaire = new CommentDto();
            return temp;
        }
        public bool UpdateNewMarkCanExecute(string operation) {return true;}


        private MovieDto getMovie(int id)
        {
            MovieDto dto = null;
            foreach (MovieDto d in Films)
            {
                if (d.id == id)
                    dto = d;
            }
            return dto;
        }
        public void UpdateMovieCan()
        {
            if (string.IsNullOrEmpty(SelectedMovie?.resume) || string.IsNullOrEmpty(SelectedMovie?.titre))
            {
                ErrorMessage = "Veuillez remplir tous les champs";
                return;
            }
            addOrUpdateNewMarkDto(SelectedMovie);
            endUpdate();
        }

        private void endUpdate()
        {
            ViewModelLocator.Facade.filmService.Upsert(SelectedMovie);
            Films = new List<MovieDto>();
            Films = ViewModelLocator.Facade.filmService.GetAll();
            initMovies();
            ErrorMessage = "";
            SelectedMovie = updateSelectedMovie(new MovieDto());
        }

        private void addOrUpdateNewMarkDto(MovieDto movie)
        {
            if (movie?.newMark == null || ViewModelLocator.MainVm.Utilisateur == null)
            {
                return;
            }
            else
            {
                movie.newMark.id_film = movie.id;
                movie.newMark.id_utilisateur = ViewModelLocator.MainVm.Utilisateur.id;
            }
            if (movie?.marks == null)
            {
                movie.marks = new List<MarkDto>();
                movie.marks.Add(movie.newMark);
            }
            else
            {
                bool inMarkList = false;
                foreach (MarkDto m in movie.marks)
                {
                    if (m.id_film == movie.id && m.id_utilisateur == ViewModelLocator.MainVm.Utilisateur.id)
                    {
                        m.mark = movie.newMark.mark;
                        inMarkList = true;
                    }
                }
                if (!inMarkList)
                    movie.marks.Add(movie.newMark);
            }
        }

        public bool UpdateMovieCanExecute()
        {
            return true;
        }
        public void ViewCommentCan(int movie)
        {
            SelectedMovie = getMovieFromListMovie(movie);
            if (SelectedMovie != null)
            {
                CommentsToShow = SelectedMovie.commentaires.ToList();
            }
            else
            {
                CommentsToShow = new List<CommentDto>();
            }
        }
        public bool ViewCommentCanExecute(int movie) { return true; }

        private MovieDto getMovieFromListMovie(int id)
        {
            MovieDto toShow = null;
            if (id != 0 && Films != null)
            {
                foreach (MovieDto m in Films)
                {
                    if (m.id == id)
                    {
                        toShow = m;
                    }
                }
            }
            return toShow;
        }
        
    }
}
