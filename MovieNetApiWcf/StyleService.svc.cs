using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject.Interfaces;
using MovieNetDbProject.Dto;
using MovieNetDbProject.Mapper;
using MovieNetDbProject;

namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "StyleService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez StyleService.svc ou StyleService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class StyleService :AService<StyleDto, Genre>, IStyleService
    {
        public StyleService() { }
        public StyleService (ModelMovieNet context): base(context, new StyleMapper(context)) { }
    }
}
