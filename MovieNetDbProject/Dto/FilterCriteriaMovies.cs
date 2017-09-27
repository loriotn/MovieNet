using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDbProject.Dto
{
    public class FilterCriteriaMovies
    {
        public FilterCriteriaMovies()
        {
        }
        public int IdType { get; set; }
        public string Title { get; set; }
        public int AverageMark { get; set; }
        public int MinComments { get; set; }
        public int MaxComments { get; set; }
        public bool OverOrBelowAverageMark { get; set; }
        public bool BeforeReleaseDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
