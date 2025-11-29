# **Waste2Rewards – Application Mobile .NET MAUI**

Une application mobile moderne destinée aux habitants de **Douala-Bonaberi**, permettant de **vendre des déchets recyclables** ou de **commander un ramassage**, tout en proposant une interface fluide et intuitive développée en **.NET MAUI**.

## **Présentation du projet**

Waste2Rewards est une application hybride développée avec **.NET MAUI**, mettant l’accent sur :

* Une **expérience utilisateur fluide**
* Des **interfaces modernes et eco**
* Une **architecture propre et modulaire (MVVM)**
* Des fonctionnalités orientées vers la **collecte et la valorisation des déchets recyclables**
* Des paiements sécurisés via **Flutterwave**
* Une compatibilité multiplateforme : **Android, iOS et Windows**

## **Structure du projet**

Le projet respecte une architecture claire basée sur le pattern **MVVM (Model – ViewModel – View)**.

Waste2Rewards/
│
├── Models/
│   ├── User.cs
│   ├── PickupRequest.cs
│   ├── WasteSale.cs
│   └── ApiResponse.cs
│
├── ViewModels/
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   ├── HomeViewModel.cs
│   ├── PickupViewModel.cs
│   ├── SellViewModel.cs
│   ├── HistoryViewModel.cs
│   └── ProfileViewModel.cs
│
├── Views/
│   ├── LoginPage.xaml
│   ├── RegisterPage.xaml
│   ├── HomePage.xaml
│   ├── PickupPage.xaml
│   ├── SellPage.xaml
│   ├── HistoryPage.xaml
│   └── ProfilePage.xaml
│
├── Services/
│   ├── ApiService.cs
│   ├── AuthService.cs
│   ├── PaymentService.cs
│   └── LocationService.cs
│
├── Helpers/
│   ├── Constants.cs
│   ├── Converters/
│   └── Validators/
│
├── Resources/
│   ├── Images/
│   │   ├── logo.png
│   │   └── icons/...
│   ├── Fonts/
│   │   ├── Montserrat-Regular.ttf
│   │   └── Montserrat-Bold.ttf
│   └── Styles/
│       ├── Colors.xaml
│       └── Styles.xaml
│
├── Platforms/
│   ├── Android/
│   ├── iOS/
│   └── Windows/
│
├── App.xaml
├── AppShell.xaml
├── MauiProgram.cs
└── README.md

## **Fonctionnalités principales**

### 1. **Authentification**

* Inscription & Connexion
* Gestion du profil utilisateur
* Stockage local sécurisé

### 2. **Demande de ramassage**

* Choix du type :

  * Instantané
  * Hebdomadaire
  * Bi-hebdomadaire
  * Mensuel
* Interface intuitive pour sélectionner la date/heure
* Paiement Flutterwave intégré

### 3. **Vente de déchets recyclables**

* Saisie du poids en kilogrammes
* Calcul automatique du montant
* Confirmation et suivi

### 4. **Historique des opérations**

* Visualisation des demandes précédentes
* Filtrage des opérations (vente / ramassage)

### 5. **Paiements (Flutterwave)**

* Redirection vers l’interface sécurisée Flutterwave
* Gestion retour succès/erreur

---

## **Architecture technique**

### **Pattern utilisé : MVVM**

* **Models** → Représentation des données
* **ViewModels** → Logique métier + Binding
* **Views** → Interfaces XAML

### **Technologies**

| Technologie     | Rôle                         |
| --------------- | ---------------------------- |
| .NET MAUI       | Développement cross-platform |
| C#              | Langage principal            |
| MVVM            | Architecture                 |
| MySQL           | Base de données backend      |
| PHP MVC         | Backend API                  |
| Flutterwave     | Paiements                    |
| Google Maps API | Localisation (optionnel)     |

---

## **Installation et lancement du projet**

### **Prérequis**

* .NET SDK 8.0+
* Visual Studio 2022 (workload MAUI installé)
* Un appareil Android ou un émulateur
* Compte Flutterwave (clé API)
* Backend PHP + MySQL déployé

### **Étapes**

1. Cloner le projet :

```sh
git clone https://github.com/briandave-dev/Waste2Rewards.git
```

2. Restaurer les packages :

```sh
dotnet restore
```

3. Lancer le projet :

```sh
dotnet build
dotnet maui run
```

---

## **Design et UI/UX**

* Palette de couleurs orientée “écologie” : vert, blanc, gris doux
* Icônes simples et lisibles
* Navigation via **AppShell**
* Styles centralisés dans `/Resources/Styles/`
* Expérience fluide et intuitive

---

## **Sécurité**

* Aucune donnée sensible stockée en clair
* Appels API sécurisés (HTTPS recommandé)
* Respect du cycle MAUI pour permissions (location, camera si besoin)

---

## **Tests prévus**

* Tests UI manuels
* Tests de navigation
* Tests de validation des formulaires
* Tests d’intégration Flutterwave
* Tests sur appareils Android réels (priorité)

---

## **Perspectives d’évolution**

* Ajout d'une IA pour reconnaître les déchets via photo
* Expansion à toute la ville de Douala
* Notifications push (Firebase)
* Suivi en temps réel des collecteurs
* Programme de fidélité (gamification : badges, récompenses)

---

## **Auteur**

**Brian Mountou**
Master 2 – Génie Logiciel