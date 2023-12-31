-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 16, 2023 at 05:41 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `diba`
--

-- --------------------------------------------------------

--
-- Table structure for table `addressbookeksternal`
--

CREATE TABLE `addressbookeksternal` (
  `id_pengguna` varchar(16) NOT NULL,
  `id_bank` int(11) NOT NULL,
  `no_rekening` varchar(10) NOT NULL,
  `keterangan` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `addressbookeksternal`
--

INSERT INTO `addressbookeksternal` (`id_pengguna`, `id_bank`, `no_rekening`, `keterangan`) VALUES
('111', 1, '1101234567', 'teman'),
('123', 4, '1401234567', 'temen'),
('123', 5, '1501234567', 'fren'),
('222', 1, '1101234567', NULL),
('222', 1, '1101234568', 'rekening kerja'),
('222', 3, '1301234567', NULL),
('222', 5, '1501234567', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `addressbookinternal`
--

CREATE TABLE `addressbookinternal` (
  `id_pengguna` varchar(16) NOT NULL,
  `no_rekening` varchar(10) NOT NULL,
  `keterangan` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `addressbookinternal`
--

INSERT INTO `addressbookinternal` (`id_pengguna`, `no_rekening`, `keterangan`) VALUES
('111', '2212070001', 'rekening urusan pekerjaan'),
('222', '2212070001', NULL),
('123', '2212070002', 'rekening usaha'),
('222', '2212070002', NULL),
('111', '2212090001', 'teman'),
('123', '2212090001', 'teman');

-- --------------------------------------------------------

--
-- Table structure for table `banklain`
--

CREATE TABLE `banklain` (
  `id` int(11) NOT NULL,
  `nama` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `banklain`
--

INSERT INTO `banklain` (`id`, `nama`) VALUES
(1, 'BCA'),
(2, 'Mandiri'),
(3, 'Panin Bank'),
(4, 'BRI'),
(5, 'BNI');

-- --------------------------------------------------------

--
-- Table structure for table `deposito`
--

CREATE TABLE `deposito` (
  `id_deposito` varchar(20) NOT NULL,
  `no_rekening` varchar(10) NOT NULL,
  `jatuh_tempo` enum('1 bulan','3 bulan','6 bulan','1 tahun','2 tahun','3 tahun') NOT NULL,
  `nominal` double NOT NULL,
  `bunga` double NOT NULL,
  `status` enum('aktif','unverified','cair','nonaktif') NOT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `verifikator_buka` int(11) NOT NULL,
  `verifikator_cair` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `deposito`
--

INSERT INTO `deposito` (`id_deposito`, `no_rekening`, `jatuh_tempo`, `nominal`, `bunga`, `status`, `tgl_buat`, `tgl_perubahan`, `verifikator_buka`, `verifikator_cair`) VALUES
('2022/12/17/0001/0001', '2212090001', '3 bulan', 1000, 5, 'nonaktif', '2022-12-17 00:00:00', '2022-12-17 00:00:00', 1, 3),
('2022/12/17/0001/0002', '2212090001', '2 tahun', 100000, 8, 'nonaktif', '2022-12-17 00:00:00', '2022-12-20 00:00:00', 1, 1),
('2022/12/17/0001/0003', '2212090001', '2 tahun', 1000000, 8, 'nonaktif', '2022-12-17 00:00:00', '2022-12-17 00:00:00', 2, 3),
('2022/12/20/0002/0001', '2212070002', '3 bulan', 1000, 5, 'aktif', '2022-12-20 00:00:00', '2022-12-21 00:00:00', 1, 1),
('2023/01/11/0001/0001', '2212070001', '3 bulan', 300000, 5, 'nonaktif', '2023-01-11 00:00:00', '2023-01-16 00:00:00', 2, 2);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `id` int(11) NOT NULL,
  `nama_depan` varchar(150) NOT NULL,
  `nama_keluarga` varchar(100) DEFAULT NULL,
  `position` int(11) NOT NULL,
  `nik` varchar(16) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(128) NOT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`id`, `nama_depan`, `nama_keluarga`, `position`, `nik`, `email`, `password`, `tgl_buat`, `tgl_perubahan`) VALUES
(1, 'Wenny', 'Aliana', 1, '345', 'wenny', 'ce4b5e9dda18adb15fa4683b2b31dfe657376196e5f7e90b21f5ce2df54d2c086326a5a7103358e30e9604bd48209b0a56bff5dc92e6c5045b3da62803737487', '2022-12-04 00:00:00', '2022-12-08 00:00:00'),
(2, 'Ruben', 'Pangestu', 2, '444', 'ruben', 'ce4b5e9dda18adb15fa4683b2b31dfe657376196e5f7e90b21f5ce2df54d2c086326a5a7103358e30e9604bd48209b0a56bff5dc92e6c5045b3da62803737487', '2022-12-06 00:00:00', '2022-12-08 00:00:00'),
(3, 'Cindy', 'Rosabela', 2, '456', 'cindy', 'ce4b5e9dda18adb15fa4683b2b31dfe657376196e5f7e90b21f5ce2df54d2c086326a5a7103358e30e9604bd48209b0a56bff5dc92e6c5045b3da62803737487', '2022-12-08 00:00:00', '2022-12-08 00:00:00'),
(4, 'Denny', 'Sijabat', 1, '555', 'denny', 'ce4b5e9dda18adb15fa4683b2b31dfe657376196e5f7e90b21f5ce2df54d2c086326a5a7103358e30e9604bd48209b0a56bff5dc92e6c5045b3da62803737487', '2023-01-16 00:00:00', '2023-01-16 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `inbox`
--

CREATE TABLE `inbox` (
  `id_pengguna` varchar(16) NOT NULL,
  `id_pesan` int(11) NOT NULL,
  `pesan` longtext DEFAULT NULL,
  `tanggal_kirim` datetime NOT NULL,
  `status` enum('dibaca','diterima') DEFAULT NULL,
  `tgl_perubahan` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `inbox`
--

INSERT INTO `inbox` (`id_pengguna`, `id_pesan`, `pesan`, `tanggal_kirim`, `status`, `tgl_perubahan`) VALUES
('111', 1, 'Hai, Fenny! Selamat datang di DiBa.', '2022-12-08 00:00:00', 'dibaca', '2022-12-08 19:57:05'),
('111', 2, 'Pin telah berhasil dibuat, Anda dapat melakukan transaksi', '2022-12-08 00:00:00', 'dibaca', '2022-12-08 19:57:12'),
('111', 3, 'Pembukaan deposito telah diverifikasi', '2022-12-21 00:00:00', 'dibaca', '2022-12-21 00:00:00'),
('111', 4, 'Transfer internal ke rekening ChristinGunawan-2212090001\r Nominal: Rp 5000', '2022-12-21 00:00:00', 'dibaca', '2022-12-21 00:00:00'),
('111', 5, 'Transfer internal ke rekening FransiscaPriscillia-2212070001\r Nominal: Rp 5000', '2022-12-22 00:00:00', 'diterima', '2022-12-22 00:00:00'),
('111', 6, 'Top Up saldo rekening 2212070002 sebesar Rp 1000000', '2022-12-22 00:00:00', 'diterima', '2022-12-22 00:00:00'),
('111', 7, 'Transfer internal ke rekening FransiscaPriscillia-2212070001\r Nominal: Rp 10000', '2022-12-22 00:00:00', 'diterima', '2022-12-22 00:00:00'),
('111', 8, 'Transfer internal ke rekening ChristinGunawan-2212090001\r Nominal: Rp 1000', '2022-12-22 00:00:00', 'diterima', '2022-12-22 00:00:00'),
('111', 9, 'Transaksi Debit dengan rekening eksternal Chelsea-1101234567\nNominal : Rp 10000', '2022-12-22 00:00:00', 'diterima', '2022-12-22 00:00:00'),
('111', 10, 'Transaksi Debit dengan rekening eksternal Chelsea-1101234567\nNominal : Rp 2000', '2022-12-22 00:00:00', 'diterima', '2022-12-22 00:00:00'),
('111', 11, 'Transfer internal ke rekening FransiscaPriscillia-2212070001\nNominal: Rp 100000', '2023-01-09 00:00:00', 'diterima', '2023-01-09 00:00:00'),
('111', 12, 'Transfer internal ke rekening FransiscaPriscillia-2212070001\nNominal: Rp 200000', '2023-01-09 00:00:00', 'diterima', '2023-01-09 00:00:00'),
('111', 13, 'Transfer internal ke rekening FransiscaPriscillia-2212070001\nNominal: Rp 6000', '2023-01-09 00:00:00', 'diterima', '2023-01-09 00:00:00'),
('111', 14, 'Transfer internal ke rekening ChristinGunawan-2212090001\nNominal: Rp 1000', '2023-01-09 00:00:00', 'diterima', '2023-01-09 00:00:00'),
('123', 1, 'Hai, Fransisca! Selamat datang di DiBa.', '2022-12-08 00:00:00', 'dibaca', '2022-12-09 00:00:00'),
('123', 2, 'Pin telah berhasil dibuat, Anda dapat melakukan transaksi', '2022-12-08 00:00:00', 'dibaca', '2022-12-09 00:00:00'),
('123', 3, 'inbox tanggal 9 desember 2022 yes', '2022-12-09 00:00:00', 'dibaca', '2022-12-09 00:00:00'),
('123', 4, 'Transaksi Debit dengan rekening eksternal Karin-1401234567\nNominal : Rp 100000', '2023-01-11 00:00:00', 'dibaca', '2023-01-11 00:00:00'),
('123', 5, 'Anda mengajukan pembukaan deposito jangka waktu 3 bulan dengan nominal Rp 300000', '2023-01-11 00:00:00', 'dibaca', '2023-01-11 00:00:00'),
('123', 6, 'Top Up saldo rekening 2212070001 sebesar Rp 1000000', '2023-01-11 00:00:00', 'dibaca', '2023-01-16 00:00:00'),
('123', 7, 'Pembukaan deposito telah diverifikasi', '2023-01-16 00:00:00', 'dibaca', '2023-01-16 00:00:00'),
('123', 8, 'Pencairan deposito No. 2023/01/11/0001/0001', '2023-01-16 00:00:00', 'dibaca', '2023-01-16 00:00:00'),
('222', 1, 'Hai Christin! Selamat datang di DiBa.', '2022-12-09 00:00:00', 'dibaca', '2022-12-09 00:00:00'),
('222', 2, 'Pin tabungan Anda telah dibuat,\nsekarang Anda dapat melakukan berbagai transaksi DiBa.', '2022-12-09 00:00:00', 'dibaca', '2022-12-09 00:00:00'),
('222', 3, 'Transaksi Debit dengan rekening Andy-1201234567', '2022-12-17 00:00:00', 'dibaca', '2022-12-17 00:00:00'),
('222', 4, 'Top Up saldo rekening 2212090001 sebesar Rp 10000000', '2022-12-17 00:00:00', 'dibaca', '2022-12-17 00:00:00'),
('222', 5, 'Transaksi Debit dengan rekening FennyCahyawati-2212070002', '2022-12-19 00:00:00', 'dibaca', '2022-12-20 00:00:00'),
('222', 6, 'Transaksi Debit dengan rekening Chelsea-1101234567', '2022-12-20 00:00:00', 'dibaca', '2022-12-20 00:00:00'),
('222', 7, 'Top Up saldo rekening 2212090001 sebesar Rp 100000', '2022-12-20 00:00:00', 'dibaca', '2022-12-20 00:00:00'),
('222', 8, 'Top Up saldo rekening 2212090001 sebesar Rp 10000', '2022-12-20 00:00:00', 'dibaca', '2022-12-20 00:00:00'),
('222', 9, 'Transaksi Debit dengan rekening Miranda-1101234568', '2022-12-21 00:00:00', 'dibaca', '2022-12-21 00:00:00'),
('222', 10, 'Tabungan Anda telah diaktifkan kembali', '2022-12-21 00:00:00', 'dibaca', '2022-12-21 00:00:00'),
('222', 11, 'Tabungan Anda telah diaktifkan kembali', '2022-12-21 00:00:00', 'dibaca', '2022-12-21 00:00:00'),
('222', 12, 'Top Up saldo rekening 2212090001 sebesar Rp 10000', '2022-12-21 00:00:00', 'dibaca', '2022-12-21 00:00:00'),
('222', 13, 'Transfer internal ke rekening FransiscaPriscillia-2212070001\nNominal: Rp 5000', '2022-12-22 00:00:00', 'diterima', '2022-12-22 00:00:00'),
('234', 1, 'Hai Muhammad! Selamat datang di DiBa.', '2022-12-21 00:00:00', 'diterima', '2022-12-21 00:00:00'),
('234', 2, 'Tabungan Anda telah diaktifkan', '2022-12-21 00:00:00', 'diterima', '2022-12-21 00:00:00'),
('234', 3, 'Tabungan Anda telah diaktifkan', '2022-12-21 00:00:00', 'diterima', '2022-12-21 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `jenispengguna`
--

CREATE TABLE `jenispengguna` (
  `id` int(11) NOT NULL,
  `nama` varchar(45) NOT NULL,
  `limit_transfer` double NOT NULL,
  `batas_atas_reward` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `jenispengguna`
--

INSERT INTO `jenispengguna` (`id`, `nama`, `limit_transfer`, `batas_atas_reward`) VALUES
(1, 'Silver', 10000000, 100),
(2, 'Gold', 25000000, 250),
(3, 'Platinum', 100000000, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `jenistransaksi`
--

CREATE TABLE `jenistransaksi` (
  `id_jenis_transaksi` int(11) NOT NULL,
  `kode` varchar(3) NOT NULL,
  `nama` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `jenistransaksi`
--

INSERT INTO `jenistransaksi` (`id_jenis_transaksi`, `kode`, `nama`) VALUES
(1, 'DBT', 'Debit'),
(2, 'CRT', 'Credit'),
(3, 'TAX', 'Tax'),
(4, 'ITR', 'Interest');

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

CREATE TABLE `pengguna` (
  `nik` varchar(16) NOT NULL,
  `nama_depan` varchar(100) NOT NULL,
  `nama_keluarga` varchar(100) DEFAULT NULL,
  `alamat` varchar(150) DEFAULT NULL,
  `email` varchar(100) NOT NULL,
  `no_telepon` varchar(15) NOT NULL,
  `password` varchar(128) NOT NULL,
  `pin` varchar(128) NOT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `jenis_pengguna` int(11) NOT NULL,
  `reward` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`nik`, `nama_depan`, `nama_keluarga`, `alamat`, `email`, `no_telepon`, `password`, `pin`, `tgl_buat`, `tgl_perubahan`, `jenis_pengguna`, `reward`) VALUES
('111', 'Fenny', 'Cahyawati', 'Surabaya', 'fenny', '081', 'b599109871b12a944cdf4c937e2ed8b8ab3e04e312c9e724be1f0b3a72ddb8a5fa6c2e11cfcc650c8ef180a5c003a0fcd0031f602d283698742fb2526f49a880', '9506c1cd1aad60374c3da154d2cebb9b6f274805b9b6515a14f87f0ab43fd0404d2eaab564db7e503b0a71184d9036ac67ab18c9c69db48fcd3047cb4853b7f2', '2022-12-07 00:00:00', '2022-12-07 00:00:00', 2, 54),
('123', 'Fransisca', 'Priscillia', 'Jawa Timur', 'priscil', '082', 'b599109871b12a944cdf4c937e2ed8b8ab3e04e312c9e724be1f0b3a72ddb8a5fa6c2e11cfcc650c8ef180a5c003a0fcd0031f602d283698742fb2526f49a880', '9506c1cd1aad60374c3da154d2cebb9b6f274805b9b6515a14f87f0ab43fd0404d2eaab564db7e503b0a71184d9036ac67ab18c9c69db48fcd3047cb4853b7f2', '2022-12-07 00:00:00', '2022-12-07 00:00:00', 1, 1),
('222', 'Christin', 'Gunawan', 'Palu', 'christin', '083', 'b599109871b12a944cdf4c937e2ed8b8ab3e04e312c9e724be1f0b3a72ddb8a5fa6c2e11cfcc650c8ef180a5c003a0fcd0031f602d283698742fb2526f49a880', '9506c1cd1aad60374c3da154d2cebb9b6f274805b9b6515a14f87f0ab43fd0404d2eaab564db7e503b0a71184d9036ac67ab18c9c69db48fcd3047cb4853b7f2', '2022-12-09 00:00:00', '2022-12-09 00:00:00', 1, 2),
('234', 'Muhammad', 'Fillah', 'Kalimantan', 'fillah', '084', 'b599109871b12a944cdf4c937e2ed8b8ab3e04e312c9e724be1f0b3a72ddb8a5fa6c2e11cfcc650c8ef180a5c003a0fcd0031f602d283698742fb2526f49a880', '0', '2022-12-21 00:00:00', '2022-12-21 00:00:00', 1, 0),
('333', 'Trevin', 'Timisela', 'Sulawesi', 'trevin', '085', 'b599109871b12a944cdf4c937e2ed8b8ab3e04e312c9e724be1f0b3a72ddb8a5fa6c2e11cfcc650c8ef180a5c003a0fcd0031f602d283698742fb2526f49a880', '0', '2022-12-22 00:00:00', '2022-12-22 00:00:00', 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `position`
--

CREATE TABLE `position` (
  `id` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `keterangan` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `position`
--

INSERT INTO `position` (`id`, `nama`, `keterangan`) VALUES
(1, 'admin', NULL),
(2, 'verifikator', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tabunganeksternal`
--

CREATE TABLE `tabunganeksternal` (
  `id_bank` int(11) NOT NULL,
  `no_rekening` varchar(10) NOT NULL,
  `nama_pemilik` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tabunganeksternal`
--

INSERT INTO `tabunganeksternal` (`id_bank`, `no_rekening`, `nama_pemilik`) VALUES
(1, '1101234567', 'Chelsea'),
(1, '1101234568', 'Miranda'),
(2, '1201234567', 'Andy'),
(3, '1301234567', 'Leonardo'),
(3, '1301234568', 'Jerome'),
(4, '1401234567', 'Karin'),
(5, '1501234567', 'Christian');

-- --------------------------------------------------------

--
-- Table structure for table `tabunganinternal`
--

CREATE TABLE `tabunganinternal` (
  `no_rekening` varchar(10) NOT NULL,
  `id_pengguna` varchar(16) NOT NULL,
  `saldo` double NOT NULL,
  `status` enum('unverified','aktif','suspend','nonaktif') NOT NULL,
  `keterangan` varchar(225) DEFAULT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `verifikator` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tabunganinternal`
--

INSERT INTO `tabunganinternal` (`no_rekening`, `id_pengguna`, `saldo`, `status`, `keterangan`, `tgl_buat`, `tgl_perubahan`, `verifikator`) VALUES
('2212070001', '123', 16910000, 'aktif', '', '2022-12-07 00:00:00', '2023-01-16 00:00:00', 2),
('2212070002', '111', 66400000, 'aktif', '', '2022-12-07 00:00:00', '2023-01-09 00:00:00', 2),
('2212090001', '222', 10023950, 'suspend', '', '2022-12-09 00:00:00', '2023-01-09 00:00:00', 3),
('2212210001', '234', 0, 'unverified', '', '2022-12-21 00:00:00', '2022-12-21 00:00:00', 1),
('2212220001', '333', 0, 'unverified', NULL, '2022-12-22 00:00:00', '2022-12-22 00:00:00', 1);

-- --------------------------------------------------------

--
-- Table structure for table `transaksieksternal`
--

CREATE TABLE `transaksieksternal` (
  `rekening_internal` varchar(10) NOT NULL,
  `id_transaksi` int(11) NOT NULL,
  `id_jenis_transaksi` int(11) NOT NULL,
  `id_bank` int(11) NOT NULL,
  `rekening_eksternal` varchar(10) NOT NULL,
  `tgl_transaksi` datetime NOT NULL,
  `nominal` double NOT NULL,
  `keterangan` varchar(225) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `transaksieksternal`
--

INSERT INTO `transaksieksternal` (`rekening_internal`, `id_transaksi`, `id_jenis_transaksi`, `id_bank`, `rekening_eksternal`, `tgl_transaksi`, `nominal`, `keterangan`) VALUES
('2212070001', 1, 1, 4, '1401234567', '2023-01-11 00:00:00', 100000, 'fee'),
('2212070002', 1, 1, 1, '1101234567', '2022-12-22 00:00:00', 10000, 'titipan'),
('2212070002', 2, 1, 1, '1101234567', '2022-12-22 00:00:00', 2000, 'tambahan'),
('2212090001', 1, 1, 2, '1201234567', '2022-12-17 00:00:00', 10000, ''),
('2212090001', 2, 1, 1, '1101234567', '2022-12-20 00:00:00', 100000, 'hadiah'),
('2212090001', 3, 1, 1, '1101234568', '2022-12-21 00:00:00', 20000, 'beli menantea');

-- --------------------------------------------------------

--
-- Table structure for table `transaksiinternal`
--

CREATE TABLE `transaksiinternal` (
  `rekening_sumber` varchar(10) NOT NULL,
  `id_transaksi` int(11) NOT NULL,
  `id_jenis_transaksi` int(11) NOT NULL,
  `tgl_transaksi` datetime NOT NULL,
  `rekening_tujuan` varchar(10) NOT NULL,
  `nominal` double NOT NULL,
  `keterangan` varchar(225) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `transaksiinternal`
--

INSERT INTO `transaksiinternal` (`rekening_sumber`, `id_transaksi`, `id_jenis_transaksi`, `tgl_transaksi`, `rekening_tujuan`, `nominal`, `keterangan`) VALUES
('2212070002', 1, 1, '2022-12-20 00:00:00', '2212070001', 16000, 'coba'),
('2212070002', 2, 1, '2022-12-21 00:00:00', '2212090001', 5000, 'urunan'),
('2212070002', 3, 1, '2022-12-22 00:00:00', '2212070001', 100000, 'jajan'),
('2212070002', 4, 1, '2022-12-22 00:00:00', '2212070001', 5000, 'jajan'),
('2212070002', 5, 1, '2022-12-22 00:00:00', '2212070001', 10000, 'gojek'),
('2212070002', 6, 1, '2022-12-22 00:00:00', '2212070001', 10000, 'gojek'),
('2212070002', 7, 1, '2022-12-22 00:00:00', '2212090001', 1000, 'fotocopy'),
('2212070002', 8, 1, '2023-01-09 00:00:00', '2212070001', 100000, 'coba'),
('2212070002', 9, 1, '2023-01-09 00:00:00', '2212070001', 200000, 'coba'),
('2212070002', 10, 1, '2023-01-09 00:00:00', '2212070001', 6000, 'coba aman'),
('2212070002', 11, 1, '2023-01-09 00:00:00', '2212090001', 1000, 'halo'),
('2212090001', 1, 1, '2022-12-19 00:00:00', '2212070002', 15000, 'utang ayam geprek'),
('2212090001', 2, 1, '2022-12-22 00:00:00', '2212070001', 5000, 'titip ngeprint');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `addressbookeksternal`
--
ALTER TABLE `addressbookeksternal`
  ADD PRIMARY KEY (`id_pengguna`,`id_bank`,`no_rekening`),
  ADD KEY `fk_tabunganEksternal_has_pengguna_pengguna1_idx` (`id_pengguna`),
  ADD KEY `fk_tabunganEksternal_has_pengguna_tabunganEksternal1_idx` (`id_bank`,`no_rekening`);

--
-- Indexes for table `addressbookinternal`
--
ALTER TABLE `addressbookinternal`
  ADD PRIMARY KEY (`no_rekening`,`id_pengguna`),
  ADD KEY `fk_addressBook_tabungan1_idx` (`no_rekening`),
  ADD KEY `fk_addressBook_pengguna1` (`id_pengguna`);

--
-- Indexes for table `banklain`
--
ALTER TABLE `banklain`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `deposito`
--
ALTER TABLE `deposito`
  ADD PRIMARY KEY (`id_deposito`),
  ADD KEY `fk_deposito_tabungan1_idx` (`no_rekening`),
  ADD KEY `fk_deposito_employee1_idx` (`verifikator_cair`),
  ADD KEY `fk_deposito_employee2_idx` (`verifikator_buka`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_employee_position1_idx` (`position`);

--
-- Indexes for table `inbox`
--
ALTER TABLE `inbox`
  ADD PRIMARY KEY (`id_pengguna`,`id_pesan`),
  ADD KEY `fk_inbox_pengguna1_idx` (`id_pengguna`);

--
-- Indexes for table `jenispengguna`
--
ALTER TABLE `jenispengguna`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `jenistransaksi`
--
ALTER TABLE `jenistransaksi`
  ADD PRIMARY KEY (`id_jenis_transaksi`);

--
-- Indexes for table `pengguna`
--
ALTER TABLE `pengguna`
  ADD PRIMARY KEY (`nik`),
  ADD KEY `fk_pengguna_jenisPengguna1_idx` (`jenis_pengguna`);

--
-- Indexes for table `position`
--
ALTER TABLE `position`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tabunganeksternal`
--
ALTER TABLE `tabunganeksternal`
  ADD PRIMARY KEY (`id_bank`,`no_rekening`),
  ADD KEY `fk_tabunganEksternal_bankLain1_idx` (`id_bank`);

--
-- Indexes for table `tabunganinternal`
--
ALTER TABLE `tabunganinternal`
  ADD PRIMARY KEY (`no_rekening`),
  ADD KEY `fk_tabungan_pengguna1_idx` (`id_pengguna`),
  ADD KEY `fk_tabungan_employee1_idx` (`verifikator`);

--
-- Indexes for table `transaksieksternal`
--
ALTER TABLE `transaksieksternal`
  ADD PRIMARY KEY (`rekening_internal`,`id_transaksi`),
  ADD KEY `fk_transaksiAntarBank_jenisTransaksi1_idx` (`id_jenis_transaksi`),
  ADD KEY `fk_transaksiAntarBank_tabungan1_idx` (`rekening_internal`),
  ADD KEY `fk_transaksiEksternal_tabunganEksternal1_idx` (`id_bank`,`rekening_eksternal`);

--
-- Indexes for table `transaksiinternal`
--
ALTER TABLE `transaksiinternal`
  ADD PRIMARY KEY (`rekening_sumber`,`id_transaksi`),
  ADD KEY `fk_transaksiAntarRekening_jenisTransaksi1_idx` (`id_jenis_transaksi`),
  ADD KEY `fk_transaksiAntarRekening_tabungan1_idx` (`rekening_sumber`),
  ADD KEY `fk_transaksiAntarRekening_tabungan2_idx` (`rekening_tujuan`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `addressbookeksternal`
--
ALTER TABLE `addressbookeksternal`
  ADD CONSTRAINT `fk_tabunganEksternal_has_pengguna_pengguna1` FOREIGN KEY (`id_pengguna`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tabunganEksternal_has_pengguna_tabunganEksternal1` FOREIGN KEY (`id_bank`,`no_rekening`) REFERENCES `tabunganeksternal` (`id_bank`, `no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `addressbookinternal`
--
ALTER TABLE `addressbookinternal`
  ADD CONSTRAINT `fk_addressBook_pengguna1` FOREIGN KEY (`id_pengguna`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_addressBook_tabungan1` FOREIGN KEY (`no_rekening`) REFERENCES `tabunganinternal` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `deposito`
--
ALTER TABLE `deposito`
  ADD CONSTRAINT `fk_deposito_employee1` FOREIGN KEY (`verifikator_cair`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_deposito_employee2` FOREIGN KEY (`verifikator_buka`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_deposito_tabungan1` FOREIGN KEY (`no_rekening`) REFERENCES `tabunganinternal` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `fk_employee_position1` FOREIGN KEY (`position`) REFERENCES `position` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `inbox`
--
ALTER TABLE `inbox`
  ADD CONSTRAINT `fk_inbox_pengguna1` FOREIGN KEY (`id_pengguna`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pengguna`
--
ALTER TABLE `pengguna`
  ADD CONSTRAINT `fk_pengguna_jenisPengguna1` FOREIGN KEY (`jenis_pengguna`) REFERENCES `jenispengguna` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `tabunganeksternal`
--
ALTER TABLE `tabunganeksternal`
  ADD CONSTRAINT `fk_tabunganEksternal_bankLain1` FOREIGN KEY (`id_bank`) REFERENCES `banklain` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `tabunganinternal`
--
ALTER TABLE `tabunganinternal`
  ADD CONSTRAINT `fk_tabungan_employee1` FOREIGN KEY (`verifikator`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tabungan_pengguna1` FOREIGN KEY (`id_pengguna`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `transaksieksternal`
--
ALTER TABLE `transaksieksternal`
  ADD CONSTRAINT `fk_transaksiAntarBank_jenisTransaksi1` FOREIGN KEY (`id_jenis_transaksi`) REFERENCES `jenistransaksi` (`id_jenis_transaksi`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_transaksiAntarBank_tabungan1` FOREIGN KEY (`rekening_internal`) REFERENCES `tabunganinternal` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_transaksiEksternal_tabunganEksternal1` FOREIGN KEY (`id_bank`,`rekening_eksternal`) REFERENCES `tabunganeksternal` (`id_bank`, `no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `transaksiinternal`
--
ALTER TABLE `transaksiinternal`
  ADD CONSTRAINT `fk_transaksiAntarRekening_jenisTransaksi1` FOREIGN KEY (`id_jenis_transaksi`) REFERENCES `jenistransaksi` (`id_jenis_transaksi`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_transaksiAntarRekening_tabungan1` FOREIGN KEY (`rekening_sumber`) REFERENCES `tabunganinternal` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_transaksiAntarRekening_tabungan2` FOREIGN KEY (`rekening_tujuan`) REFERENCES `tabunganinternal` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
