using iMargin.Model;
using iMargin.Repository;
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

namespace iMargin
{
    /// <summary>
    /// Interaction logic for EditNote.xaml
    /// </summary>
    public partial class EditNote : Window
    {
        private static NoteRepository repo = new NoteRepository();
        public Note noteInput;


        public EditNote(Note note)
        {
            InitializeComponent();
            this.noteInput = note;
            WrapperPanel.DataContext = note;
        }

        private void New_Category_Button(object sender, RoutedEventArgs e)
        {
            NewCategory newCat = new NewCategory();
            newCat.Show();
        }

        private void Save_Note_Changes(object sender, RoutedEventArgs e)
        {
            repo.SaveChanges();
            repo.SaveChanges();
            ViewNote v = new ViewNote(repo.GetById(noteInput.NoteId));
            v.Show();
            this.Close();
        }
    }
}
