using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericWebApp.UnitTest.Common
{
    public static class ClassExtension
    {
        public static void AssertErrorList(this AssertCollection assertCollection, string assertMessage, List<DTO.Common.Error> errorList)
        {
            if(errorList != null && errorList.Count > 0)
            {
                List<string> tempList = new List<string>();

                foreach (var error in errorList)
                {
                    tempList.Add($"Code: {error.Code}, Message: {error.Message}");
                }

                string errorMessages = String.Join(",", tempList);

                assertCollection.Assert(assertMessage,
                    () => Assert.NotEqual("", errorMessages));
            }
        }
    }
}
