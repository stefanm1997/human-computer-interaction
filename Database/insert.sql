-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: player_transfers
-- ------------------------------------------------------
-- Server version	8.0.19

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
-- Dumping data for table `igrac`
--

LOCK TABLES `igrac` WRITE;
/*!40000 ALTER TABLE `igrac` DISABLE KEYS */;
INSERT INTO `igrac` VALUES (18,'Allison','Becker','1992-10-02','Novo Hambuurgo','Brasil','Golakeeper',191,88,65000000.00,'Right'),(19,'Virgil','van Dijk','1991-07-08','Breda','Netherlands','Center back',193,86,70000000.00,'Right'),(20,'Andrew ','Robertson','1994-03-11','Glasgow','Scotland','Left back',178,70,70000000.00,'Left'),(21,'Trent','Alexnadre Arnold','1998-10-07','Liverpool','England','Right back',180,71,100000000.00,'Right'),(22,'Georginio','Wijnaldum','1990-11-11','Rotterdam','Netherlands','Central midfielder',175,68,35000000.00,'Right'),(23,'Sadio','Mane','1992-04-10','Sedhioou','Senegal','Left winger',174,65,100000000.00,'Right'),(24,'Mohamed','Salah','1992-06-15','Nagrig','Egypt','Right winger',175,70,110000000.00,'Left'),(25,'Roberto','Firmino','1991-10-02','Marceio','Brasil','Centre forward',181,78,55000000.00,'Right'),(26,'Ederson','Santana de Moraes','1993-08-17','Osasco','Brasil','Goalkeeper',188,85,56000000.00,'Left'),(27,'Ruben','Dias','1997-05-14','Amadora','Portugal','Centre back',187,81,70000000.00,'Right'),(28,'Aymeric','Laporte','1994-05-27','Agen','France','Centre back',189,86,50000000.00,'Right'),(29,'Joao','Cancelo','1994-05-27','Barreiro','Portugal','Right bacl',182,79,50000000.00,'Right'),(30,'Rodri','Hernandez','1996-06-22','Madrid','Spain','Defensive midfielder',191,88,70000000.00,'Right'),(31,'Phil','Foden','2000-05-28','Stockport','England','Central midfielder',171,64,70000000.00,'Left'),(32,'Kevin','De Bruyne','1991-06-28','Drongen','Belgium','Attacking midfielder',181,74,100000000.00,'Right'),(33,'Bernardo','Silva','1994-08-10','Lisboa','Portugal','Attacking midfielder',173,67,70000000.00,'Left'),(34,'Raheem','Sterling','1994-12-08','Kingston','England','Left winger',170,64,100000000.00,'Right'),(35,'Ferran','Torres','2000-02-29','Foios','Spain','Right winger',184,80,50000000.00,'Right'),(36,'Gabriel','Jesus','1997-04-03','Sao Paulo','Brasil','Centre forward',175,70,60000000.00,'Right'),(37,'Edouard','Mendy','1992-03-01','Montivilliers','Senegal','Goalkeeper',196,88,25000000.00,'Right'),(38,'Reece','James','1999-12-08','Lonfon','England','Right back',182,78,40000000.00,'Right'),(39,'Ben ','Chilwell','1996-12-21','Milton Keynes','England','Left back',178,71,50000000.00,'Left'),(40,'Jorginho','Luiz Frello','1991-12-20','Imbituba','Italy','Defensive midfielder',180,75,45000000.00,'Right'),(41,'Ngolo','Kante','1991-03-29','Paris','France','Central midfielder',168,62,55000000.00,'Right'),(42,'Kai','Havertz','1999-06-11','Aachen','Germany','Attacking midfielder',189,79,70000000.00,'Left'),(43,'Mason','Mount','1999-01-10','Portsmouth','England','Attacking midfielder',178,67,60000000.00,'Right'),(44,'Christian','Pulisic','1998-09-18','Hershley','United States','Right winger',172,64,50000000.00,'Right'),(45,'Hakim','Ziyech','1993-03-19','Dronten','Morocco','Right winger',181,74,40000000.00,'Left'),(46,'Timo','Werner','1996-03-06','Stuttgart','Germany','Centre forward',181,75,65000000.00,'Right'),(47,'Tammy','Abraham','1997-10-02','London','England','Centre forward',190,87,40000000.00,'Right'),(48,'David ','de Gea','1990-11-07','Madrid','Spain','Goalkeeper',192,85,22000000.00,'Right'),(49,'Harry','Maguire','1993-03-05','Sheffield','England','Centre back',194,89,40000000.00,'Right'),(50,'Aaron','Wan Bissaka','1997-11-26','London','England','Right back',183,78,40000000.00,'Right'),(51,'Paul ','Pogba','1993-03-15','Lagny sur Marne','France','Central midfielder',191,78,60000000.00,'Right'),(52,'Bruno','Fernandes','1994-09-08','Maia','Portugal','Attacking midfielder',179,75,90000000.00,'Right'),(53,'Marcus','Rashford','1997-10-31','Manchester','England','Left winger',185,80,85000000.00,'Right'),(54,'Mason','Greenwood','2001-10-01','Bradford','England','Right winger',181,74,50000000.00,'Left'),(55,'Anthony','Martial','1995-12-05','Massy','France','CEntre forward',181,75,50000000.00,'Right');
/*!40000 ALTER TABLE `igrac` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `klub`
--

LOCK TABLES `klub` WRITE;
/*!40000 ALTER TABLE `klub` DISABLE KEYS */;
INSERT INTO `klub` VALUES (5,'Manchester United','Premier league','1878-01-01','Old Trafford Sir Matt Busby Way','44 161 868 8000','Old Trafford'),(6,'Manchester City','Premier league','1880-01-01','Etihad Campus','44 161 4441894','Etihad Stadium'),(7,'Liverpool FC','Premier legaue','1892-03-15','Anfield Road ','44 151 2632361','Anfiled Road'),(8,'Chelsea FC','Premier league','1905-03-10','Fulham Road','4473869','Stamford Bridge');
/*!40000 ALTER TABLE `klub` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `korisnik`
--

LOCK TABLES `korisnik` WRITE;
/*!40000 ALTER TABLE `korisnik` DISABLE KEYS */;
INSERT INTO `korisnik` VALUES (14,'Stefan','Milincic','stefanm','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5','Admin'),(15,'Pero','Peric','test','9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08','User'),(16,'Tamo','Neki','user','04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb','Admin');
/*!40000 ALTER TABLE `korisnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `statistika_igraca`
--

LOCK TABLES `statistika_igraca` WRITE;
/*!40000 ALTER TABLE `statistika_igraca` DISABLE KEYS */;
INSERT INTO `statistika_igraca` VALUES (6,27,'2020/21',25,2,0,10),(6,36,'2020/21',30,7,3,1),(7,18,'2020/21',55,0,0,3),(8,42,'2020/21',35,15,18,7),(8,46,'2020/21',29,8,2,9);
/*!40000 ALTER TABLE `statistika_igraca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `transfer`
--

LOCK TABLES `transfer` WRITE;
/*!40000 ALTER TABLE `transfer` DISABLE KEYS */;
INSERT INTO `transfer` VALUES (18,'2021-04-15',20000000.00,5,6,29),(19,'2021-04-15',25000000.00,7,8,22),(20,'2021-04-15',35000000.00,8,7,22);
/*!40000 ALTER TABLE `transfer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `ugovor_klub_igrac`
--

LOCK TABLES `ugovor_klub_igrac` WRITE;
/*!40000 ALTER TABLE `ugovor_klub_igrac` DISABLE KEYS */;
INSERT INTO `ugovor_klub_igrac` VALUES (8,'2018-06-12','2023-06-13',200000.00,1,'Allison',7,18),(9,'2016-06-21','2025-07-09',300000.00,11,'Salah',7,24),(10,'2017-03-02','2023-01-09',250000.00,3,'van Dijk',7,19),(11,'2018-06-12','2025-06-17',180000.00,5,'Wijnaldum',7,22),(13,'2019-07-17','2023-02-15',200000.00,20,'Cancelo',6,29);
/*!40000 ALTER TABLE `ugovor_klub_igrac` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-04-15 23:47:44
