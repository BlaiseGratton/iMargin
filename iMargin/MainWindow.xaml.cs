using DrWPF.Windows.Data;
using iMargin.Model;
using iMargin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace iMargin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static NoteRepository repo = new NoteRepository();
        public static ObservableDictionary<string, int> titleDict = new ObservableDictionary<string,int>(repo.GetAllTitles());
        public static IEnumerable<Model.Note> allNotes = repo.All();
        public static ObservableDictionary<int, string> catDict = new ObservableDictionary<int, string>(repo.GetAllCategories());

        public MainWindow()
        {
            InitializeComponent();
            NoteTitleList.MouseDoubleClick += new MouseButtonEventHandler(ViewNote);
            if (repo.GetCount() == 0)
            {
                //repo.PopulateDatabase();
            }
            NoteTitleList.DataContext = titleDict;
        }

        private void new_note_button_Click(object sender, RoutedEventArgs e)
        {
            NewNote n = new NewNote();
            n.Show();
        }

        private void ViewNote(object sender, RoutedEventArgs e)
        {
            var title = sender as ListBox;
            var noteDict = title.SelectedItem as Dictionary<string, int>;
            var tuple = titleDict.ElementAt(title.SelectedIndex);
            int noteId = tuple.Value;
            Note note = repo.GetNoteById(noteId);
            var v = new ViewNote(note);
            v.Show();
        }
    }
}
