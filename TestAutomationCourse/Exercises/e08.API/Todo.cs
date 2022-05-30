using System.Collections.Generic;

namespace TestAutomationCourse.Exercises.e08.API
{
    public  class Temperatures
    {
        public List<Todo> Todos { get; set; }
    }
    public class Todo
    {
        public string description { get; set; }
        public bool doneStatus { get; set; }

        public string title { get; set; }
    }
}