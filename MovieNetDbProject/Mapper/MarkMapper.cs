using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Dto;

namespace MovieNetDbProject.Mapper
{
    public class MarkMapper : AMapper<MarkDto, Note>
    {
        public MarkMapper(ModelMovieNet context): base(context) { }
        public override ICollection<MarkDto> ToDto(ICollection<Note> models)
        {
            List<MarkDto> dtos = null;
            if (models != null)
            {
                dtos = new List<MarkDto>();
                foreach (Note model in models)
                {
                    dtos.Add(ToDto(model));
                }
            }
            return dtos;
        }

        public override MarkDto ToDto(Note model)
        {
            MarkDto dto = null;
            if (model != null)
            {
                dto.id = model.id;
                dto.mark = model.note;
                dto.id_film = model.id_film;
                dto.id_utilisateur = model.id_utilisateur;
            }
            return dto;
        }

        public override ICollection<Note> ToModel(ICollection<MarkDto> dtos)
        {
            List<Note> models = null;
            if (dtos != null)
            {
                models = new List<Note>();
                foreach (MarkDto dto in dtos)
                {
                    models.Add(ToModel(dto));
                }
            }
            return models;
        }

        public override Note ToModel(MarkDto dto)
        {
            Note model = null;
            if (dto != null)
            {
                model = new Note();
                model.id = dto.id;
                model.id_film = dto.id_film;
                model.id_utilisateur = dto.id_utilisateur;
                model.note = dto.mark;
            }
            return model;
        }
    }
}
