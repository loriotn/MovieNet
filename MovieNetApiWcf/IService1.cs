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
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetName(int id);
        [OperationContract]
        string GetFirstName();
        [OperationContract]
        Utilisateur SetData();
        [OperationContract]
        Genre GetGenre();
        [OperationContract]
        Utilisateur GetUtilisateur(int id);
        [OperationContract]
        List<Utilisateur> GetUtilisateurs();
        [OperationContract]
        void Delete(int id);
        [OperationContract]
        List<Utilisateur> SearchUsers(string name);


    }
}
