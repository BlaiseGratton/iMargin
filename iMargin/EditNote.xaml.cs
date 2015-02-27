﻿using iMargin.Model;
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
        public Note noteInput;


        public EditNote(Note note)
        {
            InitializeComponent();
            this.noteInput = note;
            CatCombo.DataContext = cats;
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
            repo.SaveChanges();
            repo.SaveChanges();
            ViewNote v = new ViewNote(repo.GetNoteById(noteInput.NoteId));
            v.Show();
            this.Close();
        }
    }
}