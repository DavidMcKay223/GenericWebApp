using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericWebApp.UnitTest.Common
{
    public class AssertCollection
    {
        private readonly List<(string Description, Exception Exception)> _exceptions = new List<(string, Exception)>();
        private readonly string _description;

        public AssertCollection(string description = null)
        {
            _description = description;
        }

        public void Assert(Action assert)
        {
            try
            {
                assert();
            }
            catch (Exception ex)
            {
                _exceptions.Add(("", ex));
            }
        }

        public void Assert(string description, Action assert)
        {
            try
            {
                assert();
            }
            catch (Exception ex)
            {
                _exceptions.Add((description, ex));
            }
        }

        public void Verify()
        {
            if (_exceptions.Count > 0)
            {
                var message = "Multiple assertion failures:\n";
                message += string.Join("\n", _exceptions.Select((ex, index) => $"\tAssertion {index + 1}: {ex.Description} - {ex.Exception.Message}"));
                throw new Exception(message);
            }
        }
    }
}
