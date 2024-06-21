DELIMITER $$
CREATE TRIGGER BEFORE_INSERT_PASSAGEM
BEFORE INSERT ON PASSAGEM
FOR EACH ROW
BEGIN
    UPDATE POLTRONA
    SET ESTA_VAGA = FALSE
    WHERE ID = NEW.ID_POLTRONA;
END$$

CREATE TRIGGER BEFORE_DELETE_AERONAVE
BEFORE DELETE ON AERONAVE
FOR EACH ROW
BEGIN
    DELETE FROM POLTRONA WHERE ID_AERONAVE = OLD.ID;
    DELETE FROM VOO WHERE ID_AERONAVE = OLD.ID;
END$$

CREATE TRIGGER BEFORE_DELETE_COMPANHIA_AEREA
BEFORE DELETE ON COMPANHIA_AEREA
FOR EACH ROW
BEGIN
    DELETE FROM AERONAVE WHERE ID_COMPANHIA_AEREA = OLD.ID;
END$$

CREATE TRIGGER BEFORE_DELETE_POLTRONA
BEFORE DELETE ON POLTRONA
FOR EACH ROW
BEGIN
    DELETE FROM PASSAGEM WHERE ID_POLTRONA = OLD.ID;
END$$

CREATE TRIGGER BEFORE_DELETE_VOO
BEFORE DELETE ON VOO
FOR EACH ROW
BEGIN
	DELETE FROM MALA WHERE ID_VOO = OLD.ID;
    DELETE FROM ESCALA WHERE ID_VOO = OLD.ID;
    DELETE FROM PASSAGEM WHERE ID_VOO = OLD.ID;
END$$

DELIMITER ;