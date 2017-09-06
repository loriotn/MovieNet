using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetApiWcf.Dto;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IFilmService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IFilmService: IAService<MovieDto, Film>
    {
    }
}
