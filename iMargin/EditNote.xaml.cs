using DrWPF.Windows.Data;
using iMargin.Model;
using iMargin.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static ObservableCollection<Model.Category> cats = repo.Context().Categories.Local;
        private Note noteInput;
        private string oldTitle;


        public EditNote(Note note)
        {
            InitializeComponent();
            this.noteInput = note;
            oldTitle = noteInput.Title;
            CatCombo.DataContext = MainWindow.catDict;
            CatCombo.SelectedIndex = cats.IndexOf(repo.GetCatById(note.CategoryId));
            WrapperPanel.DataContext = note;
        }

        private void New_Category_Button(object sender, RoutedEventArgs e)
        {
            NewCategory newCat = new NewCategory();
            newCat.Show();
        }

        private void Save_Note_Changes(object sender, RoutedEventArgs e)
        {
            Note edited = repo.GetNoteById(noteInput.NoteId);
            edited.Title = TitleBox.Text;
            edited.Content = ContentBox.Text;
            edited.CategoryId = (int)CatCombo.SelectedValue;
            repo.SaveChanges();
            if (oldTitle != edited.Title)
            {
                MainWindow.titleDict.Add(TitleBox.Text, noteInput.NoteId);
                MainWindow.titleDict.Remove(oldTitle);
            }
            ViewNote v = new ViewNote(repo.GetNoteById(noteInput.NoteId));
            v.Show();
            this.Close();
        }
    }
}
