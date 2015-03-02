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
using DrWPF.Windows.Data;
using System.Collections.ObjectModel;

namespace iMargin
{
    /// <summary>
    /// Interaction logic for NewNote.xaml
    /// </summary>
    public partial class NewNote : Window
    {
        private static NoteRepository repo = new NoteRepository();
        public static ObservableCollection<Model.Category> cats = repo.Context().Categories.Local;
        public string createdOn = DateTime.Now.ToShortDateString();

        public NewNote()
        {
            InitializeComponent();
            CatCombo.SelectedIndex = 0;
            CatCombo.DataContext = MainWindow.catDict;
            DateBox.Text = createdOn;
        }

        private void Add_Note(object sender, RoutedEventArgs e)
        {
            string new_title = NewTitle.Text;
            string new_content = NoteContent.Text;
            int new_catId = (int)CatCombo.SelectedValue;
            Note note = new Note(new_title, createdOn, new_catId, new_content);
            MainWindow.repo.AddNote(note);
            MainWindow.titleDict.Add(note.Title, note.NoteId);
            this.Close();
        }

        private void Open_Add_Category_Window(object sender, RoutedEventArgs e)
        {
            var c = new NewCategory();
            c.Show();
        }
    }
}