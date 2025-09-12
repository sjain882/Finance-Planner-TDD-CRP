CREATE TABLE USERS
(
    id       serial PRIMARY KEY,
    username varchar(50) NOT NULL,
    email    varchar(50) NOT NULL
);

CREATE TABLE WAGE
(
    id       serial PRIMARY KEY,
    datepaid date    NOT NULL,
    userid   integer NOT NULL references USERS,
    value    numeric NOT NULL
);