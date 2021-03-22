using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverErvingOefeningen
{
    class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        private double price;

        public virtual double Price
        {
            get { return price; }
            set { price = value; }
        }

        public static Book TelOp(Book boek1, Book boek2)
        {
            Book nieuwBoek = new Book();
            nieuwBoek.Title = $"Omnibus van [{boek1.Author}, {boek2.Author}]";
            nieuwBoek.Price = (boek1.Price + boek2.Price) / 2;
            return nieuwBoek;
        }
        public override string ToString()
        {
            return $"({Title} - {Author} ({ISBN}) {Price})";
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || (!(obj is Book))) return false;
            if (ISBN == ((Book)obj).ISBN) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ ISBN.GetHashCode() ^ Author.GetHashCode() ^ Price.GetHashCode();
        }
    }
    class TextBook : Book
    {
        public int GradeLevel { get; set; }

        public override double Price 
        { 
            get => base.Price; 
            set
            {
                if (value > 19 && value < 81) base.Price = value;
            }
                 
        }
    }
    class CoffeeTableBook : Book
    {
        public override double Price
        {
            get => base.Price;
            set
            {
                if (value > 34 && value < 101) base.Price = value;
            }

        }
    }
}
