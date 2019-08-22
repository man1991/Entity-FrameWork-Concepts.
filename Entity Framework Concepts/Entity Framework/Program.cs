using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    /// <summary>
    /// Entity Framework creates class tblCountry with two properties: CountryName and Population
    /// Entity framework is all about bridging two worlds:
    /// Where one is relational world where we have Tables with primary key, foreign key
    /// than we have middle layer where we think w.r.t classes, objects, aggregation, composition. We think more about
    /// representing real world objects.
    /// Naming convention should also be focused like a table: tblCountry is valid
    /// but a class named tblCountry is not real world name.
    /// EF 5 - DeleteObject() & EF 6 - Remove()
    /// EF 5 - AddObject() & EF 6 - Add()
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CustomerEntities objContext = new CustomerEntities();

            //Reading Data
            List<Country> objCountries = objContext.Countries.ToList<Country>();
            foreach(Country o in objCountries)
            {
                Console.WriteLine(o.CountryName + " " + o.Population);
            }

            //Inserting Data
            Country objCountry = new Country();//create object
            objCountry.CountryName = "Sri Lanka";//add data
            objCountry.Population = 2000;//add data
            //objContext.Countries.Add(objCountry);//call Add() method adds data in memory and not to database - inmemory commit
            //objContext.SaveChanges();//call SaveChanges() method adds data into database - physical commit

            //Updating Data
            Country objUpdate = objCountries[0];
            objUpdate.Population = 900;
            objContext.SaveChanges();

            //Deleting Data
            Country objDelete = objCountries[0];
            objContext.Countries.Remove(objDelete);
            objContext.SaveChanges();
            Console.ReadLine();

        }
    }
}
