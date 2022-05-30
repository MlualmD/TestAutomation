using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestAutomationCourse.Exercises.e05.JSON
{
    [TestFixture]
    public class FilmsJSONTests
    {
        private JArray jsonFilms;

        [SetUp]
        public void SetUp()
        {
            using var sr = new StreamReader(@"C:\Users\מולועלם דפרשה\source\repos\CSharp-Automation\TestAutomationCourse\Exercises\e05.JSON\films.json");

            var reader = new JsonTextReader(sr);
            jsonFilms = JArray.Load(reader);

        }
        [Test]
        public void Get_Bi_lingual_ReturnSix()
        {
            int num = 0;
            var allData = (JArray)jsonFilms;
            for (int i = 0; i < allData.Count; i++)
            {
                string language = (string)allData[i]["Language"];
                string[] count = language.Split(',');

                if (count.Length >= 2)
                {
                    num++;
                }
            }
            Assert.That(num, Is.EqualTo(6));
        }
        [Test]
        public void Found_Crime_In_Genre_ReturnSix()
        {
            int numcrime = 0;
            var allData = (JArray)jsonFilms;
            for (int i = 0; i < allData.Count; i++)
            {
                string genre = (string)allData[i]["Genre"];
                string[] findCrime = genre.Split(',');

                foreach (string crime in findCrime)
                {
                    if (crime.Trim().Equals("Crime"))
                    {

                        numcrime++;
                    }
                }
            }
            Assert.That(numcrime, Is.EqualTo(6));
        }

        private int ConvertToDateTime(string value)
        {
            try
            {
                DateTime myDate = DateTime.Parse(value);
                return myDate.Year;
            }
            catch (Exception)
            {

                Console.WriteLine("'{0}' is not formt.", value);
            }
            return 0;
        }
        [Test]
        public void Find_Actor_Befor_2010()
        {
            List<string> actorList = new List<string>();
            int jsonFilmsLenghe = jsonFilms.Count;
            for (int i = 0; i < jsonFilmsLenghe; i++)
            {
                string actor = (string)jsonFilms[i]["Actors"];
                string released = (string)jsonFilms[i]["Released"];
                int year = ConvertToDateTime(released);
                if (year < 2010)
                {
                    actorList.Add(actor);
                }

            }
            Assert.That(actorList.Count, Is.EqualTo(5));
        }

        [Test]
        public void Calculate_Average_ByImdbRating_More200K()
        {
            int overVotes = 200000;
            List<float> averageRating = new List<float>();
            
            int jsonFilmsLenghe = jsonFilms.Count;
            for (int i = 0; i < jsonFilmsLenghe; i++)
            {
                string watchIMDB = (string)jsonFilms[i]["imdbVotes"];
               float convertWatchIMDB = watchIMDB == "N/A" ? 0 : float.Parse(watchIMDB);

                if (convertWatchIMDB > overVotes)
                {
                    string imdbRating = (string)jsonFilms[i]["imdbRating"];
                    float convertImdbRating = watchIMDB == "N/A" ? 0 : float.Parse(watchIMDB);
                    averageRating.Add(convertImdbRating);
                }
            }
           float average = averageRating.Average(x => x);
            Assert.That(average, Is.GreaterThan(8));
        }
    }
}
