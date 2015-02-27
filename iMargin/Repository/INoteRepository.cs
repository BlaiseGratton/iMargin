using iMargin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iMargin.Repository
{
    public interface INoteRepository
    {
        int GetCount();
        void AddNote(Note N);
        void Delete(Note N);
        void Clear();
        IEnumerable<Note> All();
        Note GetNoteById(int id);
        Note GetByDate(string date);
        IQueryable<Note> SearchFor(Expression<Func<Note, bool>> predicate);
    }
}
