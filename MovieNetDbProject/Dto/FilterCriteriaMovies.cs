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
            NumberOfComments = -1;
        }
        public int IdType { get; set; }
        public string Title { get; set; }
        public int AverageMark { get; set; }
        public int NumberOfComments { get; set; }
        public bool OverOrBelowAverageMark { get; set; }
        public bool OverOrBelowNumberOfComments { get; set; }        
    }
}
