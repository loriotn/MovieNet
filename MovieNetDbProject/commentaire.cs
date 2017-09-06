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
    [Table("commentaire")]
    public class Commentaire: IEntity
    {

        #region properties
        [Key]
        [Column("id_commentaire")]
        public int id { get; set; }

        [Column("id_film", Order = 0)]
        public int id_film { get; set; }

        [Column("id_utilisateur", Order = 1)]
        public int id_utilisateur { get; set; }

        [Column("commentaire", TypeName = "text")]
        public string commentaire { get; set; }

        #endregion

        #region Foreign key
        [ForeignKey("id_film")]
        public virtual Film film { get; set; }
        [ForeignKey("id_utilisateur")]
        public virtual Utilisateur utilisateur { get; set; }

        #endregion
    }
}
