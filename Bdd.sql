
DROP TABLE IF EXISTS Casier;
DROP TABLE IF EXISTS Utilisateur;

CREATE TABLE Tag (
    id_Tag INT PRIMARY KEY AUTO_INCREMENT,
    tag VARCHAR(50) NOT NULL UNIQUE,
    dateDebut DATE NOT NULL,
    dateFin DATE NOT NULL
) ENGINE = InnoDB;

CREATE TABLE Utilisateur (
    id_Utilisateur INT PRIMARY KEY AUTO_INCREMENT,
    tag VARCHAR(50) NOT NULL UNIQUE,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL UNIQUE,
    motDePasse VARCHAR(255) NOT NULL,
    CONSTRAINT fk_Utilisateur FOREIGN KEY (tag) REFERENCES Tag(tag)
) ENGINE=InnoDB;

CREATE TABLE Casier (
    id_Casier INT PRIMARY KEY AUTO_INCREMENT,
    id_Utilisateur INT NOT NULL,
    numeroCasier INT NOT NULL UNIQUE,
    tag VARCHAR(50),
    CONSTRAINT fk_id_Utilisateur FOREIGN KEY (id_Utilisateur) REFERENCES Utilisateur(id_Utilisateur)
) ENGINE=InnoDB;