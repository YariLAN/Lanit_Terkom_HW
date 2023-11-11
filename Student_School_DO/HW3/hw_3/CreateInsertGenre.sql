CREATE TABLE genre_type
(
	id_genre INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nameGenre nchar(50) NOT NULL
);

INSERT INTO genre_type
	VALUES
		('russian_classic'),
		('fantasy'),
		('for_children'),
		('detective'),
		('dystopia'),
		('horror'),
		('world_classic'),
		('romantic'),
		('history'),
		('education'),
		('health'),
		('nutrition'),
		('business'),
		('psyhology'),
		('action'),
		('IT'),
		('construction_business'),
		('religion'),
		('biography'),
		('for_families'),
		('adventure');