-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: netwyrks
-- ------------------------------------------------------
-- Server version	8.0.28

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
-- Table structure for table `audit`
--

DROP TABLE IF EXISTS `audit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `audit` (
  `audit_id` int NOT NULL AUTO_INCREMENT,
  `audit_user_id` int DEFAULT NULL,
  `audit_record_type` varchar(45) DEFAULT NULL,
  `audit_record_id` varchar(45) DEFAULT NULL,
  `audit_date` datetime DEFAULT NULL,
  `audit_action` varchar(45) DEFAULT NULL,
  `audit_before` text,
  `audit_after` text,
  `audit_computer_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`audit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `audit`
--

LOCK TABLES `audit` WRITE;
/*!40000 ALTER TABLE `audit` DISABLE KEYS */;
INSERT INTO `audit` VALUES (1,-1,'6','1','2022-05-09 22:20:00','4','1.0.1.40194','','LAPTOP-11NSK703'),(2,-1,'6','1','2022-05-09 22:21:05','4','1.0.1.40194','','LAPTOP-11NSK703'),(3,-1,'6','1','2022-05-09 22:26:35','4','1.0.1.40194','','LAPTOP-11NSK703'),(4,-1,'6','-1','2022-05-09 22:27:32','2','',' - no new password','LAPTOP-11NSK703'),(5,1,'6','1','2022-05-09 22:28:42','5',NULL,NULL,'LAPTOP-11NSK703'),(6,-1,'6','1','2022-05-09 22:30:17','4','1.0.1.40194','','LAPTOP-11NSK703'),(7,1,'6','1','2022-05-09 22:30:25','5',NULL,NULL,'LAPTOP-11NSK703'),(8,-1,'6','1','2022-05-09 22:33:03','4','1.0.1.40194','','LAPTOP-11NSK703'),(9,1,'6','1','2022-05-09 22:33:38','5',NULL,NULL,'LAPTOP-11NSK703');
/*!40000 ALTER TABLE `audit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `configuration`
--

DROP TABLE IF EXISTS `configuration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `configuration` (
  `configuration_id` varchar(45) NOT NULL,
  `configuration_type` varchar(45) DEFAULT NULL,
  `configuration_value` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`configuration_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `configuration`
--

