using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }

        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(p=>p.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public virtual void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductId.Equals(product.ProductId));        

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalValue() => Lines.Sum(l => l.Quantity * l.Product.ProductPrice);
    }
}
