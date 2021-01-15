using System;
using System.Collections.Generic;

namespace Toko_Olahraga.Models
{
    public partial class StaffGudang
    {
        public StaffGudang()
        {
            Barang = new HashSet<Barang>();
        }

        public int IdStaff { get; set; }
        public string NamaStaff { get; set; }
        public int? NoTlp { get; set; }
        public string Alamat { get; set; }

        public ICollection<Barang> Barang { get; set; }
    }
}
