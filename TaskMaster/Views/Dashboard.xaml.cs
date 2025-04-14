using TaskMaster.ViewModels;
using TaskMaster.Services;

namespace TaskMaster.Views
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard(ISessionService sessionService)
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel(sessionService);
        }
    }
} 