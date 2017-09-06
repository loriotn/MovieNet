using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject.Dto;
using MovieNetDbProject.Interfaces;
using MovieNetDbProject.Mapper;
using MovieNetDbProject;

namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IStyleService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IStyleService: IAService<StyleDto, Genre>
    {
    }
}
