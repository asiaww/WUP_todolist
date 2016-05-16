using System;
using Newtonsoft.Json;

namespace ToDoListApp3
{
    class ToDoTask
    {

        public int? Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string OwnerId { get; set; }
        public string CreatedAt { get; set; }

        public ToDoTask(int Id, string Title, string Value, string OwnerId, string CreatedAt)
        {
            this.Id = Id;
            this.Title = Title;
            this.Value = Value;
            this.OwnerId = OwnerId;
            this.CreatedAt = CreatedAt;
        }

        public ToDoTask(string Title, string Value, string OwnerId)
        {
            Id = null;
            this.Title = Title;
            this.Value = Value;
            this.OwnerId = OwnerId;
            CreatedAt = DateTime.Now.ToString();
        }

        public string SerializeToDoTask()
        {
            return JsonConvert.SerializeObject(this);
        }

     }
}