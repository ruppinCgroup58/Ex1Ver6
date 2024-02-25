﻿using System.Runtime.InteropServices;

namespace Ex1Ver6.BL
{
    public class Flat
    {
        string id;
        string city;
        string address;
        double price;
        int numberOfRooms;
        static List<Flat> FlatsList = new List<Flat>();
        DBServices dbs = new DBServices();

        public Flat()
        {

        }

        public Flat(string id, string city, string address, double price, int numberOfRooms)
        {
            Id = id;
            City = city;
            Address = address;
            NumberOfRooms = numberOfRooms;
            Price = price;
        }

        public string Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public int NumberOfRooms { get => numberOfRooms; set => numberOfRooms = value; }
        public double Price { get => price; set => price = discount(value); }

        public bool Insert()
        {
            foreach (Flat item in FlatsList)
            {
                if (item.Id == Id)
                {
                    return false;
                }
            }
            dbs.Insert(this);
            FlatsList.Add(this);
            return true;
        }

        public List<Flat> Read()
        {
            return dbs.Read();
        }

        public double discount(double value)
        {
            if (this.NumberOfRooms > 1 && value > 100)
            {
                return value *= 0.9;
            } else
            {
                return value;
            }
        }

        public static IEnumerable<Flat> GetByCityAndPrice(string city, double price)
        {
            List<Flat> listReturn = new List<Flat>();
            foreach (Flat item in FlatsList)
            {
                if (item.Price <= price && item.City == city)
                    listReturn.Add(item);
            }
            return listReturn;
        }
        
    }
}
