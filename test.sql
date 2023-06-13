CREATE DATABASE API;
USE API;

CREATE TABLE City (
    city_id INT PRIMARY KEY,
    name VARCHAR(255) 
);

CREATE TABLE Elements (
    element_id INT PRIMARY KEY,
    visibility INT
);


CREATE TABLE Main (
    main_id INT PRIMARY KEY,
    temp INT,
    feels_like INT
);

CREATE TABLE Sys (
    sys_id INT PRIMARY KEY,
    country VARCHAR(255)
);

CREATE TABLE Weather (
    weather_id INT PRIMARY KEY,
    decription VARCHAR(255)
);

CREATE TABLE WeatherMap (
    weather_map_id INT PRIMARY KEY,
    name_id INT,
    sys_id INT,
    weather_id INT,
    main_id INT,
    city_id INT,
    element_id INT,
    FOREIGN KEY (name_id) REFERENCES City (name),
    FOREIGN KEY (sys_id) REFERENCES Sys (sys_id),
    FOREIGN KEY (weather_id) REFERENCES Weather (weather_id),
    FOREIGN KEY (main_id) REFERENCES Main (main_id),
    FOREIGN KEY (city_id) REFERENCES City (city_id),
    FOREIGN KEY (element_id) REFERENCES Elements (element_id)
);
