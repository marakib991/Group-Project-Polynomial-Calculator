public class Polynomial
{
    // A reference to the first node of a singly linked list
    private Node<Term> front;

    //creates the zero polynomial, i.e. 0
    public Polynomial()
    {
        Term n1 = new Term(0, 0);
        front = new Node<Term>(n1, null);
    }

    /* The implument as class n1 as conefficent and exponent as 0, ignoring x
     * The polynominal sets as " 0x ^ 0) " when the class has no input values.
     * - Returns the settled polynomial from Term n1.
     */

    /* ** AddTerm(Term T) Method **:
    * Inserts term t into the current polynomial in its proper order
    * If a term with the same exponent already exists then the two terms are added together
    * If the two terms cancel out then no new term is created
    */

    // will throw exception if front is not in proper order
    public void AddTerm(Term T)
    {
        // front = 4x^2 + 2
        // T = 3x
        // expected: 4x^2 + 3x + 2
        // now: 3x + 4x^2 + 2
        // T = 3x
        // expected: 4x^2 + 6x + 2
        // now: 3x + 3x + 4x^2 + 2
        Term mockT = new Term(T.Coefficent, T.Exponent);
        
        Node<Term> dump = new Node<Term>(new Term(0, 0), front);
        Node<Term> dummy = dump;
        while (dump.Next != null)
        {
            if (dump.Next.Item.Exponent == mockT.Exponent)
            {
                dump.Next.Item.Coefficent += mockT.Coefficent;
                return;
            } else if (dump.Next.Item.Exponent < mockT.Exponent)
            {
                Node<Term> dump2 = new Node<Term>(mockT, dump.Next);
                dump.Next = dump2;
                front = dummy.Next;
                return;
            }
            dump = dump.Next;
        }
        dump.Next = new Node<Term>(mockT, null);
        front = dummy.Next;

        Node<Term> dummy2 = front;
        int exponent = dummy2.Item.Exponent;
        while (dummy2.Next != null)
        {
            dummy = dummy.Next;
            if (exponent < dummy2.Item.Exponent)
            {
                throw new Exception("Polynomical is not in proper order");
            }
            exponent = dummy2.Item.Exponent;
        }
    }

    // Adds polynomials p and q to yield a new polynomial (Do 1st)
    public static Polynomial operator +(Polynomial p, Polynomial q)
    {
        //How to operate:
        /*
         * To make new variables for adding polynomial p and q
         * Using if-else to add those polynomials
         */

        // 4x + 6x -> 10x
        // 4x + 6x^2 -> 6x^2 + 4x
        // 6x^2 + 4x -> 6x^2 + 4x

        // 3x^5 + 4x
        // 8x^2 + 3x
        Polynomial polynomial = new Polynomial();
        Node<Term> tempP = p.front;
        Node<Term> tempQ = q.front;
        while (tempP != null)
        {
            polynomial.AddTerm(tempP.Item);
            tempP = tempP.Next;
        }
        while (tempQ != null)
        {
            polynomial.AddTerm(tempQ.Item);
            tempQ = tempQ.Next;
        }
            
        return polynomial;
    }

    // Multiplies polynomials p and q to yield a new polynomial (Do 1st)
    
    //How to operate:
    /*
     * Make new polynomial 
     */
    public static Polynomial operator *(Polynomial p, Polynomial q)
    {
        //Creating Sol as returning Node.

        // 4x
        // 3x^5 + 4x + 3
        // 8x^2 + 3x
        // (3x^5 + 4x) * (8x^2 + 3x) = ? --> ? = 24x^7 + (32x^3 + 9x^6) + 12x^2
        // (3x^5 + 4x) * (8x^2 + 3x) --> 24x^7 + 9x^6 + 32x^3 + 12x^2
        // (3x^5 + 4x + 4) * (8x^2 + 3x + 3) -->

        Polynomial polynomial = new Polynomial();
        Node<Term> tempP = p.front;
        while(tempP != null)
        {
            Node<Term> tempQ = q.front;
            while(tempQ != null)
            {
                Term term = new Term(tempP.Item.Coefficent * tempQ.Item.Coefficent, tempP.Item.Exponent + tempQ.Item.Exponent);
                polynomial.AddTerm(term);
                tempQ = tempQ.Next;
            }
            tempP = tempP.Next;
        }
        return polynomial;
    }

    //// Evaluates the current polynomial at x and returns the result
    public double Evaluate(double x)
    {
        Node<Term> nodeTerm = this.front;
        double result = 0;
        // 4x^3 + 2x+ 1, when x = 2, return 32 + 4 + 1 --> 37
        while(nodeTerm!= null)
        {
            result += nodeTerm.Item.Evaluate(x);
            nodeTerm = nodeTerm.Next;
        }        
        return result;
    }

    //// Creates and returns a clone of the current polynomial except that the exponents
    //// of the current polynomial are assigned to the coefficients of the clone in reverse order
    //// For example, 4x^3 – 3x + 9 is cloned as 9x^3 – 3x + 4
    public Object Clone()
    {
        Stack<int> S = new Stack<int>(); // Stack of exponents

        Node<Term> node = this.front;
        // 4x^2 + 3x + 1 --> Stack(2,1,0)
        
        /* In this implement. If node isn't null, then the stack pushes the item's exponent.
         * the node will be next node be used until there're no nodes.
         */
        while (node != null)
        {
            if (node.Item.Coefficent != 0)
            {
                S.Push(node.Item.Exponent);
            }
            node = node.Next;
        }
        Node<Term> node2 = this.front;

        // should form x^2 + 3x + 4
        Polynomial polynomial = new Polynomial();
        while(node2 != null)
        {
            if (node2.Item.Coefficent != 0)
            {
                int exponent = S.Pop();
                Term term = new Term(node2.Item.Coefficent, exponent);
                polynomial.AddTerm(term);
            }
            node2 = node2.Next;
        }
       
        return polynomial;
    }

    // Prints the current polynomial
    /* The method implement prints the in order of
     * polynomials, for instance ax^v + bx^w + cx^z
     */
    public void Print()
    {
        Node<Term> node = this.front;
        String result = "";
        int index = 0;

        // for empty polynomial
        if (node.Next == null)
        {
            Console.WriteLine(node.Item.ToString());
            return;
        }

        while (node != null)
        {
            if (node.Item.Coefficent > 0)
            {
                if (index != 0)
                {
                    result += "+ ";

                }
                result += node.Item.ToString();
                index = 1;
            }
            node = node.Next;
        }
        Console.WriteLine(result);
    }
}