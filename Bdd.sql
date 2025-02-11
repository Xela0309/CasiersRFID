DROP TABLE IF EXISTS Utilisateur;
DROP TABLE IF EXISTS Affectation;
DROP TABLE IF EXISTS Casier;
DROP TABLE IF EXISTS Visiteur;
DROP TABLE IF EXISTS Tag;



CREATE TABLE Tag (
    tag VARCHAR(20) PRIMARY KEY NOT NULL 
) ENGINE = InnoDB;

CREATE TABLE Visiteur (
    id_Visiteur INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    compagnie VARCHAR(70) NOT NULL,
    numPlaque VARCHAR(9) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE Casier (
    numeroCasier INT PRIMARY KEY NOT NULL 
) ENGINE=InnoDB;

CREATE TABLE Affectation (
    id_Affectation INT PRIMARY KEY AUTO_INCREMENT,
    id_Casier INT NOT NULL,
    id_Visiteur INT NOT NULL,
    id_Tag VARCHAR(20) NOT NULL,
    dateDebut DATE NOT NULL,
    dateFin DATE NOT NULL,
    CONSTRAINT fk_id_Casier FOREIGN KEY (id_Casier) REFERENCES Casier(numeroCasier),
    CONSTRAINT fk_id_Visiteur FOREIGN KEY (id_Visiteur) REFERENCES Visiteur(id_Visiteur),
    CONSTRAINT fk_id_Tag FOREIGN KEY (id_Tag) REFERENCES Tag(tag)
) ENGINE=InnoDB;

CREATE TABLE Utilisateur (
    id_Administrateur INT PRIMARY KEY AUTO_INCREMENT,
    role Enum('admin', 'user') NOT NULL,
    login VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL
) ENGINE=InnoDB;