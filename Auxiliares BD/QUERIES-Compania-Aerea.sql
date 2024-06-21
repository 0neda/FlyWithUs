USE SISTEMA_AVIACAO;

/* LISTAGEM DE AERONAVES ORDENADAS POR TIPO */
SELECT
COMPANHIA_AEREA.NOME AS 'Companhia Aérea',
    AERONAVE.MODELO as 'Modelo',
	AERONAVE.TIPO AS 'Tipo'
FROM AERONAVE JOIN COMPANHIA_AEREA ON AERONAVE.ID_COMPANHIA_AEREA = COMPANHIA_AEREA.ID
ORDER BY TIPO;

/* RELATÓRIO DE VÔOS DAS AERONAVES POR PERIODO */
SELECT 
	COMPANHIA_AEREA.NOME AS 'Companhia Aérea',
	AERONAVE.MODELO AS 'Modelo',
	AEROPORTO_PARTIDA.NOME AS 'Aeroporto de Partida',
	VOO.HORARIO_PARTIDA AS 'Partida',
    AEROPORTO_CHEGADA.NOME AS 'Aeroporto de Chegada',
    VOO.HORARIO_CHEGADA AS 'Chegada'
    
FROM VOO JOIN AERONAVE ON VOO.ID_AERONAVE = AERONAVE.ID
JOIN COMPANHIA_AEREA ON AERONAVE.ID_COMPANHIA_AEREA = COMPANHIA_AEREA.ID JOIN AEROPORTO AEROPORTO_PARTIDA ON VOO.ID_AEROPORTO_PARTIDA = AEROPORTO_PARTIDA.ID
JOIN AEROPORTO AEROPORTO_CHEGADA ON VOO.ID_AEROPORTO_CHEGADA = AEROPORTO_CHEGADA.ID
ORDER BY VOO.HORARIO_PARTIDA;
    
/* RELATÓRIO DE VÔOS QUE FAZEM ESCALA EM UM DETERMINADO LOCAL */
SELECT 
    VOO.ID AS 'ID do Vôo',
    AEROPORTO_CHEGADA.NOME AS 'Destino',
    AEROPORTO_ESCALA.NOME AS 'Nome do Aeroporto de Escala'
FROM ESCALA 
JOIN VOO ON ESCALA.ID_VOO = VOO.ID
JOIN AEROPORTO AEROPORTO_ESCALA ON ESCALA.ID_AEROPORTO_SAIDA = AEROPORTO_ESCALA.ID
JOIN AEROPORTO AEROPORTO_CHEGADA ON VOO.ID_AEROPORTO_CHEGADA = AEROPORTO_CHEGADA.ID
WHERE AEROPORTO_ESCALA.NOME = 'Aeroporto Internacional Guarulhos'
ORDER BY VOO.ID;

/* RELATÓRIO DE POLTRONAS DISPONÍVEIS EM X AVIÃO */
SELECT 
    POLTRONA.ID AS 'Poltrona',
	AERONAVE.MODELO AS 'Aeronave',
    CASE 
        WHEN POLTRONA.ESTA_VAGA = 1 THEN 'Sim' ELSE 'Não'
    END AS 'Poltrona Vaga?',
    POLTRONA.LOCALIZACAO AS 'Localização'
FROM AERONAVE
JOIN POLTRONA ON POLTRONA.ID_AERONAVE = AERONAVE.ID
WHERE AERONAVE.ID = 2
ORDER BY AERONAVE.ID ASC;