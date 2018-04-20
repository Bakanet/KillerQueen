DROP FUNCTION IF EXISTS connect_(VARCHAR(64), VARCHAR(64));
DROP FUNCTION IF EXISTS create_(VARCHAR(64), VARCHAR(64));
DROP FUNCTION IF EXISTS get_data_(VARCHAR(64));
DROP FUNCTION IF EXISTS match_(VARCHAR(64));
DROP FUNCTION IF EXISTS like_(VARCHAR(64), VARCHAR(64));
DROP FUNCTION IF EXISTS dislike_(VARCHAR(64), VARCHAR(64));
DROP FUNCTION IF EXISTS get_friends_(VARCHAR(64));
DROP TABLE IF EXISTS matches CASCADE;
DROP TABLE IF EXISTS users CASCADE;

DROP ROLE IF EXISTS server_sup;
DROP ROLE IF EXISTS server;

-- USERS --
CREATE TABLE users
(
	id 				SERIAL 			NOT NULL,
    login 			VARCHAR(64) 	NOT NULL DEFAULT '',
    password 		VARCHAR(64) 	NOT NULL DEFAULT '',
    firstname 		VARCHAR(64) 	NOT NULL DEFAULT '',
    lastname 		VARCHAR(64) 	NOT NULL DEFAULT '',
    age 			INT		 		NOT NULL DEFAULT 0,
    description 	VARCHAR(1024) 	NOT NULL DEFAULT '',
    picture 		VARCHAR(64)	 	NOT NULL DEFAULT '',
	animes_series 	BOOLEAN 		NOT NULL DEFAULT FALSE,
    books 			BOOLEAN 		NOT NULL DEFAULT FALSE,
    games 			BOOLEAN 		NOT NULL DEFAULT FALSE,
    mangas_comics 	BOOLEAN 		NOT NULL DEFAULT FALSE,
    movies 			BOOLEAN 		NOT NULL DEFAULT FALSE,

	PRIMARY KEY (id),
	UNIQUE (login)
);

-- MATCHES --
CREATE TABLE matches
(
	id 				SERIAL 			NOT NULL,
	source_id		INT				NOT NULL DEFAULT 0,
	target_id		INT			 	NOT NULL DEFAULT 0,
	matches			BOOLEAN			NOT NULL DEFAULT FALSE,
	
	PRIMARY KEY(id),
	FOREIGN KEY (source_id) REFERENCES users(id),
	FOREIGN KEY (target_id) REFERENCES users(id),
	UNIQUE (source_id, target_id),
	CHECK (source_id != target_id)
);

-- SERVER FOR SUP --
CREATE ROLE server_sup LOGIN PASSWORD 'espece de sup';
GRANT SELECT, INSERT, UPDATE ON users TO server_sup;
GRANT SELECT, UPDATE ON users_id_seq TO server_sup;
GRANT SELECT, INSERT, UPDATE ON matches TO server_sup;
GRANT SELECT, UPDATE ON matches_id_seq TO server_sup;

-- CONNECT --
CREATE OR REPLACE FUNCTION connect_(login VARCHAR(64), password VARCHAR(64))
RETURNS VARCHAR(64) AS
$$
DECLARE
	login_ VARCHAR(64);
BEGIN
	SELECT INTO login_ u.login FROM users u
		WHERE u.login = connect_.login
		AND u.password = connect_.password;
	RETURN login_;
END
$$ LANGUAGE plpgsql;

-- CREATE --
CREATE OR REPLACE FUNCTION create_(login VARCHAR(64), password VARCHAR(64))
RETURNS void AS
$$
BEGIN
	INSERT INTO users (id, login, password)
	VALUES (DEFAULT, create_.login, create_.password);
END
$$ LANGUAGE plpgsql;

-- GET DATA --
CREATE OR REPLACE FUNCTION get_data_(login VARCHAR(64))
RETURNS SETOF users AS
$$
BEGIN
	RETURN QUERY
	SELECT * FROM users u WHERE get_data_.login = u.login;
END
$$ LANGUAGE plpgsql;

