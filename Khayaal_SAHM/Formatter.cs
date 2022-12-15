﻿using System;
using System.Data;

namespace Khayaal_SAHM
{
    public class Formatter
    {
        /// <summary>
        /// to Put any text in Foramt "Mmmmmmm Ssssssss" and erased the first and last space if was existed
        /// </summary>
        /// <example> "  MMsassa ssaddedAS" => "Mmsassa Ssaddedas"</example>
        /// <example> "  MMsassa ssaddedAS" => "Mmsassa Ssaddedas"</example>
        /// <param name="String"></param>
        /// <returns></returns>
        public static string String(string String)
        {

            string[] Strings = String.Trim().Split(' ');
            for (int i = 0; i < Strings.Length; i++)
            {
                Strings[i] = char.ToUpper(Strings[i][0]) + Strings[i].ToLower().Remove(0, 1);

            }

            String = string.Join(" ", Strings);

            return String;
        }



        /// <summary>
        /// بيقرب اي سترينج من تنسيق الفلوت لأقرب رقمين عشريين
        /// </summary>
        /// <example>زي مثلا تيكست بوكس بياخد سعر او كمية فلازم يتقرب قبل ما تتبعت للداتا بيز</example>
        /// <param name="String">Float string Need TO BE ROUNDED </param>
        /// <returns>Sring</returns>
        public static string Float(string String)//not_Avtivated
        {

            return Math.Round(float.Parse(String), 2).ToString();
        }
        /// <summary>
        /// Correct The Date_Time_Picker Value Formating
        /// For Using it in a Sql Query
        /// </summary>
        /// <param name="Date">The Date_Time_Picker Value</param>
        /// <param name="Case">The Case Of Formatting</param>
        /// <returns>String</returns>
        public static string Date_Formating(DateTime Date, string Case)//activated
        {
            string Correct_Date;
            if (Case == "From_Payment")
                Correct_Date = $"{Date.Year}-{Date.Month}-{Date.Day} 00:00:00";
            else if (Case == "To_Payment")
                Correct_Date = $"{Date.Year}-{Date.Month}-{Date.Day} 23:59:59";
            else
                Correct_Date = $"{Date.Year}-{Date.Month}-{Date.Day} 23:59:59";
            return Correct_Date;
        }
        //Payment like (Bill,Best_Sales_Purchases)
        /// <summary>
        /// Used For (Validate The Date Range): Ensure That The Start Date is Before The End Date
        /// </summary>
        /// <param name="From">The Start of Range</param>
        /// <param name="To">The End of Range</param>
        /// <returns>Boolean</returns>
        public static bool Check_Payment_Date_Range(DateTime From, DateTime To) => DateTime.Parse(Date_Formating(From, "From_Payment")) < DateTime.Parse(Date_Formating(To, "To_Payment"));//activated
        /// <summary>
        /// Check there is no any intersections With Other Bookings Date Ranges
        /// </summary>
        /// <param name="Bookings">List of Booking of the same table</param>
        /// <returns>bool</returns>

        [Obsolete("Under_Development", true)]
        public bool Check_Bookings_Conflicts(DataTable Bookings)//not activated
        {

            foreach (DataRow row in Bookings.Rows)
            {
                if (true)
                {
                    return false;

                }
            }
            return true;
        }


    }



}
