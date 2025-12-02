# Waste2Rewards

Une application mobile .NET MAUI pour la gestion des demandes de collecte de déchets avec un système de récompenses.

## Aperçu

Waste2Rewards est une application mobile multi-pages qui permet aux utilisateurs de demander des collectes de déchets, suivre leur historique de gestion des déchets et gagner des récompenses. L'application offre une interface claire et intuitive avec un flux de travail complet depuis la soumission de la demande jusqu'au suivi.

## Fonctionnalités

- Flux de demande de collecte de déchets en plusieurs étapes
- Planification de collecte par zone
- Options de fréquence flexibles (hebdomadaire, mensuelle, trimestrielle)
- Catégorisation des types de déchets
- Suivi de l'historique des demandes
- Système de récompenses intégré
- Annulation des demandes en attente
- Capture d'image pour documentation des déchets

## Technologies Utilisées

- .NET MAUI
- C# 11
- Pattern MVVM
- Injection de Dépendances
- Navigation Shell

## Structure du Projet

```
Waste2Rewards/
├── Models/
│   └── WastePickup.cs
├── Services/
│   └── WastePickupService.cs
├── Pages/
│   ├── HomePage.xaml
│   ├── PickupTypePage.xaml
│   ├── PickupAreaPage.xaml
│   ├── PickupDatePage.xaml
│   ├── PickupCompletionPage.xaml
│   ├── WasteHistoryPage.xaml
│   ├── WasteDetailPage.xaml
│   └── ProfilePage.xaml
├── AppShell.xaml
└── MauiProgram.cs
```

## Modèle de Données

### WastePickup
- **Id**: Identifiant unique (GUID)
- **UserId**: Identifiant utilisateur fixe (USER001)
- **PickupType**: Collecte normale ou programmée
- **Area**: Zone géographique de collecte
- **Address**: Adresse exacte de collecte
- **Frequency**: Fréquence de collecte (une fois, hebdomadaire, bimensuelle)
- **Date**: Date de collecte prévue
- **WasteType**: Catégorie de déchets (Électrique, Carbone, Domestique, Plastique, Métal)
- **Description**: Détails optionnels
- **ImagePath**: Chemin de la photo documentation
- **Status**: État de la demande (requested, cancelled, done)
- **CreatedAt**: Horodatage de création de la demande

## Couche de Service

### IWastePickupService

L'interface de service fournit les opérations suivantes :

- `Create(WastePickup request)` - Soumettre une nouvelle demande de collecte
- `GetHistory(string userId)` - Récupérer l'historique des demandes de l'utilisateur
- `Cancel(string id)` - Annuler une demande en attente
- `GetById(string id)` - Obtenir les détails d'une demande spécifique

### Notes d'Implémentation

- Utilise un stockage en mémoire avec une List statique
- Aucune base de données ou API externe requise
- Génération automatique d'ID lors de la création
- Attribution du statut par défaut à "requested"
- Historique trié par date de création (le plus récent en premier)

## Flux Utilisateur

1. **Écran d'Accueil** - L'utilisateur initie une demande de collecte
2. **Sélection du Type de Collecte** - Choisir entre service normal ou programmé
3. **Sélection de la Zone** - Sélectionner la zone géographique et fournir l'adresse exacte
4. **Configuration de la Date** - Choisir la fréquence et la date spécifique
5. **Finalisation** - Ajouter une photo, sélectionner le type de déchet, ajouter une description
6. **Soumission** - Demande créée et sauvegardée
7. **Vue Historique** - Consulter toutes les demandes passées et actuelles
8. **Vue Détaillée** - Examiner une demande spécifique et annuler si nécessaire

## Palette de Couleurs

- Principal: #FF7200 (Orange)
- Texte: #323232 (Gris Foncé)
- Arrière-plan: #FFFFFF (Blanc)
- Arrière-plan Secondaire: #F5F5F5 (Gris Clair)
- Bordure: #E0E0E0 (Bordure Claire)
- Succès: #28A745 (Vert)
- Erreur: #DC3545 (Rouge)

## Routes de Navigation

