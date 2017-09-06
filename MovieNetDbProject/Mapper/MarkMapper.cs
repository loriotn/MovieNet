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
            throw new NotImplementedException();
        }

        public override MarkDto ToDto(Note model)
        {
            throw new NotImplementedException();
        }

        public override ICollection<Note> ToModel(ICollection<MarkDto> dtos)
        {
            throw new NotImplementedException();
        }

        public override Note ToModel(MarkDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
