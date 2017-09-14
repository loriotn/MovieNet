using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject.Dto;
using MovieNetDbProject;

namespace MovieNetApiWcf
{
    [ServiceContract]
    public interface IMarkService: IAService<MarkDto, Note>
    {
        [OperationContract]
        MarkDto GetMarkByUserIdAndMovieId(int userId, int movieId);
    }
}
