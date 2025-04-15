using Microsoft.Maui.Controls;
using TaskMaster.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskMaster.Views;

public partial class AjouterTache : ContentPage, INotifyPropertyChanged
{
    private Projet _projet;
    
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
    
    private DateTime _dateEcheance = DateTime.Now.AddDays(1);
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
    
    public AjouterTache(Projet projet)
    {
        InitializeComponent();
        _projet = projet;
        
        // Valeurs par défaut
        Titre = "";
        Description = "";
        Statut = Statuts[0]; // À faire
        Priorite = Priorites[1]; // Moyenne
        Categorie = "";
        Etiquette = "";
        
        BindingContext = this;
    }
    
    private async void OnAjouterClicked(object sender, EventArgs e)
    {
        // Vérifier que les champs obligatoires sont remplis
        if (string.IsNullOrWhiteSpace(Titre) || string.IsNullOrWhiteSpace(Description))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs obligatoires", "OK");
            return;
        }
        
        try
        {
            // Créer une nouvelle tâche
            var nouvelleTache = new Tache
            {
                Titre = Titre,
                Description = Description,
                DateCreation = DateTime.Now,
                DateEcheance = DateEcheance,
                Statut = Statut,
                Priorite = Priorite,
                Categorie = Categorie,
                Etiquette = Etiquette,
                Id_Utilisateur = 1
            };
            
            // Ajouter la tâche au projet
            _projet.Taches.Add(nouvelleTache);
            
            // Naviguer en arrière
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Une erreur est survenue lors de l'ajout de la tâche : {ex.Message}", "OK");
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
