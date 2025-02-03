
DROP TABLE IF EXISTS Casier;
DROP TABLE IF EXISTS Utilisateur;
DROP TABLE IF EXISTS Tag;
DROP TABLE IF EXISTS Affectation;
DROP TABLE IF EXISTS Administrateur;

CREATE TABLE Tag (
    id_Tag INT PRIMARY KEY AUTO_INCREMENT,
    tag VARCHAR(50) NOT NULL 
) ENGINE = InnoDB;

CREATE TABLE Utilisateur (
    id_Utilisateur INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL 
) ENGINE=InnoDB;

CREATE TABLE Casier (
    id_Casier INT PRIMARY KEY AUTO_INCREMENT,
    numeroCasier INT NOT NULL 
) ENGINE=InnoDB;

CREATE TABLE Affectation (
    id_Affectation INT PRIMARY KEY AUTO_INCREMENT,
    id_Casier INT NOT NULL,
    id_Utilisateur INT NOT NULL,
    id_Tag INT NOT NULL,
    dateDebut DATE NOT NULL,
    dateFin DATE NOT NULL,
    CONSTRAINT fk_id_Casier FOREIGN KEY (id_Casier) REFERENCES Casier(id_Casier),
    CONSTRAINT fk_id_Utilisateur FOREIGN KEY (id_Utilisateur) REFERENCES Utilisateur(id_Utilisateur),
    CONSTRAINT fk_id_Tag FOREIGN KEY (id_Tag) REFERENCES Tag(id_Tag)
) ENGINE=InnoDB;

CREATE TABLE Admistrateur (
    id_Administrateur INT PRIMARY KEY AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL
) ENGINE=InnoDB;