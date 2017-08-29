﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieNetDbProject;

namespace MovieNetApiWcf
{
    public sealed class ServiceFacade
    {
        public UserService userService;
        public FilmService filmService;
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