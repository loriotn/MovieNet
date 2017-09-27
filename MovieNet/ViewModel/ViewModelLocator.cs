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
        public static FilmViewModel FilmVm { get; } = new FilmViewModel();
        public static ConnectWindowViewModel TestVm { get; } = new ConnectWindowViewModel();
    }
}