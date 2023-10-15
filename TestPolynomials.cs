public class TestPolynomials
{
    public static void Test() 
    {
        Console.WriteLine("TESTING POLYNOMIALS...");
        bool testConstructor = true;
        bool testMethods = true;
        if (testConstructor) TestConstructor();
        if (testMethods) TestMethods();
        Console.WriteLine("TESTING POLYNOMIALS COMPLETED\n\n");
    }

    public static void TestConstructor()
    {
        Console.WriteLine("TESTING Polynomials constructor, size should be 0");
        Polynomials p = new Polynomials();
        if (p.Size() != 0)
        {
            throw new Exception("ERROR: evaluation of 0 polynomial != 0");
        }
        Console.WriteLine("Polynomials constructor PASSED\n");
    }

    public static void TestMethods()
    {
        Console.WriteLine("TESTING Polynomials Insert/Retrieve/Delete/Size function...");
        Polynomials p = new Polynomials();
        Polynomial polynomial = new Polynomial();
        Polynomial polynomial2 = new Polynomial();
        polynomial.AddTerm(new Term(1, 3));
        polynomial.AddTerm(new Term(10, 12));
        p.Insert(polynomial);
        p.Insert(polynomial2);
        Console.WriteLine("Case 1: Insert two polynomial and check is the index correct and can be retrieved by index");
        if (p.Retrieve(0) != polynomial || p.Retrieve(1) != polynomial2)
        {
            throw new Exception("ERROR: Insert/Retrieve error, retrieve is not what inserted");
        }
        if (p.Size() != 2)
        {
            throw new Exception("ERROR: Insert error, size is not 2 after inserting");
        }
        Console.WriteLine("Case 1 PASSED");

        Console.WriteLine("Case 2: Delete by index 1");
        p.Delete(1);
        if (p.Retrieve(0) != polynomial)
        {
            throw new Exception("ERROR: Delete/Retrieve error, deleted what is not supposed to be deleted");
        }
        if (p.Size() != 1)
        {
            throw new Exception("ERROR: Delete error, size is not 1 after deleting");
        }
        Console.WriteLine("Case 2 PASSED");

        Console.WriteLine("Case 3: Retrieve/Delete non-exist index should throw exception");
        try
        {
            p.Delete(44);
            throw new Exception("Case 3 ERROR: ArgumentOutOfRangeExcpetion not thrown when attempted to delete index at 44 which is not exist");
        } catch(ArgumentOutOfRangeException e)
        {
            Console.WriteLine("ArgumentOutOfRangeExcpetion thrown when attempted to delete index at 44 which is not exist");
        }
        try
        {
            p.Retrieve(44);
            throw new Exception("Case 3 ERROR: ArgumentOutOfRangeExcpetion not thrown when attempted to retrieve index at 44 which is not exist");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("ArgumentOutOfRangeExcpetion thrown when attempted to retrieve index at 44 which is not exist");
        }
        Console.WriteLine("Case 3 PASSED");

        Console.WriteLine("Polynomials Insert/Retrieve/Delete/Size function PASSED\n");
    }
}