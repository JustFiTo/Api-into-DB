CREATE DATABASE IF NOT EXISTS API;
USE API;

CREATE TABLE IF NOT EXISTS Weatherdata (
    dates VARCHAR(255) PRIMARY KEY,
    name VARCHAR(255),  
    country VARCHAR(255),
    temp INT,
    feelslike INT,
    decription VARCHAR(255),
    visibility INT,
    windSpeed INT,
    windDeg INT,
    sunset VARCHAR(255),
    sunrise VARCHAR(255)
);
