-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 27 Mar 2024, 20:14:33
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `otelsistem`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteribilgi`
--

CREATE TABLE `musteribilgi` (
  `id` int(25) NOT NULL,
  `ad` varchar(15) NOT NULL,
  `soyad` varchar(15) NOT NULL,
  `dogumtarihi` date NOT NULL,
  `tckimlikno` varchar(11) NOT NULL,
  `telno` varchar(10) NOT NULL,
  `odano` varchar(5) NOT NULL,
  `ucret` int(11) NOT NULL,
  `gtarih` date NOT NULL,
  `ctarih` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `personel`
--

CREATE TABLE `personel` (
  `id` int(25) NOT NULL,
  `kullaniciadi` varchar(30) DEFAULT NULL,
  `sifre` varchar(64) DEFAULT NULL,
  `admin` bit(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `personel`
--

INSERT INTO `personel` (`id`, `kullaniciadi`, `sifre`, `admin`) VALUES
(8, 'deneme', '25638386F84002535C7DBFB799C95AA768C7493D37134E28682CE04719C5C144', b'01'),
(9, 'dogukan', '25638386F84002535C7DBFB799C95AA768C7493D37134E28682CE04719C5C144', b'01'),
(10, 'dogukand', '25638386F84002535C7DBFB799C95AA768C7493D37134E28682CE04719C5C144', b'01');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `musteribilgi`
--
ALTER TABLE `musteribilgi`
  ADD PRIMARY KEY (`tckimlikno`),
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `tckimlikno` (`tckimlikno`);

--
-- Tablo için indeksler `personel`
--
ALTER TABLE `personel`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `kullaniciadi` (`kullaniciadi`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `musteribilgi`
--
ALTER TABLE `musteribilgi`
  MODIFY `id` int(25) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `personel`
--
ALTER TABLE `personel`
  MODIFY `id` int(25) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
