-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema The_Dojo_League
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema The_Dojo_League
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `The_Dojo_League` DEFAULT CHARACTER SET utf8 ;
USE `The_Dojo_League` ;

-- -----------------------------------------------------
-- Table `The_Dojo_League`.`dojos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `The_Dojo_League`.`dojos` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `Location` VARCHAR(255) NULL,
  `Info` VARCHAR(255) NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `The_Dojo_League`.`ninjas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `The_Dojo_League`.`ninjas` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `Level` INT NULL,
  `Description` VARCHAR(255) NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  `dojo` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_ninjas_dojos_idx` (`dojo` ASC),
  CONSTRAINT `fk_ninjas_dojos`
    FOREIGN KEY (`dojo`)
    REFERENCES `The_Dojo_League`.`dojos` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
