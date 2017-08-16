using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MovieNetApiWcf;

namespace MovieNet.ViewModel
{
    public class ViewModelLocator
    {
        public static MainViewModel MainVm { get; } = new MainViewModel();
    }
}