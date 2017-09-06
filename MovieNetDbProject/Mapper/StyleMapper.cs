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
            throw new NotImplementedException();
        }
        public override ICollection<StyleDto> ToDto(ICollection<Genre> models)
        {
            throw new NotImplementedException();
        }
        public override ICollection<Genre> ToModel(ICollection<StyleDto> dtos)
        {
            throw new NotImplementedException();
        }

        public override Genre ToModel(StyleDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
