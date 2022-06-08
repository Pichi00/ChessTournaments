create database chess;
use chess;

create table uzytkownicy(
     username varchar(30) not null,
     haslo varchar(30) not null, 
     rodzajKonta enum("organizator","zawodnik") not null,
     primary key(username));
     
create table sedziowie(
     idSedziego tinyint unsigned not null auto_increment,
     imie varchar(30) not null, 
     nazwisko varchar(30) not null, 
     dataUrodzenia date,
     klasaSedziowska enum("M","III","II","I","P","FA","IA"),
     primary key(idSedziego)
     );
     
create table organizatorzy(
	idOrganizatora tinyint unsigned not null auto_increment,
	nazwa varchar(40),
	username varchar(30) unique not null,
	primary key(idOrganizatora),
	foreign KEY(username) references uzytkownicy(username)
);


create table turnieje(
     idTurnieju tinyint unsigned not null auto_increment,
     nazwa varchar(30) not null,
     organizator tinyint unsigned not null ,
     dataRozpoczecia datetime,
     dataZakonczenia datetime,
     pulaNagrod double,
     regulamin varchar(10000),
     primary key(idTurnieju),
     foreign key(organizator) references organizatorzy(idOrganizatora)
);

create table turniejeSedziowie(
     idTurniejSedzia tinyint unsigned not null auto_increment,
     idTurniej tinyint unsigned not null,
     idSedzia tinyint unsigned not null,
     primary key(idTurniejSedzia),
	FOREIGN KEY (idTurniej) REFERENCES turnieje(idTurnieju),
     FOREIGN KEY (idSedzia) REFERENCES sedziowie(idSedziego)
     );
     
create table zawodnicy(
	idZawodnika tinyint unsigned not null auto_increment,
     imie varchar(30) not null,
	nazwisko varchar(30) not null,
	dataUrodzenia date,
	plec enum("M","F"),
	ranking int,
	username varchar(30) unique not null,
	primary key(idZawodnika),
	foreign key(username) references uzytkownicy(username)
);

create table statusZawodnika(
	idStatusu tinyint unsigned not null auto_increment,
	idZawodnik tinyint unsigned not null,
	idTurniej tinyint unsigned not null,
	statusZawodnika enum("niezaakceptowany","zaakceptowany","odrzucony") default("niezaakceptowany"),
	primary key(idStatusu),
	foreign key(idZawodnik) references zawodnicy(idZawodnika),
	foreign key(idTurniej) references turnieje(idTurnieju)
);

create table partie(
	idPartii tinyint unsigned not null auto_increment,
     idTurnieju tinyint unsigned not null,
     idZawodnikBiale tinyint unsigned not null,
     idZawodnikCzarne tinyint unsigned not null,
     idSedziego tinyint unsigned not null,
     datarozpoczecia datetime,
     runda tinyint unsigned,
     rezultat enum("0-0","1-0","0-1","1/2-1/2") not null default("0-0"),
     primary key(idPartii),
     foreign key(idTurnieju) references turnieje(idTurnieju),
     foreign key(idZawodnikBiale) references zawodnicy(idZawodnika),
     foreign key(idZawodnikCzarne) references zawodnicy(idZawodnika),
     foreign key(idSedziego) references sedziowie(idSedziego)
);


     
     