using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iMargin.Model;

namespace TestiMargin
{
    [TestClass]
    public class NoteModelTest
    {
        [TestMethod]
        public void CreatingNoteStoresProperties()
        {
            Note toDoNote = new Note("ToDo", "12/02/2015", 1, "code code code");
            Assert.AreEqual("ToDo", toDoNote.Title);
            Assert.AreEqual("12/02/2015", toDoNote.Date);
            Assert.AreEqual(1, toDoNote.CategoryId);
            Assert.AreEqual("code code code", toDoNote.Content);
        }
    }
}
