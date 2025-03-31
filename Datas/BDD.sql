-- Suppression des tables existantes (dans l'ordre inverse des dépendances)
DROP TABLE IF EXISTS Participer;
DROP TABLE IF EXISTS Historique;
DROP TABLE IF EXISTS Commentaires;
DROP TABLE IF EXISTS SousTache;
DROP TABLE IF EXISTS Tache;
DROP TABLE IF EXISTS Utilisateur;
DROP TABLE IF EXISTS Projet;

-- Création des tables
CREATE TABLE Utilisateur (
    Id_Utilisateur INT AUTO_INCREMENT,
    Nom VARCHAR(50),
    Prenom VARCHAR(50),
    email VARCHAR(50),
    MotDePasse VARCHAR(50),
    PRIMARY KEY(Id_Utilisateur)
);

CREATE TABLE Tache (
    Id_Tache INT AUTO_INCREMENT,
    Titre VARCHAR(50),
    Description VARCHAR(244),
    DateCreation DATE,
    DateEcheance DATE,
    Statut VARCHAR(50),
    Priorite VARCHAR(50),
    Categorie VARCHAR(50),
    Etiquette VARCHAR(50),
    Id_Utilisateur INT NOT NULL,
    PRIMARY KEY(Id_Tache),
    FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur)
);

CREATE TABLE SousTache (
    Id_SousTache INT AUTO_INCREMENT,
    Titre VARCHAR(50) NOT NULL,
    Statut VARCHAR(50),
    DateEcheance DATE,
    Id_Tache INT NOT NULL,
    Id_Utilisateur INT NOT NULL,
    PRIMARY KEY(Id_SousTache),
    FOREIGN KEY(Id_Tache) REFERENCES Tache(Id_Tache),
    FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur)
);

CREATE TABLE Commentaires (
    Id_Commentaires INT AUTO_INCREMENT,
    DateCreation DATETIME,
    Contenu VARCHAR(244),
    Id_Tache INT NOT NULL,
    Id_Utilisateur INT NOT NULL,
    PRIMARY KEY(Id_Commentaires),
    FOREIGN KEY(Id_Tache) REFERENCES Tache(Id_Tache),
    FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur)
);

CREATE TABLE Historique (
    Id_Historique INT AUTO_INCREMENT,
    Description VARCHAR(244),
    AncienneValeur VARCHAR(50),
    NouvelleValeur VARCHAR(50),
    DateModification DATETIME,
    Id_Tache INT NOT NULL,
    PRIMARY KEY(Id_Historique),
    FOREIGN KEY(Id_Tache) REFERENCES Tache(Id_Tache)
);

CREATE TABLE Projet (
    Id_Projet INT AUTO_INCREMENT,
    Nom VARCHAR(50),
    Description VARCHAR(244),
    PRIMARY KEY(Id_Projet)
);

CREATE TABLE Participer (
    Id_Utilisateur INT,
    Id_Tache INT,
    Id_Projet INT,
    PRIMARY KEY(Id_Utilisateur, Id_Tache, Id_Projet),
    FOREIGN KEY(Id_Utilisateur) REFERENCES Utilisateur(Id_Utilisateur),
    FOREIGN KEY(Id_Tache) REFERENCES Tache(Id_Tache),
    FOREIGN KEY(Id_Projet) REFERENCES Projet(Id_Projet)
);