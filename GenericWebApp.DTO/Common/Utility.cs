using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Common
{
    public class ValuePair
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }

    public class Response<T>
    {
        public T Item { get; set; }
        public List<T> List { get; set; }
        public List<Common.Error> ErrorList { get; set; }
    }

    public class Error
    {
        public string Message { get; set; }
    }

    public class NavBarItem
    {
        public List<NavBarItem> ChildNavBarList { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public string Href { get; set; }
    }
}
