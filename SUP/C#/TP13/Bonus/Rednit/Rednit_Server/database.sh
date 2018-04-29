psql -h localhost -U postgres <<<'
DROP DATABASE rednit;
CREATE DATABASE rednit;
\c rednit; \i init.sql; \i data.sql'
