using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieNetDbProject;

namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetName(int id);
        [OperationContract]
        string GetFirstName();
        [OperationContract]
        Utilisateur SetData();
    }
}
