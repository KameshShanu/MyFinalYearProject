using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailUtility.EmailHelpers
{
    public class RazorToHtmlConverter
    {
        public static string Convert(string razorSyntax, object dataModel)
        {
            if (String.IsNullOrWhiteSpace(razorSyntax))
            {
                throw new ArgumentNullException("razorSyntax");
            }
            return Razor.Parse(razorSyntax, dataModel);
        }
    }
}
