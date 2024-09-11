/* Cr�ation et s�lection de la base */
CREATE DATABASE TestWebAtrio
GO
USE TestWebAtrio

/* Cr�ation des tables */
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

/* Cr�ation de la table associative de personnes et emplois */
CREATE TABLE Personne_Employ�e(
	emploiID int NOT NULL,
	personneID int NOT NULL,
	dateDebut datetime NOT NULL,
	dateFin datetime,

	CONSTRAINT PK_Personne_Employ�es_emploiID_personneID PRIMARY KEY CLUSTERED (emploiID,personneID),
	CONSTRAINT FK_Personne FOREIGN KEY (personneID) REFERENCES Personnes(personneID),
    CONSTRAINT FK_Emploi FOREIGN KEY (emploiID) REFERENCES Emplois(emploiID) 
)