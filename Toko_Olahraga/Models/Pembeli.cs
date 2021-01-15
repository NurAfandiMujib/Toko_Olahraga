using System;
using System.Collections.Generic;

namespace Toko_Olahraga.Models
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdPembeli { get; set; }
        public string NamaPembeli { get; set; }
        public string JenisKelamin { get; set; }
        public int? NoTlp { get; set; }
        public string Alamat { get; set; }

        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
