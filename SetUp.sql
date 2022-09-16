CREATE TABLE Player(
	Player_Mid VARCHAR(128) NOT NULL,
    	Player_Name VARCHAR(128) NOT NULL,
	CONSTRAINT PK_Player_Mid PRIMARY KEY CLUSTERED (Player_Mid ASC)
);
CREATE TABLE Fixture(
    Fixture_Mid VARCHAR(128) NOT NULL,
    Season VARCHAR(128) NOT NULL,
    Competition_Name VARCHAR(128) NOT NULL,
    Fixture_Datetime VARCHAR(128) NOT NULL,
    Fixture_Round VARCHAR(128) NOT NULL,
    Home_Team VARCHAR(128) NOT NULL,
    Away_Team VARCHAR(128) NOT NULL,
	CONSTRAINT PK_Fixture_Mid PRIMARY KEY CLUSTERED (Fixture_Mid ASC)
);
CREATE TABLE Event (
		Fixture_Id VARCHAR(128) NOT NULL,
        Fixture_Event_Id INT NOT NULL,
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
        Value INT NOT NULL,
		CONSTRAINT PK_Fixture_Event_Id PRIMARY KEY CLUSTERED (Fixture_Id, Fixture_Event_Id),
		CONSTRAINT FK_Event_FixtureId FOREIGN KEY (Fixture_Id) REFERENCES Fixture (Fixture_Mid),
		CONSTRAINT FK_Event_PlayerId FOREIGN KEY (Player_Id) REFERENCES Player (Player_Mid)
);