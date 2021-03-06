﻿using FilmSelector.Entities;
using FilmSelector.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSelector.Repositories
{
    public class FilmRepository
    {
        private SelectorContext selectorContext;

        public FilmRepository(SelectorContext selectorContext)
        {
            this.selectorContext = selectorContext;
        }

        public List<Film> AllFilm()
        {
            selectorContext.Users.Load();
            return selectorContext.Films.ToList();
        }

        public void AddFilm(Creator filmCreator, User user)
        {
            selectorContext.Users.Load();
            Film newFilm = new Film()
            {
                Title = filmCreator.Title,
                Link = filmCreator.Link,
                Users = new List<UserFilm>()
                {
                    new UserFilm()
                    {
                        User = user
                    }
                }
            };
            selectorContext.Films.Add(newFilm);
            selectorContext.SaveChanges();
        }

        public Film GetFilmWithId(int Id)
        {
            selectorContext.UserFilm.Load();
            selectorContext.Users.Load();
            return selectorContext.Films.Single(x => x.Id == Id);
        }

        internal void UpdateFilm(int programId)
        {
            var updatedFilm = GetFilmWithId(programId);
            updatedFilm.Seen = true;
            selectorContext.SaveChanges();
        }

        public void AddOtherUser(int filmId, int userId)
        {
            var currentFilm = GetFilmWithId(filmId);
            var currentUser = selectorContext.Users.Single(u => u.UserId == userId);
            var currentUserFilm = currentFilm.Users.Single(x => x.UserId == userId);

            if(currentUserFilm == null)
                currentFilm.Users.Add(new UserFilm() { User = currentUser });
            selectorContext.SaveChanges();
        }
    }
}
