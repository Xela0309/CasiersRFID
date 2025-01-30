
DROP TABLE IF EXISTS Casier;
DROP TABLE IF EXISTS Utilisateur;

CREATE TABLE Utilisateur (
    id_Utilisateur INT PRIMARY KEY AUTO_INCREMENT,
    tag_Utilisateur VARCHAR(50) NOT NULL UNIQUE,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL UNIQUE,
    motDePasse VARCHAR(255) NOT NULL,
    dateDePassage DATE NOT NULL,
    dateDeDepart DATE NOT NULL
) ENGINE=InnoDB;

CREATE TABLE Casier (
    id_Casier INT PRIMARY KEY AUTO_INCREMENT,
    numeroCasier INT NOT NULL UNIQUE,
    tag_Utilisateur VARCHAR(50),
    CONSTRAINT fk_Casier_Utilisateur FOREIGN KEY (tag_Utilisateur) REFERENCES Utilisateur(tag_Utilisateur)
) ENGINE=InnoDB;
