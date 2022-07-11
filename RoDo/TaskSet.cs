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
            TasksForm = CreateTaskForm();
        }

        public Control Parent { get; set; }
        public List<CheckBox> TasksForm { get; set; }
        public List<Task> Tasks { get; set; }

        private List<CheckBox> CreateTaskForm()
        {
            List<CheckBox> radioButtons = new List<CheckBox>();

            for (int i = 0; i < Tasks.Count; i++)
            {
                CheckBox rb = new CheckBox();
                rb.Text = Tasks[i].TaskText;
                rb.Location = new Point(10, i * rb.Height + 10);
                rb.Checked = Tasks[i].IsDone;
                rb.AutoSize = true;
                rb.Font = new Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                rb.CheckedChanged += OnStatusChanged;
                Parent.Controls.Add(rb);
                radioButtons.Add(rb);
            }

            return radioButtons;
        }
        public virtual void Add(Task task)
        {
            Tasks.Add(task);
            int i = Tasks.Count - 1;

            CheckBox rb = new CheckBox();
            rb.Text = task.TaskText;
            rb.Location = new Point(10, i * rb.Height + 10);
            rb.Checked = task.IsDone;
            rb.AutoSize = true;
            rb.Font = new Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rb.CheckedChanged += OnStatusChanged;
            Parent.Controls.Add(rb);
            TasksForm.Add(rb);
        }

        private void OnStatusChanged(object sender, EventArgs e)
        {
            CheckBox senderBox = (CheckBox)sender;

            if (senderBox != null)
            {
                Task task = Tasks.Find(t => t.TaskText.Trim() == senderBox.Text);
                task.IsDone = task.IsDone ? false : true;
            }
        }

        public virtual void Remove(Task task)
        {
            Tasks.Remove(task);

            CheckBox checkBox = TasksForm.Find(t => t.Text.Trim() == task.TaskText.Trim());
            Parent.Controls.Remove(checkBox);
            TasksForm.Remove(checkBox);
        }
    }
}
