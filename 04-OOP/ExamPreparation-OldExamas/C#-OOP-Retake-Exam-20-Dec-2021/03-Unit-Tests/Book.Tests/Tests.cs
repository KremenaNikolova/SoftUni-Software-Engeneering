namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class Tests
    {
        string bookName = "SailorMoon";
        string author = "Unidentify";
        Book book;

        int footNoteNumber = 32;
        string text = "Sailor Moon is The Best!!!";
        Dictionary<int, string> footNotes;

        [SetUp]
        public void SetUp()
        {
            book = new Book(bookName, author);
            footNotes = new Dictionary<int, string>();
        }

        [Test]
        public void Test_Book_ConstructorBookName()
        {
            Assert.AreEqual (bookName, book.BookName);
        }

        [Test]
        public void Test_Book_ConstructorAuthor()
        {
            Assert.AreEqual (author, book.Author);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_Book_ShouldThrowExceptionIfBookNameIsNullOrEmtySpace(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(name, "author");
            });
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_Book_ShouldThrowExceptionIfAuthorIsNullOrEmtySpace(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(bookName, name);
            });
        }

        [Test]
        public void Test_Book_AddFootnote()
        {
            book.AddFootnote(footNoteNumber, text);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, book.FootnoteCount);
        }

       [Test]
       public void Test_Book_AddFootnoteShouldThrowExceptionIfKeyAlreadyExist()
       {
            book.AddFootnote(footNoteNumber, text);

            Assert.Throws<InvalidOperationException>(() =>
           {
               book.AddFootnote(footNoteNumber, text);
           });
       }

        [Test]
        public void Test_Book_FindFootnote()
        {
            book.AddFootnote(footNoteNumber, text);
            //book.FindFootnote(footNoteNumber);

            string expectedString = $"Footnote #{footNoteNumber}: {text}";

            Assert.AreEqual(expectedString, book.FindFootnote(footNoteNumber));
        }

        [Test]
        public void Test_Book_FindFootnoteShouldThrowExceptionIfFootnoteDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(footNoteNumber);
            });
        }

        [Test]
        public void Test_Book_AlterFootnote()
        {
            string newText = "Chibi Usa is the Best!!!";

            book.AddFootnote(footNoteNumber, text);
            book.AlterFootnote(footNoteNumber, newText);

            string expectedString = $"Footnote #{footNoteNumber}: {newText}";
            string resultText = book.FindFootnote(footNoteNumber);


            Assert.AreEqual(expectedString, resultText);
        }

        [Test]
        public void Test_Book_AlterFootnoteShouldThrowExceptionIfKeyDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(55, "EmtyText");
            });
        }




    }
}