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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "CommentService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez CommentService.svc ou CommentService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class CommentService :AService<CommentDto, Commentaire>, ICommentService
    {
        public CommentService() { }
        public CommentService(ModelMovieNet context) : base(context, new CommentMapper(context)) { }

        public CommentDto GetCommentByUserIdAndMovieId(int userId, int movieId)
        {
            Commentaire comment = null;
            if (userId != 0 && movieId != 0)
            {
                comment = new Commentaire();
                comment = Context.commentaire.FirstOrDefault(n => n.id_film == movieId && n.id_utilisateur == userId);
            }
            return Mapper.ToDto(comment);
        }
    }
}
