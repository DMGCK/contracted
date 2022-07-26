CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 '';

CREATE TABLE
    IF NOT EXISTS contractors(
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(255) NOT NULL
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS companies(
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(255) NOT NULL
    ) default charset utf8;

CREATE TABLE
    IF NOT EXISTS jobs(
        id INT PRIMARY KEY AUTO_INCREMENT,
        contractorId INT NOT NULL,
        companyId INT NOT NULL,
        FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE,
        FOREIGN KEY (companyId) REFERENCES companies(id) ON DELETE CASCADE
    ) default charset utf8;

/* COMPANY, per contractor */

SELECT name
FROM jobs j
    JOIN contractors c ON j.contractorId = c.id
WHERE companyId = 2;

/* Get the information of both sides */

SELECT
    j.*,
    con.name AS contractorName,
    cpy.name AS companyName
FROM jobs j
    JOIN contractors con ON j.contractorId = con.id
    JOIN companies cpy ON j.companyId = cpy.id