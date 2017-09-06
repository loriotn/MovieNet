using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieNetDbProject;
using MovieNetDbProject.Dto;

namespace MovieNetApiWcf
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserDto GetByLogin(string login, string password);
    }
}
