using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_belengv.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book bo, int qty)
        {
            BasketLineItem Line = Items
                .Where(b => b.Book.BookId == bo.BookId)
                .FirstOrDefault();
            if (Line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bo,
                    Quantity = qty

                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }

        public  virtual void RemoveItem(Book bo)
        {
            Items.RemoveAll(x => x.Book.BookId == bo.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }
    }
    

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
