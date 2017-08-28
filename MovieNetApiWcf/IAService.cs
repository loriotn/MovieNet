using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieNetApiWcf
{
    [ServiceContract]
    public interface IAService<TEntity> where TEntity : class
    {
        [OperationContract]
        List<TEntity> GetAll();
    }
}
