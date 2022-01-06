using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;


namespace csqlite
{
    class Product
    {

        int expirationDate;
        public int ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                if (value > 0)
                {
                    expirationDate = value;
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value >= 0)
                {
                    weight = value;
                }
            }
        }


        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    price = (-1) * value;
                }
                else
                {
                    price = value;
                }
            }
        }

        public Product(string nname, double nweight, double nprice, int nexpirationDate)
        {
            this.name = nname;
            this.price = nprice;
            this.weight = nweight;
            this.expirationDate = nexpirationDate;
            
        }

        public Product() : this(nname: "Name", nweight: 0, nprice: 0, nexpirationDate: 1) { }

        public override string ToString()
        {
            return $"Name:{this.Name} - Weight: {this.Weight} - Price:{this.Price}";
        }
        public static Product Create(IDataRecord data)
        {
            return new Product(data["Name"].ToString(),Convert.ToDouble(data["Weight"]), Convert.ToDouble(data["Price"]),Convert.ToInt32(data["Weight"]));
        }
    }
    
    static class DBHelper //extensions
    {
       
       

        public static List<Product> GetProducts(this Db db)
        {
            return db.GetList<Product>("select * from Product", Product.Create);
        }
        //linq
        public static Product GetProductsByName(this Db db,string name)
        {
            return db.GetProducts().Where(p => p.Name == name).FirstOrDefault();
        }
        //sql
        public static Product GetProductsByWeight(this Db db, string weight)
        {
            return db.GetList<Product>($"select * from Product where Weight like '{weight}%' limit 1 ", Product.Create).FirstOrDefault();
        }

        
        }
    class Db
    {
        public SqliteConnection connection;
        public Db() { }
        public Db(string connectionString)
        {
            connection = new SqliteConnection(connectionString);
            connection.Open();
        }



        public void ExecuteSQL(string sql)
        {
            using (connection)
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = sql;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public List<T> GetList<T>(string sql, Func<IDataRecord, T> generator)
        {
            var list = new List<T>();
            using (connection)
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sql, connection);
                try
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            list.Add(generator(reader));
                        }

                    }

                }
                catch
                {
                    return null;
                }
            }



            return list;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {


            Db db = new Db(@"Data Source = D:\Sigma\DZ14\Program\Program\data.db");

            db.ExecuteSQL("INSERT INTO Product (ID, NAME, WEIGHT, PRICE, Expirationdate)VALUES(7, 'Tesda', 0.2, 30, 30)");

            Console.WriteLine("List");

            foreach (Product product in db.GetProducts())
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("linq");
            Console.WriteLine(db.GetProductsByName("Tea"));
            Console.WriteLine("sql");
            Console.WriteLine(db.GetProductsByWeight("1"));

            int a=3;
         }
    }
}














/*

public override int GetHashCode()
{
    return Name.GetHashCode() + Convert.ToInt32(Weight) + Convert.ToInt32(Price) + ExpirationDate + CreationTime.Day;
}

public virtual void ChangePrice(double Percentage, (int, int, int) Koefs)
{

    Price *= 1 + (Percentage / 100);
    Price = Math.Round(Price, 2);
}

public override bool Equals(Object obj)
{
    if (this.GetType() == obj.GetType())
    {
        var Second = (Product)obj;
        return this.Name == Second.Name && this.Price == Second.Price && this.Weight == Second.Weight;
    }

    return false;
}


public override string ToString()
{
    return $"Name:{this.Name}, Weight: {this.Weight}, Price:{this.Price}";
}

public Product Copy()
{
    return (Product)this.MemberwiseClone();
}

public virtual void Parse(string dataSentence)
{
    string[] words = dataSentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    if (words.Length != 5)
    {
        throw new Exception($"Impossible to initialise {this.GetType()} object - invalid string for parse");
    }

    this.Name = words[0];

    try
    {
        this.Weight = Convert.ToInt32(words[1]);
    }
    catch (Exception ex)
    {
        throw new Exception("Error with weight parameter" + ex.Message);
    }
    try
    {
        this.Price = Convert.ToDouble(words[2]);
    }
    catch (Exception ex)
    {
        throw new Exception("Error with price parameter" + ex.Message);
    }
    try
    {
        this.ExpirationDate = Convert.ToInt32(words[3]);
    }
    catch (Exception ex)
    {
        throw new Exception("Error with expiration date parameter" + ex.Message);
    }
    try
    {
        this.CreationTime = DateTime.Parse(words[4]);
    }
    catch (Exception ex)
    {
        throw new Exception("Error with creation time parameter" + ex.Message);
    }
}*/