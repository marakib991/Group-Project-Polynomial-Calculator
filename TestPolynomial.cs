public class TestPolynomial
{
    public static void Test() 
    {
        //Polynominal test1 = new Polynominal();
        bool testConstructor = true;
        bool testAddTerm = true;
        bool testPlusOperator = true;
        bool testMultiplyOperator = true;
        bool testEvaluate = true;
        bool testClone = true;
        Console.WriteLine("TESTING POLYNOMIAL...");

        if (testConstructor) TestConstructor();
        if (testAddTerm) TestAddTerm();
        if (testPlusOperator) TestPlusOperator();
        if (testMultiplyOperator) TestMultiplyOperator();
        if (testEvaluate) TestEvaluate();
        if (testClone) TestClone();
        Console.WriteLine("TESTING POLYNOMIAL COMPLETED\n\n");
    }

    public static void TestConstructor()
    {
        Console.WriteLine("TESTING Polynomial constructor for zero polynomial with evaluate...");
        Polynomial p = new Polynomial();
        if (p.Evaluate(9) != 0 || p.Evaluate(7) != 0)
        {
            throw new Exception("ERROR: evaluation of 0 polynomial != 0");
        }
        Console.WriteLine("Polynomial constructor for zero polynomial with evaluate PASSED\n");
    }

    public static void TestAddTerm()
    {
        Console.WriteLine("TESTING AddTerm with evaluate (will throw exception in logic if polynomial is not in proper order)...");
        //Case 1: Adding 2 and 4x^2
        Polynomial polynominal = new Polynomial();
        Term term1 = new Term(2, 0);
        Term term2 = new Term(4, 2);
        Term term3 = new Term(-4, 2);
        Console.WriteLine("Case 1: Add Term(2,0) into the polynomaial and evalute by x = 2, answer should be 2");
        polynominal.AddTerm(term1);
        if (polynominal.Evaluate(2) != 2)
        {
            throw new Exception("Case 1 ERROR: evaluate didn't return 2");
        }
        Console.WriteLine("Case 1 PASSED");

        Console.WriteLine("Case 2: Add Term(4,2) into the polynomaial and evalute by x = 2, answer should be 18");
        polynominal.AddTerm(term2);
        if (polynominal.Evaluate(2) != 18)
        {
            throw new Exception("Case 2 ERROR: evaluate didn't return 18");
        }
        Console.WriteLine("Case 2 PASSED");

        Console.WriteLine("Case 3: Add Term(-4,2) into the polynomaial and evalute by x = 2, answer should be 2 since term(4,2) and term(-4,2) will cancel out");
        polynominal.AddTerm(term3);
        if (polynominal.Evaluate(2) != 2)
        {
            throw new Exception("Case 3 ERROR: evaluate didn't return 2");
        }
        Console.WriteLine("Case 3 PASSED");

        Console.WriteLine("Add term function PASSED\n");
    }

    public static void TestPlusOperator()
    {
        Console.WriteLine("TESTING + operator and test with evaluate...");
        Console.WriteLine("Case 1: Add two polynomials p, q and yield RESULT, check whether RESULT.Evaluate(x) == (p.Evaluate(x) + q.Evalute(x))");
        Polynomial p = new Polynomial();
        Polynomial q = new Polynomial();
        int x = 5;
        p.AddTerm(new Term(2, 1));
        p.AddTerm(new Term(3, 2));
        q.AddTerm(new Term(4, 2));
        q.AddTerm(new Term(5, 6));
        Polynomial result = p + q;
        double pValue = p.Evaluate(x);
        double qValue = q.Evaluate(x);
        double resultValue = result.Evaluate(x);
        double t = pValue + qValue;
        if (resultValue.ToString() != (t).ToString())
        {
            throw new Exception("ERROR: RESULT.Evaluate(x) != (p.Evaluate(x) + q.Evalute(x))");
        }
        Console.WriteLine("Case 1 PASSED");
        Console.WriteLine("+ operator PASSED\n");

    }

    public static void TestMultiplyOperator()
    {
        Console.WriteLine("TESTING + operator...");
        Console.WriteLine("Case 1: multiply two polynomials p, q and yield RESULT, check whether RESULT.Evaluate(x) == (p.Evaluate(x) * q.Evalute(x))");
        Polynomial p = new Polynomial();
        Polynomial q = new Polynomial();
        int x = 5;
        p.AddTerm(new Term(2, 1));
        p.AddTerm(new Term(3, 2));
        q.AddTerm(new Term(4, 2));
        q.AddTerm(new Term(5, 6));
        Polynomial result = p * q;
        double pValue = p.Evaluate(x);
        double qValue = q.Evaluate(x);
        double resultValue = result.Evaluate(x);
        if (resultValue != pValue * qValue)
        {
            throw new Exception("ERROR: RESULT.Evaluate(x) != (p.Evaluate(x) * q.Evalute(x))");
        }
        Console.WriteLine("Case 1 PASSED");
        Console.WriteLine("* operator PASSED\n");
    }

    public static void TestEvaluate()
    {
        Console.WriteLine("TESTING Polynomial Evaluate function...");
        Console.WriteLine("Case 1: test evaluare with polynomial 3x^2 + 2x^2 with x = 5, answer should be equal to 2*5 + 3*(5^2)");
        Polynomial p = new Polynomial();
        int x = 5;
        p.AddTerm(new Term(2, 1));
        p.AddTerm(new Term(3, 2));
        
        double pValue = p.Evaluate(x);
        if (pValue != (2*x + 3*(Math.Pow(x,2))))
        {
            throw new Exception("Incorrect Evaluate function");
        }

        Console.WriteLine("Case 1 PASSED");

        Console.WriteLine("Polynomial Evaluate function PASSED\n");
    }

    public static void TestClone()
    {
        Console.WriteLine("TESTING Polynomial Clone function...");
        Console.WriteLine("Case 1: clone of polynomial 4x^3 + 3x^2 + 2x should be the same as 2x^3 + 3x^2 + 4x");
        Polynomial p = new Polynomial();
        Polynomial q = new Polynomial();
        int x = 5;
        p.AddTerm(new Term(2, 1));
        p.AddTerm(new Term(3, 2));
        p.AddTerm(new Term(4, 3));
        q.AddTerm(new Term(4, 1));
        q.AddTerm(new Term(3, 2));
        q.AddTerm(new Term(2, 3));

        Polynomial cloneP = (Polynomial) p.Clone();
        if (cloneP.Evaluate(x) != q.Evaluate(x))
        {
            throw new Exception("ERROR: Clone function");
        }
        Console.WriteLine("Case 1 PASSED");
        Console.WriteLine("Polynomial CLONE function PASSED\n");
    }
}