using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext Context;
        public ProductController(ProductDbContext _Context)
        {
            Context = _Context;
        }
        public IActionResult Index(string param)
        {
            param = !string.IsNullOrEmpty(param) ? param : ""; 
            List<Product> ProductList = Context.FindProduct(param).ToList();
            return View(ProductList);
        }

        //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? Id)
        {
            ViewBag.PageName = Id == null ? "Create Product" : "Edit Product";
            ViewBag.IsEdit = Id == null ? false : true;
            if (Id == null)
            {
                return View();
            }
            else
            {
                List<Product> Product = Context.FindProductbyId(Id).ToList();

                if (Product.Count()==0)
                {
                    return NotFound();
                }
                return View(Product.FirstOrDefault());
            }
        }

        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int? Id, [Bind("id,nama_barang,kode_barang,jumlah_barang,tanggal")]
        Product Data)
        {
            bool IsExist = false;

            List<Product> Prod = Context.FindProductbyId(Data.id).ToList();

            if (Prod.Count > 0)
            {
                IsExist = true;
            }

           
                try
                {                    

                    if (IsExist)
                    {
						var Result = Context.UpdateProduct(Data.id,Data.nama_barang,Data.kode_barang,Data.jumlah_barang,Data.tanggal).ToList();
                    }
                    else
                    {

						var Result2 = Context.InsertProduct(Data.nama_barang, Data.kode_barang, Data.jumlah_barang, Data.tanggal).ToList();

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));            
        }       

        // GET: Product/Delete/1
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var Product = Context.FindProductbyId(Id);

            if (Product == null)
            {
                return NotFound();
            }

            return View(Product.ToList().FirstOrDefault());
        }

        // POST: Produk/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var result =  Context.DeleteProduct(Id).ToList();          

            return RedirectToAction(nameof(Index));
        }
    }
}
