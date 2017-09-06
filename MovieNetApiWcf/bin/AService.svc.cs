﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject;
using System.Data.Entity;
using MovieNetDbProject.Interfaces;
using MovieNetDbProject.Mapper;

namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez AService.svc ou AService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AService<TDto, TEntity> : IAService<TDto, TEntity> where TEntity: class, IEntity, new()
                                                                    where TDto : class, IDto, new()
    {
        protected readonly ModelMovieNet Context;
        protected readonly IDbSet<TEntity> DbSet;
        protected readonly AMapper<TDto, TEntity> Mapper;
        public AService(ModelMovieNet context, AMapper<TDto, TEntity> mapper)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
            Mapper = mapper;
        }
        public virtual List<TDto> GetAll()
        {
            List<TEntity> models = DbSet.ToList();
            List<TDto> dtos = new List<TDto>();
            if (models != null)
            {
                foreach (TEntity model in models)
                {
                    TDto dto = new TDto();
                    dto = Mapper.ToDto(model);
                    dtos.Add(dto);
                }
            }
            return dtos;
        }

        public virtual TDto Upsert(TDto dto)
        {
            TEntity model = new TEntity();
            if (dto != null)
            {
                model = DbSet.FirstOrDefault(e => e.id == dto.id);
                if (model == null)
                {
                    model = Mapper.ToModel(dto);
                    DbSet.Add(model);
                }
                else
                {
                    model = Mapper.ToModel(dto);
                }
                Context.SaveChanges();
            }
            return Mapper.ToDto(model);
        }

        public virtual TDto GetById(int id)
        {
            TEntity model = DbSet.FirstOrDefault(c => c.id == id);
            TDto dto = new TDto();
            if (model != null)
                dto = Mapper.ToDto(model);
            return dto;
        }
    }
}