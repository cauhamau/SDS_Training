﻿CREATE DATABASE QLSV
GO
USE QLSV
GO
CREATE TABLE SINHVIEN
(
	MSSV INT IDENTITY(2024001,1) PRIMARY KEY,
	HOTENSV NVARCHAR(30),
	GIOITINH NVARCHAR(5),
	NGAYSINH DATE,
	LOP CHAR(5),
	KHOA INT
)
CREATE TABLE MONHOC
(
	TENMH NVARCHAR(20),
	MAMH CHAR(10) PRIMARY KEY,
	RATEDTP DECIMAL(2,1),
	RATEDQT DECIMAL(2,1),
	SOTIET INT
)

CREATE TABLE DANGKYMH
(
	SOLANHOC INT,
	MAMH CHAR(10),
	MSSV INT,
	DQT DECIMAL(4,2),
	DTP DECIMAL(4,2),
	DTK DECIMAL (4,2),
	KETQUA CHAR(10),
	PRIMARY KEY (SOLANHOC, MAMH, MSSV)
)

SELECT USERNAME , PASSWORD, HashBytes('SHA2_256', PASSWORD)
FROM USERS 
WHERE HashBytes('SHA2_256', PASSWORD)=0x7523C62ABDB7628C5A9DAD8F97D8D8C5C040EDE36535E531A8A3748B6CAE7E00


SELECT MSSV, HOTENSV
FROM SINHVIEN
WHERE (MSSV-1)=2024001

DROP TABLE USERS
CREATE TABLE USERS
(	
	USERNAME NVARCHAR(20) PRIMARY KEY,
	[PASSWORD] VARBINARY(32),
	ROLE NVARCHAR(10)
)

ALTER TABLE	DANGKYMH ADD CONSTRAINT FK_DANKYMH_MONHOC FOREIGN KEY (MAMH) REFERENCES MONHOC(MAMH)

ALTER TABLE	DANGKYMH ADD CONSTRAINT FK_DANKYMH_SV FOREIGN KEY (MSSV) REFERENCES SINHVIEN(MSSV)


--SELECT * FROM sys.triggers;
--DROP TRIGGER IF EXISTS trg_CalculateDTK;
GO
CREATE TRIGGER trg_CalculateDTK
ON DANGKYMH
AFTER INSERT, UPDATE
AS
BEGIN
	SET NOCOUNT ON
    -- Tính toán DTK dựa vào DQT và DTP
    UPDATE DANGKYMH

    SET DTK = DQT*RATEDQT + DTP*RATEDTP ,
		KETQUA = CASE
					WHEN (DQT is not null and DTP is not null) THEN
						CASE
							WHEN (DQT*RATEDQT + DTP*RATEDTP >= 5) THEN 'PASS'
							ELSE 'FAIL'
						END
					ELSE 'STUDYING'
				 END
	FROM MONHOC
    WHERE 
		MONHOC.MAMH = DANGKYMH.MAMH
		AND DANGKYMH.MAMH IN (SELECT MAMH FROM inserted)
		AND SOLANHOC IN (SELECT SOLANHOC FROM inserted)
		AND MSSV IN (SELECT MSSV FROM inserted)
END
GO

--DROP TRIGGER IF EXISTS trg_AddUserStudent;
GO
CREATE TRIGGER trg_AddUserStudent
ON SINHVIEN
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON
    -- Tính toán DTK dựa vào DQT và DTP
    INSERT INTO USERS(USERNAME, PASSWORD, ROLE) 
	SELECT CAST(MSSV AS NVARCHAR(20)), HashBytes('SHA2_256', CAST(MSSV AS NVARCHAR(20))), 'student'
	FROM INSERTED;
END
GO

delete from USERS;
INSERT INTO USERS(USERNAME, PASSWORD, ROLE) VALUES 
('admin',HashBytes('SHA2_256', N'admin'),'admin'),
('teacher',HashBytes('SHA2_256', N'teacher'),'teacher')

delete from DANGKYMH
delete from SINHVIEN;
DBCC CHECKIDENT ('SINHVIEN', RESEED, 2024000);
INSERT INTO SINHVIEN(HOTENSV, GIOITINH, NGAYSINH, LOP, KHOA) VALUES
(N'Nguyễn Văn A', 'Nam', '2000-01-01', 'K60', 2020),
(N'Trần Thị B', N'Nữ', '2001-02-02', 'K61', 2021),
(N'Phạm Văn C', 'Nam', '2002-03-03', 'K62', 2022),
(N'Lê Thị D', N'Nữ', '2003-04-04', 'K63', 2023),
(N'Hoàng Văn E', 'Nam', '2004-05-05', 'K64', 2024),
(N'Trần Văn F', 'Nam', '2005-06-06', 'K65', 2025),
(N'Nguyễn Thị G', N'Nữ', '2006-07-07', 'K66', 2026),
(N'Phạm Văn H', 'Nam', '2007-08-08', 'K67', 2027),
(N'Lê Thị I', N'Nữ', '2008-09-09', 'K68', 2028),
(N'Hoàng Văn J', 'Nam', '2009-10-10', 'K69', 2029),
(N'Trần Văn K', 'Nam', '2010-11-11', 'K70', 2030),
(N'Nguyễn Thị L', N'Nữ', '2011-12-12', 'K71', 2031),
(N'Phạm Văn M', 'Nam', '2000-01-13', 'K72', 2032),
(N'Lê Thị N', N'Nữ', '2001-02-14', 'K73', 2033),
(N'Hoàng Văn O', 'Nam', '2002-03-15', 'K74', 2034),
(N'Trần Văn P', 'Nam', '2003-04-16', 'K75', 2035),
(N'Nguyễn Thị Q', N'Nữ', '2004-05-17', 'K76', 2036),
(N'Phạm Văn R', 'Nam', '2005-06-18', 'K77', 2037),
(N'Lê Thị S', N'Nữ', '2006-07-19', 'K78', 2038),
(N'Hoàng Văn T', 'Nam', '2007-08-20', 'K79', 2039);


