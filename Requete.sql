INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("admin", "d2c72a3e81", "d2c72a3e81");
INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("user", "c4ca2b3b861738", "c3c234249812");
INSERT INTO `Utilisateur`(`role`, `login`, `password`) VALUES ("user", "d2cd3338861830", "c3c234249812");

INSERT INTO `Casier`(`numeroCasier`) VALUES (1);
INSERT INTO `Casier`(`numeroCasier`) VALUES (2);
INSERT INTO `Casier`(`numeroCasier`) VALUES (3);
INSERT INTO `Casier`(`numeroCasier`) VALUES (4);

INSERT INTO `Tag`(`tag`,`etat`) VALUES ("010C2E14093E","U");
INSERT INTO `Tag`(`tag`,`etat`) VALUES ("2600B3271BA9","U");
INSERT INTO `Tag`(`tag`,`etat`) VALUES ("2600B43EFF53","U");
INSERT INTO `Tag`(`tag`,`etat`) VALUES ("2600B438C16B","U");
INSERT INTO `Tag`(`tag`,`etat`) VALUES ("2600B326FE4D","U");

INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`, `pays`) VALUES ( "f0c2293e81",	"f2cd3338861830",	"fbe108",	"f2f97665cf220cc2",	"e1cc3e369a1b30ba88d776");
INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`, `pays`) VALUES ( "e3ca2936831f30",	"e4ca2b3b861738",	"ffe00b",	"f2831d0ecf4767a4e9",	"f2cf2b32821732f9b8");
INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`, `pays`) VALUES ( "f4d622258d1734",	"e7ca33389a173b",	"f6e60b01",	"e9e66a6fd84f78c284",	"f5d126398c13");
INSERT INTO `Visiteur`(`nom`, `prenom`, `compagnie`, `numPlaque`, `pays`) VALUES ( "f1cc35338a043cf2",	"ffd624369c",	"e0cc01258a1836ff89d87c4453",	"f2e76a67df4678db9b" ,"f5d126398c13");

INSERT INTO `Affectation`(`id_Casier`, `id_Visiteur`, `id_Tag`, `dateDebut`, `dateFin`) VALUES (1, 1, "010C2E14093E", "2020-01-01", "2020-01-02");
INSERT INTO `Affectation`(`id_Casier`, `id_Visiteur`, `id_Tag`, `dateDebut`, `dateFin`) VALUES (2, 2, "2600B3271BA9", "2020-01-01", "2020-01-02");



