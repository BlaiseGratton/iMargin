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
    /// Interaction logic for NewCategory.xaml
    /// </summary>
    public partial class NewCategory : Window
    {
        private NoteRepository repo;

        public NewCategory()
        {
            InitializeComponent();
        }

        private void Save_New_Category(object sender, RoutedEventArgs e)
        {
            repo = new NoteRepository();
            string newCategory = NewCatName.Text;
            Category cat = new Category(newCategory);
            repo.AddCategory(cat);
            this.Close();
        }
    }
}
