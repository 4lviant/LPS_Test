using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public IQueryable<Product> FindProduct(string namabarang)
        {
            SqlParameter Nama_barang = new SqlParameter("@namabarang", namabarang);
            return this.Products.FromSqlRaw("Execute Find_Produk @namabarang", Nama_barang);
        }
        public IQueryable<Product> FindProductbyId(int? id)
        {
            SqlParameter Id = new SqlParameter("@id", id);
            return this.Products.FromSqlRaw("Execute Find_ProdukbyId @id", Id);
        }
        public IQueryable<Product> InsertProduct(string namabarang,string kodebarang, int jmlbarang, DateTime tgl)
        {
            var Nama_barang = new SqlParameter("@namabarang", System.Data.SqlDbType.VarChar,200);
            var Kode_barang = new SqlParameter("@kodebarang", System.Data.SqlDbType.VarChar, 50);
            var Jml_barang = new SqlParameter("@jmlbarang", System.Data.SqlDbType.Int);
            var Tgl_barang = new SqlParameter("@tgl", System.Data.SqlDbType.DateTime);
            Nama_barang.Value = namabarang;
            Kode_barang.Value = kodebarang;
            Jml_barang.Value = jmlbarang;
            Tgl_barang.Value = tgl;
            //var result = this.Products.FromSqlRaw("Execute Insert_Produk @namabarang, @kodebarang, @jmlbarang, @tgl", Nama_barang, Kode_barang, Jml_barang, Tgl_barang);
            return this.Products.FromSqlRaw("Execute Insert_Produk @namabarang, @kodebarang, @jmlbarang, @tgl", Nama_barang,Kode_barang,Jml_barang,Tgl_barang);
        }
        public IQueryable<Product> UpdateProduct(int id,string namabarang, string kodebarang, int jmlbarang, DateTime tgl)
        {
            var Id = new SqlParameter("@id", System.Data.SqlDbType.Int);
            var Nama_barang = new SqlParameter("@namabarang", System.Data.SqlDbType.VarChar, 200);
            var Kode_barang = new SqlParameter("@kodebarang", System.Data.SqlDbType.VarChar, 50);
            var Jml_barang = new SqlParameter("@jmlbarang", System.Data.SqlDbType.Int);
            var Tgl_barang = new SqlParameter("@tgl", System.Data.SqlDbType.DateTime);
            Id.Value = id;
            Nama_barang.Value = namabarang;
            Kode_barang.Value = kodebarang;
            Jml_barang.Value = jmlbarang;
            Tgl_barang.Value = tgl;
            return this.Products.FromSqlRaw("Execute Update_Produk @id, @namabarang, @kodebarang, @jmlbarang, @tgl",Id, Nama_barang, Kode_barang, Jml_barang, Tgl_barang);
        }
        public IQueryable<Product> DeleteProduct(int id)
        {
            SqlParameter Id = new SqlParameter("@id", id);
            return this.Products.FromSqlRaw("Execute Delete_Produk @id", Id);
        }


    }
}
