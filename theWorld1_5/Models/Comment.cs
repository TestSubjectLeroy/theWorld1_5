using System;

namespace theWorld1_5.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string USerName { get; set; }
        public string Response { get; set; }
        public int Order { get; set; }

    }
}