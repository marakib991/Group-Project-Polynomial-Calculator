//Use test cases and document them
class NodeTest
{
    public static void Test()
    {
        Console.WriteLine("TESTING NODE...");
        TestConstructor();
        Console.WriteLine("TESTING NODE COMPLETED\n\n");
    }

    public static void TestConstructor()
    {
        Console.WriteLine("TESTING Node constructor, get/set...");
        

        //Test1: All shown nulls (fail)
        Node<int> node0 = new Node<int>(10, null);
        Node<int> node1 = new Node<int>(51, node0);
        Node<int> node2 = new Node<int>(36, node1);
        Node<int> node3 = new Node<int>(6, null);
        if (node0.Item != 10 || node1.Item != 51 || node2.Item != 36 || node3.Item!= 6)
        {
            throw new Exception("ERROR: constructor setting Item for node are incorrect");
        }

        if (node2.Next != node1 || node1.Next != node0 || node0.Next != null)
        {
            throw new Exception("ERROR: Next of some nodes are incorrect");
        }
        node1.Next = node3;
        if (node1.Next != node3)
        {
            throw new Exception("ERROR: unable to set next for node");
        }
        node3.Item = 1;
        if (node3.Item != 1)
        {
            throw new Exception("ERROR: unable set Item for node");
        }

        Console.WriteLine("Node constructor, get/set PASSED\n");
    }
}
