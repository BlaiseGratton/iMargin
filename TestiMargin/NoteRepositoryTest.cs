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
        }
    }
}
