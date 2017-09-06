using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieNetApiWcf;
using MovieNetApiWcf.Dto;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf
{
    [ServiceContract]
    public interface IUserService: IAService<UserDto, Utilisateur>
    {
        [OperationContract]
        UserDto GetByLogin(string login, string password);
    }
}
