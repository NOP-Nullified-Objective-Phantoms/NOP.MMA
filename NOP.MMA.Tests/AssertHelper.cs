using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA
{
    internal static class AssertHelper
    {
        public static string ValidatorMessage (string _message,object _value, object _result, object _expected )
        {
            return $"{_message} {_value} {{Value: {_result} | Expected: {_expected}}}";
        }
    }
}
