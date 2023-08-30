using RoDo.ViewModel;

namespace RoDo;

public partial class TaskDetailPage : ContentPage
{
	public TaskDetailPage(TaskDetailViewModel taskDetailViewModel)
	{
		InitializeComponent();
		BindingContext = taskDetailViewModel;
	}
}