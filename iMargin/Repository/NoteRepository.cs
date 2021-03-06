﻿using iMargin;
using iMargin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using DrWPF.Windows.Data;

namespace iMargin.Repository
{
    public class NoteRepository : INoteRepository
    {
        private NoteContext _dbContext;

        public NoteRepository()
        {
            _dbContext = new NoteContext();
            _dbContext.Notes.Load();
            _dbContext.Categories.Load();
        }

        public NoteContext Context()
        {
            return _dbContext;
        }

        public DbSet<Model.Note> GetDbSet()
        {
            return _dbContext.Notes;
        }

        public int GetCount()
        {
            return _dbContext.Notes.Count<Model.Note>();
        }

        public void AddNote(Model.Note N)
        {
            _dbContext.Notes.Add(N);
            _dbContext.SaveChanges();
        }

        public void Delete(Model.Note N)
        {
            _dbContext.Notes.Remove(N);
            _dbContext.SaveChanges();
            MainWindow.titleDict.Remove(N.Title);
        }

        public void Clear()
        {
            var a = this.All();
            _dbContext.Notes.RemoveRange(a);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Model.Note> All()
        {
            var query = from Note in _dbContext.Notes select Note;
            return query.ToList<Model.Note>();
        }

        public Model.Note GetNoteById(int id)
        {
            var query = from Note in _dbContext.Notes
                        where Note.NoteId == id
                        select Note;
            return query.First<Model.Note>();
        }

        public Model.Category GetCatById(int id)
        {
            var query = from Category in _dbContext.Categories
                        where Category.CategoryId == id
                        select Category;
            return query.First<Model.Category>();
        }

        public Model.Note GetByDate(string date)
        {
            var query = from Note in _dbContext.Notes
                        where Note.Date == date
                        select Note;
            return query.First<Model.Note>();
        }

        public IQueryable<Model.Note> SearchFor(System.Linq.Expressions.Expression<Func<Model.Note, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Dictionary<string, int> GetAllTitles()
        {
            Dictionary<string, int> titles = _dbContext.Notes.Select(n => new { n.Title, n.NoteId} )
                                             .ToDictionary( n => n.Title, n => n.NoteId );
            return titles;
        }

        public void AddCategory(Model.Category C)
        {
            _dbContext.Categories.Add(C);
            _dbContext.SaveChanges();
            MainWindow.catDict.Add(C.CategoryId, C.CategoryName);
        }

        internal void PopulateDatabase()
        {
            this.AddNote(new Note("test note", "12/24/2011", 1, "this is a test"));
            this.AddNote(new Note("test note2", "12/24/2012", 1, "this is a test"));
            this.AddNote(new Note("test note3", "12/24/2013", 2, "this is a test"));
            this.AddNote(new Note("test note4", "12/24/2014", 2, "this is a test"));
            this.AddNote(new Note("test note5", "12/24/2015", 3, "this is a test"));
            this.AddNote(new Note("test note6", "12/24/2010", 4, "this is a test"));
        }

        public Dictionary<int, string>GetAllCategories()
        {
            Dictionary<int, string> cats = _dbContext.Categories.Select(c => new { c.CategoryId, c.CategoryName })
                                           .ToDictionary( c => c.CategoryId, c => c.CategoryName);
            return cats;
        }

        internal void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Dictionary<string, int> GetByCategory(int catId)
        {
            IEnumerable<Model.Note> group = from Note in _dbContext.Notes
                                            where Note.CategoryId == catId
                                            select Note;
            Dictionary<string, int> groupedNotes = group.Select(n => new { n.Title, n.NoteId })
                                                   .ToDictionary( n => n.Title, n => n.NoteId );
            return groupedNotes;
        }

        public Dictionary<string, int> GetSubstring(string sub)
        {
            IEnumerable<Model.Note> group = from Note in _dbContext.Notes
                                            where Note.Title.IndexOf(sub) != -1 || Note.Content.IndexOf(sub) != -1
                                            select Note;
            Dictionary<string, int> groupedNotes = group.Select(n => new { n.Title, n.NoteId })
                                                   .ToDictionary( n => n.Title, n => n.NoteId );
            return groupedNotes;
        }
    }
}
