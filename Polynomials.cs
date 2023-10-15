class Polynomials
{
    //A collection of Polynomials
    private List<Polynomial> L;

    //Creates an empty list L of polynomials
    public Polynomials()
    {
        //Creating a new list of Polynomials:
        L = new List<Polynomial>();
    }

    // Retrieves the polynomial stored at position i in L
    public Polynomial Retrieve(int i)
    {
        if (i < 0 || i > this.Size() - 1)
        {
            throw new ArgumentOutOfRangeException("Size of L is " + this.Size() + ", unable to retriece at index " + "i");
        }
        return L[i];
    }

    // Inserts polynomial p into L
    public void Insert(Polynomial p)
    {
        L.Add(p);
    }

    // Deletes the polynomial at index i
    public void Delete(int i)
    {
        if (i<0 || i> this.Size() - 1)
        {
            throw new ArgumentOutOfRangeException("Size of L is " + this.Size() + ", unable to delete at index " + "i");
        }
        L.RemoveAt(i);
    }
    
    //Returns the number of polynomials in L
    public int Size()
    {
        return L.Count;
    }

    // Prints out the list of polynomials
    public void Print()
    {
        //foreach to print polynominals
        foreach (Polynomial p in L)
        {
            p.Print();
        }
    }
}
