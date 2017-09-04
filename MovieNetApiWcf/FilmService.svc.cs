﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject;
namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "FilmService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez FilmService.svc ou FilmService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class FilmService :AService<Film>, IFilmService
    {
        public FilmService(ModelMovieNet context) : base(context)
        {

        }
    }
}