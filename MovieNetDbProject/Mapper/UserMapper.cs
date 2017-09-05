using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Dto;
using MovieNetDbProject;

namespace MovieNetDbProject.Mapper
{
    public class UserMapper: AMapper<UserDto, Utilisateur>
    {
        public UserMapper(ModelMovieNet context): base(context)
        {

        }
        public override UserDto ToDto(Utilisateur model)
        {
            UserDto u = null;
            if (model != null)
            {
                u = new UserDto();
                u.inscrit = model.inscrit;
                u.mdp_utilisateur = model.mdp_utilisateur;
                u.nom_utilisateur = model.nom_utilisateur;
                u.note = model.note;
                u.prenom_utilisateur = model.prenom_utilisateur;
                u.commentaire = model.commentaire;
                u.connecte = model.connecte;
                u.id = model.id;
            }
            return u;
        }
        public override Utilisateur ToModel(UserDto dto)
        {
            Utilisateur u = null;
            if (dto != null)
            {
                u = new Utilisateur();
                u.inscrit = dto.inscrit;
                u.mdp_utilisateur = dto.mdp_utilisateur;
                u.nom_utilisateur = dto.nom_utilisateur;
                u.note = dto.note;
                u.prenom_utilisateur = dto.prenom_utilisateur;
                u.commentaire = dto.commentaire;
                u.connecte = dto.connecte;
            }
            return u;
        }
    }
}
