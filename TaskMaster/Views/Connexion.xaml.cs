using TaskMaster.ViewModels;
using TaskMaster.Services;
using Microsoft.Maui.Controls;

namespace TaskMaster.Views
{
    public partial class Connexion : ContentPage
    {
        public Connexion(IAuthService authService, ISessionService sessionService)
        {
            InitializeComponent();
            var viewModel = new ConnexionViewModel();
            viewModel.Initialize(authService, sessionService);
            BindingContext = viewModel;
        }
    }
}