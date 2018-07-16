using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClient
{
    interface ITaskProvider
    {
        Task<IList<TaskItem>> GetTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task<Uri> CreateTaskAsync(TaskItem task);
        Task<TaskItem> PutTaskAsync(TaskItem task);
        Task<HttpStatusCode> DeleteTaskByIdAsync(int id);
    }
}