-- MATCH --
CREATE OR REPLACE FUNCTION match_(login VARCHAR(64))
RETURNS SETOF users AS
$$
DECLARE
	m1_ VARCHAR(64);
	arr_ BOOL[5];
BEGIN
	SELECT concat('{', u.animes_series, ',', u.books, ',', u.games, ',', u.mangas_comics, ',', u.movies, '}') INTO arr_
		FROM users u
		WHERE u.login = match_.login;

	SELECT INTO m1_ u_1.login FROM matches m
		JOIN users u_1 ON u_1.id = m.source_id
		JOIN users u_2 ON u_2.id = m.target_id
		WHERE u_2.login = match_.login AND m.matches = FALSE
		ORDER BY RANDOM() LIMIT 1;
	
	IF m1_ IS NOT NULL THEN
		RETURN QUERY SELECT * FROM get_data_(m1_);
		RETURN;
	END IF;
	
	SELECT INTO m1_ u.login FROM users u
		WHERE u.login != match_.login
		AND NOT EXISTS( SELECT * FROM matches m
						JOIN users u_1 ON u_1.id = m.source_id
						JOIN users u_2 ON u_2.id = m.target_id
						WHERE u_1.login IN (u.login, match_.login)
						AND u_2.login IN (u.login, match_.login))
		AND
		(
			(u.animes_series = TRUE AND arr_[0] = TRUE)
			OR (u.books = TRUE AND arr_[1] = TRUE)
			OR (u.games = TRUE AND arr_[2] = TRUE)
			OR (u.mangas_comics = TRUE AND arr_[3] = TRUE)
			OR (u.movies = TRUE AND arr_[4] = TRUE)
		)
		ORDER BY RANDOM() LIMIT 1;
	RETURN QUERY SELECT * FROM get_data_(m1_);
	RETURN;
END
$$ LANGUAGE plpgsql;

-- LIKE --
CREATE OR REPLACE FUNCTION like_(login VARCHAR(64), other VARCHAR(64))
RETURNS void AS
$$
DECLARE
	id_1_ INT;
	id_2_ INT;
BEGIN
	SELECT u.id INTO id_1_ FROM users u WHERE u.login = like_.other;
	SELECT u.id INTO id_2_ FROM users u WHERE u.login = like_.login;
	
	IF EXISTS (SELECT * FROM matches m WHERE m.source_id = id_1_ AND m.target_id = id_2_) THEN
		UPDATE matches SET matches = TRUE WHERE matches.source_id = id_1_ AND matches.target_id = id_2_;
	ELSE
		INSERT INTO matches VALUES (DEFAULT, id_2_, id_1_, FALSE);
	END IF;
	RETURN;
END;
$$ LANGUAGE plpgsql;

-- DISLIKE --
CREATE OR REPLACE FUNCTION dislike_(login VARCHAR(64), other VARCHAR(64))
RETURNS void AS
$$
DECLARE
	id_1_ INT;
	id_2_ INT;
BEGIN
	SELECT u.id INTO id_1_ FROM users u WHERE u.login = dislike_.other;
	SELECT u.id INTO id_2_ FROM users u WHERE u.login = dislike_.login;
	
	IF EXISTS (SELECT * FROM matches m WHERE m.source_id = id_1_ AND m.target_id = id_2_) THEN
		DELETE FROM matches WHERE matches.source_id = id_1_ AND matches.target_id = id_2_;
	END IF;
	RETURN;
END;
$$ LANGUAGE plpgsql;

-- GET FRIENDS --
CREATE OR REPLACE FUNCTION get_friends_(login VARCHAR(64))
RETURNS SETOF VARCHAR(64) AS
$$
BEGIN
	RETURN  QUERY SELECT (CASE WHEN u_1.login != $1 THEN u_1.login ELSE u_2.login END) FROM matches m
				JOIN users u_1 ON u_1.id = m.source_id
				JOIN users u_2 ON u_2.id = m.target_id
				WHERE (u_1.login = $1 OR u_2.login = $1) AND m.matches = TRUE;
END
$$ LANGUAGE plpgsql;

