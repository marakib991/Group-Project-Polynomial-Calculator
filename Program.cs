using System;
using System.Collections.Generic;

class Program
{
    //Main() method
    public static void Main()
    {
        bool test = true;
        if (!test)
        {
            // create Polynomials S as storage of all the commands
            Polynomials S = new Polynomials();

            Console.WriteLine("\nMenu:");
            //Choices in order of numbers:
            Console.WriteLine("1): Create and insert into S");
            Console.WriteLine("2) To add two polynomials from S (retrieved by index) and to insert the resultant polynomial into S,");
            Console.WriteLine("3) To multiply two polynomials from S (retrieved by index) and to insert the resultant polynomial into S,");
            Console.WriteLine("4) To delete the polynomial from S at a given index,");
            Console.WriteLine("5) To evaluate the polynomial from S at a given index,");
            Console.WriteLine("6) To clone the polynomial from S (retrieved by index) and to insert its clone into S.");
            Console.WriteLine("0: Exit");

            String choice;
            do
            {
                // get user choice and handle it by switch
                Console.Write("\nInsert choice in numbers ==> ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Program.handleCommand1(S);
                        break;

                    case "2":
                        Program.handleCommand2(S);
                        break;

                    case "3":
                        Program.handleCommand3(S);
                        break;
                    case "4":
                        Program.handleCommand4(S);
                        break;

                    case "5":
                        Program.handleCommand5(S);
                        break;

                    case "6":
                        Program.handleCommand6(S);
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please choose again!");
                        break;
                }
            } while (choice != "0");
        } else
        {
            Test.Start();
        }
    }


    //create a polynomial and insert it into S
    public static void handleCommand1(Polynomials S)
    {
        // create local variable polynomial for the polynomial about to be inserted into S
        Polynomial polynomial = new Polynomial();

        // require user indefinitely until they input exponent as -1
        while (true)
        {
            // request for coefficient indefinitely until user input a valid coefficient
            Console.WriteLine("What term do you want to insert into the polynomial (type -1 for exponent for ending)?");
            double coeff = double.PositiveInfinity;
            while ( coeff == double.PositiveInfinity)
            {
                try
                {
                    Console.Write("Coefficient: ");
                    // will throw Format Exception if user input character and be handle by the below catch
                    coeff = Convert.ToDouble(Console.ReadLine());
                } catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Only accept double value! Try again");
                }
            }

            // request for exponent indefinitely until user input a valid exponent
            int expon = int.MinValue;
            while (expon == int.MinValue)
            {
                try
                {
                    Console.Write("Exponent (0-20): ");
                    expon = Convert.ToInt32(Console.ReadLine());
                    if (expon < -1 || expon > 20)
                    {
                        expon = int.MinValue;
                        throw new FormatException();
                    }
                } catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Only accept integer value >= -1 and <= 20! Try again!");
                } catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            // break if exponent == -1
            if (expon == -1)
            {
                break;
            }
            // create term from user input and add to the polynomial about to be inserted into S
            Term term = new Term(coeff, expon);
            polynomial.AddTerm(term);

        }
        // insert the user created polynomial into S
        S.Insert(polynomial);

