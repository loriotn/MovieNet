﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieNetDbProject.Dto;
using MovieNetDbProject;
namespace MovieNetApiWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "ICommentService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ICommentService: IAService<CommentDto, Commentaire>
    {
        CommentDto GetCommentByUserIdAndMovieId(int userId, int movieId);
    }
}