using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebAPIClient
{
    class TaskProvider: ITaskProvider
    {
        private readonly HttpClient _client;

        public TaskProvider()
        {
           _client = new HttpClient();
           _client.BaseAddress = new Uri("http://localhost:3001/");
           _client.DefaultRequestHeaders.Accept.Clear();
           _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<Uri> CreateTaskAsync(TaskItem Task)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/task", Task);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            TaskItem Task = null;
            HttpResponseMessage response = await _client.GetAsync($"api/task/{id}");
            if (response.IsSuccessStatusCode)
            {
                Task = await response.Content.ReadAsAsync<TaskItem>();
            }
            return Task;
        }

        public async Task<IList<TaskItem>> GetTasksAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("api/task");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IList<TaskItem>>();
            }
            return null;
        }

        public async Task<TaskItem> PutTaskAsync(TaskItem Task)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync($"api/task/{Task.Id}", Task);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated Task from the response body.
            TaskItem updated = await response.Content.ReadAsAsync<TaskItem>();
            return updated;
        }

        public async Task<HttpStatusCode> DeleteTaskByIdAsync(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/task/{id}");
            return response.StatusCode;
        }
    }
}
