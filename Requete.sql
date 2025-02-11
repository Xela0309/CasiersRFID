INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("admin", "admin", "admin");
INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("user", "Antoine", "passwd");
INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("user", "William", "passwd");

INSERT INTO `Casier`(`numeroCasier`) VALUES (1);
INSERT INTO `Casier`(`numeroCasier`) VALUES (2);
INSERT INTO `Casier`(`numeroCasier`) VALUES (3);
INSERT INTO `Casier`(`numeroCasier`) VALUES (4);

INSERT INTO `Tag`(`tag`) VALUES ("[01][01][01][01][01]");
INSERT INTO `Tag`(`tag`) VALUES ("[01][01][01][01][02]");
INSERT INTO `Tag`(`tag`) VALUES ("[01][01][01][01][03]");
INSERT INTO `Tag`(`tag`) VALUES ("[01][01][01][01][04]");

INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`) VALUES ("Antoine", "Canin", "HBO", "AA-123-BB");
INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`) VALUES ("William", "Pinalie", "Rothschild", "CC-456-DD");

INSERT INTO `Affectation`(`id_Casier`, `id_Visiteur`, `id_Tag`, `dateDebut`, `dateFin`) VALUES (1, 1, "[01][01][01][01][01]", "2020-01-01", "2020-01-02");
INSERT INTO `Affectation`(`id_Casier`, `id_Visiteur`, `id_Tag`, `dateDebut`, `dateFin`) VALUES (2, 2, "[01][01][01][01][02]", "2020-01-01", "2020-01-02");