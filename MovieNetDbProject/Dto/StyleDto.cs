using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetDbProject.Interfaces;

namespace MovieNetDbProject.Dto
{
    public class StyleDto: IDto
    {
        public int id { get; set; }
        public string label { get; set; }
    }
}
