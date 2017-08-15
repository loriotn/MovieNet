using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace MovieNetDbProject
{
    [DataContract]
    [Table("utilisateur")]
    public class Utilisateur
    {
        public Utilisateur()
        {
            commentaire = new List<Commentaire>();
            note = new List<Note>();
        }

        #region properties

        [Key]
        [Column("id_utilisateur")]
        public int id_utilisateur { get; set; }

        [Required]
        [StringLength(255)]
        [Column("nom_utilisateur")]
        public string nom_utilisateur { get; set; }

        [Required]
        [StringLength(255)]
        [Column("prenom_utilisateur")]
        public string prenom_utilisateur { get; set; }

        [Required]
        [StringLength(255)]
        [Column("mdp_utilisateur")]
        public string mdp_utilisateur { get; set; }

        [Column("connecte")]
        public bool connecte { get; set; }

        [Column("inscrit")]
        public bool inscrit { get; set; }

        public virtual ICollection<Commentaire> commentaire { get; set; }

        public virtual ICollection<Note> note { get; set; }
        #endregion
    }
}
