public class Term : IComparable
{
    // Implement public read and write properties for each data member
    // The set property of exponent should raise an ArgumentOutOfRangeException
    // if value is less than 0 or greater than 20
    private double coefficient;
    public double Coefficent
    {
        get {return coefficient;}
        set
        { coefficient = value; }
    }

    private int exponent;
    public int Exponent
    {
        get {return exponent;}
        set
        {
            //Sets exponent between 0 and 20. The program throws if the exponent unfit the statement.
            if (value < 0 || value > 20)
            {
                throw new ArgumentOutOfRangeException("You need to use values between 0 and 20");
            }
            else {
                exponent = value;
            }
        }
    }

    // Constructor: Creates a term with the given coefficient and exponent
    public Term(double coefficent, int exponent)
    {
        Coefficent = coefficent;
        Exponent = exponent;       
    }

    //Evalutes the current term at x and returns the result
    public double Evaluate(double x)
    {
        // Example: if coefficient = 3, exponent = 4
        // given x = 4
        // return value
        return coefficient * Math.Pow(x, exponent);
    }

    // Returns -1, 0, or 1 if the exponent of the current term
    // is less than, equal to, or greater than the exponent of obj
    // Raises an ArgumentException if obj is either null or not a term
    public int CompareTo(Object obj)
    {
        if (obj == null || obj is not Term)  {
            throw new ArgumentException("An error occurs");
        }
        Term t = (Term)obj;
        if (Exponent < t.Exponent)
        {
            return -1;
        }
        if (Exponent > t.Exponent)
        {
            return 1;
        }
        return 0;
    }

    // Returns a string representation of the current term
    public override string ToString()
    {
        if (Coefficent == 0)
        {
            return "0";
        }
        if (Exponent == 0)
        {
            return Coefficent.ToString();
        }
        return Coefficent.ToString() + "x^" + Exponent.ToString();

    }
}