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
        }
        public string TaskText { get; set; }
        public bool IsDone { get; set; } = false;

        public override string ToString()
        {
            return TaskText;
        }
    }
}
