using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using TestAutomationCourse.Demos.d02.XML;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    [TestFixture]
    internal class XMLSerializationTests
    {
        private Person person;
        [SetUp]
        public void SetUp()
        {
            XmlSerializer serializer =
               new XmlSerializer(typeof(Person));
            using (TextReader reader = new StringReader(XMLExamples.GetPersonXML()))
            {
                person = (Person)serializer.Deserialize(reader);
            }
        }

        [Test]
        public void First_name_is_joe()
        {
            Assert.That(person.FirstName, Is.EqualTo("Joe"));
        }

        [Test]
        public void Joe_has_three_children()
        {
            int amountChild = person.Children.Child.Count;
            Assert.That(amountChild, Is.EqualTo(3));
        }

        [Test]
        public void Second_child_name_is_jim()
        {
            string child = person.Children.Child[1].name;
            Assert.That(child, Is.EqualTo("Jim"));
        }
    }


}