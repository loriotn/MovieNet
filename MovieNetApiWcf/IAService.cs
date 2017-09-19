using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject.Interfaces;
namespace MovieNetApiWcf
{
    [ServiceContract]
    public interface IAService<TDto, TEntity> where TEntity : class, IEntity, new()
                                              where TDto : class, IDto, new()
    {
        [OperationContract]
        List<TDto> GetAll();

        [OperationContract]
        TDto Upsert(TDto dto);

        [OperationContract]
        TDto GetById(int id);

        [OperationContract]
        void Delete(int id);

    }
}
