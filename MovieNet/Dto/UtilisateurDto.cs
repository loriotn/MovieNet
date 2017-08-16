using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.Dto
{
    class UtilisateurDto
    {
        public int id_utilisateur { get; set; }
        public string nom_utilisateur { get; set; }
        public string prenom_utilisateur { get; set; }
        public string mdp_utilisateur { get; set; }
        public bool connecte { get; set; }
        public bool inscrit { get; set; }
    }
}
