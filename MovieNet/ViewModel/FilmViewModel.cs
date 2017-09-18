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
        public FilmViewModel()
        {
            initVar();
            initGrids();
            initRelayCommands();
        }
        #region publicVar
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
        public double HeightMovie { get; set; }
        public double WidthMovie { get; set; }
        public MainWindowProperties m = MainWindowProperties.mainWindowProperties;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; RaisePropertyChanged(); }
        }
        public StyleDto SelectedStyle
        {
            get { return selectedStyle; }
            set { selectedStyle = value; RaisePropertyChanged(); SelectedMovie.genre = SelectedStyle; }
        }
        public static List<StyleDto> Styles
        {
            get { return styles; }
            set { styles = value; }
        }
        public MovieDto SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                RaisePropertyChanged();
                UpdateComment?.RaiseCanExecuteChanged();
            }
        }
        public List<CommentDto> CommentsToShow
        {
            get { return commentsToShow; }
            set { commentsToShow = value; RaisePropertyChanged(); }
        }
        public List<MovieDto> Films
        {
            get { return films; }
            set { films = value; RaisePropertyChanged(); }
        }
        #endregion

        #region privateVar
        private string errorMessage;
        private StyleDto selectedStyle;
        private static List<StyleDto> styles;
        private MovieDto selectedMovie;
        private List<CommentDto> commentsToShow;
        private List<MovieDto> films;
        #endregion

        #region methods
        #region privateMethods
        private void initVar()
        {
            SelectedMovie = updateSelectedMovie(new MovieDto());
            Styles = ViewModelLocator.Facade.styleService.GetAll();
            initMovies();
        }
        private void initRelayCommands()
        {
            ViewComment = new RelayCommand<int>(movie => { ViewCommentCan(movie); ViewCommentCanExecute(movie); });
            UpdateMovie = new RelayCommand(UpdateMovieCan, UpdateMovieCanExecute);
            UpdateNewMark = new RelayCommand<string>(operation => UpdateNewMarkCan(operation), UpdateNewMarkCanExecute);
            NewMovie = new RelayCommand(NewMovieCan, NewMovieCanExecute);
            UpdateComment = new RelayCommand(UpdateCommentCan, UpdateCommentCanExecute);
        }
        private void initGrids()
        {
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
        
        #endregion
        #region canMethods
        public void UpdateCommentCan()
        {
            if (SelectedMovie == null)
                return;
            addOrUpdateComment(SelectedMovie);
            endUpdate();
        }
        public void NewMovieCan()
        {
            SelectedMovie = updateSelectedMovie(new MovieDto());
        }
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
        #endregion
        #region canExecuteMethods
        public bool UpdateCommentCanExecute() { return SelectedMovie != null && SelectedMovie.id != 0; }
        public bool NewMovieCanExecute() { return true; }
        public bool UpdateNewMarkCanExecute(string operation) { return true; }
        public bool UpdateMovieCanExecute() { return true; }
        public bool ViewCommentCanExecute(int movie) { return true; }
        #endregion
        #region otherMethods
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
        #endregion
        #endregion
    }
}
