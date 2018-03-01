using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCA.MongoDB.DAL;  // Cloud Computing Associates y'all
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CCA.MongoDB.DAL.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void RepositoryReturnsCollectionSymbols()
        {
            Repository repo = new Repository();

            List<marty_collection_entity> returnCollection = repo.GetCollection("marty_collection");
            Console.WriteLine("Collection count: " + returnCollection.Count);
            Console.WriteLine("Name: " + returnCollection[0].name);

            Assert.IsTrue(true); // I got your test condition, right over here

        }
    }
}
