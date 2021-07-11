-- Create table
create table Userlist(
id int primary key auto_increment,
username varchar(50) not null,
password varchar(50) not null,
email varchar(50),
info varchar(100),
regtime datetime default (datetime('now','localtime'))
);

create table PlayLists(
listID int primary key AUTO_INCREMENT,
userID int not null,
listName varchar(50) not null,
addtime datetime default (datetime('now','localtime'))
)

create table MediaList(
id int primary key AUTO_INCREMENT,
listID int not null,
mediaFile varchar(50) not null,
mediaPath varchar(100) not null,
addtime datetime default (datetime('now','localtime'))
)

-- add index
create index index_userID on playlist(userID)
