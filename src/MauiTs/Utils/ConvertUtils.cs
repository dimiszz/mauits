using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTs.Utils;

public static class ConvertUtils
{
    public static long? TryToInt64(this object? obj)
    {
        if (obj is string str && string.IsNullOrEmpty(str)) return null;
        try
        {
            return Convert.ToInt64(obj);
        }
        catch 
        {
            return null;
        }
    }
}
