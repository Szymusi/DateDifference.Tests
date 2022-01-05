using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaOTask.Services.DataCalculationService;

namespace NaOTask.Tests
{
    [TestClass]
    public class DataCalculationServiceTests
    {
        IDataCalculationService _dataCalculationService = new DataCalculationService();
        private string _firstDate;
        private string _secondDateWithDifferentDay;
        private string _secondDateWithDifferentMonth;
        private string _secondDateWithDifferentYear;

        [TestInitialize]
        public void TestInit()
        {
            _firstDate = "11.1.1111";
            _secondDateWithDifferentDay = "12.1.1111";
            _secondDateWithDifferentMonth = "11.2.1111";
            _secondDateWithDifferentYear = "11.1.1112";
        }
        [TestMethod]
        public void GetDateDiffResult_ShouldReturnDayDiference()
        {
            var args = new string[] { _firstDate, _secondDateWithDifferentDay };
            string result = _dataCalculationService.GetDateDiffResult(args);

            result.Should().Be("11-12.1.1111");
        }

        [TestMethod]
        public void GetDateDiffResult_ShouldReturnMonthsAndDayDiference()
        {
            var args = new string[] { _firstDate, _secondDateWithDifferentMonth };
            string result = _dataCalculationService.GetDateDiffResult(args);

            result.Should().Be("11.1 - 11.2.1111");
        }

        [TestMethod]
        public void GetDateDiffResult_ShouldReturnMothsDaysAndYersDifference()
        {
            var args = new string[] { _firstDate, _secondDateWithDifferentYear };
            string result = _dataCalculationService.GetDateDiffResult(args);

            result.Should().Be("11.1.1111 - 11.1.1112");
        }
    }
}
