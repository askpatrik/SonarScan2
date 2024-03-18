/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__UInt16_rand_multiply_68a.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-68a.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: rand Set data to result of rand()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: multiply
 *    GoodSink: Ensure there will not be an overflow before multiplying data by 2
 *    BadSink : If data is positive, multiply by 2, which can cause an overflow
 * Flow Variant: 68 Data flow: data passed as a member variable in the "a" class, which is used by a method in another class in the same package
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__UInt16_rand_multiply_68a : AbstractTestCase
{

    public static ushort data;
#if (!OMITBAD)
    public override void Bad()
    {
        /* POTENTIAL FLAW: Use a random value */
        data = (ushort)(new Random().Next(ushort.MinValue, ushort.MaxValue));
        CWE190_Integer_Overflow__UInt16_rand_multiply_68b.BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        CWE190_Integer_Overflow__UInt16_rand_multiply_68b.GoodG2BSink();
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        /* POTENTIAL FLAW: Use a random value */
        data = (ushort)(new Random().Next(ushort.MinValue, ushort.MaxValue));
        CWE190_Integer_Overflow__UInt16_rand_multiply_68b.GoodB2GSink();
    }
#endif //omitgood
}
}
