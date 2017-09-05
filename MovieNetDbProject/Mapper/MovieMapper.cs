using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Dto;
using MovieNetDbProject;

namespace MovieNetDbProject.Mapper
{
    public class MovieMapper: AMapper<MovieDto, Film>
    {
        public MovieMapper(ModelMovieNet context): base(context)
        {

        }
        public override Film ToModel(MovieDto dto)
        {
            throw new NotImplementedException();
        }
        public override MovieDto ToDto(Film model)
        {
            MovieDto Movie = null;
            if (model != null)
            {
                Movie = new MovieDto();
                Movie.id = model.id;
                Movie.averageMark = (int)Context.note.Where(n => n.id_film == model.id).Average(c => c.note);
                Movie.genre = model.genre;
                Movie.marks = model.note;
                Movie.commentaires = model.commentaire;
                Movie.resume = model.resume_film;
                Movie.titre = model.titre_film;
                Movie.commentaire = new Commentaire();
                Movie.newMark = new Note();
            }
            return Movie;
        }
    }
}
