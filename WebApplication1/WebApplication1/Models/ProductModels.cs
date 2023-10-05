using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Nama Barang")]
        [MaxLength(200)]
        public string nama_barang {  get; set; }
        [Required]
        [Display(Name = "Kode Barang")]
        [MaxLength(50)]
        public string kode_barang { get; set; }

        [Display(Name = "Jumlah barang")]
        public int jumlah_barang { get; set; }
        [Required]
        [Display(Name = "Tanggal")]
        public DateTime tanggal {  get; set; }
    }
}
