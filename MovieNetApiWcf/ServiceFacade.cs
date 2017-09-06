using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf
{
    public sealed class ServiceFacade
    {
        public UserService userService { get; private set; }
        public FilmService filmService { get; private set; }    
        private static readonly ServiceFacade serviceFacade = new ServiceFacade();
        private ModelMovieNet Context;
        public static ServiceFacade ServiceFacadeInstance
        {
            get { return serviceFacade; }
        }
        private ServiceFacade()
        {
            this.Context = ModelMovieNet.GetContext();
            userService = new UserService(Context);
            filmService = new FilmService(Context);
        }
    }
}