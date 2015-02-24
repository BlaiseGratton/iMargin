﻿using iMargin.Model;
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

        public MainWindow()
        {
            InitializeComponent();
            NoteTitleList.MouseDoubleClick += new MouseButtonEventHandler(ViewNote);
            MessageBox.Show("Hello world!");
            if (repo.GetCount() == 0)
            {
                repo.PopulateDatabase();
            }
            NoteTitleList.DataContext = repo.GetAllTitles();
        }

        private void new_note_button_Click(object sender, RoutedEventArgs e)
        {
            var n = new NewNote();
            n.Show();
        }

        private void ViewNote(object sender, RoutedEventArgs e)
        {
            // var n = CommandBinding 
            //SystemSounds.Beep.Play();
            Note note = new Note("ViewNoteTitle", "12/24/2015", 3, "view note contents here");
            var v = new ViewNote(note);
            v.Show();
            
        }
    }
}
