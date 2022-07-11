using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RoDo
{
    public class TaskSet
    {
        public TaskSet(Control parent, List<Task> tasks)
        {
            Parent = parent;
            Tasks = tasks;
        }

        public Control Parent { get; set; }
        public List<Task> Tasks { get; set; }

        public List<CheckBox> Draw()
        {
            List<CheckBox> radioButtons = new List<CheckBox>();
            Parent.Controls.Clear();

            for (int i = 0; i < Tasks.Count; i++)
            {
                Tasks[i].TaskBox.Location = new Point(10, i * Tasks[i].TaskBox.Height + 10);
                Parent.Controls.Add(Tasks[i].TaskBox);
            }

            return radioButtons;
        }
        public virtual void Add(Task task)
        {
            Tasks.Add(task);
            Parent.Controls.Add(task.TaskBox);
            Draw();
        }

        public virtual void Remove(Task task)
        {
            Parent.Controls.Remove(task.TaskBox);
            Tasks.Remove(task);
            Draw();
        }
    }
}
