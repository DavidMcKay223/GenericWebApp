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
            List<DTO.Common.NavBarItem> myList = new List<DTO.Common.NavBarItem>();

            myList.Add(new DTO.Common.NavBarItem()
            {
                Description = "Home",
                Class = "oi-home",
                Href = "",
                ChildNavBarList = new List<DTO.Common.NavBarItem>()
                {
                    new DTO.Common.NavBarItem() { Description = "Music", Class = "oi-musical-note", Href = "music" }
                }
            });

            myList.Add(new DTO.Common.NavBarItem() { Description = "NPI Registry", Class = "oi-list-rich", Href = "npi" });

            return myList;
        }

        public static List<DTO.Common.ValuePair> GetStateList()
        {
            List<DTO.Common.ValuePair> myList = new List<DTO.Common.ValuePair>();

            myList.Add(new DTO.Common.ValuePair() { Description = "Alabama", Value = "AL" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Alaska", Value = "AK" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Arizona", Value = "AZ" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Arkansas", Value = "AR" });
            myList.Add(new DTO.Common.ValuePair() { Description = "California", Value = "CA" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Colorado", Value = "CO" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Connecticut", Value = "CT" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Delaware", Value = "DE" });
            myList.Add(new DTO.Common.ValuePair() { Description = "District of Columbia", Value = "DC" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Florida", Value = "FL" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Georgia", Value = "GA" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Hawaii", Value = "HI" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Idaho", Value = "ID" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Illinois", Value = "IL" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Indiana", Value = "IN" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Iowa", Value = "IA" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Kansas", Value = "KS" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Kentucky", Value = "KY" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Louisiana", Value = "LA" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Maine", Value = "ME" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Montana", Value = "MT" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Nebraska", Value = "NE" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Nevada", Value = "NV" });
            myList.Add(new DTO.Common.ValuePair() { Description = "New Hampshire", Value = "NH" });
            myList.Add(new DTO.Common.ValuePair() { Description = "New Jersey", Value = "NJ" });
            myList.Add(new DTO.Common.ValuePair() { Description = "New Mexico", Value = "NM" });
            myList.Add(new DTO.Common.ValuePair() { Description = "New York", Value = "NY" });
            myList.Add(new DTO.Common.ValuePair() { Description = "North Carolina", Value = "NC" });
            myList.Add(new DTO.Common.ValuePair() { Description = "North Dakota", Value = "ND" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Ohio", Value = "OH" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Oklahoma", Value = "OK" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Oregon", Value = "OR" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Maryland", Value = "MD" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Massachusetts", Value = "MA" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Michigan", Value = "MI" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Minnesota", Value = "MN" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Mississippi", Value = "MS" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Missouri", Value = "MO" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Pennsylvania", Value = "PA" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Rhode Island", Value = "RI" });
            myList.Add(new DTO.Common.ValuePair() { Description = "South Carolina", Value = "SC" });
            myList.Add(new DTO.Common.ValuePair() { Description = "South Dakota", Value = "SD" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Tennessee", Value = "TN" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Texas", Value = "TX" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Utah", Value = "UT" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Vermont", Value = "VT" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Virginia", Value = "VA" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Washington", Value = "WA" });
            myList.Add(new DTO.Common.ValuePair() { Description = "West Virginia", Value = "WV" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Wisconsin", Value = "WI" });
            myList.Add(new DTO.Common.ValuePair() { Description = "Wyoming", Value = "WY" });

            return myList;
        }
    }
}
