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
            var errorMessages = string.Join(", ", errorList.Select(e => $"\n\t\tCode: {e.Code}, \n\t\tDescription: {e.Message}"));
            assertCollection.Assert(assertMessage,
                () => Assert.False(errorList.Any(),
                $"Errors: {errorMessages}"));
        }
    }
}
