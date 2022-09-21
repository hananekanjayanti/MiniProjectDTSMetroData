CREATE DATABASE MProject

use MProject

CREATE TABLE Details(user_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
					 user_name VARCHAR(50) NOT NULL,
					 user_age INT NOT NULL)

SELECT * FROM Details

INSERT INTO DETAILS (user_name, user_age) VALUES('Agung', 25)

UPDATE Details
SET user_age =35
where user_id = 1
