using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using log4net;

public static class Asserter
{
    static ILog log = LogManager.GetLogger("Asserter");

    public static void IsTrue(bool value, string message)
    {
        if (value)
        {
            return;
        }
        log.Error(message);
        if (Debugger.IsAttached)
        {
            throw new Exception(message);
        }
    }

    public static void VerifyContains(this List<string> existing, string expecting, string message)
    {
        IsTrue(existing.Any(x => x.ToLowerInvariant() == expecting.ToLowerInvariant()), message);
    }
}