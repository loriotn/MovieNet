using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MovieNetApiWcf;
using MovieNetDbProject;

namespace MovieNet.ViewModel
{
    public class ViewModelLocator
    {
        public static MainViewModel MainVm { get; } = new MainViewModel();
        public static UserViewModel UserVm { get; } = new UserViewModel();
        public static FilmViewModel FilmVm { get; } = new FilmViewModel();
        public static WelcomeViewModel WelcomeVm { get; } = new WelcomeViewModel();
        public static ConnectWindowViewModel TestVm { get; } = new ConnectWindowViewModel();
    }
}