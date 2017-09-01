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

        public Utilisateur GetByLogin(string login, string password)
        {
            Utilisateur u = new Utilisateur();
            u = DbSet.FirstOrDefault(util => util.nom_utilisateur.Equals(login));
            if (u == null)
                return null;
            else if (!string.IsNullOrEmpty(password) && !u.mdp_utilisateur.Equals(password))
                return null;
            return u;
        }
    }
}