LOCK TABLES `configuration` WRITE;
/*!40000 ALTER TABLE `configuration` DISABLE KEYS */;
INSERT INTO `configuration` VALUES ('companyname','string','netWYrks'),('minPwdLen','integer','6'),('personalfolders','string',''),('SendEmailName','string','Eric Hindle'),('SMTPHost','string',''),('SMTPPassword','string',''),('SMTPUsername','string','ekky1955@gmail.com');
/*!40000 ALTER TABLE `configuration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `customer_id` int NOT NULL AUTO_INCREMENT,
  `customer_name` varchar(45) DEFAULT NULL,
  `customer_address_1` varchar(45) DEFAULT NULL,
  `customer_address_2` varchar(45) DEFAULT NULL,
  `customer_address_3` varchar(45) DEFAULT NULL,
  `customer_address_4` varchar(45) DEFAULT NULL,
  `customer_postcode` varchar(45) DEFAULT NULL,
  `customer_telephone` varchar(45) DEFAULT NULL,
  `customer_email` varchar(45) DEFAULT NULL,
  `customer_discount_percent` decimal(9,2) DEFAULT NULL,
  `customer_notes` text,
  `customer_created` datetime DEFAULT NULL,
  `customer_changed` datetime DEFAULT NULL,
  `customer_terms` int DEFAULT NULL,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diary`
--

DROP TABLE IF EXISTS `diary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diary` (
  `diary_id` int NOT NULL AUTO_INCREMENT,
  `diary_date` datetime DEFAULT NULL,
  `diary_user_id` int DEFAULT NULL,
  `diary_job` int DEFAULT NULL,
  `diary_cust_id` int DEFAULT NULL,
  `diary_body` text,
  `diary_subject` varchar(45) DEFAULT NULL,
  `diary_reminder` tinyint DEFAULT NULL,
  `diary_closed` tinyint DEFAULT NULL,
  `diary_callback` tinyint DEFAULT NULL,
  PRIMARY KEY (`diary_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diary`
--

LOCK TABLES `diary` WRITE;
/*!40000 ALTER TABLE `diary` DISABLE KEYS */;
/*!40000 ALTER TABLE `diary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `job`
--

DROP TABLE IF EXISTS `job`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `job` (
  `job_id` int NOT NULL AUTO_INCREMENT,
  `job_name` varchar(45) DEFAULT NULL,
  `job_description` text,
  `job_completed` tinyint DEFAULT NULL,
  `job_created` datetime DEFAULT NULL,
  `job_changed` datetime DEFAULT NULL,
  `job_customer_id` int DEFAULT NULL,
  `job_invoice_number` varchar(45) DEFAULT NULL,
  `job_po_number` varchar(45) DEFAULT NULL,
  `job_reference` varchar(45) DEFAULT NULL,
  `job_invoice_date` datetime DEFAULT NULL,
  `job_payment_due` datetime DEFAULT NULL,
  `job_user_id` int DEFAULT NULL,
  `job_invoice_no` int DEFAULT NULL,
  PRIMARY KEY (`job_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `job`
--

LOCK TABLES `job` WRITE;
/*!40000 ALTER TABLE `job` DISABLE KEYS */;
/*!40000 ALTER TABLE `job` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `job_product`
--

DROP TABLE IF EXISTS `job_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `job_product` (
  `job_product_id` int NOT NULL AUTO_INCREMENT,
  `jp_quantity` int DEFAULT NULL,
  `jp_created` datetime DEFAULT NULL,
  `jp_changed` datetime DEFAULT NULL,
  `jp_product_id` int DEFAULT NULL,
  `jp_job_id` int DEFAULT NULL,
  `jp_taxable` tinyint DEFAULT NULL,
  `jp_taxrate` decimal(9,2) DEFAULT NULL,
  PRIMARY KEY (`job_product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `job_product`
--

LOCK TABLES `job_product` WRITE;
/*!40000 ALTER TABLE `job_product` DISABLE KEYS */;
/*!40000 ALTER TABLE `job_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `product_id` int NOT NULL AUTO_INCREMENT,
  `product_name` varchar(45) DEFAULT NULL,
  `product_description` text,
  `product_cost` decimal(11,4) DEFAULT NULL,
  `product_price` decimal(11,4) DEFAULT NULL,
  `product_created` datetime DEFAULT NULL,
  `product_changed` datetime DEFAULT NULL,
  `product_supplier_id` int DEFAULT NULL,
  `product_taxable` tinyint DEFAULT NULL,
  `product_tax_rate` decimal(9,2) DEFAULT NULL,
  PRIMARY KEY (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplier` (
  `supplier_id` int NOT NULL AUTO_INCREMENT,
  `supplier_name` varchar(45) DEFAULT NULL,
  `supplier_address_1` varchar(45) DEFAULT NULL,
  `supplier_address_2` varchar(45) DEFAULT NULL,
  `supplier_address_3` varchar(45) DEFAULT NULL,
  `supplier_address_4` varchar(45) DEFAULT NULL,
  `supplier_postcode` varchar(45) DEFAULT NULL,
  `supplier_telephone` varchar(45) DEFAULT NULL,
  `supplier_email` varchar(45) DEFAULT NULL,
  `supplier_discount_percent` decimal(9,2) DEFAULT NULL,
  `supplier_notes` text,
  `supplier_created` datetime DEFAULT NULL,
  `supplier_changed` datetime DEFAULT NULL,
  PRIMARY KEY (`supplier_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task` (
  `task_id` int NOT NULL AUTO_INCREMENT,
  `task_name` varchar(45) DEFAULT NULL,
  `task_description` text,
  `task_cost` decimal(9,2) DEFAULT NULL,
  `task_time` decimal(9,2) DEFAULT NULL,
  `task_start_date` datetime DEFAULT NULL,
  `task_started` tinyint DEFAULT NULL,
  `task_completed` tinyint DEFAULT NULL,
  `task_created` datetime DEFAULT NULL,
  `task_changed` datetime DEFAULT NULL,
  `task_job_id` int DEFAULT NULL,
  `task_tax_rate` decimal(9,2) DEFAULT NULL,
  `task_taxable` tinyint DEFAULT NULL,
  PRIMARY KEY (`task_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task`
--

LOCK TABLES `task` WRITE;
/*!40000 ALTER TABLE `task` DISABLE KEYS */;
/*!40000 ALTER TABLE `task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `user_login` varchar(45) DEFAULT NULL,
  `user_code` varchar(45) DEFAULT NULL,
  `user_password` varchar(45) DEFAULT NULL,
  `temp_password` varchar(45) DEFAULT NULL,
  `force_password_change` tinyint DEFAULT NULL,
  `salt` varchar(45) DEFAULT NULL,
  `user_name` varchar(45) DEFAULT NULL,
  `user_contact_number` varchar(45) DEFAULT NULL,
  `user_mobile` varchar(45) DEFAULT NULL,
  `user_email` varchar(45) DEFAULT NULL,
  `user_jobtitle` varchar(45) DEFAULT NULL,
  `user_note` text,
  `user_created` datetime DEFAULT NULL,
  `user_changed` datetime DEFAULT NULL,
  `user_role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'ekky1','EH','HzQp8zQiN0FxyeJrMSRzlKOJ7wI=','',0,'','Eric Hindle','01484317956','07870313001','ekky1955@gmail.com','Administrator','','2022-05-09 00:00:00','2022-05-09 22:27:32','Fzr3XPlLZ81S2mb0LIhulrNE7MQ=');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-09 22:35:19
