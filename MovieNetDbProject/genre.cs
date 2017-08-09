using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MovieNetDbProject
{
    [Table("genre")]
    public class Genre
    {
        public Genre()
        {
            film = new HashSet<Film>();
        }

        [Key]
        [Column("id_genre")]
        public int id_genre { get; set; }

        [Required]
        [StringLength(255)]
        [Column("label_genre")]
        public string label_genre { get; set; }

        public virtual ICollection<Film> film { get; set; }
    }
}
