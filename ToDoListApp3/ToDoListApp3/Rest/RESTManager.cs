using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ToDoList
{
    public class RESTManager
    {

        private const string REST_BASE_URI = "http://windowsphoneuam.azurewebsites.net/";
        private const string REST_PATH = "api/ToDoTasks/";

        //GET
        public async Task<List<ToDoTask>> getTasks(string ownerID)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync(REST_BASE_URI + "/" + REST_PATH + "?OwnerId=" + ownerID);
                return JsonConvert.DeserializeObject <List<ToDoTask>> (await result.Content.ReadAsStringAsync());
            }
        }

        //POST
        public async void postTask(ToDoTask currentTask)
        {
            using (HttpClient client = new HttpClient()) { 
                client.BaseAddress = new Uri(REST_BASE_URI);
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, REST_PATH);
                request.Content = new StringContent(currentTask.SerializeToDoTask(), Encoding.UTF8, "application/json");
                await client.SendAsync(request);
            }
        }

        //PUT
        public async void updateTask(ToDoTask currentTask)
        {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(REST_BASE_URI);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, REST_PATH + currentTask.Id);
                request.Content = new StringContent(currentTask.SerializeToDoTask(), Encoding.UTF8, "application/json");
                await client.SendAsync(request);
            }
        }


        //DELETE
        public async Task deleteTask(ToDoTask currentTask)
        {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(REST_BASE_URI);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, REST_PATH + currentTask.Id);
                await client.SendAsync(request);
            }
        }


    }
}
