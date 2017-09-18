using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MovieNetApiWcf;
using MovieNetDbProject;
using MovieNet.Tools;
namespace MovieNet.ViewModel
{
    public class ViewModelLocator
    {
        public static ServiceFacade Facade = ServiceFacade.ServiceFacadeInstance;
        public static MainViewModel MainVm { get; } = new MainViewModel();
        public static UserViewModel UserVm { get; } = new UserViewModel();
        public static FilmViewModel FilmVm { get; } = new FilmViewModel();
        public static WelcomeViewModel WelcomeVm { get; } = new WelcomeViewModel();
        public static ConnectWindowViewModel TestVm { get; } = new ConnectWindowViewModel();
        public static SaveMovieWindowViewModel SaveMovieVm { get; } = new SaveMovieWindowViewModel();
        public static StyleViewModel StyleVm { get; } = new StyleViewModel();
    }
}