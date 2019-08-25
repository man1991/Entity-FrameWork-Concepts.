using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

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
            CustomerEntities objEntities = new CustomerEntities();//for database first approach

            #region Using EF From Database First Approach
            #region Create
            //Country objCountry = new Country();//create object
            //objCountry.CountryName = "Argentina";//add data
            //objCountry.Population = 1500;//add data
            //objEntities.Countries.Add(objCountry);//call Add() method adds data in memory and not to database - inmemory commit
            //objEntities.SaveChanges();//call SaveChanges() method adds data into database - physical commit 

            #region AddRange
            //List<Country> lstCountries = new List<Country>();
            //lstCountries.Add(new Country() {CountryName="Peru", Population= 400 });
            //lstCountries.Add(new Country() { CountryName = "Venezuela", Population = 4000 });
            //lstCountries.Add(new Country() { CountryName = "Costa Rica", Population = 40 });

            //lstCountries.Add(new Country() { CountryName = "A", Population = 6001 });
            //lstCountries.Add(new Country() { CountryName = "B", Population = 7001 });
            //lstCountries.Add(new Country() { CountryName = "C", Population = 8001 });

            //old way of adding to database
            //foreach (var item in lstCountries)
            //{
            //    objEntities.Countries.Add(item);
            //}

            //objEntities.Countries.AddRange(lstCountries);//AddRange() - to add list of elements
            //objEntities.SaveChanges();//call SaveChanges() method adds data into database - physical commit 
            #endregion
            #endregion

            #region Read
            //List<Country> objCountries = objEntities.Countries.ToList<Country>();
            //var objCountries = objEntities.Countries.ToList<Country>();

            //foreach (Country o in objCountries)
            //{
            //    Console.WriteLine("Country Name: {0} Population: {1}", o.CountryName, o.Population);
            //}

            //var objPopulationGreaterThan1000 = objEntities.Countries.Where(x => x.Population > 1000).ToList();
            //Console.WriteLine("\nPopulation Greater Than 1000:");
            //foreach (Country o in objPopulationGreaterThan1000)
            //{
            //    Console.WriteLine("Country Name: {0} Population: {1}", o.CountryName, o.Population);
            //}
            #endregion

            #region Update
            //Country objUpdate = objCountries[0];
            //objUpdate.Population = 900;
            //objEntities.SaveChanges();

            //OR
            //FirstOrDefault() returns null value whereas First() does not return null values and it won't store same
            //var changePopulation = objEntities.Countries.Where(x => x.CountryName == "NEP").FirstOrDefault();
            //changePopulation.Population = 5000;
            //objEntities.SaveChanges();

            //will throw exception if data doesn't match and does not return null
            //var changePopulation = objEntities.Countries.Where(x => x.CountryName == "NE").First();
            //changePopulation.Population = 5000;
            //objEntities.SaveChanges();

            //won't throw exception if data doesn't match and returns null
            //var changePopulation = objEntities.Countries.Where(x => x.CountryName == "NE").FirstOrDefault();
            //if (changePopulation != null)//used if data doesn't data match
            //{
            //    changePopulation.Population = 5000;
            //    objEntities.SaveChanges();
            //}

            //FirstOrDefault() returns null value whereas First() does not return null values and it won't store same
            var changeCountryName = objEntities.Countries.Where(x => x.Population == 101).FirstOrDefault();
            changeCountryName.CountryName = "Kenya";
            try
            {
                objEntities.SaveChanges();
            }
            catch
            {
                //handle concurrency
            }
            #endregion

            #region Delete
            //Country objDelete = objCountries[0];
            //objEntities.Countries.Remove(objDelete);
            //objEntities.SaveChanges(); 

            //OR
            //var deleteRecord = objEntities.Countries.Where(x => x.Population == 1500).FirstOrDefault();
            //objEntities.Countries.Remove(deleteRecord);

            #region RemoveRange
            ////RemoveRange() - to remove list of elements
            //var deleteRecordsInRange = objEntities.Countries.Where(x => x.Population > 6000).ToList();
            //objEntities.Countries.RemoveRange(deleteRecordsInRange);
            //objEntities.SaveChanges(); 
            #endregion
            #endregion
            #endregion

            #region Using Code First Approch
            //CustomerCodeFirst objEntities = new CustomerCodeFirst();//for code first approach
            #region Read
            //var objCountries = objEntities.Countries.ToList<Country>();

            //foreach (Country o in objCountries)
            //{
            //    Console.WriteLine("Country Name: {0} Population: {1}", o.CountryName, o.Population);
            //}
            #endregion
            #endregion

            Console.ReadLine();

        }
    }
}
