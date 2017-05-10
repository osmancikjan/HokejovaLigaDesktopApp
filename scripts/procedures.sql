
--	1.3 Seznam hracu
Alter PROCEDURE SeznamHracu (@parametr VARCHAR(50) = NULL)
AS
BEGIN
	IF @parametr IS NOT NULL
		BEGIN
			SELECT * FROM Hrac 
				WHERE CAST(idHrac as VARCHAR) = @parametr 
					OR jmeno = @parametr 
					OR prijmeni = @parametr 
					OR post = @parametr 
					OR  CAST(cislo as VARCHAR) = @parametr
		END
	ELSE
		BEGIN
			SELECT * FROM Hrac
		END
END

--	2.1 Vlozeni zapasu
CREATE PROCEDURE VlozeniZapasu(@idZapas INT, @domaci CHAR(10), @hoste CHAR(10), @datum DATETIME, @kolo INT, @skoreD INT, @skoreH INT)
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Zapas VALUES (@idZapas, @domaci, @hoste, @datum, @kolo, @skoreD, @skoreH)
			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END

--	2.3 Seznam zapasu
Alter PROCEDURE SeznamZapasu(@parametr Date)
AS
BEGIN
	select idZapas,
		(select t.nazev from Tym t where t.kod = z.domaci) as domaci, 
		(select t1.nazev from Tym t1 where t1.kod = z.hoste) as hoste, 
		skoreD, skoreH, datum, kolo 
	from Zapas z 
		where datum >= @parametr
END

--	2.4 Detail zapasu 
ALTER PROCEDURE DetailZapasu(@idZapas integer, @typ char(1))
AS 
BEGIN
	IF @typ = 'G' or @typ = 'A' 
		BEGIN
			SELECT h.cislo, h.jmeno, h.prijmeni, h.post FROM Bodovani b JOIN Hrac h ON b.idHrac = h.idHrac WHERE b.typ = @typ AND b.idZapas = @idZapas
		END
	ELSE
		BEGIN
			print 'Neplatny typ'
		END
END

--	3.3 Seznam trestu
CREATE PROCEDURE SeznamTrestu
AS
BEGIN
	SELECT h.*, t.zacatek, t.konec FROM Trest t JOIN Hrac h ON h.idHrac = t.idHrac WHERE GETDATE() BETWEEN zacatek AND konec
END


--	3.4 Detail trestu
CREATE PROCEDURE DetailTrestu (@parametr VARCHAR(50))
AS
BEGIN
	SELECT h.*, t.zacatek, t.konec FROM Trest t JOIN Hrac h ON h.idHrac = t.idHrac WHERE h.prijmeni = @parametr OR CAST(h.cislo AS VARCHAR) = @parametr
END

--	4.3 Seznam lig
ALTER PROCEDURE SeznamLig
AS
BEGIN
	SELECT r.idRocnik, r.nazev, l.idLiga, l.nazev FROM Liga l JOIN Rocnik r ON r.idLiga = l.idLiga WHERE getdate() BETWEEN r.zacatek AND r.konec
END
select * from Bodovani
--	4.4 Detail ligy
CREATE PROCEDURE DetailLigy (@idRocnik integer)
AS
BEGIN
	select t.nazev,
		(IsNull((select sum(IsNull(z.skoreD,0)) from Zapas z where z.domaci = u.idTym),0)
			+
		IsNull((select sum(IsNull(z.skoreH,0)) from Zapas z where z.hoste = u.idTym),0)) as vstrelene_goly,

		(IsNull((select sum(IsNull(z.skoreH,0)) from Zapas z where z.domaci = u.idTym),0)
			+
		IsNull((select sum(IsNull(z.skoreD,0)) from Zapas z where z.hoste = u.idTym),0)) as obdrzene_goly,

		u.body 
		from Ucastnik u join Tym t on t.kod = u.idTym
			where u.idRocnik = @idRocnik 
			order by body desc
END

