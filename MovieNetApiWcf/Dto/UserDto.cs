using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetApiWcf.Interfaces;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf.Dto
{
    public class UserDto: IDto
    {
        public int id { get; set; }
        public string nom_utilisateur { get; set; }
        public string prenom_utilisateur { get; set; }
        public string mdp_utilisateur { get; set; }
        public bool connecte { get; set; }
        public bool inscrit { get; set; }
        public virtual ICollection<Commentaire> commentaire { get; set; }
        public virtual ICollection<Note> note { get; set; }
    }

}
    