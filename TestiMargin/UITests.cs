using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace TestiMargin
{
    [TestClass]
    public class UITests
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;

        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TestiMargin\\bin\\Debug\\iMargin");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
        }

        [TestMethod]
        public void TestZeroState()
        {
            Button new_note_button = window.Get<Button>("new_note_button");
            Button view_notes_button = window.Get<Button>("view_notes_button");
            Button search_button = window.Get<Button>("search_button");

            Assert.IsTrue(new_note_button.Enabled);
            Assert.IsTrue(view_notes_button.Enabled);
            Assert.IsTrue(search_button.Enabled);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}
