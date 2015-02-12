using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMargin.Model
{
    public class Note : INotifyPropertyChanged
    {
        public int NoteId { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }        
        public string Content { get; set; }

        public Note()
        {

        }

        public Note(string NoteTitle, string NoteDate, string NoteCategory, string NoteContent)
        {
            this.Title = NoteTitle;
            this.Date = NoteDate;
            this.Category = NoteCategory;
            this.Content = NoteContent;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