delete from MONHOC
INSERT INTO MONHOC(TENMH, MAMH, RATEDTP, RATEDQT, SOTIET) VALUES
(N'Hóa học', 'MH003', 0.3, 0.7, 3),
(N'Sinh học', 'MH004', 0.4, 0.6, 5),
(N'Lịch sử', 'MH005', 0.2, 0.8, 4),
(N'Địa lý', 'MH006', 0.3, 0.7, 4),
(N'Văn học', 'MH007', 0.4, 0.6, 3),
(N'Ngoại ngữ', 'MH008', 0.3, 0.7, 3),
(N'Giáo dục công dân', 'MH009', 0.2, 0.8, 5),
(N'Công nghệ', 'MH010', 0.4, 0.6, 5),
(N'Thể dục', 'MH001', 0.3, 0.7, 3),
(N'Âm nhạc', 'MH002', 0.2, 0.8, 4);


delete from DANGKYMH
INSERT INTO DANGKYMH(SOLANHOC, MAMH, MSSV, DQT, DTP, DTK, KETQUA) VALUES
(1, 'MH003', 2024001, 8.5, 7.8 ,null, null),
(1, 'MH004', 2024001, 9.2, 8.7 ,null, null),
(1, 'MH002', 2024002, 7.5, 6.8 ,null, null),
(1, 'MH005', 2024002, 6.9, 7.2 ,null, null),
(1, 'MH001', 2024003, 8.0, 9.1 ,null, null),
(1, 'MH006', 2024003, 7.8, 8.5 ,null, null),
(1, 'MH002', 2024004, 7.2, 7.9 ,null, null),
(1, 'MH007', 2024004, 8.7, 9.0 ,null, null),
(1, 'MH003', 2024005, 9.1, 8.4 ,null, null),
(1, 'MH008', 2024005, 7.6, 6.9 ,null, null),
(1, 'MH004', 2024006, 8.3, 7.6 ,null, null),
(1, 'MH009', 2024006, 9.0, 8.3 ,null, null),
(1, 'MH005', 2024007, 7.9, 7.2 ,null, null),
(1, 'MH010', 2024007, 8.5, 9.2 ,null, null),
(1, 'MH006', 2024008, 8.7, 9.0 ,null, null),
(1, 'MH001', 2024008, 7.4, 6.7 ,null, null),
(1, 'MH007', 2024009, 9.2, 8.5 ,null, null),
(1, 'MH002', 2024009, 8.6, 7.9 ,null, null),
(1, 'MH008', 2024010, 7.8, 6.5 ,null, null),
(1, 'MH003', 2024010, 8.9, 9.3 ,null, null),
(1, 'MH009', 2024011, 9.5, 8.8 ,null, null),
(1, 'MH004', 2024011, 7.6, 7.9 ,null, null),
(1, 'MH010', 2024012, 8.2, 7.5 ,null, null),
(1, 'MH005', 2024012, 9.1, null ,null, null),
(1, 'MH001', 2024013, 7.9, 9 ,null, null),
(1, 'MH006', 2024013, 6, 3 ,null, null),
(2, 'MH006', 2024003, 5, null, null, null);


--SELECT DANGKYMH.MAMH, TENMH, DTP, DQT, RATEDQT, RATEDTP, ROUND((DTP*RATEDTP+DQT*RATEDQT),2) AS DTK,
--CASE WHEN ROUND((DTP*RATEDTP+DQT*RATEDQT),2) > 4.0 THEN 'Pass' ELSE 'Fail' END AS KETQUA
--FROM DANGKYMH
--INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH
--WHERE MSSV = 13
--ORDER BY SOLANHOC ASC;



--SELECT *
--FROM DANGKYMH dm
--WHERE NOT EXISTS (
--    SELECT 1
--    FROM DANGKYMH dm2
--    WHERE dm.MSSV = dm2.MSSV
--        AND dm.MAMH = dm2.MAMH
--        AND dm.SOLANHOC < dm2.SOLANHOC
--);

--select * from DANGKYMH



--UPDATE DANGKYMH
--SET DQT = null, DTP = null
--WHERE SOLANHOC = 1 AND MAMH = 'MH001' AND MSSV = 1;


--SELECT *
--FROM MONHOC
--WHERE NOT EXISTS (
--    SELECT 1
--    FROM DANGKYMH
--    WHERE MONHOC.MAMH = DANGKYMH.MAMH
--		AND MSSV = 13
--        AND (DANGKYMH.DTP IS NULL OR DANGKYMH.DQT IS NULL)
--);


--SELECT* FROM MONHOC WHERE NOT EXISTS( SELECT 1 FROM DANGKYMH WHERE MONHOC.MAMH = DANGKYMH.MAMH AND MSSV = 1 AND(DANGKYMH.DTP IS NULL OR DANGKYMH.DQT IS NULL));

