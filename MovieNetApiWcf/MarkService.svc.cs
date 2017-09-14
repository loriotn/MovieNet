using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject.Dto;
using MovieNetDbProject;
using MovieNetDbProject.Mapper;

namespace MovieNetApiWcf
{
    public class MarkService : AService<MarkDto, Note>, IMarkService
    {
        public MarkService() { }
        public MarkService(ModelMovieNet context) : base(context, new MarkMapper(context)) { }
        public MarkDto GetMarkByUserIdAndMovieId(int userId, int movieId)
        {
            Note note = null;
            if (userId != 0 && movieId != 0)
            {
                note = new Note();
                note = Context.note.FirstOrDefault(n => n.id_film == movieId && n.id_utilisateur == userId);
            }
            return Mapper.ToDto(note);
        }
    }
}