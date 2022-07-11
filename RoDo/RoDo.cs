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
            taskSet = new TaskSet(pnlTasks, GetTasks());
            taskSet.Draw();
        }

        private TaskSet taskSet;

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
                foreach (Task task in taskSet.Tasks)
                {
                    writer.WriteLine($"{task.TaskText}, {task.IsDone}");
                }
            }
        }
        private void bCreate_Click(object sender, EventArgs e)
        {
            string taskText = tbInput.Text;
            if(IsValide(taskText))
            {
                Task task = new Task(taskText, false);
                taskSet.Add(task);
            }
        }
        private bool IsValide(string taskText)
        {
            return taskText != "" &&
                !string.IsNullOrWhiteSpace(taskText) &&
                taskSet.Tasks.Find(t => t.TaskText.Trim() == taskText.Trim()) == null;
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
        private void RoDo_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTasks();
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (tbInput.Text == "Enter your task here...")
            {
                tbInput.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbInput.Text))
                tbInput.Text = "Enter your task here...";
        }
    }
}
