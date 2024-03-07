using System;
using System.Collections.Generic;
using UnityEngine;

namespace Exercises
{
    public class Exercise4 : MonoBehaviour
    {
        /*
         * Exercise 4: Enums and Switch Statements
            Write a program that checks what month it is. Inside the console, what season that month usually falls
            in (for example, if the month is January, display the words “It is Summer.”).
            In South Africa, the seasons typically fall as follows:
            • Summer: December – February
            • Autumn: March – May
            • Winter: June – August
            • Spring: September – November
            Your program must work no matter which month is used as input.
         */

        [SerializeField]
        private Months month;

        [SerializeField]
        private bool useSelectedMonth;
        
        public enum Months
        {
            Jan, Feb, March, April, May, June, July, August, September, October, November, December
        }

        public enum Days
        {
            Monday, Tuesday, Wedensday
        }

        public enum Seasons
        {
            Summer,
            Autumn,
            Winter,
            Spring
        }

        public readonly Dictionary<Seasons, string> outputSeasons = new()
        {
            { Seasons.Summer, "It is Summer"},
            { Seasons.Autumn , "It is Autumn"},
            { Seasons.Winter , "It is Winter"},
            { Seasons.Spring , "It is Spring"}
        };

        
        private void Start()
        {
            for (int i = 0; i < 12; i++)
            {
                Months thisMonth = (Months)i;
                Debug.Log($"{i}. {thisMonth}");
            }
            
            Months selectedMonth = Months.Jan;
            if (useSelectedMonth)
            {
                selectedMonth = month;
            }
            else
            {
                var currentMonth = DateTime.Today.Month - 1;
                selectedMonth = (Months)currentMonth;
            }
            OutputSeasonByMonth(selectedMonth);
        }

        private void OutputSeasonByMonth(Months selectedMonth)
        {
            int numberRepresentation = (int)selectedMonth;
            if (selectedMonth == Months.Jan || selectedMonth == Months.December || selectedMonth == Months.Feb)
            {
                
            }

            int num = 2;
            switch (num)
            {
                case 10:
                    num += 22;
                    break;
            }


            switch (selectedMonth)
            {
                case Months.Jan:
                    break;
                case Months.Feb:
                    break;
                case Months.March:
                    break;
                case Months.April:
                    break;
                case Months.May:
                    break;
                case Months.June:
                    break;
                case Months.July:
                    break;
                case Months.August:
                    break;
                case Months.September:
                    break;
                case Months.October:
                    break;
                case Months.November:
                    break;
                case Months.December:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(selectedMonth), selectedMonth, null);
            }
            
            
            Debug.Log(selectedMonth);
        }
    }
}