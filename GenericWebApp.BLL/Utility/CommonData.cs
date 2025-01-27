using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Utility
{
    public static class CommonData
    {
        public static List<DTO.Common.NavBarItem> GetNavBarItemList()
        {
            List<DTO.Common.NavBarItem> myList =
            [
                new DTO.Common.NavBarItem()
                {
                    Description = "Home",
                    Class = "oi-home",
                    Href = "",
                    ChildNavBarList =
                    [
                        new DTO.Common.NavBarItem() { Description = "Music", Class = "oi-musical-note", Href = "music" }
                    ]
                },
                new DTO.Common.NavBarItem()
                {
                    Description = "Management",
                    Class = "oi-basket",
                    Href = "management",
                    ChildNavBarList =
                    [
                        new DTO.Common.NavBarItem() { Description = "CMS1500", Class = "oi-book", Href = "/management/cms1500list" },
                        new DTO.Common.NavBarItem() { Description = "Task", Class = "oi-task", Href = "/management/tasks" }
                    ]
                },
                new DTO.Common.NavBarItem() { Description = "NPI Registry", Class = "oi-list-rich", Href = "npi" },
            ];

            return myList;
        }

        public static List<DTO.Common.ValuePair> GetStateList()
        {
            List<DTO.Common.ValuePair> myList =
            [
                new DTO.Common.ValuePair() { Description = "Alabama", Value = "AL" },
                new DTO.Common.ValuePair() { Description = "Alaska", Value = "AK" },
                new DTO.Common.ValuePair() { Description = "Arizona", Value = "AZ" },
                new DTO.Common.ValuePair() { Description = "Arkansas", Value = "AR" },
                new DTO.Common.ValuePair() { Description = "California", Value = "CA" },
                new DTO.Common.ValuePair() { Description = "Colorado", Value = "CO" },
                new DTO.Common.ValuePair() { Description = "Connecticut", Value = "CT" },
                new DTO.Common.ValuePair() { Description = "Delaware", Value = "DE" },
                new DTO.Common.ValuePair() { Description = "District of Columbia", Value = "DC" },
                new DTO.Common.ValuePair() { Description = "Florida", Value = "FL" },
                new DTO.Common.ValuePair() { Description = "Georgia", Value = "GA" },
                new DTO.Common.ValuePair() { Description = "Hawaii", Value = "HI" },
                new DTO.Common.ValuePair() { Description = "Idaho", Value = "ID" },
                new DTO.Common.ValuePair() { Description = "Illinois", Value = "IL" },
                new DTO.Common.ValuePair() { Description = "Indiana", Value = "IN" },
                new DTO.Common.ValuePair() { Description = "Iowa", Value = "IA" },
                new DTO.Common.ValuePair() { Description = "Kansas", Value = "KS" },
                new DTO.Common.ValuePair() { Description = "Kentucky", Value = "KY" },
                new DTO.Common.ValuePair() { Description = "Louisiana", Value = "LA" },
                new DTO.Common.ValuePair() { Description = "Maine", Value = "ME" },
                new DTO.Common.ValuePair() { Description = "Montana", Value = "MT" },
                new DTO.Common.ValuePair() { Description = "Nebraska", Value = "NE" },
                new DTO.Common.ValuePair() { Description = "Nevada", Value = "NV" },
                new DTO.Common.ValuePair() { Description = "New Hampshire", Value = "NH" },
                new DTO.Common.ValuePair() { Description = "New Jersey", Value = "NJ" },
                new DTO.Common.ValuePair() { Description = "New Mexico", Value = "NM" },
                new DTO.Common.ValuePair() { Description = "New York", Value = "NY" },
                new DTO.Common.ValuePair() { Description = "North Carolina", Value = "NC" },
                new DTO.Common.ValuePair() { Description = "North Dakota", Value = "ND" },
                new DTO.Common.ValuePair() { Description = "Ohio", Value = "OH" },
                new DTO.Common.ValuePair() { Description = "Oklahoma", Value = "OK" },
                new DTO.Common.ValuePair() { Description = "Oregon", Value = "OR" },
                new DTO.Common.ValuePair() { Description = "Maryland", Value = "MD" },
                new DTO.Common.ValuePair() { Description = "Massachusetts", Value = "MA" },
                new DTO.Common.ValuePair() { Description = "Michigan", Value = "MI" },
                new DTO.Common.ValuePair() { Description = "Minnesota", Value = "MN" },
                new DTO.Common.ValuePair() { Description = "Mississippi", Value = "MS" },
                new DTO.Common.ValuePair() { Description = "Missouri", Value = "MO" },
                new DTO.Common.ValuePair() { Description = "Pennsylvania", Value = "PA" },
                new DTO.Common.ValuePair() { Description = "Rhode Island", Value = "RI" },
                new DTO.Common.ValuePair() { Description = "South Carolina", Value = "SC" },
                new DTO.Common.ValuePair() { Description = "South Dakota", Value = "SD" },
                new DTO.Common.ValuePair() { Description = "Tennessee", Value = "TN" },
                new DTO.Common.ValuePair() { Description = "Texas", Value = "TX" },
                new DTO.Common.ValuePair() { Description = "Utah", Value = "UT" },
                new DTO.Common.ValuePair() { Description = "Vermont", Value = "VT" },
                new DTO.Common.ValuePair() { Description = "Virginia", Value = "VA" },
                new DTO.Common.ValuePair() { Description = "Washington", Value = "WA" },
                new DTO.Common.ValuePair() { Description = "West Virginia", Value = "WV" },
                new DTO.Common.ValuePair() { Description = "Wisconsin", Value = "WI" },
                new DTO.Common.ValuePair() { Description = "Wyoming", Value = "WY" },
            ];

            return myList;
        }
    }
}
