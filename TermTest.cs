class TermTest
{
    public static void Test()
    {
        bool testConstructor = true;
        bool testEvaluate = true;
        bool testCompareTo = true;
        if (testConstructor) TestConstructor();
        if (testEvaluate) TestEvaluate();
        if (testCompareTo) TestCompareTo();
        Console.WriteLine("TESTING TERM COMPLETED\n\n");

    }

    public static void TestConstructor()
    {
        Console.WriteLine("TESTING Term constructor, get/set and ToString()...");

        //Case 1: test for constructor, get/set and ToString(), with double coefficient and int exponent
        Console.WriteLine("Case 1: test for constructor, get/set and ToString(), with double coefficient and int exponent");
        Term term1 = new Term(1.7, 2);
        if (term1.ToString() != "1.7x^2") throw new Exception($"Case 1 ERROR: Term toString incorrect, {term1.ToString()} != 1.7x^2");
        Console.WriteLine("Case 1 PASSED");


        //Case 2: test for constructor, get/set and ToString(), with int coefficient and int exponent
        Console.WriteLine("Case 2: test for constructor, get/set and ToString(), with int coefficient and int exponent");
        Term term2 = new Term(2, 5);
        if (term2.ToString() != "2x^5") throw new Exception($"Case 2 ERROR: Term toString incorrect, {term2.ToString()} != 2x^5");
        Console.WriteLine("Case 2 PASSED");

        //Case 3: test for constuctor, get/set with exponent > 20, ArgumentException should be thrown
        Console.WriteLine("Case 3: test for constuctor, get/set with exponent > 20, ArgumentException should be thrown");
        try
        {
            Term term3 = new Term(2.5, 21);
            throw new Exception("Case 3 ERROR: ArgumentException hasn't been thrown when exponent > 20");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Case 3 PASSED");
        }

        //Case 4: test for constuctor, get/set with exponent < 0, ArgumentException should be thrown
        Console.WriteLine("Case 4: test for constuctor, get/set with exponent < 0, ArgumentException should be thrown");
        try
        {
            Term term4 = new Term(5.4, -5);
            throw new Exception("Case 4 ERROR: ArgumentException hasn't been thrown when exponent < 0");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Case 4 PASSED");
        }
        Console.WriteLine("Term constructor, get/set and ToString() PASSED\n");
    }

    public static void TestEvaluate()
    {
        Console.WriteLine("TESTING Term evaluate function...");

        //Case 1: test evaluare with coefficient = 1.7 and exponent = 5, answer should be 1.7x^5
        Console.WriteLine("Case 1: test evaluare with x = 5, coefficient = 1.7 and exponent = 5, answer should be equal to 1.7(5^5)");
        Term term1 = new Term(1.7, 5);
        double term1Value = term1.Evaluate(5);
        if (term1Value != 1.7 * Math.Pow(5, 5))
        {
            throw new Exception("Incorrect Evaluate function");
        }

        Console.WriteLine("Case 1: Evaluate function PASSED");


        Console.WriteLine("Term evaluate function PASSED\n");
    }

    public static void TestCompareTo()
    {
        //Case 1: should return -1 when current term with exponent 5 compare to term with exponent 6
        Console.WriteLine("TESTING Term CompareTo function...");
        Console.WriteLine("Case 1: should return -1 when current term with exponent 5 compare to term with exponent 6");
        Term term1 = new Term(6, 5);
        Term term2 = new Term(5.5, 6);
        if (term1.CompareTo(term2) != -1)
        {
            throw new Exception("CASE 1 ERROR: return value != 1");

        }
        Console.WriteLine("Case 1 PASSED ");

        //Case 2: should return 0 when current term with exponent 5 compare to term with exponent 5
        Console.WriteLine("Case 2: should return 0 when current term with exponent 5 compare to term with exponent 5");
        Term term3 = new Term(64, 5);
        if (term1.CompareTo(term3) != 0)
        {
            throw new Exception("CASE 2 ERROR: return value != 0");

        }
        Console.WriteLine("Case 2 PASSED ");

        //Case 3: should return 1 when current term with exponent 5 compare to term with exponent 4
        Console.WriteLine("Case 3: should return 1 when current term with exponent 5 compare to term with exponent 4");
        Term term4 = new Term(64, 4);
        if (term1.CompareTo(term4) != 1)
        {
            throw new Exception("CASE 3 ERROR: return value != 1");

        }
        Console.WriteLine("Case 3 PASSED ");

        //Case 4: should raises an ArgumentException if obj is null
        Console.WriteLine("Case 4: should raises an ArgumentException if obj is null");
        try
        {
            term1.CompareTo(null);
            throw new Exception("CASE 4 ERROR: Did not throw ArgumentException when object is null");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("CASE 4 PASSED");
        }

        //Case 5: should raises an ArgumentException if obj is not a term
        Console.WriteLine("Case 5: should raises an ArgumentException if obj is not a term");
        String a = new String("DD");
        try
        {
            term1.CompareTo(a);
            throw new Exception("CASE 5 ERROR: Did not throw ArgumentException when object is not a term");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("CASE 5 PASSED");
        }

        Console.WriteLine("CompareTo function PASSED\n");
    }
}