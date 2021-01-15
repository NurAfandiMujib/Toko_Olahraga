using System;
using System.Collections.Generic;

namespace Toko_Olahraga.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdBarang { get; set; }
        public int? IdPembeli { get; set; }
        public DateTime? Tanggal { get; set; }
        public string Keterangan { get; set; }

        public Barang IdBarangNavigation { get; set; }
        public Pembeli IdPembeliNavigation { get; set; }
    }
}
