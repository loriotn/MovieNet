using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Interfaces;

namespace MovieNetDbProject.Dto
{
    public class MovieDto: IDto
    {
        public MovieDto()
        {
            genre = new Genre();
            commentaire = new Commentaire();
            commentaires = new List<Commentaire>();
            marks = new List<Note>();
        }
        public int id { get; set; }
        public string titre { get; set; }
        public string resume { get; set; }
        public int averageMark { get; set; }
        public Note newMark { get; set; }
        public Genre genre { get; set; }
        public Commentaire commentaire { get; set; }
        public ICollection<Commentaire> commentaires { get; set; }
        public ICollection<Note> marks { get; set; }
    }
}
