// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	//using FestivalManager.Entities;
	using NUnit.Framework;
    using System;
	using System.Linq;

	[TestFixture]
	public class StageTests
    {
		string firstName = "Lepa";
		string lastName = "Brena";
		int age = 52;
		Performer perfomer;

		string songName = "I dont know any song's of her";
		TimeSpan duration = new TimeSpan(0, 0, 3, 33);
		Song song;

		Stage stage;
		[SetUp]
		public void SetUp()
		{
			perfomer = new Performer(firstName, lastName, age);
			song = new Song(songName, duration);
			stage = new Stage();
		}


		[Test]
	    public void Test_Stage_PerformersCollection()
	    {
			stage.AddPerformer(perfomer);

			int expectedCount = 1;

			Assert.AreEqual(expectedCount, stage.Performers.Count);
		}

		[Test]
		public void Test_Stage_ShouldThrowExceptionIfAgeIsBelow18()
		{
			Assert.Throws < ArgumentException>(() =>
			{
				stage.AddPerformer(new Performer(firstName, lastName, 15));
			});
		}

		[Test]
		public void Test_Stage_AddSong_ShouldThrowExceptionIfDurationIsBelowOneMintue()
		{
			song = new Song(songName, new TimeSpan(0, 0, 0));

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			});
		}

		[Test]
		public void Test_Stage_AddSongToPerformer()
		{
			stage.AddPerformer(perfomer);
			stage.AddSong(song);

			string expectedOutput = $"{song} will be performed by {perfomer}";

			Assert.AreEqual(expectedOutput, stage.AddSongToPerformer(songName, firstName + " " + lastName));
        }

		[Test]
		public void Test_Stage_Play()
		{
            var songsCount = stage.Performers.Sum(p => p.SongList.Count());
            string expectedOutput = $"{stage.Performers.Count} performers played {songsCount} songs";

			Assert.AreEqual(expectedOutput, stage.Play());

        }

		[Test]
		public void Test_Stage_GetPerformer_ShouldThrowExceptionIfPerformerDoesntExist()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer("empty", "Error");
			});
		}

		[Test]
		public void Test_Stage_GetSong_ShouldThrowExceptionIfSongDoesntExis()
		{
			stage.AddPerformer(perfomer);
			string perfomerFullName = firstName + " " + lastName;

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer("Error", perfomerFullName);
			});
		}

		[Test]
		public void Test_ValidateNullValue()
		{
			perfomer = null;
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddPerformer(perfomer);
			});
		}




    }
}