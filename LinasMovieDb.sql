CREATE DATABASE LinasMovieDb;
GO
USE LinasMovieDb;

CREATE TABLE Genres (
	Id INT IDENTITY(1,1)
PRIMARY KEY,
	GenreName NVARCHAR(50) NOT NULL
);

CREATE TABLE Movies (
	Id INT IDENTITY(1,1)
PRIMARY KEY,
	Title NVARCHAR(100) NOT NULL,
	ReleaseYear INT NULL,
	GenreId INT NOT NULL,
	CONSTRAINT FK_Movie_Genre
FOREIGN KEY (GenreId) REFERENCES
Genres(Id)
);

-- 2. Genrer (får id 1–4)
INSERT INTO Genres (GenreName) VALUES
('Action'),           -- 1
('Fantasy'),          -- 2
('Science fiction'),  -- 3
('Drama');            -- 4

-- 3. Filmer, 4 per genre
INSERT INTO Movies (Title, ReleaseYear, GenreId) VALUES
('Snabba cash', 2010, 1),
('Noll tolerans', 1999, 1),
('Hamilton – I nationens intresse', 2012, 1),
('Arn – Tempelriddaren', 2007, 1),

('Bröderna Lejonhjärta', 1977, 2),
('Ronja Rövardotter', 1984, 2),
('Sagan om ringen', 2001, 2),
('Harry Potter och de vises sten', 2001, 2),

('Stjärnornas krig', 1977, 3),
('Rymdimperiet slår tillbaka', 1980, 3),
('Tillbaka till framtiden', 1985, 3),
('Aniara', 2018, 3),

('Mitt liv som hund', 1985, 4),
('Fucking Åmål', 1998, 4),
('Så som i himmelen', 2004, 4),
('En man som heter Ove', 2015, 4);


