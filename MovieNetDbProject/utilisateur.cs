using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using MovieNetDbProject.Interfaces;

namespace MovieNetDbProject
{
    [DataContract]
    [Table("utilisateur")]
    public class Utilisateur: IEntity
    {
        public Utilisateur()
        {
            commentaire = new List<Commentaire>();
            notes = new List<Note>();
        }

        #region properties
        [DataMember]
        [Key]
        [Column("id_utilisateur")]
        public int id { get; set; }

        [DataMember]
        [Required]
        [StringLength(255)]
        [Column("nom_utilisateur")]
        public string nom_utilisateur { get; set; }

        [DataMember]
        [Required]
        [StringLength(255)]
        [Column("prenom_utilisateur")]
        public string prenom_utilisateur { get; set; }

        [DataMember]
        [Required]
        [StringLength(255)]
        [Column("mdp_utilisateur")]
        public string mdp_utilisateur { get; set; }

        [DataMember]
        [Column("connecte")]
        public bool connecte { get; set; }

        [DataMember]
        [Column("inscrit")]
        public bool inscrit { get; set; }

        public virtual ICollection<Commentaire> commentaire { get; set; }

        public virtual ICollection<Note> notes { get; set; }
        #endregion
    }
}
