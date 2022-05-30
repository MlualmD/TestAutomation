using Newtonsoft.Json;
using NUnit.Framework;
using TestAutomationCourse.Demos.d04.Serialization;

namespace TestAutomationCourse.Exercises.e06.combo
{
    [TestFixture]
    public class ComboTests
    {
        //[Test]
        //public void Serlize()
        //{
        //    Album a = new Album();
        //    a.beatles.artists = new List<Artist>() {  new Artist() };
        //    var json = JsonConvert.SerializeObject(a);
        //    var deserializedMessage = JsonConvert.DeserializeObject<Album>(json);
        //    Assert.That(deserializedMessage.beatles.artists[0].plays, Is.EqualTo(a.beatles.artists[0].plays));
        //}

        // test 1
        // load the beatles xml
        // load the beatles json
        // prove that paul plays bass in both of them

        // test 2
        // create a data object for the MCU
        // MCU includes films
        // Each film has a name and a series counter (Captain America: The Winter Soldier is 2)
        // Each film has super-heroes in it (could be more than one)

        // Create data objects
        // Load the following data objects as follows:
        // "Thor" -> Thor
        // "Captain America - The First Avenger" -> Cap
        // "Black Widow" -> Black Widow
        // "Avengers" -> Thor, Cap, Black Widow, Hawekeye, Hulk, Iron Man
        //
        // Create the JSON String using ObjectMapper.writeValue()
        // Prove that the JSON String contains the all the names of the super heroes
        // Prove that Ant-Man was not in Avengers

    }

}