--	6.1 Vlozeni Bodovani
ALTER PROCEDURE VlozeniBodovani (@idZapas INTEGER, @idHrac INTEGER, @typ CHAR)
AS 
BEGIN
	DECLARE @indx INTEGER
	SET @indx = 1
	
	WHILE (SELECT COUNT(*) FROM Bodovani WHERE idZaznam = @indx) > 0
		BEGIN
			SET @indx = @indx + 1
		END
	IF @typ = 'G' or @typ = 'A' 
		BEGIN
			IF (SELECT COUNT(*) FROM Hrac WHERE idHrac = @idHrac) > 0
				BEGIN
					IF (SELECT COUNT(*) FROM Zapas WHERE idZapas = @idZapas) > 0
						BEGIN							
							BEGIN TRANSACTION
								BEGIN TRY
									INSERT INTO Bodovani VALUES (@indx, @idZapas, @idHrac, @typ)
									COMMIT
								END TRY
								BEGIN CATCH
									PRINT 'Prikaz neproveden'
									ROLLBACK
								END CATCH
						END
					ELSE
						BEGIN
							PRINT 'Zapas neexistuje'
						END
				END
			ELSE
				BEGIN
					PRINT 'Hrac neexistuje'
				END
		END
	ELSE 
		BEGIN
			PRINT 'Spatny typ. Povoleno je pouze A - asistence a G - gol.'
		END
END

-- 7.1 Pridani kontraktu
ALTER PROCEDURE PridaniKontraktu (@idHrac integer, @tym char(10), @zacatek date, @konec date = null)
AS
BEGIN
	IF (SELECT COUNT(*) FROM Hrac WHERE idHrac = @idHrac) > 0 OR (SELECT COUNT(*) FROM Tym WHERE kod = @tym) > 0
		BEGIN
			IF (SELECT COUNT(*) FROM TymHrac th JOIN Hrac h ON h.idHrac = th.idHrac WHERE h.idHrac = @idHrac AND GETDATE() BETWEEN th.zacatek AND th.konec) > 0
				BEGIN
					PRINT 'Hrac je nyni jiz v kontraktu s jinym tymem'
				END
			ELSE
				BEGIN
					BEGIN TRANSACTION 
						BEGIN TRY
							INSERT INTO TymHrac values (@tym, @idHrac, @zacatek, @konec )
							COMMIT
						END TRY
						BEGIN CATCH
							PRINT 'Prikaz neproveden'
							ROLLBACK
						END CATCH
				END
		END
	ELSE
		BEGIN
			PRINT 'Hrac nebo tym neexistuje'
		END
END

--  7.3 Seznam kontraktu
CREATE PROCEDURE SeznamKontraktu (@parametr VARCHAR(50) = NULL)
AS
BEGIN
	IF @parametr IS NOT NULL
		BEGIN
			SELECT h.idHrac, h.jmeno, h.prijmeni, h.cislo, t.nazev as tym FROM TymHrac th
      JOIN Tym t ON th.tym = t.kod
	  JOIN Hrac h ON h.idHrac = th.idHrac
				WHERE t.kod = @parametr 
					OR t.nazev = @parametr 
					OR h.prijmeni = @parametr 
		END
	ELSE
		BEGIN
			SELECT h.idHrac, h.jmeno, h.prijmeni, h.cislo, t.nazev as tym FROM TymHrac th
				JOIN Tym t ON th.tym = t.kod
				JOIN Hrac h ON h.idHrac = th.idHrac order by t.nazev
		END
END

--	8.1 Pridani ucasti
CREATE PROCEDURE PridaniUcasti(@kod CHAR(10), @idRocnik integer)
AS
BEGIN
	IF (SELECT COUNT (*) FROM Ucastnik u JOIN Rocnik r ON r.idRocnik = u.idRocnik WHERE u.idTym = @kod AND GETDATE() BETWEEN r.zacatek AND r.konec) > 0 
		BEGIN
			
		END
END

--	9.1 Vlozeni tymu
CREATE PROCEDURE VlozeniTymu(@kod CHAR(10), @nazev VARCHAR(50))
AS
BEGIN
	IF (SELECT COUNT(*) FROM Tym WHERE kod = @kod or nazev = @nazev) > 0
		BEGIN
			print 'Tym jiz v tabulce existuje.'
		END
	ELSE
		BEGIN
			BEGIN TRANSACTION
				BEGIN TRY
					INSERT INTO Tym VALUES (@kod, @nazev)
					COMMIT
				END TRY
				BEGIN CATCH
					PRINT 'Prikaz se neprovedl.'
					ROLLBACK
				END CATCH
		END
END

--	9.3 Smazani tymu
CREATE PROCEDURE VymazTym(@kod CHAR(10))
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM TymHrac WHERE tym = @kod; 
			DELETE FROM Ucastnik WHERE idTym = @kod; 
			DELETE FROM Bodovani WHERE 
				EXISTS (SELECT * 
							FROM Zapas 
							WHERE (domaci = @kod OR hoste = @kod) AND Zapas.idZapas = Bodovani.idZapas); 
			DELETE FROM Zapas WHERE domaci = @kod OR hoste = @kod; 
			DELETE FROM Tym where kod = @kod;
			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
