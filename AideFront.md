**Contrôles de base**
- `Label` : Affichage de texte
- `Button` : Bouton standard
- `ImageButton` : Bouton avec image
- `Image` : Affichage d'images

**Contrôles de saisie**
- `Entry` : Champ de texte sur une ligne
- `Editor` : Zone de texte multi-lignes
- `SearchBar` : Barre de recherche
- `Slider` : Curseur pour sélectionner une valeur
- `Stepper` : Boutons +/- pour incrémenter/décrémenter
- `Switch` : Interrupteur On/Off
- `DatePicker` : Sélecteur de date
- `TimePicker` : Sélecteur d'heure
- `Picker` : Liste déroulante

**Conteneurs de mise en page**
- `StackLayout` : Empile les éléments verticalement ou horizontalement
- `Grid` : Disposition en grille
- `HorizontalStackLayout` : Empile horizontalement
- `VerticalStackLayout` : Empile verticalement
- `FlexLayout` : Disposition flexible
- `AbsoluteLayout` : Positionnement absolu
- `RelativeLayout` : Positionnement relatif
- `ScrollView` : Vue défilante
- `Frame` : Conteneur avec bordure
- `Border` : Conteneur avec bordure personnalisable

**Listes et Collections**
- `CollectionView` : Liste moderne et performante
- `CarouselView` : Vue en carrousel
- `ListView` : Liste classique
- `TableView` : Vue tabulaire
- `IndicatorView` : Indicateurs de position (souvent utilisé avec CarouselView)

**Navigation**
- `NavigationPage` : Page avec barre de navigation
- `TabbedPage` : Page avec onglets
- `FlyoutPage` : Page avec menu latéral
- `Shell` : Navigation moderne (recommandée)

**Indicateurs et Notifications**
- `ActivityIndicator` : Indicateur de chargement
- `ProgressBar` : Barre de progression
- `RefreshView` : Vue avec rafraîchissement par glissement

**Graphiques et Dessins**
- `BoxView` : Rectangle coloré simple
- `GraphicsView` : Zone de dessin personnalisée
- `WebView` : Affichage de contenu web

**Contrôles de disposition avancés**
- `ContentView` : Vue personnalisable
- `ContentPage` : Page de contenu
- `SwipeView` : Vue avec actions par glissement
- `RadioButton` : Bouton radio
- `CheckBox` : Case à cocher

**Propriétés communes importantes**
- `Margin` : Marges externes
- `Padding` : Marges internes
- `BackgroundColor` : Couleur de fond
- `HorizontalOptions` : Alignement horizontal
- `VerticalOptions` : Alignement vertical
- `IsVisible` : Visibilité
- `IsEnabled` : Activation/Désactivation
- `Opacity` : Transparence

**Exemples d'utilisation**

```xaml
<!-- Exemple de formulaire basique -->
<VerticalStackLayout Spacing="10" Padding="20">
    <Label Text="Nom :" />
    <Entry Placeholder="Entrez votre nom" />
    
    <Label Text="Age :" />
    <HorizontalStackLayout Spacing="10">
        <Stepper Minimum="0" Maximum="120" />
        <Label Text="{Binding Source={x:Reference stepper}, Path=Value}" />
    </HorizontalStackLayout>
    
    <Label Text="Date de naissance :" />
    <DatePicker />
    
    <Label Text="Notifications :" />
    <Switch />
    
    <Button Text="Enregistrer" />
</VerticalStackLayout>

<!-- Exemple de liste -->
<CollectionView>
    <CollectionView.ItemTemplate>
        <DataTemplate>
            <Frame Margin="5">
                <HorizontalStackLayout>
                    <Image Source="{Binding ImageUrl}" />
                    <Label Text="{Binding Name}" />
                </HorizontalStackLayout>
            </Frame>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```

Chaque contrôle peut être personnalisé avec :
- Des styles
- Des templates
- Des triggers
- Des behaviors
- Des effets visuels

### Couleurs prédéfinies

- **Couleurs de base** :
  - `Black`
  - `White`
  - `Gray`
  - `Red`
  - `Green`
  - `Blue`
  - `Yellow`
  - `Orange`
  - `Purple`
  - `Pink`
  - `Brown`
  - `Cyan`
  - `Magenta`

- **Nuances de gris** :
  - `DarkGray`
  - `LightGray`

- **Couleurs supplémentaires** :
  - `Transparent`
  - `Aqua`
  - `Lime`
  - `Maroon`
  - `Navy`
  - `Olive`
  - `Teal`
  - `Silver`
  - `Fuchsia`

### Utilisation des couleurs

Vous pouvez utiliser ces couleurs directement dans vos fichiers XAML ou en C#.

**Exemple en XAML** :
```xaml
<Label Text="Hello, World!" 
       TextColor="Blue" 
       BackgroundColor="LightGray" />
```

**Exemple en C#** :
```csharp
var label = new Label
{
    Text = "Hello, World!",
    TextColor = Colors.Blue,
    BackgroundColor = Colors.LightGray
};
```

### Définition de couleurs personnalisées

Vous pouvez également définir vos propres couleurs en utilisant des valeurs hexadécimales ou RGB.

**Exemple en XAML** :
```xaml
<Label Text="Hello, World!" 
       TextColor="#FF5733" 
       BackgroundColor="#33FF57" />
```

**Exemple en C#** :
```csharp
var label = new Label
{
    Text = "Hello, World!",
    TextColor = Color.FromArgb("#FF5733"),
    BackgroundColor = Color.FromArgb("#33FF57")
};
```

### Utilisation des ressources de couleur

Vous pouvez définir des couleurs dans les ressources de votre application pour une utilisation cohérente.

**Exemple dans `App.xaml`** :
```xaml
<Application xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="TaskMaster.App">
    <Application.Resources>
        <ResourceDictionary>
            <Color x:Key="PrimaryColor">#FF5733</Color>
            <Color x:Key="SecondaryColor">#33FF57</Color>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

**Utilisation dans XAML** :
```xaml
<Label Text="Hello, World!" 
       TextColor="{StaticResource PrimaryColor}" 
       BackgroundColor="{StaticResource SecondaryColor}" />
```

**Utilisation en C#** :
```csharp
var label = new Label
{
    Text = "Hello, World!",
    TextColor = (Color)Application.Current.Resources["PrimaryColor"],
    BackgroundColor = (Color)Application.Current.Resources["SecondaryColor"]
};
```

### Résumé

- Utilisez les couleurs prédéfinies pour des couleurs de base.
- Définissez des couleurs personnalisées avec des valeurs hexadécimales ou RGB.
- Utilisez les ressources de couleur pour une utilisation cohérente dans toute l'application.