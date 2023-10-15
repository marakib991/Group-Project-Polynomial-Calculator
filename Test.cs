class Test
{
    static public void Start()
    {
        Console.WriteLine("TESTING STARTED...");
        bool testTerm = true;
        bool testNode = true;
        bool testPolynomial = true;
        bool testPolynomials = true;

        if (testTerm) TermTest.Test();
        if (testNode) NodeTest.Test();
        if (testPolynomial) TestPolynomial.Test();
        if (testPolynomials) TestPolynomials.Test();
        Console.WriteLine("TESTING COMPLETED, ALL PASS");
    }
}