using System;
using System.Collections.Generic;
using System.Text;

namespace FormatError
{
    public static class ErrorCode
    {
        public enum DataType
        {
            IsLetter,
            IsDigit,
            IsBool
        }
        public static bool FormatError(string inputData, DataType dataType)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(inputData))
            {
                if (dataType == DataType.IsLetter)
                    result = CheckIsLetter(inputData);
                else if (dataType == DataType.IsDigit)
                    result = CheckIsDigit(inputData);
                else if (dataType == DataType.IsBool)
                    result = CheckIsBool(inputData);

            }

            return result;
        }

        private static bool CheckIsBool(string inputData)
        {
            bool result = false;
            if (inputData.ToUpper().Equals("TRUE") ||
                inputData.ToUpper().Equals("FALSE")
                )
            {
                result = true;
            }
            return result;
        }

        private static bool CheckIsDigit(string inputData)
        {
            bool result = false;
            foreach (char item in inputData)
            {
                if (Char.IsDigit(item))
                    result = true;
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private static bool CheckIsLetter(string inputData)
        {
            bool result = false;
            foreach (char item in inputData)
            {
                if (Char.IsLetter(item))
                    result = true;
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool MissingValue(string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData))
                return false;
            else
                return true;
        }
    }
}
