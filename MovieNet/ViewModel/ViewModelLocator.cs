using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MovieNetApiWcf;
using MovieNetDbProject;

namespace MovieNet.ViewModel
{
    public class ViewModelLocator
    {
        
        public static Service1 service = new Service1(new ModelMovieNet());
        public static MainViewModel MainVm { get; } = new MainViewModel(service);
        public static UserViewModel UserVm { get; } = new UserViewModel(service);
        public static SignInViewModel SignInVm { get; } = new SignInViewModel(service);

    }
}