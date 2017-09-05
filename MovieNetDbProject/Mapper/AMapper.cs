using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Interfaces;
using System.Data.Entity;

namespace MovieNetDbProject.Mapper
{
    public abstract class AMapper <TDto, TEntity> where TDto: class, IDto , new()
                                         where TEntity: class, IEntity, new()
    {
        protected readonly ModelMovieNet Context;
        protected readonly IDbSet<TEntity> DbSet;

        public AMapper(ModelMovieNet context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public abstract TDto ToDto(TEntity models);

        public abstract TEntity ToModel(TDto dto);
    }
}
