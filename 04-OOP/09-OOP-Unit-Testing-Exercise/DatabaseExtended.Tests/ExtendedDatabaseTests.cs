namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        [SetUp]
        public void SetUp()
        {
            Person[] persons = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                int id = i;
                string userName = ((char)('K' + i)).ToString();
                Person person = new Person(id, userName);
                persons[i] = person;
            }
            db = new Database(persons);
        }

        [Test]
        public void TestConstructorPerson()
        {
            Person person = new Person(12345, "Petar");
            Person[] personArray = new Person[] { person };
            
            Database database= new Database(personArray);

            int expectedCount = personArray.Length;
            int actualCount = database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddRangeMethodShouldThrowExceptionIfArrayIs16AndMore()
        {
            Person[] persons = new Person[17];

            for (int i = 0; i <= 16; i++)
            {
                int id = i;
                string userName = ((char)('K' + i)).ToString();
                Person person = new Person(id, userName);
                persons[i] = person;
            }

            Assert.Throws<ArgumentException>(() =>
            {
                Database db = new Database(persons);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void TestAddShouldCanNotBeAbove16()
        {
            db.Add(new Person(312, "Ivan"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(365, "Kremena"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void TestAddMethodIfAddPersonsPropertly()
        {
            Person person = new Person(12345, "Petar");

            Database database = new Database();
            database.Add(person);

            int expectedCount = 1;
            int actualCount = database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddMethodCounter()
        {
            Person person = new Person(12345, "Petar");

            Database database = new Database();
            database.Add(person);

            int expectedCount = 1;
            int actualCount = database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddMethodShouldThrowExceptionIfWeTryToAddPersonWithSameName()
        {
            Person[] person = new Person[] {new Person (920220, "Kremena") };
            Database database = new Database(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(9202, "Kremena"));
            }, "There is already user with this username!");

        }

        [Test]
        public void TestAddMethodShouldThrowExceptionIfWeTryToAddPersonWithSameID()
        {
            Person[] person = new Person[] { new Person(920220, "Kremena") };
            Database database = new Database(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(920220, "Kremi"));
            }, "There is already user with this Id!");

        }

        [Test]
        public void TestRemoveMethodShouldRemoveElements()
        {
            int expectedCount = db.Count-1;
            db.Remove();
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestRemoveMethodShouldThrowExceptionIfCountIsZero()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void TestRemoveMethodIsPersonsOnPositionCountIsNull()
        {
            Person[] persons = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                int id = i;
                string userName = ((char)('K' + i)).ToString();
                Person person = new Person(id, userName);
                persons[i] = person;
            }
            db = new Database(persons);

            db.Remove();
            int count = db.Count;

            Assert.AreEqual(null, persons[count] = null);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestFindByUserNameShouldThrowExceptionIfUsernameIsNullOrEmpty(string person)
        {
            Assert.Throws<ArgumentNullException>(() => { db.FindByUsername(person); }, "Username parameter is null!") ;
        }

        [Test]
        public void TestFindByUserNameShouldThrowExceptionIfUsernameNotExist()
        {

            Assert.Throws<InvalidOperationException>(() => { db.FindByUsername("Kremena"); }, "No user is present by this username!");
        }

        [Test]
        public void TestFindByUserNameShouldReturnRightUsername()
        {
            Person myPerson = new Person(365, "Kremena");
            Database database = new Database(myPerson);

            Person actualPerson = database.FindByUsername("Kremena");

            Assert.AreEqual(myPerson, actualPerson);
        }

        [Test]
        public void TestFindByIdMethodCanNotBeBelow0()
        {
            long expectedId = -321;

            Assert.Throws<ArgumentOutOfRangeException>(() => { db.FindById(expectedId); }, "Id should be a positive number!");
            
        }

        [Test]
        public void TestFindByIdMethodShouldThrowExceptionIfIdDoesntExist()
        {
            Person myPerson = new Person(365, "Kremena");
            Database database = new Database(myPerson);

            Assert.Throws<InvalidOperationException>(() => { database.FindById(123); }, "No user is present by this ID!");
            
        }

        [Test]
        public void TestFindByIdMethodShouldFindTheRightPerson()
        {
            Person myPerson = new Person(365, "Kremena");
            Database database = new Database(myPerson);

            Person expectedPerson = database.FindById(365);

            Assert.AreEqual(myPerson, expectedPerson);
        }

        [Test]
        public void TestPersonClassShouldAcceptUsername()
        {
            string username = "Kremena";
            Person person = new Person(365,username);

            Assert.AreEqual(username, person.UserName);
        }

        [Test]
        public void TestPersonVlassShouldAcceptId()
        {
            int id = 365;
            Person person = new Person(id, "Kremena");

            Assert.AreEqual(id, person.Id);
        }
    }
}