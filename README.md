# api

- Get - print all the planner info;
- Get[id] - print id info;
- Post - create a new task;
- Put - change all the parameters, except the id;
- Patch - mark work as done or not done with timechanging;
- Delete - delete task

Parameteres:
- Id;
- type (type of work);
- Description;
- IsWorkDone
- Date (IsWorkDone == false ? date of the beginning : date of ending)
 * You can use only "Work" and "Personal" types of tasks. Also work cannot be done, when you create a new task
