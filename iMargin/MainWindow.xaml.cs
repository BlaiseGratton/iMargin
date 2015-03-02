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
        public static ObservableDictionary<string, int> searchResultDict;

        public MainWindow()
        {
            InitializeComponent();
            SearchBox.Visibility = Visibility.Collapsed;
            DateContentBox.Visibility = Visibility.Collapsed;
            SearchButton.Visibility = Visibility.Collapsed;
            SearchComboBox.ItemsSource = new string[] { "Category", "Date", "Content" };
            SearchCats.Visibility = Visibility.Collapsed;
            NoteTitleList.MouseDoubleClick += new MouseButtonEventHandler(ViewNote);
            SearchResults.MouseDoubleClick += new MouseButtonEventHandler(ViewSearchNote);
            if (repo.GetCount() == 0)
            {
                //repo.PopulateDatabase();
            }
            NoteTitleList.DataContext = titleDict;
        }

        private void ViewSearchNote(object sender, MouseButtonEventArgs e)
        {
            var title = sender as ListBox;
            var noteDict = title.SelectedItem as Dictionary<string, int>;
            var tuple = searchResultDict.ElementAt(title.SelectedIndex);
            int noteId = tuple.Value;
            Note note = repo.GetNoteById(noteId);
            var v = new ViewNote(note);
            v.Show();
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

        private void all_notes_button_Click(object sender, RoutedEventArgs e)
        {
            NoteTitleList.Visibility = Visibility.Visible;
            SearchBox.Visibility = Visibility.Collapsed;
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            NoteTitleList.Visibility = Visibility.Collapsed;
            SearchBox.Visibility = Visibility.Visible;
        }

        private void SearchComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox searchCombo = sender as ComboBox;
            if (searchCombo.SelectedItem.ToString() == "Category")
            {
                SearchCats.Visibility = Visibility.Visible;
                DateContentBox.Visibility = Visibility.Collapsed;
                SearchButton.Visibility = Visibility.Collapsed;
                DateContentBox.Text = "";
                SearchCats.ItemsSource = catDict;
            }
            else if (searchCombo.SelectedItem.ToString() == "Date")
            {
                SearchCats.Visibility = Visibility.Collapsed;
                DateContentBox.Visibility = Visibility.Visible;
                SearchButton.Visibility = Visibility.Collapsed;
                DateContentBox.Text = "";
            }
            else if (searchCombo.SelectedItem.ToString() == "Content")
            {
                SearchCats.Visibility = Visibility.Collapsed;
                DateContentBox.Visibility = Visibility.Visible;
                SearchButton.Visibility = Visibility.Collapsed;
                DateContentBox.Text = "";
            }
        }

        private void SearchCats_DropDownClosed(object sender, EventArgs e)
        {
            SearchButton.Visibility = Visibility.Visible;
        }

        private void DateContentBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            SearchButton.Visibility = Visibility.Visible;
            if (DateContentBox.Text == "")
            {
                SearchButton.Visibility = Visibility.Collapsed;
            }
            if (SearchComboBox.SelectedItem.ToString() == "Date")
            {
                SearchButton.Visibility = Visibility.Collapsed;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchComboBox.SelectedValue.ToString() == "Category")
            {
                searchResultDict = new ObservableDictionary<string, int>(repo.GetByCategory((int)SearchCats.SelectedValue));
                SearchResults.DataContext = searchResultDict;
            }
            if (SearchComboBox.SelectedValue.ToString() == "Date")
            {
                MessageBox.Show(SearchComboBox.SelectedValue.ToString());
                SearchResults.DataContext = searchResultDict;
            }
            if (SearchComboBox.SelectedValue.ToString() == "Content")
            {
                searchResultDict = new ObservableDictionary<string,int>(repo.GetSubstring((string)DateContentBox.Text));
                SearchResults.DataContext = searchResultDict;
            }
        }
    }
}
