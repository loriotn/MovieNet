using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Dto;

namespace MovieNetDbProject.Mapper
{
    public class CommentMapper: AMapper<CommentDto, Commentaire>
    {
        public CommentMapper(ModelMovieNet context): base(context) { }
        public override CommentDto ToDto(Commentaire model)
        {
            CommentDto dto = new CommentDto();
            if (model != null)
            {
                dto.commentaire = model.commentaire;
                dto.id_film = model.id_film;
                dto.id_utilisateur = model.id_utilisateur;
                dto.id = model.id;
            }
            return dto;
        }
        public override ICollection<CommentDto> ToDto(ICollection<Commentaire> models)
        {
            List<CommentDto> dtos = null;
            if (models != null)
            {
                dtos = new List<CommentDto>();
                foreach (Commentaire c in models)
                {
                    dtos.Add(ToDto(c));
                }
            }
            return dtos;
        }
        public override Commentaire ToModel(CommentDto dto)
        {
            Commentaire model = null;
            if (dto != null)
            {
                model = new Commentaire();
                model.id = dto.id;
                model.id_film = dto.id_film;
                model.id_utilisateur = dto.id_utilisateur;
                model.commentaire = dto.commentaire;
            }
            return model;
        }

        public override ICollection<Commentaire> ToModel(ICollection<CommentDto> dtos)
        {
            List<Commentaire> models = null;
            if (dtos != null)
            {
                models = new List<Commentaire>();
                foreach (CommentDto dto in dtos)
                {
                    models.Add(ToModel(dto));
                }
            }
            return models;
        }
    }
}