L'application utilise la navigation Shell avec les routes suivantes :

- `home` - Page d'accueil principale
- `pickup_type` - Sélection du type de collecte
- `pickup_area` - Saisie de la zone et de l'adresse
- `pickup_date` - Sélection de la fréquence et de la date
- `pickup_completion` - Formulaire de soumission final
- `waste_history` - Liste de l'historique des demandes
- `waste_detail` - Détails d'une demande individuelle
- `profile` - Profil utilisateur (placeholder)

## Instructions d'Installation

### Prérequis

- .NET 7.0 ou version ultérieure
- Visual Studio 2022 ou Visual Studio Code
- Workload .NET MAUI installé

### Installation

1. Cloner le dépôt
```bash
git clone https://github.com/yourusername/waste2rewards.git
```

2. Naviguer vers le répertoire du projet
```bash
cd waste2rewards
```

3. Restaurer les dépendances
```bash
dotnet restore
```

4. Compiler le projet
```bash
dotnet build
```

5. Exécuter l'application
```bash
dotnet run
```

### Configuration Spécifique aux Plateformes

#### Android
Ajouter les permissions caméra et stockage dans `AndroidManifest.xml` :
```xml
<uses-permission android:name="android.permission.CAMERA" />
<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
```

#### iOS
Ajouter les clés requises dans `Info.plist` :
```xml
<key>NSCameraUsageDescription</key>
<string>Cette application a besoin d'accéder à la caméra pour prendre des photos des déchets.</string>
<key>NSPhotoLibraryUsageDescription</key>
<string>Cette application a besoin d'accéder aux photos.</string>
```

## Configuration

### Injection de Dépendances

Les services et pages sont enregistrés dans `MauiProgram.cs` :

```csharp
// Services
builder.Services.AddSingleton<IWastePickupService, WastePickupService>();

// Pages
builder.Services.AddTransient<HomePage>();
builder.Services.AddTransient<PickupTypePage>();
// ... autres pages
```

## Utilisation

### Créer une Demande de Collecte

1. Appuyer sur "Waste & get Point" sur l'écran d'accueil
2. Sélectionner votre type de collecte préféré
3. Choisir votre zone dans la liste
4. Saisir votre adresse exacte
5. Sélectionner la fréquence et la date de collecte
6. Capturer ou sélectionner une photo des déchets
7. Choisir le type de déchet dans la liste déroulante
8. Ajouter une description optionnelle
9. Soumettre la demande

### Consulter l'Historique

1. Naviguer vers l'onglet "My History"
2. Voir les statistiques récapitulatives
3. Appuyer sur n'importe quelle demande pour voir les détails

### Annuler une Demande

1. Ouvrir les détails de la demande depuis l'historique
2. Appuyer sur le bouton "Cancel Request" (disponible uniquement pour les demandes en attente)
3. Confirmer l'annulation

## Persistance des Données

Actuellement, l'application utilise un stockage en mémoire. Toutes les données sont perdues lorsque l'application se ferme. Cette conception permet :

- Un prototypage rapide
- Des tests simples
- Une démonstration facile
- Aucune configuration de base de données requise

Pour une utilisation en production, envisagez d'implémenter :
- Base de données locale SQLite
- Stockage cloud (Azure, Firebase)
- Intégration API REST

## Tests

Le service en mémoire peut être facilement testé :

```csharp
var service = new WastePickupService();

// Créer une demande de test
var request = new WastePickup
{
    UserId = "USER001",
    PickupType = "normal",
    Area = "Shah Alam",
    // ... autres propriétés
};

await service.Create(request);

// Récupérer l'historique
var history = await service.GetHistory("USER001");
```

## Améliorations Futures

- Système d'authentification utilisateur
- Notifications en temps réel
- Calcul des points de récompense
- Intégration de paiement
- Optimisation des itinéraires pour les collecteurs
- Tableau de bord analytique
- Support multilingue
- Mode hors ligne avec synchronisation
- Notifications push

## Remerciements

- Développé avec .NET MAUI
- Design UI inspiré des principes modernes du material design
- Les icônes et images sont des placeholders à des fins de démonstration