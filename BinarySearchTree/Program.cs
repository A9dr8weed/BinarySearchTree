using BinarySearchTree.Model;

using System;

namespace BinarySearchTree
{
    public static class Program
    {
        private static void Main()
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(2);
            tree.Add(8);
            tree.Add(6);
            tree.Add(9);
            tree.Add(4);

            Console.WriteLine(tree.DisplayNode());

            Console.WriteLine($"Max element of tree: {tree.FindMax(tree.Root)}.");
            Console.WriteLine($"Min element of tree: {tree.FindMin(tree.Root)}.");
            Console.WriteLine(tree.Search(5));

            tree.Delete(8);

            Console.Write("Preorder traversal: ");
            foreach (int item in tree.Preorder())
            {
                Console.Write(item + ", ");
            }

            Console.Write("\nPostorder traversal: ");
            foreach (int item in tree.Postorder())
            {
                Console.Write(item + ", ");
            }

            Console.Write("\nInorder traversal: ");
            foreach (int item in tree.Inorder())
            {
                Console.Write(item + ", ");
            }
        }
    }
}