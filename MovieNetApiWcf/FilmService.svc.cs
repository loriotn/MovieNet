using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject;
using MovieNetDbProject.Mapper;
using MovieNetDbProject.Dto;
using System.Data.Entity.Migrations;

namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "FilmService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez FilmService.svc ou FilmService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class FilmService :AService<MovieDto, Film>, IFilmService
    {
        protected readonly MarkMapper markMapper;
        protected readonly CommentMapper commentMapper;
        public FilmService() { }
        public FilmService(ModelMovieNet context) : base(context, new MovieMapper(context))
        {
            markMapper = new MarkMapper(context);
            commentMapper = new CommentMapper(context);
        }
        public ICollection<MovieDto> MovieFilter(FilterCriteriaMovies filterObject)
        {
            ICollection<Film> models = new List<Film>();
            models = Context.film
                .Where(m => (filterObject.Title == "" || filterObject.Title == null) ? m.id > 0 : m.titre_film.ToLower().Contains(filterObject.Title.ToLower()))
                .Where(m => filterObject.IdType == 0 ? m.id > 0 : m.genre_id == filterObject.IdType)
                .Where(m => filterObject.NumberOfComments == -1 ? m.id > 0 : filterObject.OverOrBelowNumberOfComments ? m.commentaire.Count() > filterObject.NumberOfComments : m.commentaire.Count() <= filterObject.NumberOfComments).ToList();
            return Mapper.ToDto(models);
        }
        public override MovieDto Upsert(MovieDto dto)
        {
            List<CommentDto> comments = dto.commentaires.ToList();
            dto = base.Upsert(dto);
            if (dto != null)
            {
                DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                
                Context.film.FirstOrDefault(m => m.id == dto.id).register_date = d;
                Context.note.Where(n => n.id_film == dto.id).ToList().Clear();
                Context.commentaire.Where(c => c.id_film == dto.id).ToList().Clear();
                Context.SaveChanges();
                foreach (MarkDto m in dto.marks)
                {
                    Context.note.AddOrUpdate(markMapper.ToModel(m));
                }
                foreach (CommentDto c in comments)
                {
                    Context.commentaire.AddOrUpdate(commentMapper.ToModel(c));
                }
                Context.SaveChanges();
            }
            
            return Mapper.ToDto(Context.film.FirstOrDefault(f => f.id == dto.id));
        }
    }
}
