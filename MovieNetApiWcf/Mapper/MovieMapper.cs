﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNetApiWcf.Dto;
using MovieNetApiWcf.Model;

namespace MovieNetApiWcf.Mapper
{
    public class MovieMapper: AMapper<MovieDto, Film>
    {
        public MovieMapper(ModelMovieNet context): base(context)
        {

        }
        public override ICollection<MovieDto> ToDto(ICollection<Film> models)
        {
            throw new NotImplementedException();
        }

        public override ICollection<Film> ToModel(ICollection<MovieDto> dtos)
        {
            throw new NotImplementedException();
        }

        public override Film ToModel(MovieDto dto)
        {
            throw new NotImplementedException();
        }
        public override MovieDto ToDto(Film model)
        {
            MovieDto Movie = null;

            if (model != null)
            {
                
                Movie = new MovieDto();
                Movie.id = model.id;
                Movie.averageMark = getAverageMark(Context.note.Where(n => n.id_film == model.id).ToList());
                Movie.genre = model.genre;
                Movie.marks = model.note;
                Movie.commentaires = model.commentaire;
                Movie.resume = model.resume_film;
                Movie.titre = model.titre_film;
                Movie.countComment = Context.commentaire.Where(c => c.id_film == model.id).Count();
                Movie.commentaire = new Commentaire();
                Movie.newMark = new Note();
            }
            return Movie;
        }

        private decimal getAverageMark(List<Note> notes)
        {
            int sum = 0;
            int count = 0;
            decimal result = 0;
            notes.ForEach(n => { sum += n.note; count += 1; });
            if (count != 0)
                result = sum / count;
            return result;
        }
    }
}