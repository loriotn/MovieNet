using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using MovieNetApiWcf.Interfaces;

namespace MovieNetApiWcf.Model
{
    [DataContract]
    [Table("film")]
    public class Film : IEntity
    {
        public Film()
        {
            commentaire = new List<Commentaire>();
            note = new List<Note>();
        }

        #region properties

        [Key]
        [Column("id_film")]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("titre_film")]
        public string titre_film { get; set; }

        [Column("resume_film", TypeName = "text")]
        public string resume_film { get; set; }

        #endregion

        #region Foreign key
        [Column("id_genre")]
        public int id_genre { get; set; }
        public virtual ICollection<Commentaire> commentaire { get; set; }
        public virtual Genre genre { get; set; }
        public virtual ICollection<Note> note { get; set; }
        #endregion
    }
}