using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖVNINGSUPPGIFT___SHOPPINGLISTA.Models
{
    public class Product
    {
        /*
         Åtkomstmodifierare
            public, private, protected, internal används för att styra åtkomsten till klassmedlemmar.
            public: Åtkomst från var som helst.
            private: Endast åtkomst inom klassen.
            protected: Åtkomst inom klassen och dess subklasser.
        */

        // Variabler
        private string productName;
        private double productPrice = 0;

        //Egenskaper
        public string Name
        {
            get { return productName; }
            set { productName = value.Trim(); }
        }
        public double Price
        {
            get { return productPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Priset kan inte vara negativt.");
                productPrice = value;
            }
        }

        // Exempel på privat kod.
        //public double Price
        //{
        //    get { return productPrice; } // Tillåter läsning
        //    private set { productPrice = value; } // Begränsar tilldelning. Endast åtkomst inom klassen.
        //}

        // Konstruktor
        public Product(string name, double price)
        {
            productName = name;
            productPrice = price;

            // Vi kan också passa på att köra kod i samband med att konstruktorn skapas.
            Console.WriteLine($"Grattis, du har lagt till {productName} i shoppinglistan!");
        }

        // Metoder
        public void Description()
        {
            Console.WriteLine($"{productName} för endast {productPrice}kr, vilket kap!");
        }
    }
} 
