using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Adidas Shoe", Price = 999, Imgadress="https://images.journeys.com/images/navigation/1_3097.JPG"},
            new Product { Id = 2, Name = "Nike Shoe", Price = 1799, Imgadress = "https://www.nike.com.kw/dw/image/v2/BDVB_PRD/on/demandware.static/-/Sites-akeneo-master-catalog/default/dw4b587fa2/nk/x7d/i/z/y/j/w/a/x7dizyjwaxql70mv12lj.jpg?sw=700&sh=700&sm=fit&q=100&strip=false"},
            new Product { Id = 3, Name = "DC Shoe", Price = 1499, Imgadress = "https://images.napali.app/global/dcshoes-products/all/default/xlarge/adys400043_dcshoes,p_6dw_frt1.jpg" },
            new Product { Id = 4, Name = "Reebok Shoe", Price = 799, Imgadress = "https://cdn.shopify.com/s/files/1/0862/7834/0912/files/100214359_SLC_eCom-tif.png?v=1736434885" },
            new Product { Id = 5, Name = "Lacoste Shoe", Price = 975, Imgadress="https://image1.lacoste.com/dw/image/v2/AAQM_PRD/on/demandware.static/Sites-SE-Site/Sites-master/en_SE/dwcfbdbadb/47SMA0013_02H_01.jpg?imwidth=615&impolicy=pctp" }
        };

        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
