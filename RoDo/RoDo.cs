using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RoDo
{
    public partial class RoDo : Form
    {
        public RoDo()
        {
            InitializeComponent();
            tasks = GetTasks();
            CreateTasksForm(tasks);
        }

        private List<Task> tasks = new List<Task>();

        private List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();
            int count = GetCountTasks();
            
            using (StreamReader reader = new StreamReader("tasks.txt"))
            {
                for (int i = 0; i < count; i++)
                {
                    string[] taskLine = reader.ReadLine().Split(',');
                    tasks.Add(new Task(taskLine[0], bool.Parse(taskLine[1])));
                }
            }

            return tasks;
        }
        private void SaveTasks()
        {
            using (StreamWriter writer = new StreamWriter("tasks.txt"))
            {
                foreach (Task task in tasks)
                {
                    writer.WriteLine($"{task.TaskText}, {task.IsDone}");
                }
            }
        }
        private int GetCountTasks()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader("tasks.txt"))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }
            return count;
        }
        private void bCreate_Click(object sender, EventArgs e)
        {
            string taskText = tbInput.Text;
            if(IsValide(taskText))
            {
                Task task = new Task(taskText, false);
                tasks.Add(task);
                CreateTaskForm(task);
            }
        }
        private bool IsValide(string taskText)
        {
            if (taskText != "") return true;
            return false;
        }
        private void CreateTasksForm(List<Task> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {

            }
        }
        private void CreateTaskForm(Task task)
        {
            
        }
        private void RoDo_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTasks();
        }
    }
}
