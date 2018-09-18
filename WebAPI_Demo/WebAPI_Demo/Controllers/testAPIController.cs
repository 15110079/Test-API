
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DataModel;

namespace WebAPI_Demo.Controllers
{
    public class testAPIController : ApiController
    {

        [HttpGet]
        [Route("api")]
        public IEnumerable<product> Get()
        {
            using (dataEntities da = new dataEntities())
            {
                return da.products.Select(x => x).Where(x => x.status == true).ToList();
            }
        }


        [HttpGet]
        [Route("api/get/{id}")]
        public product Get(int id)
        {
            using (dataEntities da = new dataEntities())
            {
                return da.products.FirstOrDefault(c => c.id == id && c.status==true);
            }
        }
        [HttpPost]
        [Route("api/post")]
        public product Post([FromBody]product newProduct)
        {
            using (dataEntities da = new dataEntities())
            {

                try
                {
                    newProduct.status = true;
                    da.products.Add(newProduct);
                    da.SaveChanges();
                    return newProduct;
                }
                catch
                {

                }
                return null;
            }
        }
        [HttpPut]
        [Route("api/delete")]
        public string Put([FromBody]product deletedProduct)
        {
            using (dataEntities db = new dataEntities())
            {
                try
                {
                    var deletedEmployee = db.products.Where(c => c.id == deletedProduct.id).FirstOrDefault();
                    deletedEmployee.status = false;
                    db.SaveChanges();
                    return "Delete successfully";

                }
                catch (Exception)
                {

                    return "Delete fail";
                    
                }
               
            }
          
        }
        [HttpPut]
        [Route("api/modify")]
        public string Putproduct([FromBody]product modifiedProduct)
        {
            using (dataEntities db = new dataEntities())
            {
                try
                {
                    var Product = db.products.Where(c => c.id == modifiedProduct.id).FirstOrDefault();
                    //Product = modifiedProduct;
                    //db.Entry(Product).State = EntityState.Modified;
                    Product.name = modifiedProduct.name;
                    Product.NSX = modifiedProduct.NSX;
                    Product.image1 = modifiedProduct.image1;
                    Product.image1 = modifiedProduct.image2;
                    Product.image1 = modifiedProduct.image3;
                    Product.price = modifiedProduct.price;
                    Product.unit = modifiedProduct.unit;
                    db.SaveChanges();
                    return "Modify successfully";
                }
                catch (Exception)
                {

                    return "Modify fail";
                }
            }
        }

    }
}
