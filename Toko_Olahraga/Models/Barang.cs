using System;
using System.Collections.Generic;

namespace Toko_Olahraga.Models
{
    public partial class Barang
    {
        public Barang()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public int? Harga { get; set; }
        public int? Stok { get; set; }
        public int? IdStaff { get; set; }
        public int? IdAdmin { get; set; }
        public string Size { get; set; }

        public Admin IdAdminNavigation { get; set; }
        public StaffGudang IdStaffNavigation { get; set; }
        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
