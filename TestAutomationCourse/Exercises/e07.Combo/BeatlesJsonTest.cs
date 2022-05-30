using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TestAutomationCourse.Exercises.e07.Combo
{
    [TestFixture]
    public class BeatlesJsonTest
    {
 
        private Beatles Beatles;
        [SetUp]
        public void SetUp()
        {
            XmlSerializer serializer =
            new XmlSerializer(typeof(Beatles));
            string xml = File.ReadAllText(@"C:\Users\מולועלם דפרשה\source\repos\CSharp-Automation\TestAutomationCourse\Exercises\e04.XML\Beatles.xml");
            using (TextReader reader = new StringReader(xml))
            {
                Beatles = (Beatles)serializer.Deserialize(reader);
            }

        }
        [Test]
        public void ArtistsCount()
        {
           Assert.That(Beatles.Artists.Artist.Count, Is.EqualTo(4));
        }
    }
}
