using System;

namespace api.Models
{
    public class Planner
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsWorkDone { get; set; }
        public DateTime Date { get; set; }
    }
}
