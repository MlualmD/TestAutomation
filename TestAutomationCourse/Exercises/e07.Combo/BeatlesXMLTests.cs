using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestAutomationCourse.Demos.d04.Serialization;

namespace TestAutomationCourse.Exercises.e07.Combo
{
     [TestFixture]
    public class BeatlesXMLTests
    {
         private Album album;
        [SetUp]
        public void SetUp()
        {
            string json = File.ReadAllText(@"C:\Users\מולועלם דפרשה\source\repos\CSharp-Automation\TestAutomationCourse\Exercises\e05.JSON\Beatles.json");
            album = JsonConvert.DeserializeObject<Album>(json);
        }
        
        
    }
}
