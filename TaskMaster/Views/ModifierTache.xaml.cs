using Microsoft.Maui.Controls;
using TaskMaster.Models;
using TaskMaster.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskMaster.Views;

public partial class ModifierTache : ContentPage, INotifyPropertyChanged
{
    private readonly ITacheService _tacheService;
    private readonly Tache _tache;
    
    // Événement pour notifier de la modification d'une tâche
    public event EventHandler<Tache> TacheModified;
    
    // Propriétés pour le binding
    private string _titre;
    public string Titre
    {
        get => _titre;
        set
        {
            if (_titre != value)
            {
                _titre = value;
                OnPropertyChanged();
            }
        }
    }
    
    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
    
    private DateTime _dateEcheance;
    public DateTime DateEcheance
    {
        get => _dateEcheance;
        set
        {
            if (_dateEcheance != value)
            {
                _dateEcheance = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime DateMinimum => DateTime.Today;
    
    private string _statut;
    public string Statut
    {
        get => _statut;
        set
        {
            if (_statut != value)
            {
                _statut = value;
                OnPropertyChanged();
            }
        }
    }
    
    private string _priorite;
    public string Priorite
    {
        get => _priorite;
        set
        {
            if (_priorite != value)
            {
                _priorite = value;
                OnPropertyChanged();
            }
        }
    }
    
    private string _categorie;
    public string Categorie
    {
        get => _categorie;
        set
        {
            if (_categorie != value)
            {
                _categorie = value;
                OnPropertyChanged();
            }
        }
    }
    
    private string _etiquette;
    public string Etiquette
    {
        get => _etiquette;
        set
        {
            if (_etiquette != value)
            {
                _etiquette = value;
                OnPropertyChanged();
            }
        }
    }
    
    // Listes pour les pickers
    public List<string> Statuts { get; } = new List<string> { "À faire", "En cours", "Terminé" };
    public List<string> Priorites { get; } = new List<string> { "Haute", "Moyenne", "Basse" };
    
    public ModifierTache(Tache tache, ITacheService tacheService)
    {
        InitializeComponent();
        _tache = tache;
        _tacheService = tacheService;
        
        // Initialiser les champs avec les valeurs actuelles de la tâche
        Titre = tache.Titre;
        Description = tache.Description;
        DateEcheance = tache.DateEcheance;
        Statut = tache.Statut;
        Priorite = tache.Priorite;
        Categorie = tache.Categorie;
        Etiquette = tache.Etiquette;
        
        BindingContext = this;
    }
    
    private async void OnEnregistrerClicked(object sender, EventArgs e)
    {
        // Vérifier que les champs obligatoires sont remplis
        if (string.IsNullOrWhiteSpace(Titre) || string.IsNullOrWhiteSpace(Description))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs obligatoires", "OK");
            return;
        }
        
        try
        {
            // Mettre à jour la tâche
            var tacheModifiee = await _tacheService.UpdateTacheAsync(
                _tache.Id_Tache,
                Titre,
                Description,
                Categorie,
                Priorite,
                Statut,
                DateEcheance,
                Etiquette
            );
            
            // Notifier de la modification
            TacheModified?.Invoke(this, tacheModifiee);
            
            await DisplayAlert("Succès", "La tâche a été modifiée avec succès", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Une erreur est survenue lors de la modification de la tâche : {ex.Message}", "OK");
        }
    }
    
    private async void OnAnnulerClicked(object sender, EventArgs e)
    {
        // Naviguer en arrière sans sauvegarder
        await Navigation.PopAsync();
    }
    
    // Implémentation de INotifyPropertyChanged
    public new event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
} 