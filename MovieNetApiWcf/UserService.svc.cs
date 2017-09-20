using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieNetDbProject;
using System.Data.Entity.Validation;
using MovieNetDbProject.Dto;
using MovieNetDbProject.Mapper;
using System.Data.Entity.Migrations;

namespace MovieNetApiWcf
{
     public class UserService :AService<UserDto, Utilisateur>, IUserService
    {
        public UserService() { }
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
        public UserDto GetByLogin(string login, int id)
        {
            Utilisateur u = new Utilisateur();
            u = DbSet.FirstOrDefault(util => util.nom_utilisateur.Equals(login));
            if (u == null)
                return null;
            else if (u.id == id)
                return null;
            else
                return Mapper.ToDto(u);
        }
        public override UserDto Upsert(UserDto dto)
        {
            if (dto?.id != 0)
            {
                DbSet.FirstOrDefault(u => u.id == dto.id).nom_utilisateur = dto.nom_utilisateur;
                DbSet.FirstOrDefault(u => u.id == dto.id).prenom_utilisateur = dto.prenom_utilisateur;
                DbSet.FirstOrDefault(u => u.id == dto.id).mdp_utilisateur = dto.mdp_utilisateur;
                Context.SaveChanges();
                return Mapper.ToDto(DbSet.FirstOrDefault(u => u.id == dto.id));
            }
            else
                return base.Upsert(dto);
        }
    }
}
