using DragoAdminWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Provider
{
    public class AppProvider
    {
        public static List<string> EnableStates = new List<string>() {
            "Enabled"
            ,"Disabled"
        };

        public static List<string> Months = new List<string>()
        {
            "January"
            ,"February"
            ,"March"
            ,"April"
            ,"May"
            ,"June"
            ,"July"
            ,"August"
            ,"September"
            ,"October"
            ,"November"
            ,"December"
        };

        public static List<string> UTCs = new List<string>()
        {
            "-12"
            ,"-11"
            ,"-10"
            ,"-9"
            ,"-8"
            ,"-7"
            ,"-6"
            ,"-5"
            ,"-4"
            ,"-3"
            ,"-2"
            ,"-1"
            ,"+0"
            ,"+1"
            ,"+2"
            ,"+3"
            ,"+4"
            ,"+5"
            ,"+6"
            ,"+7"
            ,"+8"
            ,"+9"
            ,"+10"
            ,"+11"
            ,"+12"
        };

        public static List<string> NumericDays = new List<string>()
        {
            "1"
            ,"2"
            ,"3"
            ,"4"
            ,"5"
            ,"6"
            ,"7"
            ,"8"
            ,"9"
            ,"10"
            ,"11"
            ,"12"
            ,"13"
            ,"14"
            ,"15"
            ,"16"
            ,"17"
            ,"18"
            ,"19"
            ,"20"
            ,"21"
            ,"22"
            ,"33"
            ,"24"
            ,"25"
            ,"26"
            ,"27"
            ,"28"
            ,"29"
            ,"30"
            ,"31"
        };

        public static List<string> WordDays = new List<string>()
        {
            "Sunday"
            ,"Monday"
            ,"Tuesday"
            ,"Wednesday"
            ,"Thursday"
            ,"Friday"
            ,"Saturday"
        };

        public static List<string> AlarmTypes = new List<string>()
        {
            "Not Alarm"
            ,"Once"
            ,"Periodic"
            ,"Hourly"
            ,"Daily"
            ,"Weekly"
            ,"Monthly"
            ,"Yearly"
            ,"Times In Hour"
        };

        public static List<int> HourNumeric = Enumerable.Range(0, 24).ToList();

        public static List<string> HourString()
        {
            List<string> hourString = new List<string>();
            foreach(var number in HourNumeric)
            {
                hourString.Add(number.ToString("00"));
            }
            return hourString;
        }

        public static List<int> MinuteNumeric = Enumerable.Range(0, 60).ToList();

        public static List<string> MinuteString()
        {
            List<string> minuteString = new List<string>();
            foreach (var number in MinuteNumeric)
            {
                minuteString.Add(number.ToString("00"));
            }
            return minuteString;
        }

        public static List<int> SecondNumeric = Enumerable.Range(0, 60).ToList();

        public static List<string> SecondString()
        {
            List<string> secondString = new List<string>();
            foreach (var number in SecondNumeric)
            {
                secondString.Add(number.ToString("00"));
            }
            return secondString;
        }
    }
}
