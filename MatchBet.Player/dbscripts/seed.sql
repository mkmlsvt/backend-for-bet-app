CREATE TABLE IF NOT EXISTS Players
(
    Id serial PRIMARY KEY,
    Username  VARCHAR (15)  NOT NULL,
    Password  VARCHAR (15)  NOT NULL,
    Name  VARCHAR (30)  NOT NULL,
    Surname  VARCHAR (20)  NOT NULL,
    Credit SMALLINT DEFAULT 0 NOT NULL,
    Score DOUBLE PRECISION NULL
);


INSERT INTO Players (Username,Password, Name, Surname, Credit, Score)
SELECT 'ysfrdvn' AS Username, '1995' AS Password, 'yusuf rıdvan' AS Name, 'savut' AS Surname, 3 as Credit, 0 as score
WHERE Not EXISTS(
            SELECT Username FROM Players WHERE Username= 'ysfrdvn'
    )
LIMIT 1;
