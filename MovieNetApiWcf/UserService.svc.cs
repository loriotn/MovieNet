using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieNetApiWcf;
using System.Data.Entity.Validation;
using MovieNetApiWcf.Dto;
using MovieNetApiWcf.Mapper;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf
{
     public class UserService :AService<UserDto, Utilisateur>, IUserService
    {
        public UserService(ModelMovieNet context): base(context, new UserMapper(context))
        {
        }

        public UserDto GetByLogin(string login, string password)
        {
            Utilisateur u = new Utilisateur();
            u = DbSet.FirstOrDefault(util => util.nom_utilisateur.Equals(login));
            if (u == null)
                return null;
            else if (!string.IsNullOrEmpty(password) && !u.mdp_utilisateur.Equals(password))
                return null;
            return Mapper.ToDto(u);
        }

        public UserDto GetByLogin(string login)
        {
            Utilisateur u = new Utilisateur();
            u = DbSet.FirstOrDefault(util => util.nom_utilisateur.Equals(login));
            if (u == null)
                return null;
            return Mapper.ToDto(u);
        }
    }
}
