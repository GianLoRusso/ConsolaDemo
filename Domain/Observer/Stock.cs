///////////////////////////////////////////////////////////
//  Stock.cs
//  Implementation of the Class Stock
//  Generated by Enterprise Architect
//  Created on:      05-jun.-2023 19:31:58
//  Original author: gasto
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Observador;
namespace Observador {
	/// <summary>
	/// This class knows its observers and provides an interface for attaching and
	/// detaching Observer objects.
	/// </summary>
	public abstract class Stock {

		private string symbol;
		private double price;

		private List<IInvestor> investors = new List<IInvestor>();
		// Constructor
		public Stock(string symbol, double price)
		{
			this.symbol = symbol;
			this.price = price;
		}

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }
        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }
        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }
        // Gets or sets the price
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }
        // Gets the symbol
        public string Symbol
        {
            get { return symbol; }
        }

    }//end Stock

}//end namespace Observador