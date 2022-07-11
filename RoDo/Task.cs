using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RoDo
{
    public class Task
    {
        public Task(string text, bool isDone)
        {
            TaskText = text;
            IsDone = isDone;
            TaskBox = CreateTaskForm();
        }

        public string TaskText { get; set; }
        public bool IsDone { get; set; } = false;
        public CheckBox TaskBox { get; set; }

        private CheckBox CreateTaskForm()
        {
            CheckBox rb = new CheckBox();
            rb.Text = TaskText;
            rb.Location = new Point();
            rb.Checked = IsDone;
            rb.AutoSize = true;
            rb.Font = new Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            rb.CheckedChanged += OnStatusChanged;

            return rb;
        }
        public void OnStatusChanged(object sender, EventArgs e)
        {
            IsDone = IsDone ? false : true;
        }
        public override string ToString()
        {
            return TaskText;
        }
    }
}
