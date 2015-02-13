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
            repo.Add(new Note("notetitle", "12/24/2011", "Misc.", "heyyyyy QT"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void MyTestMethod()
        {
            repo.Add(new Note("notetitle", "12/24/2011", "Misc.", "heyyyyy QT"));
            repo.Add(new Note("newnote", "12/22/2010", "School", "idk lol"));
            Assert.AreEqual(2, repo.GetCount());
        }

        [TestMethod]
        public void TestGetCount()
        {
            Assert.AreEqual(0, repo.GetCount());
            repo.Add(new Note("notetitle", "12/24/2011", "Misc.", "heyyyyy QT"));
            Assert.AreEqual(1, repo.GetCount());
        }

        [TestMethod]
        public void TestClear()
        {
            repo.Add(new Note("notetitle", "12/24/2011", "Misc.", "heyyyyy QT"));
            repo.Clear();
            Assert.AreEqual(0, repo.GetCount());
        }
    }
}
