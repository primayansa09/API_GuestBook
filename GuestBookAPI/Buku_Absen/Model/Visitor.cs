using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buku_Absen.Model
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string No_hp { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public string Provinsi { get; set; }
        public string Kota_Kabupaten { get; set; }
        public string Kecamatan { get; set; }
        public string Kelurahan { get; set; }
        public int KodePos { get; set; }
        public DateTime Kehadiran { get; set; }
    }
}
