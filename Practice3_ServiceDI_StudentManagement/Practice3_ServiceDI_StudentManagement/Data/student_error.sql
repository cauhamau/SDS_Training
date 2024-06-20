CREATE DATABASE QLSV

CREATE TABLE SINHVIEN
(
	MASV INT PRIMARY KEY,
	HOTENSV CHAR(30),
	MAKHOA CHAR(10),
	NAMSINH INT,
	QUEQUAN CHAR(30)
)

INSERT INTO SINHVIEN (MASV, HOTENSV, MAKHOA, NAMSINH, QUEQUAN)
VALUES
(1, 'Nguyen Thi A', 'K001', 2000, 'Ha Noi'),
(2, 'Tran Van B', 'K002', 2001, 'Hai Phong'),
(3, 'Le van son', 'K003', 1999, 'Đa Nang'),
(4, 'Pham Thanh D', 'K004', 2000, 'Ho Chi Minh'),
(5, 'Hoang Van E', 'K005', 1999, 'Can Tho'),
(6, 'Nguyen Thi F', 'K001', 2001, 'Hai Duong'),
(7, 'Tran Van G', 'K002', 2000, 'Thanh Hoa'),
(8, 'Le Thi H', 'K003', 1999, 'Nghe An'),
(9, 'Pham Van I', 'K004', 2001, 'Hung Yen'),
(10, 'Hoang Thi K', 'K005', 2000, 'Bac Giang'),
(11, 'Nguyen Van L', 'K001', 1999, 'Hoa Binh'),
(12, 'Tran Thi M', 'K002', 2000, 'Quang Ninh'),
(13, 'Le Van N', 'K003', 2001, 'Thai Binh'),
(14, 'Pham Thanh O', 'K004', 1999, 'Bac Ninh'),
(15, 'Hoang Van P', 'K005', 2000, 'Lang Son'),
(16, 'Nguyen Tha Q', 'K001', 2001, 'Nam Đinh'),
(17, 'Tran Van R', 'K002', 1999, 'Vinh Phuc'),
(18, 'Le Thi S', 'K003', 2000, 'Thai Nguyen'),
(19, 'Pham Van T', 'K004', 2001, 'Bac Kan'),
(20, 'Hoang Thi U', 'K005', 1999, 'Phu Tho')
