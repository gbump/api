using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Services
{
    public static class PlannerService
    {
        static List<Planner> Plans { get; }
        static int nextId = 3;
        static PlannerService()
        {
            Plans = new List<Planner>
            {
                new Planner { Id = 1, Type = "work", Description = "make a study project", Date = DateTime.Now, IsWorkDone = false },
                new Planner { Id = 2, Type = "personal", Description = "clean the house", Date = DateTime.Now, IsWorkDone = false }
            };
        }
        public static List<Planner> GetAll() => Plans;

        public static Planner Get(int id) => Plans.FirstOrDefault(p => p.Id == id);

        public static void Add(Planner planner)
        {
            planner.Id = nextId++;
            if (!(planner.Type.Equals("work")) && !(planner.Type.Equals("personal")))
                return ;
            if (planner.IsWorkDone == true)
                return ;
            Plans.Add(planner);
        }

        public static void Delete(int id)
        {
            var planner = Get(id);
            if (planner is null)
                return;
            //SaveChanges();
            Plans.Remove(planner);
        }

        public static void Update(Planner planner)
        {
            var index = Plans.FindIndex(p => p.Id == planner.Id);
            if (index == -1)
                return;
            if (Plans[index].IsWorkDone != planner.IsWorkDone)
            {
                Plans[index].IsWorkDone = planner.IsWorkDone;
                Plans[index].Date = DateTime.Now;
            }
            string[] strA = { "work", "personal" };
            if (planner.Type.Equals(strA[0]) || planner.Type.Equals(strA[1]))
              Plans[index].Type = planner.Type;
            Plans[index].Description = planner.Description;
            // Plans[index] = planner;
        }
        public static void Patch([FromBody]Planner planner)
        {
            var index = Plans.FindIndex(p => p.Id == planner.Id);
            if (index == -1)
                return;
            if (Plans[index].IsWorkDone != planner.IsWorkDone)
            {
                Plans[index].IsWorkDone = planner.IsWorkDone;
                Plans[index].Date = DateTime.Now;
            }
        }
    }
}

