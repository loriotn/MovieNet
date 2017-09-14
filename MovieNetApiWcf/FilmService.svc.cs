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
        public FilmService() { }
        public FilmService(ModelMovieNet context) : base(context, new MovieMapper(context))
        {
            markMapper = new MarkMapper(context);
        }

        public override MovieDto Upsert(MovieDto dto)
        {
            dto = base.Upsert(dto);
            if (dto != null)
            {
                Context.note.Where(n => n.id_film == dto.id).ToList().Clear();
                Context.SaveChanges();
                foreach (MarkDto m in dto.marks)
                {
                    Context.note.AddOrUpdate(markMapper.ToModel(m));
                }
                Context.SaveChanges();
            }
            return Mapper.ToDto(Context.film.FirstOrDefault(f => f.id == dto.id));
        }
    }
}