        // Prints the whole result
        Console.Write("Polynomial inserted into stack S: ");
        polynomial.Print();
        Console.WriteLine("Size of stack S: " + S.Size());
        Console.WriteLine("S has the following polynomials:");
        S.Print();
    }

    // add two polynomials from S (retrieved by index) and insert the resultant polynomial into S
    public static void handleCommand2(Polynomials S)
    {
        Console.WriteLine("\nWhich polynomials do you want to add from?");
        int count = S.Size();
        // return if S is empty since no possible to have any polynomial to add
        if (count == 0)
        {
            Console.WriteLine("S is empty, please insert some polynomials through command 1");
            return;
        }

        Console.WriteLine("Input index in range 1 - " + count);

        // p as the first polynomial to be retrieved from S
        Polynomial p = Program.getPolynomialByIndex(S, "Index of the first polynomial: ");
            
        // q as the second polynomial to be retrieved from S
        Polynomial q = Program.getPolynomialByIndex(S, "Index of the second polynomial: ");
        
        // add p and q by the + operator defined in Polynomial.cs and get pq
        Polynomial pq = p + q;

        // inserts pq into S
        S.Insert(pq);

        // Print entire S
        S.Print();
    }

    // multiply two polynomials from S(retrieved by index) and to insert the resultant polynomial into S
    public static void handleCommand3(Polynomials S)
    {
        int count = S.Size();
        // return if S is empty since no possible to have any polynomial to multiply
        if (count == 0)
        {
            Console.WriteLine("S is empty, please insert some polynomials through command 1");
            return;
        }
        Console.WriteLine("\nWhich polynomials do you want to multiply from?");
        Console.WriteLine("Input index in range 1 - " + count);

        // p as the first polynomial to be retrieved from S
        Polynomial p = Program.getPolynomialByIndex(S, "Index of the first polynomial: ");

        // q as the second polynomial to be retrieved from S
        Polynomial q = Program.getPolynomialByIndex(S, "Index of the second polynomial: ");

        // multiply p and q by the * operator defined in Polynomial.cs and get pq
        Polynomial pq = p * q;

        // inserts pq into S
        S.Insert(pq);

        // Print entire S
        S.Print();
    }


    // delete the polynomial from S at a given index,
    public static void handleCommand4(Polynomials S)
    {
        int count = S.Size();
        // return if S is empty since no possible to have any polynomial to multiply
        if (count == 0)
        {
            Console.WriteLine("S is empty, please insert some polynomials through command 1");
            return;
        }
        Console.Write("Which index do you want to delete at? ");
        Console.WriteLine("Input index in range 1 - " + count);

        // get valid index from user to be deleted from S
        int indexToDelete = Program.getIndex(S);
        Console.Write("Polynomial to be deleted from stack S: ");
        S.Retrieve(indexToDelete).Print();

        // delete polynomial at index "indexToDelete" From S
        S.Delete(indexToDelete);

        // log purpose
        Console.WriteLine("Size of stack S: " + S.Size());
        Console.WriteLine("S has the following polynomials now:");
        S.Print();
    }

    // evaluate the polynomial from S at a given index
    public static void handleCommand5(Polynomials S)
    {
        int count = S.Size();
        // return if S is empty since no possible to have any polynomial to multiply
        if (count == 0)
        {
            Console.WriteLine("S is empty, please insert some polynomials through command 1");
            return;
        }
        Console.Write("What index do you want to evaluate at? ");
        Console.WriteLine("Input index in range 1 - " + count);


        // get valid index from S to be evaluate
        int indexToBeEvalute = Program.getIndex(S);

        // retrieve x from user indefinitely until x is a valid double value
        double valueOfX = double.PositiveInfinity;
        while (valueOfX == double.PositiveInfinity)
        {
            try
            {
                valueOfX = Convert.ToDouble(Console.ReadLine());
            }
            // will be thrown if user didn't input integer
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + "Must send an integer, send again!");
            }
            // will be thrown if user input overflow
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message + "You got an overflow -- When your value is larger than ToInt32() method's value...");
            }
        }

        Console.Write("For polynomial ");
        S.Retrieve(indexToBeEvalute).Print();
        Console.WriteLine("When x = " + valueOfX.ToString() + ", polynomial = ");
        // print the evalutaion of polynomial at index "indexToBeEvaluate" for x = "valueOfX"
        Console.WriteLine(S.Retrieve(indexToBeEvalute).Evaluate(valueOfX));
    }

    public static void handleCommand6(Polynomials S)
    {
        int count = S.Size();
        // return if S is empty since no possible to have any polynomial to multiply
        if (count == 0)
        {
            Console.WriteLine("S is empty, please insert some polynomials through command 1");
            return;
        }
        Console.Write("Which index do you want to clone at?");
        Console.WriteLine("Input index in range 1 - " + count);

        // get valid index from S to be clone
        int indexToBeClone = Program.getIndex(S);
        // clone index from user input and append to S
        S.Insert((Polynomial)S.Retrieve(indexToBeClone).Clone());

        // log purpose
        Console.Write("Polynomial to be clone: ");
        S.Retrieve(indexToBeClone).Print();
        Console.Write("Cloned polynomial: ");
        S.Retrieve(S.Size() - 1).Print();
    }

    public static Polynomial getPolynomialByIndex(Polynomials S, string message)
    {
        Polynomial p = null;
        while (p == null)
        {
            try
            {
                // try to get the user-input-index - 1 from S as p
                // user input is minused by 1 to retrieve the correct index
                Console.Write(message);
                p = S.Retrieve(Convert.ToInt32(Console.ReadLine()) - 1);
            }
            // will be thrown if user didn't input integer
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + "Must send an integer, send again!");
            }
            // will be thrown if user input overflow
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            // will be thrown if user input is not in the range of 1 to size of S
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message + " -- Must send values between 1 and " + S.Size() + ", send again!");
            }
        }
        return p;
    }

    // return index if it exists in S, keep prompting until a valid index is inputed
    public static int getIndex(Polynomials S)
    {
        // Keep requesting valid index (0 - count) to delete polynomial from S
        while (true)
        {
            try
            {
                int i = Convert.ToInt32(Console.ReadLine()) - 1;
                if (S.Retrieve(i) != null)
                {
                    return i;
                }
            }
            // will be thrown if user didn't input integer
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + "Must send an integer, send again!");
            }
            // will be thrown if user input overflow
            catch (OverflowException e) //Tells the user that goes value larger than capacity of ToInt32's value.
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e) //Tells user to insert index value between 0 and count(The size of Polynomials).
            {
                Console.WriteLine(e.Message + " -- Must send values between 1 and " + S.Size() + ", send again!");
            }
        }
    }
}