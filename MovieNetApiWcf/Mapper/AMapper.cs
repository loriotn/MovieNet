using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetApiWcf.Interfaces;
using System.Data.Entity;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf.Mapper
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

        public abstract TDto ToDto(TEntity model);
        public abstract ICollection<TDto> ToDto(ICollection<TEntity> models);
        public abstract TEntity ToModel(TDto dto);
        public abstract ICollection<TEntity> ToModel(ICollection<TDto> dtos);
    }
}
