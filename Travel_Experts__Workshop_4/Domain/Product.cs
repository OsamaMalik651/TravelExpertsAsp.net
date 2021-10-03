using System;
using System.Collections.Generic;

#nullable disable

namespace Travel_Experts__Workshop_4.Domain
{
    public partial class Product
    {
        public Product()
        {
            ProductsSuppliers = new HashSet<ProductsSupplier>();
        }

        public int ProductId { get; set; }
        public string ProdName { get; set; }

        public virtual ICollection<ProductsSupplier> ProductsSuppliers { get; set; }
    }
}
