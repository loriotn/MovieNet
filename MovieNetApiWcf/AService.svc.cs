using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject;
using System.Data.Entity;


namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez AService.svc ou AService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AService<TEntity> : IAService<TEntity> where TEntity: class
    {
        protected readonly ModelMovieNet Context;
        protected readonly IDbSet<TEntity> DbSet;
        public AService(ModelMovieNet context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
        public List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
