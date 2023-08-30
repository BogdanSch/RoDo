using RoDo.Model;
using RoDo.ViewModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RoDo;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel mainViewModel)
    {
        InitializeComponent();
        BindingContext = mainViewModel;
    }
}

