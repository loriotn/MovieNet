using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MovieNetDbProject
{
    [Table("commentaire")]
    public class Commentaire
    {
        #region properties
        [Key]
        [Column("id_film", Order = 0)]
        public int id_film { get; set; }

        [Key]
        [Column("id_utilisateur", Order = 1)]
        public int id_utilisateur { get; set; }

        [Column("commentaire", TypeName = "text")]
        public string commentaire { get; set; }

        #endregion

        #region Foreign key
        public virtual Film film { get; set; }

        public virtual Utilisateur utilisateur { get; set; }

        #endregion
    }
}
