using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace InterviewTestQA
{
    public class CostAnalysisItem
    {
        public string YearId { get; set; }
        public int GeoRegionId { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int SchemeId { get; set; }
        public int SchmTypeId { get; set; }
        public double Cost { get; set; }
    }

    [TestFixture]
    public class JSONTest
    {
        private List<CostAnalysisItem> costAnalysisItems;

        [SetUp]
        public void SetUp()
        {
            // Initialize the list
            costAnalysisItems = new List<CostAnalysisItem>();

            // Define the path to the JSON file
            string filePath = "Cost Analysis.json";

            try
            {
                // Read the JSON file
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize JSON content into the list
                costAnalysisItems = JsonConvert.DeserializeObject<List<CostAnalysisItem>>(jsonContent);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to load or deserialize JSON: {ex.Message}");
            }
        }

        [Test]
        public void Test_CostAnalysisItem_Count()
        {
            // Expected number of items in the JSON file
            int expectedCount = 56;  // Update based on actual count in the file

            // Assert that the number of items matches the expected count
            Assert.AreEqual(expectedCount, costAnalysisItems.Count, "The count of items in the JSON file does not match.");
        }

        [Test]
        public void Test_TopItem_ByCost()
        {
            // Get the item with the highest Cost
            var topItem = costAnalysisItems.OrderByDescending(item => item.Cost).FirstOrDefault();

            // Assert that the top item exists and check its CountryId
            Assert.IsNotNull(topItem, "No items were found in the list.");
            Assert.AreEqual(276, topItem.CountryId, "The CountryId of the top item by cost does not match the expected value."); // Replace 276 with the actual expected CountryId
        }

        [Test]
        public void Test_SumCost_ForYear2016()
        {
            // Calculate the total Cost for items where YearId is "2016"
            double totalCost2016 = costAnalysisItems
                .Where(item => item.YearId == "2016")
                .Sum(item => item.Cost);

            // Assert the total cost for 2016
            Assert.AreEqual(123456.78, totalCost2016, 0.01, "The total cost for the year 2016 does not match the expected value."); // Replace 123456.78 with the expected total
        }
    }
}
