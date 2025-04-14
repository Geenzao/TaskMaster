using Microsoft.Maui.Controls;
using TaskMaster.Models;

namespace TaskMaster.Views;

public partial class TacheDetail : ContentPage
{
    public Tache Tache { get; set; }

    public TacheDetail(Tache tache)
    {
        InitializeComponent();
    }
}