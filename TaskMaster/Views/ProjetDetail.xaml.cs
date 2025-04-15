using TaskMaster.ViewModels;
using TaskMaster.Services;
using TaskMaster.Models;

namespace TaskMaster.Views
{
    public partial class ProjetDetail : ContentPage
    {
        public ProjetDetail(Projet projet, ITacheService tacheService, ISessionService sessionService)
        {
            InitializeComponent();
            BindingContext = new ProjetDetailViewModel(tacheService, sessionService, projet.Id_Projet);
        }
    }
} 