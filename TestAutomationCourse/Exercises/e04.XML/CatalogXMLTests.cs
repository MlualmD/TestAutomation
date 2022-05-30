using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TestAutomationCourse.Exercises.e04.XML
{
    [TestFixture]
    public class CatalogXMLTests
    {
        private XmlDocument xmlDoc;
        private XmlElement root_element;

        [SetUp]
        public void SetUp()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Users\מולועלם דפרשה\source\repos\CSharp-Automation\TestAutomationCourse\Exercises\e04.XML\CD_Catalog.xml");
            root_element = xmlDoc.DocumentElement;
        }

        [Test]
        public void Get_Title_First_Return_Empire_Burlesque()
        {
            var firstElement = root_element.GetElementsByTagName("TITLE").Item(0);
            var val = firstElement.InnerText;
            Assert.That(val, Is.EqualTo("Empire Burlesque"));
        }
        [Test]
        public void Get_ARTIST_Secand_Return_Bonnie_Tyler()
        {
            var firstElement = root_element.GetElementsByTagName("ARTIST").Item(1);
            var val = firstElement.InnerText;
            Assert.That(val, Is.EqualTo("Bonnie Tyler"));
        }
        [Test]
        public void There_are_Twentysix_cd()
        {
            int countCD = root_element.GetElementsByTagName("CD").Count;
            Assert.That(countCD, Is.EqualTo(26));
        }
        [Test]
        public void CalculatrTotalPrice()
        {
            float totalPrice = 0;
            var prices = root_element.GetElementsByTagName("PRICE");
            foreach (XmlNode price in prices)
            {
                totalPrice += float.Parse(price.InnerText);
            }
            Assert.That(totalPrice, Is.GreaterThanOrEqualTo(236f));
        }

        [Test]
        public void Price_All_Year_Older_1987()
        {
            float totalPrice = 0;
            var yearsLength = root_element.GetElementsByTagName("YEAR").Count;
            for (int i = 0; i < yearsLength; i++)
            {
                var yearPrice = root_element.GetElementsByTagName("YEAR").Item(i);
                int num_Year_Over_1987 = int.Parse(yearPrice.InnerText);
                if (num_Year_Over_1987 > 1987)
                {
                    var itemPrice = root_element.GetElementsByTagName("PRICE").Item(i);
                    totalPrice += float.Parse(itemPrice.InnerText);
                }
            }
            Assert.That(totalPrice, Is.GreaterThan(135f));
        }
        [Test]
        public void Titel_From_USA()
        {
            List<string> titelAllList = new List<string>();
            int countreisCount = root_element.GetElementsByTagName("COUNTRY").Count;
            for (int i = 0; i < countreisCount; i++)
            {
                string nameCountry = root_element.GetElementsByTagName("COUNTRY").Item(i).InnerText;
                if (nameCountry.Equals("USA"))
                {
                    var titleList = (string)root_element.GetElementsByTagName("TITLE").Item(i).InnerText;
                    titelAllList.Add(titleList);
                }
            }
            titelAllList.Sort();
            Assert.That(titelAllList.Count, Is.EqualTo(7));
           
        }

    }
}
