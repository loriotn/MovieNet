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
        [Column("genre_id")]
        public int genre_id { get; set; }
        public virtual ICollection<Commentaire> commentaire { get; set; }
        public virtual ICollection<Note> note { get; set; }
        #endregion
    }
}
