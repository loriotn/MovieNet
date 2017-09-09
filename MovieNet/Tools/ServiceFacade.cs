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
        private string azureConnectionString = "Server=tcp:movienetazure.database.windows.net,1433;Initial Catalog=MovieNetAzure;Persist Security Info=False;User ID=MovieNet;Password=M0vieNet;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        private string localConnectionString = "Data Source=pa-82t5l12\\localhost;Integrated Security=true;MultipleActiveResultSets=true;Initial Catalog=MovieNetDB";

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
            this.Context = ModelMovieNet.GetContext(localConnectionString);
            userService = new UserService(Context);
            filmService = new FilmService(Context);
            styleService = new StyleService(Context);
        }
    }
}