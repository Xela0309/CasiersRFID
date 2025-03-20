INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("admin", "d2c72a3e81", "d2c72a3e81");
INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("user", "c4ca2b3b861738", "c3c234249812");
INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("user", "d2cd3338861830", "c3c234249812");

INSERT INTO `Casier`(`numeroCasier`) VALUES (1);
INSERT INTO `Casier`(`numeroCasier`) VALUES (2);
INSERT INTO `Casier`(`numeroCasier`) VALUES (3);
INSERT INTO `Casier`(`numeroCasier`) VALUES (4);

INSERT INTO `Tag`(`tag`) VALUES ("[01][01][01][01][01]");
INSERT INTO `Tag`(`tag`) VALUES ("[01][01][01][01][02]");
INSERT INTO `Tag`(`tag`) VALUES ("[01][01][01][01][03]");
INSERT INTO `Tag`(`tag`) VALUES ("[01][01][01][01][04]");

INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`) VALUES ( "e3ca2936831f30","e4ca2b3b861738", "ffe00b", "f2e66a62db4078d39a");
INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`) VALUES ( "f0c2293e81","f2cd3338861830", "fbe108", "f7e46a66da4f78d396");
INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`) VALUES ( "f4d622258d1734","e7ca33389a173b", "f6e60b01", "f6e56a60da4578c69b");
INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`) VALUES ( "e1c629369a12","fec2333f8605", "e1c629369a1a21", "f5f96a60d74378d49f");


INSERT INTO `Affectation`(`id_Casier`, `id_Visiteur`, `id_Tag`, `dateDebut`, `dateFin`) VALUES (1, 1, "[01][01][01][01][01]", "2020-01-01", "2020-01-02");
INSERT INTO `Affectation`(`id_Casier`, `id_Visiteur`, `id_Tag`, `dateDebut`, `dateFin`) VALUES (2, 2, "[01][01][01][01][02]", "2020-01-01", "2020-01-02");



