-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: sferret
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `post`
--

DROP TABLE IF EXISTS `post`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `post` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `MovieId` int NOT NULL,
  `Comment` varchar(5000) DEFAULT NULL,
  `Rating` int DEFAULT NULL,
  `PublishedDate` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `post_user_idx` (`UserId`),
  KEY `post_movie_idx` (`MovieId`),
  CONSTRAINT `post_movie` FOREIGN KEY (`MovieId`) REFERENCES `movie` (`Id`),
  CONSTRAINT `post_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `post`
--

LOCK TABLES `post` WRITE;
/*!40000 ALTER TABLE `post` DISABLE KEYS */;
INSERT INTO `post` VALUES (6,1,20,'good',5,'2023-01-13'),(7,11,20,'wow',4,'2023-01-13'),(8,11,2,'intresting',4,'2023-01-13'),(9,125,2,'i was sure it is the little mermaid',1,'2023-01-13'),(10,45,5,'there were only 3',1,'2023-01-13'),(11,7,12,'Spoilr Alert!!!!\nI can\'t believe they realy found him',5,'2023-01-17'),(12,58,10661,'Adam Sandler\'s bast movie everrrrrrr',5,'2023-01-17'),(13,58,79156,'ein davar kaze 9 kochavim ze rak ad 5',2,'2023-01-17'),(14,100,161,'George Clooney is soooo handsome',5,'2023-01-17'),(15,100,211,'yeah... it\'s obvious',1,'2023-01-17'),(16,100,640,'shit... i couldn\'t',3,'2023-01-17'),(17,100,2,'i saw the whole movie... no character named Ariel',3,'2023-01-17'),(18,218,79156,'Great hotel, i\'ll come to visit very soon',4,'2023-01-17'),(19,475,10661,'Israeli army is the best!!',5,'2023-01-17'),(20,475,75656,'one of the best movies i saw! great story, amazing effects. very recomended!',5,'2023-01-17'),(21,475,291805,'marvelous sequel! I wish there was another one...',5,'2023-01-17'),(23,562,12,'pixar are the best',4,'2023-01-17'),(24,562,211,'really funny movie (Although very tragic)',3,'2023-01-17'),(25,1281,4488,'Frightening movie, can\'t sleep for like a week',4,'2023-01-17'),(26,1281,3597,'sweet just like Shawn Mendes and Camila Cabello\'s song... not scary at all',2,'2023-01-17'),(27,391,329,'great movie! the Dino look real!!',4,'2023-01-17'),(28,391,160324,'Hi friends, nice short movie',3,'2023-01-17'),(29,891,327,'nice japanise movie',3,'2023-01-17'),(30,891,267872,'nice korean doc about korean waves',4,'2023-01-17'),(31,1,640,'an amazing and intrigue movie! really \"caught\" my attention.',4,'2023-01-17'),(32,1,3597,'very scary! even when you are watching it in the summer and don\'t remember what i did last summer ',4,'2023-01-18');
/*!40000 ALTER TABLE `post` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-19 17:51:22
