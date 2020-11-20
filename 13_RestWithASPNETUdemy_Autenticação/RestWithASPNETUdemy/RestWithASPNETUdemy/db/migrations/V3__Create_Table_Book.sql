create table if not exists book
(
	id bigint NOT NULL AUTO_INCREMENT,
    title varchar(150) NOT NULL,
    author varchar(150) NOT NULL,
    launch_date varchar(150) NOT NULL,
    price double,
    PRIMARY KEY(id)
);