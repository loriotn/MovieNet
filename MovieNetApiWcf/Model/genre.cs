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
    [Table("genre")]
    public class Genre: IEntity
    {
        public Genre()
        {
            film = new List<Film>();
        }

        [Key]
        [Column("id_genre")]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("label_genre")]
        public string label_genre { get; set; }

        public virtual ICollection<Film> film { get; set; }
    }
}
