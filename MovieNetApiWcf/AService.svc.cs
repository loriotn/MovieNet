using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject;
using System.Data.Entity;
using MovieNetDbProject.Interfaces;

namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez AService.svc ou AService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AService<TEntity> : IAService<TEntity> where TEntity: class, IEntity, new()
    {
        protected readonly ModelMovieNet Context;
        protected readonly IDbSet<TEntity> DbSet;
        public AService(ModelMovieNet context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
        public virtual List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity Upsert(TEntity entity)
        {
            TEntity model = new TEntity();
            if (entity != null)
            {
                model = DbSet.FirstOrDefault(e => e.id == entity.id);
                if (model == null)
                {
                    DbSet.Add(entity);
                }
                else
                {
                    model = entity;
                }
                Context.SaveChanges();
            }
            return entity;
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(c => c.id == id);
        }
    }
}
