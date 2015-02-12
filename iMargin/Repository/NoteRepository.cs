using iMargin;
using iMargin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMargin.Repository
{
    public class NoteRepository : INoteRepository
    {
        private NoteContext _dbContext;

        public NoteRepository()
        {
            _dbContext = new NoteContext();
            _dbContext.Notes.Load();
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

        public void Add(Model.Note N)
        {
            _dbContext.Notes.Add(N);
            _dbContext.SaveChanges();
        }

        public void Delete(Model.Note N)
        {
            _dbContext.Notes.Remove(N);
            _dbContext.SaveChanges();
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

        public Model.Note GetById(int id)
        {
            var query = from Note in _dbContext.Notes
                        where Note.NoteId == id
                        select Note;
            return query.First<Model.Note>();
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
    }
}
