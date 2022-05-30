using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    [TestFixture]
    internal class JSONSerializationTests
    {
        private Album album;

        [SetUp]
        public void SetUp()
        {
            string json = File.ReadAllText(".//Exercises//e05.JSON//Beatles.json");
            album = JsonConvert.DeserializeObject<Album>(json);
        }
        [Test]
        public void There_are_four_artists()
        {
            Assert.That(album.beatles.artists.Length, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            int no = 0;
            int yes = 0;
            int amoutAlbum = album.beatles.artists.Length;
            for (int i = 0; i < amoutAlbum; i++)
            {
                if (album.beatles.artists[i].isAlive == "No")
                {
                    no++;
                }
                else if (album.beatles.artists[i].isAlive == "Yes")
                {
                    yes++;
                }
            }
            Assert.That(no, Is.EqualTo(2));
            Assert.That(yes, Is.EqualTo(2));
        }

        [Test]
        public void Ringo_plays_drums()
        {
            var artists = album.beatles.artists;
            foreach (var artist in artists)
            {
                var name = artist.name;

                if (name.Equals("Ringo Starr"))
                {
                    var res = artist.plays;
                    Assert.That(res, Is.EqualTo("Drums"));
                }

            }
        }


    }
}
