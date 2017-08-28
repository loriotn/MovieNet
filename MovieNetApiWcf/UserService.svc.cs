using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieNetDbProject;
using System.Data.Entity.Validation;

namespace MovieNetApiWcf
{
     public class UserService :AService<Utilisateur>, IUserService
    {
        public UserService(ModelMovieNet context): base(context)
        {
        }
    }
}
