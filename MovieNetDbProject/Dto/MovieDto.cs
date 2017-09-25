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
            genre = new StyleDto();
            commentaire = new CommentDto();
            commentaires = new List<CommentDto>();
            marks = new List<MarkDto>();
        }
        public int id { get; set; }
        public string titre { get; set; }
        public string resume { get; set; }
        public decimal averageMark { get; set; }
        public int countComment { get; set; }
        public DateTime? releaseDate { get; set; }
        public string releaseDateStringFormat { get; set; }
        public string registerDateStringFormat { get; set; }
        public MarkDto newMark { get; set; }
        public StyleDto genre { get; set; }
        public CommentDto commentaire { get; set; }
        public ICollection<CommentDto> commentaires { get; set; }
        public ICollection<MarkDto> marks { get; set; }
        public ICollection<StyleDto> styles { get; set; }
    }
}
