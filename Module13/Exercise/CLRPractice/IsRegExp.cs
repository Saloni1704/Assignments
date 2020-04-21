using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace CLRPractice
{
    public class RegexFunctions
    {
        public static SqlBoolean clrIsMatch(SqlString strInput, SqlString strPattern)
        {
            if (strPattern.IsNull || strInput.IsNull)
            {
                return SqlBoolean.False;
            }
            return (SqlBoolean)Regex.IsMatch(strInput.Value, strPattern.Value);
        }
    }
}
