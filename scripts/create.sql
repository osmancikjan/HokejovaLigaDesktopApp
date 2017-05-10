CREATE TABLE Hrac (
	idHrac INTEGER NOT NULL PRIMARY KEY,
	jmeno VARCHAR(20) NOT NULL,
	prijmeni VARCHAR(40) NOT NULL,
	body INTEGER NOT NULL,
	post CHAR(1),
	cislo INTEGER
)

CREATE TABLE Liga (
	idLiga INTEGER NOT NULL PRIMARY KEY,
	nazev VARCHAR(50) NOT NULL,
	CONSTRAINT AK_nazev UNIQUE(nazev)
)

CREATE TABLE Tym (
	kod CHAR(10) NOT NULL PRIMARY KEY,
	nazev VARCHAR(50) NOT NULL
)

CREATE TABLE Rocnik (
	idRocnik INTEGER NOT NULL PRIMARY KEY,
	idLiga INTEGER NOT NULL REFERENCES Liga,
	nazev VARCHAR(50) NOT NULL,
	zacatek DATE NOT NULL,
	konec DATE NOT NULL,
	pocetKol INTEGER NOT NULL
)

CREATE TABLE Trest (
	idTrest INTEGER NOT NULL PRIMARY KEY,
	idHrac INTEGER NOT NULL REFERENCES Hrac,
	zacatek DATE NOT NULL,
	konec DATE NOT NULL
)

CREATE TABLE Ucastnik (
	idTym CHAR(10) NOT NULL,
	idRocnik INTEGER NOT NULL,
	body INTEGER NOT NULL,
	PRIMARY KEY CLUSTERED ( idTym, idRocnik ),
	FOREIGN KEY ( idTym ) REFERENCES Tym ( kod ) ON UPDATE NO ACTION ON DELETE CASCADE,
	FOREIGN KEY ( idRocnik ) REFERENCES Rocnik ( idRocnik ) ON UPDATE NO ACTION ON DELETE CASCADE,
)

CREATE TABLE Zapas (
	idZapas INTEGER NOT NULL PRIMARY KEY,
	domaci CHAR(10) NOT NULL REFERENCES Tym,
	hoste CHAR(10) NOT NULL REFERENCES Tym,
	datum DATETIME NOT NULL,
	kolo INTEGER NOT NULL,
	skoreD INTEGER,
	skoreH INTEGER
)

CREATE TABLE Bodovani (
	idZaznam INTEGER NOT NULL PRIMARY KEY,
	idZapas INTEGER NOT NULL REFERENCES Zapas,
	idHrac INTEGER NOT NULL REFERENCES Hrac,
	typ CHAR(1) NOT NULL
)

CREATE TABLE TymHrac (
	tym CHAR(10) NOT NULL,
	idHrac INTEGER NOT NULL,
	zacatek DATE NOT NULL,
	konec DATE,
	FOREIGN KEY ( tym ) REFERENCES Tym ( kod ) ON UPDATE NO ACTION ON DELETE CASCADE,
	FOREIGN KEY ( idHrac ) REFERENCES Hrac ( idHrac ) ON UPDATE NO ACTION ON DELETE CASCADE
)

insert into Liga values (1, 'Tipsport ELH')
insert into Liga values (2, 'WSM Liga')

insert into Rocnik values (1, 1, '2016/2017', '2016-09-01', '2017-05-01', 52)
insert into Rocnik values (2, 2, '2016/2017', '2016-09-01', '2017-05-01', 52)
insert into Rocnik values (3, 2, '2015/2016', '2015-09-01', '2016-05-01', 52)
insert into Rocnik values (4, 2, '2015/2016', '2015-09-01', '2016-05-01', 52)

insert into Tym values ('CZ01020300', 'HC Vítkovice Ridera')
insert into Tym values ('CZ01020301', 'HC Bílí Tygři Liberec')
insert into Tym values ('CZ01020302', 'BK Mladá Boleslav')
insert into Tym values ('CZ01020303', 'HC Kometa Brno')
insert into Tym values ('CZ01020304', 'HC Oceláři Třinec')
 
