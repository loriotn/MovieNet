using System;
using System.Collections.Generic;
using System.Text;
using MovieNetDbProject;

namespace MovieNetDto.Mapper
{
    public class MovieMapper
    {
        public MovieDto ToDto(Film film)
        {
            MovieDto Movie = new MovieDto();
            if (film != null)
            {

            }
            return Movie;
        }
    }
}
