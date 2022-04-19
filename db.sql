--Creación de la base de datos.
DROP DATABASE IF EXISTS imaginedreams;
CREATE DATABASE IF NOT EXISTS imaginedreams;

--Creación de las tablas.
DROP TABLE IF EXISTS users;
CREATE TABLE IF NOT EXISTS users(
    id INT NOT NULL,
    firstname VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    address VARCHAR(255) NOT NULL,
    phone VARCHAR(30) NOT NULL,
    birth DATE,
    email VARCHAR(60) NOT NULL,
    type VARCHAR(20) DEFAULT 'CUSTOMER',
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS product(
    product_id INT AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
    category  VARCHAR(50) NOT NULL,
    price VARCHAR(255) NOT NULL,
    stock INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(category_id) REFERENCES category(category_id)
);

CREATE TABLE IF NOT EXISTS shopping_cart(
    id INT AUTO_INCREMENT,
    product_id INT NOT NULL,
    quantity  INT NOT NULL,
    user_id INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (product_id) REFERENCES product(product_id)
);

CREATE TABLE IF NOT EXISTS invoice(
    id INT AUTO_INCREMENT,
    product_id INT NOT NULL,
    user_id  INT NOT NULL,
    quantity INT NOT NULL,
    total_price INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (product_id) REFERENCES product(product_id)
);

CREATE TABLE IF NOT EXISTS invoice(
    id INT AUTO_INCREMENT,
    product_id INT NOT NULL,
    user_id  INT NOT NULL,
    quantity INT NOT NULL,
    total_price INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (product_id) REFERENCES productxshopping_cart(product_id)
);
CREATE TABLE IF NOT EXISTS productxshopping_cart(
    id INT AUTO_INCREMENT,
    product_id INT NOT NULL,
    user_id  INT NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS category(
	category_id INT AUTO_INCREMENT,
    name VARCHAR(50),
    PRIMARY KEY (category_id)
);

CREATE TABLE IF NOT EXISTS department(
    department_id INT AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
    PRIMARY KEY(department_id)
);

CREATE TABLE IF NOT EXISTS municipality(
    municipality_id INT AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
    department_id INT NUTT,
    PRIMARY KEY(municipality_id),
    FOREIGN KEY (department_id) REFERENCES department(department_id)
);