insert into Hrac values (1, 'Petr', 'Kolouch', 0, 'Ú', 81)
insert into Hrac values (2, 'Daniel', 'Dolejš', 0, 'B', 30)
insert into Hrac values (3, 'Patrik', 'Bartošák', 0, 'B', 32)
insert into Hrac values (4, 'Jan', 'Výtisk', 0, 'O', 6)
insert into Hrac values (5, 'Lukáš', 'Kovář', 0, 'O', 18)
insert into Hrac values (6, 'Lukáš', 'Kucsera', 0, 'Ú', 71)
insert into Hrac values (7, 'Ján', 'Lašák', 0, 'B', 25)
insert into Hrac values (8, 'Roman', 'Will', 0, 'B', 35)
insert into Hrac values (9, 'Adam', 'Jánošík', 0,'O', 3)
insert into Hrac values (10, 'Tomáš', 'Mojžíš', 0,'O', 4)
insert into Hrac values (11, 'Vladimír', 'Svačina', 0,'Ú', 13)
insert into Hrac values (12, 'Jaroslav', 'Vlach', 0,'Ú', 53)
insert into Hrac values (13, 'Dominik', 'Groh', 0, 'B', 31)
insert into Hrac values (14, 'Jan', 'Lukáš', 0, 'B', 29)
insert into Hrac values (15, 'Tomáš', 'Pastor', 0, 'O', 6)
insert into Hrac values (16, 'Matěj', 'Stříteský', 0, 'O', 20)
insert into Hrac values (17, 'Dominik', 'Pacovský', 0, 'Ú', 30)
insert into Hrac values (18, 'Ivan', 'Ďurač', 0, 'Ú', 97)
insert into Hrac values (19, 'Marek', 'Čiliak', 0, 'B', 1)
insert into Hrac values (20, 'Karel', 'Vejmelka', 0, 'B', 50)
insert into Hrac values (21, 'Jozef', 'Kováčik', 0, 'O', 6)
insert into Hrac values (22, 'Michal', 'Gulaši', 0, 'O', 24)
insert into Hrac values (23, 'Leoš', 'Čermák', 0, 'Ú', 12)
insert into Hrac values (24, 'Jan', 'Hruška', 0, 'Ú', 57)
insert into Hrac values (25, 'Peter', 'Hamerlík', 0, 'B', 2)
insert into Hrac values (26, 'Šimon', 'Hrubec', 0, 'B', 30)
insert into Hrac values (27, 'Lukáš', 'Galvas', 0, 'O', 51)
insert into Hrac values (28, 'Michal', 'Roman', 0, 'O', 25)
insert into Hrac values (29, 'Erik', 'Hrňa', 0, 'Ú', 88)
insert into Hrac values (30, 'Cory', 'Kane', 0, 'Ú', 78)

insert into TymHrac values ('CZ01020300', 1, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020300', 3, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020301', 9, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020301', 10, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020302', 18, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020302', 13, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020303', 19, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020303', 21, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020304', 25, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020304', 26, '2016-09-01', '2017-05-01')
insert into TymHrac values ('CZ01020300', 2, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020300', 4, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020301', 7, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020301', 12, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020302', 17, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020302', 14, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020303', 23, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020303', 20, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020304', 27, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020304', 28, '2015-09-01', '2018-05-01')
insert into TymHrac values ('CZ01020300', 5, '2015-09-01', null)
insert into TymHrac values ('CZ01020300', 6, '2015-09-01', null)
insert into TymHrac values ('CZ01020301', 11, '2015-09-01', null)
insert into TymHrac values ('CZ01020301', 8, '2015-09-01', null)
insert into TymHrac values ('CZ01020302', 15, '2015-09-01', null)
insert into TymHrac values ('CZ01020302', 16, '2015-09-01', null)
insert into TymHrac values ('CZ01020303', 22, '2015-09-01', null)
insert into TymHrac values ('CZ01020303', 24, '2015-09-01', null)
insert into TymHrac values ('CZ01020304', 29, '2015-09-01', null)
insert into TymHrac values ('CZ01020304', 30, '2015-09-01', null)

insert into Ucastnik values ('CZ01020300', 1, 0)
insert into Ucastnik values ('CZ01020301', 1, 0)
insert into Ucastnik values ('CZ01020302', 1, 0)
insert into Ucastnik values ('CZ01020303', 1, 0)
insert into Ucastnik values ('CZ01020304', 1, 0)

insert into Zapas values (1, 'CZ01020300', 'CZ01020302', '2016-09-01 18:30:00.000', 1, 5, 2)
insert into Zapas values (2, 'CZ01020301', 'CZ01020304', '2016-09-01 18:30:00.000', 1, 3, 4)

insert into Bodovani values (1, 1, 1, 'G')
insert into Bodovani values (2, 1, 1, 'G')
insert into Bodovani values (3, 1, 6, 'G')
insert into Bodovani values (4, 1, 6, 'G')
insert into Bodovani values (5, 1, 6, 'G')
insert into Bodovani values (6, 1, 4, 'A')
insert into Bodovani values (7, 1, 4, 'G')
insert into Bodovani values (8, 1, 16, 'G')
insert into Bodovani values (9, 1, 17, 'G')

insert into Trest values (1, 8, '2017-03-03', '2017-08-08' )