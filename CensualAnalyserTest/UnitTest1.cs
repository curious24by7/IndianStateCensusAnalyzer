using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensualAnalyserTest
{
    public class Tests
    {
        //Headers
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        //CorrectFilePaths
        static string indianStateCensusFilePath = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\IndiaStateCode.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
        //WrongFiles
        static string wrongIndianStateCodeFilePath = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\IndianStateCode.txt";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\soham\source\repos\IndianStateCensusAnalyzer\CensualAnalyserTest\CsvFiles\IndiaStateCensusData.txt";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        //CensusDataCount
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        //CodeDataCount
        [Test]
        public void GivenIndianCodeFilePath_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        //WrongFilePath(Census)
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        //WrongFilePath(Code)
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenReaded_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
        //WrongFileType(Census)
        [Test]
        public void GivenWrongIndianStateCensusFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        //WrongFileType(Code)
    }
}