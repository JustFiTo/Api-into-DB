-- MySQL dump 10.13  Distrib 8.0.32, for macos12.6 (arm64)
--
-- Host: 127.0.0.1    Database: API
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Weatherdata`
--

DROP TABLE IF EXISTS `Weatherdata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Weatherdata` (
  `dates` varchar(255) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `country` varchar(255) DEFAULT NULL,
  `temp` int DEFAULT NULL,
  `feelslike` int DEFAULT NULL,
  `decription` varchar(255) DEFAULT NULL,
  `visibility` int DEFAULT NULL,
  `windSpeed` int DEFAULT NULL,
  `windDeg` varchar(255) DEFAULT NULL,
  `sunset` varchar(255) DEFAULT NULL,
  `sunrise` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`dates`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Weatherdata`
--

LOCK TABLES `Weatherdata` WRITE;
/*!40000 ALTER TABLE `Weatherdata` DISABLE KEYS */;
INSERT INTO `Weatherdata` VALUES ('04.07.2023 13:45:03','Stuttgart','DE',25,25,'clear sky',10000,4,' test ','21:29:06','05:25:48'),('04.07.2023 13:45:24','Berlin','DE',21,21,'clear sky',10000,7,'SW','21:31:29','04:49:33'),('04.07.2023 13:52:47','Munich','DE',24,24,'scattered clouds',10000,3,'W','21:16:34','05:19:09'),('04.07.2023 13:54:09','Stuttgart','DE',25,25,'clear sky',10000,4,'S','21:29:06','05:25:48');
/*!40000 ALTER TABLE `Weatherdata` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-04 14:26:58
