using NUnit.Framework;
using System.Xml;

namespace TestAutomationCourse.Exercises.e04.Xml
{
    [TestFixture]
    internal class BeatlesXMLTests
    {
        private XmlDocument doc;

        [SetUp]
        public void Setup()
        {
            doc = new XmlDocument();
            doc.Load(".//Exercises//e04.Xml//Beatles.xml");
        }

        [Test]
        public void There_are_four_artists()
        {
            XmlElement root_element = doc.DocumentElement;
            int num_of_artict = root_element.GetElementsByTagName("Artist").Count;
            Assert.That(num_of_artict, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
          XmlElement root_element = doc.DocumentElement;
          int count_isAlibe = root_element.GetElementsByTagName("IsAlive").Count;
            int count_yes = 0;
            int count_no = 0;   
            for (int i = 0; i < count_isAlibe; i++)
            {
              string restult =  root_element.GetElementsByTagName("IsAlive").Item(i).InnerText;
               
                if(restult == "No")
                {
                    count_no++;
                }
                if (restult == "Yes")
                {
                    count_yes++;
                }

            }
            Assert.That(count_no,Is.EqualTo(2));
            Assert.That(count_yes, Is.EqualTo(2));

        }

        [Test]
        public void Ringo_plays_drums()
        {
           XmlElement root_element = doc.DocumentElement;
           XmlNodeList artistList = root_element.GetElementsByTagName("Artist");
            
            foreach (XmlElement artist in artistList)
            {
                if(artist.GetAttribute("name")=="Ringo Starr")
                {
                    string currentPlay =  artist.GetElementsByTagName("Plays").Item(0).InnerText;
                    Assert.That(currentPlay, Is.EqualTo("Drums"));

                }
                else
                {
                    XmlNodeList currentPlay = artist.GetElementsByTagName("Plays");
                    if(currentPlay !=null && currentPlay.Item(0) != null)
                    {

                    }
                }
            }
            
        }

    }
}
