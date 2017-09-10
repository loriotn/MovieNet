using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Interfaces;

namespace MovieNetDbProject.Dto
{
    public class MarkDto: IDto
    {
        public int id { get; set; }
        public int id_film { get; set; }
        public int id_utilisateur { get; set; }
        public int mark { get; set; }
    }
}
