using System;
using System.Collections.Generic;
using System.IO;
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
    }
}
