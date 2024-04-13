using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoDo.Model;

public class TaskItem
{
    private static int _latestId = 0;

    private int _id;
    private string _title;
    private string _note;
    private bool _isDone;

    public TaskItem(string title = "A task", string note = "", bool isDone = false)
    {
        Id = ++_latestId;
        Title = title;
        Note = note;
        IsDone = isDone;
    }

    public int Id { get => _id; set => _id = value; }
    public string Title { get => _title; set => _title = value; }
    public string Note { get => _note; set => _note = value; }
    public bool IsDone { get => _isDone; set => _isDone = value; }
}

