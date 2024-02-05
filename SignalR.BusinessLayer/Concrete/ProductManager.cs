using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _ProductDal;

        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
        }

        public void TAdd(Product entity)
        {
            _ProductDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _ProductDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return _ProductDal.GetByID(id);
        }

        public List<Product> TGetListAll()
        {
            return _ProductDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _ProductDal.GetProductsWithCategories();
        }

        public int TProductCount()
        {
            return _ProductDal.ProductCount();
        }

        public string TProductNameByMaxPrice()
        {
            return _ProductDal.ProductNameByMaxPrice();
        }

        public string TProductNameByMinPrice()
        {
            return _ProductDal.ProductNameByMinPrice();
        }

        public decimal TProductPriceAvg()
        {
            return _ProductDal.ProductPriceAvg();
        }

        public decimal TProductAvgPriceByHamburger()
        {
            return _ProductDal.ProductAvgPriceByHamburger();
        }

        public int TProdudtCountByCategoryNameDrink()
        {
            return _ProductDal.ProdudtCountByCategoryNameDrink();
        }

        public int TProdudtCountByCategoryNameHamburger()
        {
            return _ProductDal.ProdudtCountByCategoryNameHamburger();
        }

        public void TUpdate(Product entity)
        {
            _ProductDal.Update(entity);
        }
    }
}
