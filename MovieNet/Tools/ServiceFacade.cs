using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieNetDbProject;
using MovieNetApiWcf;

namespace MovieNet
{
    public sealed class ServiceFacade
    {
        public UserService userService { get; private set; }
        public FilmService filmService { get; private set; }
        public StyleService styleService { get; private set; } 
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
            styleService = new StyleService(Context);
        }
    }
}