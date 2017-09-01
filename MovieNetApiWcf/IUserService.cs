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
    public interface IUserService
    {
        [OperationContract]
        Utilisateur GetByLogin(string login, string password);
    }
}
