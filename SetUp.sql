CREATE database RugbyAustralia;
USE RugbyAustralia;
CREATE TABLE Player(
	Player_Mid VARCHAR(128) NOT NULL PRIMARY KEY,
    Player_Name VARCHAR(128) NOT NULL
);
CREATE TABLE Fixture(
	Fixture_Mid VARCHAR(128) NOT NULL PRIMARY KEY,
    Season VARCHAR(128) NOT NULL,
    Competition_Name VARCHAR(128) NOT NULL,
    Fixture_Datetime VARCHAR(128) NOT NULL,
    Fixture_Round VARCHAR(128) NOT NULL,
    Home_Team VARCHAR(128) NOT NULL,
    Away_Team VARCHAR(128) NOT NULL
);
CREATE TABLE Event (
	Fixture_Id VARCHAR(128) NOT NULL,
        Fixture_Event_Id INT NOT NULL PRIMARY KEY,
        Match_Half INT NOT NULL,
        Match_Time INT NOT NULL,
        Team VARCHAR(128) NOT NULL,
        Player_Id VARCHAR(128) NOT NULL,
        Position_Number VARCHAR(128) NOT NULL,
        Shirt_Number INT NOT NULL,
        Sequence_Number INT NOT NULL,
        Possession_Number INT NOT NULL,
        Phase_Number INT NOT NULL,
        EvEnt VARCHAR(128) NOT NULL,
        Eventtype VARCHAR(128) NOT NULL,
        Eventresult VARCHAR(128) NOT NULL,
        Qualifier3 VARCHAR(128) NOT NULL,
        Qualifier4 VARCHAR(128) NOT NULL,
        Qualifier5 VARCHAR(128) NOT NULL,
        Value VARCHAR(128) NOT NULL
);