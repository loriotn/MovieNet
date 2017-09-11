using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Dto;

namespace MovieNetDbProject.Mapper
{
    public class StyleMapper: AMapper<StyleDto, Genre>
    {
        public StyleMapper(ModelMovieNet context): base(context) { }

        public override StyleDto ToDto(Genre model)
        {
            StyleDto dto = null;
            if (model != null)
            {
                dto = new StyleDto();
                dto.id = model.id;
                dto.label = model.label_genre;
            }
            return dto;
        }
        public override ICollection<StyleDto> ToDto(ICollection<Genre> models)
        {
            ICollection<StyleDto> dtos = null;
            if (models != null)
            {
                dtos = new List<StyleDto>();
                foreach (Genre g in models)
                {
                    dtos.Add(ToDto(g));
                }
            }
            return dtos;
        }
        public override ICollection<Genre> ToModel(ICollection<StyleDto> dtos)
        {
            throw new NotImplementedException();
        }

        public override Genre ToModel(StyleDto dto)
        {
            Genre model = null;
            if (dto != null)
            {
                model = new Genre();
                model.id = dto.id;
                model.label_genre = dto.label;
            }
            return model;
        }
    }
}
