-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema player_transfers
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `player_transfers` ;

-- -----------------------------------------------------
-- Schema player_transfers
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `player_transfers` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin ;
USE `player_transfers` ;

-- -----------------------------------------------------
-- Table `player_transfers`.`igrac`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `player_transfers`.`igrac` ;

CREATE TABLE IF NOT EXISTS `player_transfers`.`igrac` (
  `idIgraca` INT NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(30) NOT NULL,
  `Prezime` VARCHAR(30) NOT NULL,
  `DatumRodjenja` DATE NOT NULL,
  `MjestoRodjenja` VARCHAR(50) NOT NULL,
  `Drzavljanstvo` VARCHAR(50) NOT NULL,
  `Pozicija` VARCHAR(50) NOT NULL,
  `Visina` INT NOT NULL,
  `Tezina` INT NOT NULL,
  `Cijena` DECIMAL(20,2) NULL DEFAULT NULL,
  `Noga` VARCHAR(20) NULL DEFAULT NULL,
  PRIMARY KEY (`idIgraca`))
ENGINE = InnoDB
AUTO_INCREMENT = 56
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `player_transfers`.`klub`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `player_transfers`.`klub` ;

CREATE TABLE IF NOT EXISTS `player_transfers`.`klub` (
  `idKluba` INT NOT NULL AUTO_INCREMENT,
  `NazivKluba` VARCHAR(100) NOT NULL,
  `Liga` VARCHAR(70) NOT NULL,
  `DatumOsnivanja` DATE NULL DEFAULT NULL,
  `Adresa` VARCHAR(100) NOT NULL,
  `Telefon` VARCHAR(50) NOT NULL,
  `NazivStadiona` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idKluba`))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `player_transfers`.`korisnik`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `player_transfers`.`korisnik` ;

CREATE TABLE IF NOT EXISTS `player_transfers`.`korisnik` (
  `idKorisnika` INT NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(30) NOT NULL,
  `Prezime` VARCHAR(30) NOT NULL,
  `Korisnicko_ime` VARCHAR(50) NOT NULL,
  `Lozinka` VARCHAR(100) NOT NULL,
  `Uloga` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`idKorisnika`),
  UNIQUE INDEX `Korisnicko ime_UNIQUE` (`Korisnicko_ime` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 17
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `player_transfers`.`statistika_igraca`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `player_transfers`.`statistika_igraca` ;

CREATE TABLE IF NOT EXISTS `player_transfers`.`statistika_igraca` (
  `KLUB_idKluba` INT NOT NULL,
  `IGRAC_idIgraca` INT NOT NULL,
  `Sezona` VARCHAR(50) NOT NULL,
  `OdigranihUtakmica` INT NOT NULL,
  `Golova` INT NOT NULL,
  `Asistencija` INT NOT NULL,
  `BrojKartona` INT NOT NULL,
  PRIMARY KEY (`KLUB_idKluba`, `IGRAC_idIgraca`, `Sezona`),
  INDEX `fk_STATISTIKA_IGRACA_KLUB1_idx` (`KLUB_idKluba` ASC) VISIBLE,
  INDEX `fk_STATISTIKA_IGRACA_IGRAC1_idx` (`IGRAC_idIgraca` ASC) VISIBLE,
  CONSTRAINT `fk_STATISTIKA_IGRACA_IGRAC1`
    FOREIGN KEY (`IGRAC_idIgraca`)
    REFERENCES `player_transfers`.`igrac` (`idIgraca`),
  CONSTRAINT `fk_STATISTIKA_IGRACA_KLUB1`
    FOREIGN KEY (`KLUB_idKluba`)
    REFERENCES `player_transfers`.`klub` (`idKluba`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `player_transfers`.`transfer`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `player_transfers`.`transfer` ;

CREATE TABLE IF NOT EXISTS `player_transfers`.`transfer` (
  `idTransfera` INT NOT NULL AUTO_INCREMENT,
  `DatumTransfera` DATE NOT NULL,
  `Cijena` DECIMAL(20,2) NOT NULL,
  `KLUB_idKluba1` INT NULL DEFAULT NULL,
  `KLUB_idKluba2` INT NULL DEFAULT NULL,
  `IGRAC_idIgraca` INT NOT NULL,
  PRIMARY KEY (`idTransfera`),
  INDEX `fk_TRANSFER_KLUB1_idx` (`KLUB_idKluba1` ASC) VISIBLE,
  INDEX `fk_TRANSFER_KLUB2_idx` (`KLUB_idKluba2` ASC) VISIBLE,
  INDEX `fk_TRANSFER_IGRAC1_idx` (`IGRAC_idIgraca` ASC) VISIBLE,
  CONSTRAINT `fk_TRANSFER_IGRAC1`
    FOREIGN KEY (`IGRAC_idIgraca`)
    REFERENCES `player_transfers`.`igrac` (`idIgraca`),
  CONSTRAINT `fk_TRANSFER_KLUB1`
    FOREIGN KEY (`KLUB_idKluba1`)
    REFERENCES `player_transfers`.`klub` (`idKluba`),
  CONSTRAINT `fk_TRANSFER_KLUB2`
    FOREIGN KEY (`KLUB_idKluba2`)
    REFERENCES `player_transfers`.`klub` (`idKluba`))
ENGINE = InnoDB
AUTO_INCREMENT = 22
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `player_transfers`.`ugovor_klub_igrac`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `player_transfers`.`ugovor_klub_igrac` ;

CREATE TABLE IF NOT EXISTS `player_transfers`.`ugovor_klub_igrac` (
  `idUgovora` INT NOT NULL AUTO_INCREMENT,
  `DatumOd` DATE NOT NULL,
  `DatumDo` DATE NOT NULL,
  `Plata` DECIMAL(20,2) NOT NULL,
  `Broj` INT NOT NULL,
  `Natpis` VARCHAR(50) NULL DEFAULT NULL,
  `KLUB_idKluba` INT NOT NULL,
  `IGRAC_idIgraca` INT NOT NULL,
  PRIMARY KEY (`idUgovora`),
  INDEX `fk_UGOVOR_KLUB1_idx` (`KLUB_idKluba` ASC) VISIBLE,
  INDEX `fk_UGOVOR_KLUB_IGRAC_IGRAC1_idx` (`IGRAC_idIgraca` ASC) VISIBLE,
  CONSTRAINT `fk_UGOVOR_KLUB1`
    FOREIGN KEY (`KLUB_idKluba`)
    REFERENCES `player_transfers`.`klub` (`idKluba`)
    ON UPDATE CASCADE,
  CONSTRAINT `fk_UGOVOR_KLUB_IGRAC_IGRAC1`
    FOREIGN KEY (`IGRAC_idIgraca`)
    REFERENCES `player_transfers`.`igrac` (`idIgraca`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 18
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
