using System;
using System.Collections.Generic;

namespace Toko_Olahraga.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Barang = new HashSet<Barang>();
        }

        public int IdAdmin { get; set; }
        public string NamaAdmin { get; set; }

        public ICollection<Barang> Barang { get; set; }
    }
}
