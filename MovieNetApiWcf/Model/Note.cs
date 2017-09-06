using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace MovieNetApiWcf.Model
{
    [DataContract]
    [Table("note")]
    public partial class Note
    {
        #region properties

        [Key]
        [Column("id_film", Order = 0)]
        public int id_film { get; set; }

        [Key]
        [Column("id_utilisateur", Order = 1)]
        public int id_utilisateur { get; set; }

        [Column("note")]
        public int note { get; set; }
       
        #endregion
        
        #region foreign key
        public virtual Film film { get; set; }

        public virtual Utilisateur utilisateur { get; set; }
        
        #endregion
    }
}
