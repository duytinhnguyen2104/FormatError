using System;
using System.Collections.Generic;

namespace FormatError
{
    public class Program
    {
        // List Check Format Error
        private static List<string> listIsLetter = new List<string>
        {
            "Branch",
            "BU",
            "Incotern",
            "Party Name",
            "Orgin Departure",
            "Departure Location",
            "Arrival Location",
            "Final Discharge",
            "Final Distination"
        };
        private static List<string> listIsDigit = new List<string>
        {
            "Tariff No",
            "Party Code",
        };
        private static List<string> listIsBool = new List<string>
        {
            "Dangerous"
        };
        // List Check Error Code
        private static List<string> listAllowCheckFormatError = new List<string>
        {
            "Tariff No",
            "Branch",
            "BU",
            "Incotern",
            "Party Code",
            "Party Name",
            "Dangerous",
            "Orgin Departure",
            "Departure Location",
            "Arrival Location",
            "Final Discharge",
            "Final Distination"
        };
        private static List<string> listAllowCheckUnknowData = new List<string>
        {
            "Tariff",
            "Branch",
            "BU",
            "Incotern",
            "Party Code",
            "Orgin Departure",
            "Departure Location",
            "Arrival Location",
            "Final Discharge",
            "Final Distination"
        };
        private static List<string> listAllowCheckMissingValue = new List<string>
        {
            "Brach",
            "BU",
        };
        private static List<string> listAllowDuplication = new List<string>()
        { };
        private static List<string> listAllowUnknowData = new List<string>()
        { };
        private static List<string> listInconsistency = new List<string>() { };
        // Data Test
        private static List<string> listTariff = new List<string>();
        private static List<string> listBranch = new List<string>();
        private static List<string> list3rdParty = new List<string>();
        // INPUT DATA
        private static Dictionary<string, List<string>> dicDatas = new Dictionary<string, List<string>>();
        static void Main(string[] args)
        {
            string formatErrorResult = string.Empty;
            string missingValueResult = string.Empty;
            string result = string.Empty; 
            // -- Init Data Test ---
            InitializeData();
            // ---------------------
            foreach(var key in dicDatas.Keys)
            {
                if (listAllowCheckFormatError.Contains(key))
                {
                    formatErrorResult = FormatError(dicDatas[key], key);
                }

                if (listAllowCheckMissingValue.Contains(key))
                {
                    missingValueResult = MissingValue(dicDatas[key], key);
                }
                result = formatErrorResult + missingValueResult;
                Console.WriteLine(result);
            }
        }
        private static string MissingValue(List<string> listData, string headerName)
        {
            string result = string.Empty;
            int index = 0;
            foreach (var value in listData)
            {
                if (!ErrorCode.MissingValue(value))
                    result += string.Format("- Line [{0}] Cells [{1}]", (index + 1).ToString(), headerName) + Environment.NewLine;
            }

            return result;
        }
        private static string FormatError(List<string> listData, string headerName)
        {
            string result = string.Empty;
            int index = 0;
            foreach(var value in listData)
            {
                if (listIsLetter.Contains(headerName))
                {
                    if (!ErrorCode.FormatError(value, dataType: ErrorCode.DataType.IsLetter))
                    {
                        result += string.Format("- Line [{0}] Cells [{1}]", (index + 1).ToString(), headerName) + Environment.NewLine; 
                    };
                }
                else if (listIsDigit.Contains(headerName))
                {
                    if (!ErrorCode.FormatError(value, dataType: ErrorCode.DataType.IsDigit))
                    {
                        result += string.Format("- Line [{0}] Cells [{1}]", (index + 1).ToString(), headerName) + Environment.NewLine;
                    };
                }
                else if (listIsBool.Contains(headerName))
                {
                    if (!ErrorCode.FormatError(value, dataType: ErrorCode.DataType.IsBool))
                    {
                        result += string.Format("- Line [{0}] Cells [{1}]", (index + 1).ToString(), headerName) + Environment.NewLine;
                    };
                }
                index++;
            }
            return result;
           

        }
        // Init Data
        private static void InitializeData()
        {
            InitTariff();
            InitBranch();
            Init3rdParty();
           
        }
        private static void Init3rdParty()
        {
            list3rdParty.Add("902233");
            list3rdParty.Add("902233");
            list3rdParty.Add("902233");
            list3rdParty.Add("90223A"); // Format Error
            dicDatas.Add("Party Code", list3rdParty);

        }
        private static void InitBranch()
        {
            listBranch.Add("CAY3L"); // Format Error
            listBranch.Add("CMBOG");
            listBranch.Add("TRI^T"); // Format Error
            listBranch.Add(string.Empty); // Missing Value
            dicDatas.Add("Branch", listBranch);

        }
        private static void InitTariff()
        {
            listTariff.Add("28375");
            listTariff.Add("28375");
            listTariff.Add("2883w"); // Format Error
            listTariff.Add("28836");
            dicDatas.Add("Tariff No", listTariff);

        }
    }
       
}
