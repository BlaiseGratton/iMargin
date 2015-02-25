using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iMargin.Model;
using iMargin.Repository;

namespace iMargin
{
    /// <summary>
    /// Interaction logic for NewNote.xaml
    /// </summary>
    public partial class NewNote : Window
    {
        private NoteRepository repo;
        private Note note;

        public NewNote()
        {
            InitializeComponent();
        }

        private void Add_Note(object sender, RoutedEventArgs e)
        {
            repo = new NoteRepository();
            string new_title = NewTitle.Text;
            string new_content = NoteContent.Text;
            note = new Note(new_title, "12/13/2015", 1, new_content);
            repo.AddNote(note);
            MainWindow.titleDict.Add(note.Title, note.NoteId);
            MainWindow.refreshDict();
            // close window
        }
    }
}
