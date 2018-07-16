using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPIClient;

namespace HttpClientSample
{

    class Program
    {
        static void Main()
        {
            ITaskProvider provider = new TaskProvider();

            IList<TaskItem> tasks = provider.GetTasksAsync().GetAwaiter().GetResult();

            foreach (var item in tasks)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.IsCompleted}");
            }

            provider.CreateTaskAsync(new TaskItem()
            {
                Name = "TRIOROROppppppppZZZ",
                IsCompleted = false
            }).GetAwaiter().GetResult();

            Console.WriteLine(new string('-', 50));

            IList<TaskItem> tasks2 = provider.GetTasksAsync().GetAwaiter().GetResult();

            foreach (var item in tasks2)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.IsCompleted}");
            }

            Console.ReadKey();
        }
    }
}