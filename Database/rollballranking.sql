-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- ホスト: localhost
-- 生成日時: 2020 年 4 月 24 日 07:00
-- サーバのバージョン： 10.4.11-MariaDB
-- PHP のバージョン: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- データベース: `tasksystem`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `rollballranking`
--

CREATE TABLE `rollballranking` (
  `Rank` int(11) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Time` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- テーブルのデータのダンプ `rollballranking`
--

INSERT INTO `rollballranking` (`Rank`, `Name`, `Time`) VALUES
(1, 'Kami', '00:20:000'),
(2, 'Stin', '00:22:000'),
(3, 'Soto', '00:25:000'),
(4, 'Keita', '00:30:000'),
(5, 'Toshi', '00:35:000');

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `rollballranking`
--
ALTER TABLE `rollballranking`
  ADD PRIMARY KEY (`Rank`);

--
-- ダンプしたテーブルのAUTO_INCREMENT
--

--
-- テーブルのAUTO_INCREMENT `rollballranking`
--
ALTER TABLE `rollballranking`
  MODIFY `Rank` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
