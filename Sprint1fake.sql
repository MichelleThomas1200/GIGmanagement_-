use master
--drop database Sprint1team5

create database gmsDB
use gmsDB

create table USERS
(
	username varchar(50),
	pword varchar(15),
	name varchar(50),
	primary key(username)
)
--drop table USERS
create table ARTIST
(
	artistname varchar(50),
	pword varchar(15),
	name varchar(50),
	primary key(artistname)
)

create table GIGS
(
	gigID varchar(10),
	timing datetime,
	venue varchar(50),
	artistname varchar(50),
	genre varchar(50),
	isCancelled varchar(1),
	primary key(gigID),
	foreign key (artistname) references ARTIST(artistname)
)

create table CALENDAR
(
	username varchar(50),
	gigID varchar(10),
	IsAttending varchar(1),
	foreign key (username) references USERS(username),
	foreign key (gigID) references GIGS(gigID)
)

insert into artist values('bob', 'b123', 'bob dylan');
select * from artist
select * from users
select * from gigs

select name from ARTIST where artistname='bob'
insert into GIGS values(10001, 17/06/2022, 'Blore', 'bob', 'Pop','n')
--insert into GIGS values(10002, 17/06/2022 16:30:00, 'Blore', 'Ke$ha', 'Pop','n')
insert into GIGS values(10002, 17/06/2022, 'Blore', 'Ke$ha', 'Pop','n')
delete from gigs where artistname='Ke$ha'
