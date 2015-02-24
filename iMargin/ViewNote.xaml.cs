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
    /// Interaction logic for ViewNote.xaml
    /// </summary>
    public partial class ViewNote : Window
    {
        private NoteRepository repo;
        private Note note;


        public ViewNote(Note note)
        {
            InitializeComponent();
            this.CategoryText.Text = note.CategoryId.ToString();
            this.TitleText.Text = note.Title;
            this.DateText.Text = note.Date;
            this.ContentText.Text = note.Content;
        }
    }
}
