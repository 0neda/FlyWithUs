-- TRIGGER PARA ATUALIZAR O ESTADO DA POLTRONA (VAGA OU NÃO)
DELIMITER $$
CREATE TRIGGER BEFORE_INSERT_PASSAGEM
BEFORE INSERT ON PASSAGEM
FOR EACH ROW
BEGIN
    UPDATE POLTRONA
    SET ESTA_VAGA = FALSE
    WHERE ID = NEW.FK_ID_POLTRONA;
END$$

CREATE TRIGGER BEFORE_DELETE_AERONAVE
BEFORE DELETE ON AERONAVE
FOR EACH ROW
BEGIN
    DELETE FROM POLTRONA WHERE FK_ID_AERONAVE = OLD.ID;
    DELETE FROM VOO WHERE FK_ID_AERONAVE = OLD.ID;
END$$

CREATE TRIGGER BEFORE_DELETE_COMPANIA_AEREA
BEFORE DELETE ON COMPANIA_AEREA
FOR EACH ROW
BEGIN
    DELETE FROM AERONAVE WHERE FK_ID_COMPANIA_AEREA = OLD.ID;
END$$

CREATE TRIGGER BEFORE_DELETE_POLTRONA
BEFORE DELETE ON POLTRONA
FOR EACH ROW
BEGIN
    DELETE FROM PASSAGEM WHERE FK_ID_POLTRONA = OLD.ID;
END$$

CREATE TRIGGER BEFORE_DELETE_VOO
BEFORE DELETE ON VOO
FOR EACH ROW
BEGIN
	DELETE FROM MALA WHERE FK_ID_VOO = OLD.ID;
    DELETE FROM ESCALA WHERE FK_ID_VOO = OLD.ID;
END$$

CREATE TRIGGER BEFORE_DELETE_MALA
BEFORE DELETE ON VOO
FOR EACH ROW
BEGIN
    DELETE FROM ESCALA WHERE FK_ID_VOO = OLD.ID;
END$$

DELIMITER ;