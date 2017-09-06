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
            CommentDto dto = null;
            if (model != null)
            {
                dto = new CommentDto();
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
            throw new NotImplementedException();
        }
        public override ICollection<Commentaire> ToModel(ICollection<CommentDto> dtos)
        {
            throw new NotImplementedException();
        }
    }
}
