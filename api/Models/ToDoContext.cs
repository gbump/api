using System;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Planner> TodoItems { get; set; }
    }
}