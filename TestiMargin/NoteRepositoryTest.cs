using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iMargin.Repository;
using iMargin;
using iMargin.Model;

namespace TestiMargin
{
    [TestClass]
    public class NoteRepositoryTest
    {
        private static NoteRepository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new NoteRepository();
            repo.Clear();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            repo.Clear();
        }

        [TestCleanup]
        public void ClearDatabase() 
        {
            repo.Clear();
        }

        [TestMethod]
        public void TestAddToDatabase()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.AddNote(new Note("notetitle", "12/24/2011", 2, "heyyyyy QT"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestAddMultipleNotesToDatabase()
        {
            repo.AddNote(new Note("notetitle", "12/24/2011", 1, "heyyyyy QT"));
            repo.AddNote(new Note("newnote", "12/22/2010", 4, "idk lol"));
            Assert.AreEqual(2, repo.GetCount());
        }

        [TestMethod]
        public void TestGetCount()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.AddNote(new Note("notetitle", "12/24/2011", 2, "heyyyyy QT"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestClear()
        {
            repo.AddNote(new Note("notetitle", "12/24/2011", 2, "heyyyyy QT"));
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
        }

        [TestMethod]
        public void TestViewTitles()
        {
            repo.AddNote(new Note("title", "12/24/2012", 3, "hi y'all"));
            repo.AddNote(new Note("titles", "12/24/2013", 2, "hi y'all howdy"));
            var allTitles = repo.GetAllTitles();
            Assert.IsTrue(allTitles.ContainsKey("title"));
            Assert.IsTrue(allTitles.ContainsKey("titles"));
            Assert.IsFalse(allTitles.ContainsKey("Blaise"));
        }
    }
}
