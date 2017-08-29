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
    public interface IAService<TEntity> where TEntity : class
    {
        [OperationContract]
        List<TEntity> GetAll();

        [OperationContract]
        TEntity Upsert(TEntity entity);

        [OperationContract]
        TEntity GetById(int id);

    }
}
