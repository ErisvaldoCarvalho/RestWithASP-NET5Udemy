create table if not exists person
(
	id bigint NOT NULL AUTO_INCREMENT,
    address varchar(150) NOT NULL,
    first_name varchar(150) NOT NULL,
    last_name varchar(150) NOT NULL,
    gender varchar(150) NOT NULL,
    PRIMARY KEY(ID)
);