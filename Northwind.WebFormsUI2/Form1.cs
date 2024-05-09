using Northwind.Business2.Abstract;
using Northwind.Business2.Concrete;
using Northwind.DataAccess2.Abstract;
using Northwind.DataAccess2.Concrete;
using Northwind.DataAccess2.Concrete.EntitiyFramework;
using Northwind.DataAccess2.Concrete.EntityFramework;
using Northwind.DataAccess2.Concrete.NHibernate;
using Northwind.Entities2.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // interface ni güzeligini burada görüyoruz ProductManager
            // parametresini ne verirsek o veri tabanın verilerini getirir
            // EfProductDal NhproductDal da IProductDal interfacesini kulandıgmız için

            _productService = new ProductManager(new EfProductDal());         // farklı veri tabanı ile çalışmak istersek örenk NhProductDal ((new EfProductDal()) 
                                                                              // bu kısmı degiştirmek yeterli olacaktır
            _categoryService = new CategoryManager(new EfCategoryDal());    // EfCategoryDal ICategoryDalı kulanılarak implemente edildi

        }

        private IProductService _productService;            //  Bu dosya içinde IProductServicecin özeliklerini kulanamk için sadece bu dosyaya özel
                                                            //  bir degişken tanımlayıp IProductService özeliklerin kulanabilecez
        private ICategoryService _categoryService;          // // // // // // / Aynı işlemi ICatagoryService içinde uyguladık // // // // // // // 

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();        // ürünleri listeleyen method
            LoadCategories();      // Katakori komboboxunu  dolduran method


        }

        private void LoadCategories()
        {
            // sayfa yüklendigi zaman katagorinin otomatik olark dolması
            // katagori gorup box
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";   // GÖRÜNEN kategorinin ismi olmalı                                                
            cbxCategory.ValueMember = "CategoryId";    // ama biz veriyi seçtigmiz  zaman bize katagorinin ID sini vermesi lazım  
            // ürün ekle group box
            cbxCategoryId.DataSource = _categoryService.GetAll();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryId";
            // ürün güncelle group box
            cbxCategoryIdUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryIdUpdate.DisplayMember = "CategoryName";
            cbxCategoryIdUpdate.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
                // Ben sana ürünleri getirmen için kategori ID si verecem sende bana sana verdigim ID ye göre ürünleri getir

            }
            catch
            {


            }
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e) // ürün ismine göre arama
        {
            if (!String.IsNullOrEmpty(tbxProductName.Text)) // tbxProductNamenin texti boş degilse içerde deger varsa bu kodu çalıştır ama tbxProductName de deger yoks tüm verileri getir
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxProductName.Text); // parametresi tbxProductNamegirilen deger

            }
            else
            {
                LoadProducts(); // eger tbxProductName de herhengi bir deger yoksa veya boşsa tüm verileri getirir
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cbxCategoryId.SelectedValue),  // cbxCategoryId den gelen degeri integer degere çeviriyorz
                    ProductName = tbxProductName2.Text,                      // tbxProductName2 den gelen texti ProductName ye atıyoruz
                    QuantityPerUnit = tbxQuantityPerUnit.Text,               //  tbxQunatiPerUnit ten gelen texti QuantiyPerUnite atıyoruz
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),         // tbxUnitPrice gelen integr degeri decimal sayı olarak UnitPriceye atıyoruz
                    UnitsInStock = Convert.ToInt16(tbxStock.Text),             //  UnitsInStock ınt16 tanımladıgmız için tbxStock textindeki degeri de çeviriyoruz

                });
                MessageBox.Show("Ürün Eklendi!"); // kulanıcı bilgilendirme
                LoadProducts();                   // girilen ürünn ardından ekran güncelenmesi
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {

                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    ProductName = tbxUpdateProductName.Text,
                    CategoryId = Convert.ToInt32(cbxCategoryIdUpdate.SelectedValue),
                    UnitsInStock = Convert.ToInt16(tbxUnitsInStockUpdate.Text),
                    QuantityPerUnit = tbxQuantitiyPerUnitUpdate.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),


                });
                MessageBox.Show("Ürün Güncellendi");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)  // (event) // seçilen ürünün özeliklerini Atama
        {
            var row = dgwProduct.CurrentRow; // KISALTMA AMAÇLI
            tbxUpdateProductName.Text = row.Cells[1].Value.ToString();          // tbxUpdateProductName nin text ine dgwProducta seçili olan ürünün ilgili özeligni ata
            cbxCategoryIdUpdate.SelectedValue = row.Cells[2].Value;             //[0] ürünün Id[1] ürün ismi ...... 
            tbxUnitPriceUpdate.Text = row.Cells[3].Value.ToString();
            tbxQuantitiyPerUnitUpdate.Text = row.Cells[4].Value.ToString();
            tbxUnitsInStockUpdate.Text = row.Cells[5].Value.ToString();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)  // seçilen boş degilse 
            {                                   //{
                try                       // Dene
                {
                    _productService.Delet(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value) // ProducId ye datagridwiewde seçilen ürünün ata

                    });
                    MessageBox.Show("Ürün Silindi");
                    LoadProducts();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message); // hata mesajı 

                }
            }

        }


    }

}
