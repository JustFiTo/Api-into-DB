CREATE DATABASE IF NOT EXISTS API;
USE API;

CREATE TABLE IF NOT EXISTS Weatherdata (
    dates VARCHAR(255) PRIMARY KEY,
    name VARCHAR(255),  
    country VARCHAR(255),
    temp FLOAT,
    feelslike FLOAT,
    description VARCHAR(255),
    visibility INT,
    windSpeed FLOAT,
    windDeg VARCHAR(10),
    sunset VARCHAR(255),
    sunrise VARCHAR(255)
);

