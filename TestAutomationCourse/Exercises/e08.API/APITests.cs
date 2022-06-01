using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TestAutomationCourse.Exercises.e08.API
{
    [TestFixture]
    internal class APITests
    {
        // JsonPlaceHolder api
        // Use JArray.Parse
        [Test]
        public async Task number_of_total_posts_is_100()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");

            RestRequest restRequest = new RestRequest("posts");

            var response = await client.GetAsync(restRequest);

            var jsonArray = JArray.Parse(response.Content);

            Assert.That(jsonArray.Count, Is.EqualTo(100));
        }

        [Test]
        public async Task title_of_first_post_for_userid_1_contains_facere()
        {
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");

            RestRequest restRequest = new RestRequest("posts/1");

            var response = await client.GetAsync(restRequest);

            var jsonArray = JObject.Parse(response.Content);

            string title = (string)jsonArray["title"];

            Assert.That(title, Does.Contain("facere"));
        }

        // apichallenges api
        [Test]
        public async Task create_todo_and_get_it_by_its_id()
        {
            Todo newTodo = new Todo();
            newTodo.title = "My Todo";
            newTodo.doneStatus = false;
            newTodo.description = "dognabbit";

            RestClient client = new RestClient("https://apichallenges.herokuapp.com/todos");
            RestRequest request = new RestRequest();

            request.AddJsonBody(newTodo);

            var response = await client.PostAsync(request);

            var json = JObject.Parse(response.Content);

            var id = (int)json["id"];

            RestRequest RequestTodo = new RestRequest($"/{id}");

            var responseTodo = await client.GetAsync(RequestTodo);

            var getTodoJson = JObject.Parse(responseTodo.Content);

            var objectTodo = getTodoJson["todos"][0];

            Console.WriteLine(objectTodo);

            var todoId = (int)objectTodo["id"];

            Assert.That(id, Is.EqualTo(todoId));


        }

        // use body("Y", hasItem(X)); to find if the ID was added.
        [Test]
        public async Task create_todo_and_check_if_added_to_todos()
        {
            Todo newTodo = new Todo();
            newTodo.title = "My Todo";
            newTodo.doneStatus = false;
            newTodo.description = "dognabbit";

            RestClient client = new RestClient("https://apichallenges.herokuapp.com/todos");
            RestRequest request = new RestRequest();

            request.AddJsonBody(newTodo);

            var response = await client.PostAsync(request);


            var json = JObject.Parse(response.Content);

            var id = (int)json["id"];


            RestRequest RequestAllTodo = new RestRequest();

            var responseAllTodo = await client.GetAsync(RequestAllTodo);

            var getTodoJson = JObject.Parse(responseAllTodo.Content);

            var objectTodos = (JArray)getTodoJson["todos"];
            int existIdTodos = 0;
            for (int i = 0; i < objectTodos.Count; i++)
            {
                int tmp = (int)objectTodos[i]["id"];

                if (tmp == id)
                {

                    existIdTodos = tmp;
                    break;
                }
            }

            Assert.That(id, Is.EqualTo(existIdTodos));



        }

        // Update the description field
        [Test]
        public async Task create_get_update_delete_todo()
        {
            Todo new_todo = new Todo();
            new_todo.title = "new title";
            new_todo.description = "new description";
            new_todo.doneStatus = false;

            RestClient client = new RestClient("https://apichallenges.herokuapp.com/todos");
            RestRequest request = new RestRequest();

            request.AddJsonBody(new_todo);

            var response = await client.PostAsync(request);

            var json = JObject.Parse(response.Content);

            var id = (int)json["id"];


            var path = $"https://apichallenges.herokuapp.com/todos/{id}";

            var response_Todo = await client.GetJsonAsync<Temperatures>(path);

            response_Todo.Todos[0].description = "change Att muuuluuuu";

            await client.PostJsonAsync(path, response_Todo.Todos[0]);

            RestRequest RequestTodo = new RestRequest($"/{id}");

            var res1 = await client.DeleteAsync(RequestTodo);

            Assert.That(res1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
