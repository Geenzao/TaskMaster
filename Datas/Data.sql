-- Insertion des utilisateurs
INSERT INTO Utilisateur (Nom, Prenom, email, MotDePasse) VALUES
('Lorenzo', 'Quentin', 'quentin.lorenzo@email.com', 'password0'),
('Sudre', 'Aymeric', 'aymeric.sudre@email.com', 'password1'),
('Doe', 'John', 'john.doe@email.com', 'password2');

-- Insertion des projets
INSERT INTO Projet (Nom, Description) VALUES
('Refonte Site Web', 'Modernisation du site web de l''entreprise'),
('Application Mobile', 'Développement d''une application mobile client'),
('Marketing Digital', 'Campagne marketing Q4 2024');

-- Insertion des tâches
INSERT INTO Tache (Titre, Description, DateCreation, DateEcheance, Statut, Priorite, Categorie, Etiquette, Id_Utilisateur) VALUES
('Maquettes UI', 'Créer les maquettes pour la page d''accueil', '2024-03-15', '2024-04-01', 'En cours', 'Haute', 'Design', 'Frontend', 1),
('API REST', 'Développer l''API backend', '2024-03-15', '2024-04-15', 'À faire', 'Moyenne', 'Développement', 'Backend', 2),
('Tests Utilisateurs', 'Organiser des sessions de tests', '2024-03-15', '2024-04-30', 'À faire', 'Basse', 'QA', 'Testing', 3);

-- Insertion des sous-tâches
INSERT INTO SousTache (Titre, Statut, DateEcheance, Id_Tache, Id_Utilisateur) VALUES
('Design Mobile', 'En cours', '2024-03-25', 1, 1),
('Design Desktop', 'À faire', '2024-03-28', 1, 1),
('Documentation API', 'À faire', '2024-04-10', 2, 2);

-- Insertion des commentaires
INSERT INTO Commentaires (DateCreation, Contenu, Id_Tache, Id_Utilisateur) VALUES
('2024-03-15 10:00:00', 'Première version des maquettes terminée', 1, 1),
('2024-03-15 14:30:00', 'Architecture de l''API validée', 2, 2),
('2024-03-15 16:45:00', 'Planning des tests à valider', 3, 3);

-- Insertion dans la table Historique
INSERT INTO Historique (Description, AncienneValeur, NouvelleValeur, DateModification, Id_Tache) VALUES
('Modification statut', 'À faire', 'En cours', '2024-03-15 09:00:00', 1),
('Modification priorité', 'Basse', 'Moyenne', '2024-03-15 11:00:00', 2),
('Modification date échéance', '2024-04-15', '2024-04-30', '2024-03-15 14:00:00', 3);

-- Insertion des participations aux projets
INSERT INTO Participer (Id_Utilisateur, Id_Tache, Id_Projet) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1);
