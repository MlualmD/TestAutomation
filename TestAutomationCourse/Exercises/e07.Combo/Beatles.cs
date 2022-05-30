using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TestAutomationCourse.Exercises.e07.Combo
{
    public class Beatles
    {
        [XmlElement]
        public artists Artists;

        public class artists
        {
            [XmlElement]
            public List<artist> Artist;
        }
        public class artist
        {
            [XmlAttribute]
            public string name;
            [XmlElement]
            public string Plays;
            [XmlElement]
            public string IsAlive;
        }


    }
}
