using System;
using System.Collections.Generic;
using System.Text;
using MovieNetDbProject;

namespace MovieNetDto
{
    public class MovieDto
    {
        public MovieDto()
        {
            genre = new Genre();
            commentaire = new Commentaire();
            commentaires = new List<Commentaire>();
            notes = new List<Note>();
        }
        public int id { get; set; }
        public string titre{ get; set; }
        public string resume { get; set; }
        public Genre genre { get; set; }
        public Commentaire commentaire { get; set; }
        public ICollection<Commentaire> commentaires { get; set; }
        public ICollection<Note> notes { get; set; }
    }
}
