using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf.Dto
{
    public class CommentDto 
    {
        public int id_film { get; set; }
        public int id_utilisateur { get; set; }
        public string commentaire { get; set; }
        public virtual Film film { get; set; }
        public virtual Utilisateur utilisateur { get; set; }
    }
}
