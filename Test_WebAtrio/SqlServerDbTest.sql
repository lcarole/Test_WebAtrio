/* Création et sélection de la base */
CREATE DATABASE TestWebAtrio
GO
USE TestWebAtrio

/* Création des tables */
CREATE TABLE Personnes(
	personneID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nom varchar(50) NOT NULL,
	prenom varchar(50) NOT NULL,
	dateDeNaissance datetime NOT NULL,
)

CREATE TABLE Emplois(
	emploiID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	entreprise varchar(100) NOT NULL,
	poste varchar(100) NOT NULL,
)

/* Création de la table associative de personnes et emplois */
CREATE TABLE Personne_Employée(
	emploiID int NOT NULL,
	personneID int NOT NULL,
	dateDebut datetime NOT NULL,
	dateFin datetime,

	CONSTRAINT PK_Personne_Employées_emploiID_personneID PRIMARY KEY CLUSTERED (emploiID,personneID),
	CONSTRAINT FK_Personne FOREIGN KEY (personneID) REFERENCES Personnes(personneID),
    CONSTRAINT FK_Emploi FOREIGN KEY (emploiID) REFERENCES Emplois(emploiID) 
)