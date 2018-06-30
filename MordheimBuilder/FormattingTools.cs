﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder
{
    internal static class FormattingTools
    {
        public static string SplitCamelCasing(this string stringValue)
        {
            string formattedText = String.Empty;
            bool firstValue = true;

            foreach (char item in stringValue)
            {
                if (item >= 'A' && item <= 'Z' && firstValue == false)
                {
                    formattedText += $" {item}";
                }
                else
                {
                    formattedText += item;
                }
                firstValue = false;
            }

            return formattedText;
        }
    }
}