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
    [Table("genre")]
    public class Genre: IEntity
    {
        public Genre()
        {
        }

        [Key]
        [Column("id_genre")]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("label_genre")]
        public string label_genre { get; set; }
    }
}
