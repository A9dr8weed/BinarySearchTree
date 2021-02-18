using System;
using System.Text;

namespace BinarySearchTree.Model
{
    /// <summary>
    /// Node.
    /// </summary>
    /// <typeparam name="T"> Data type. </typeparam>
    public class Node<T> : IComparable<T>, IComparable where T : IComparable, IComparable<T>
    {
        /// <summary>
        /// Data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Left node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Right node.
        /// </summary>
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            // Check the input data for correctness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Data = data;
            Left = Right = null;
        }

        public void displayNode(StringBuilder output, int depth)
        {
            // If Right != null recursively call the function and move to the depth.
            Right?.displayNode(output, depth + 1);

            output.Append('\t', depth).AppendLine(Data.ToString());

            // If Left != null recursively call the function and move to the depth.
            Left?.displayNode(output, depth + 1);
        }

        /// <summary>
        /// Add an item to the node.
        /// </summary>
        /// <param name="data"> Added item. </param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public void Add(T data)
        {
            // Check the input data for correctness.
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // New item.
            Node<T> node = new Node<T>(data);

            // If the item being compared is on the left.
            if (node.Data.CompareTo(Data) == -1)
            {
                // If the node is null.
                if (Left == null)
                {
                    // Assign a node element.
                    Left = node;
                }
                else
                {
                    // Recursive addition.
                    Left.Add(data);
                }
            }
            else
            {
                // If the node is null.
                if (Right == null)
                {
                    // Assign a node element.
                    Right = node;
                }
                else
                {
                    // Recursive addition.
                    Right.Add(data);
                }
            }
        }

        /// <summary>
        /// Comparison of types.
        /// </summary>
        /// <param name="obj"> Object of comparison. </param>
        /// <returns> If obj managed to bring Node<T>, then compare the data, otherwise an exception. </returns>
        public int CompareTo(object obj) => obj is Node<T> item ? Data.CompareTo(item) : throw new ArgumentException("Type mismatch.");

        public int CompareTo(T other) => Data.CompareTo(other);

        /// <summary>
        /// Convert a class instance to a string/
        /// </summary>
        /// <returns> Tree node data. </returns>
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}