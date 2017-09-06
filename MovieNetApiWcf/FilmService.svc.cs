using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetApiWcf;
using MovieNetApiWcf.Mapper;
using MovieNetApiWcf.Dto;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "FilmService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez FilmService.svc ou FilmService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class FilmService :AService<MovieDto, Film>, IFilmService
    {
        public FilmService() { }
        public FilmService(ModelMovieNet context) : base(context, new MovieMapper(context))
        {
        }
    }
}
