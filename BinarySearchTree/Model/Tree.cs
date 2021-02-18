using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree.Model
{
    public class Tree<T> where T : IComparable, IComparable<T>
    {
        /// <summary>
        /// Tree root.
        /// </summary>
        public Node<T> Root { get; private set; }

        /// <summary>
        /// Number of elements.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add data to the tree.
        /// </summary>
        /// <param name="data"> Added data. </param>
        public void Add(T data)
        {
            // If there is no root element.
            if (Root == null)
            {
                // Write it down.
                Root = new Node<T>(data);
                Count = 1;

                return;
            }

            // If the elements match. Do not add.
            if (Root.Data.Equals(data))
            {
                Console.WriteLine($"Element {Root.Data} already exist.");

                return;
            }

            // Add an item to the right or left.
            Root.Add(data);
            Count++;
        }

        /// <summary>
        /// Find the smallest value. Moving left on a tree.
        /// </summary>
        /// <remarks>
        /// Recursive pass to the left.
        /// </remarks>
        /// <param name="node"> Tree root. </param>
        /// <returns> If the tree is empty return null, if the element is extreme left == null then return node. </returns>
        public Node<T> FindMin(Node<T> node)
        {
            return node == null ? null : node.Left == null ? node : FindMin(node.Left);
        }

        /// <summary>
        /// Find the greatest value. Moving to the right on a tree.
        /// </summary>
        /// <remarks>
        /// Recursive passage to the right.
        /// </remarks>
        /// <param name="node"> Tree root. </param>
        /// <returns> If the tree is empty return null, if the element is far right == null then return node. </returns>
        public Node<T> FindMax(Node<T> node)
        {
            return node == null ? null : node.Right == null ? node : FindMax(node.Right);
        }

        /// <summary>
        /// Wrap over private method.
        /// </summary>
        /// <param name="data"> Searched data. </param>
        /// <returns> Found item. </returns>
        public Node<T> Search(T data)
        {
            return Search(Root, data);
        }

        /// <summary>
        /// Search for an item.
        /// </summary>
        /// <param name="node"> Tree root. </param>
        /// <param name="data"> Searched data. </param>
        /// <returns>The desired item. </returns>
        private Node<T> Search(Node<T> node, T data)
        {
            // If there is no element.
            if (node == null)
            {
                Console.Write($"There is no element {data}.");

                return null;
            }

            // Look in the left side.
            if (data.CompareTo(node.Data) == -1)
            {
                return Search(node.Left, data);
            }
            // Look in the right side.
            else if (data.CompareTo(node.Data) == 1)
            {
                return Search(node.Right, data);
            }
            else
            {
                Console.Write("Find element: ");
                // Found node.
                return node;
            }
        }

        /// <summary>
        /// Wrap over private method.
        /// </summary>
        /// <param name="data"> Data to delete. </param>
        public void Delete(T data)
        {
            Root = Delete(Root, data);
        }

        /// <summary>
        /// Remove a binary tree node.
        /// </summary>
        /// <param name="node"> The node to remove. </param>
        /// <param name="data"> Data to delete. </param>
        /// <returns> Deleted item. </returns>
        private Node<T> Delete(Node<T> node, T data)
        {
            // If there is no element.
            if (node == null)
            {
                Console.Write($"{data} does not exist.");

                return node;
            }

            // Otherwise, recur down the tree.
            if (data.CompareTo(node.Data) == -1)
            {
                node.Left = Delete(node.Left, data);
            }
            else if (data.CompareTo(node.Data) == 1)
            {
                node.Right = Delete(node.Right, data);
            }

            // If data is same as root's data, then this is the node to be deleted.
            else
            {
                // Node with only one child or no child.
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                // Node with two children: get the inorder successor (smallest in the right subtree).
                node = FindMin(node.Right);
                // Delete the inorder successor.
                node.Right = Delete(node.Right, node.Data);
            }

            return node;
        }

        /// <summary>
        /// Preorder tree traversal.
        /// </summary>
        /// <returns> List of elements. </returns>
        public List<T> Preorder()
        {
            // If root is null.
            if (Root == null)
            {
                // Return empty list.
                return new List<T>();
            }

            return Preorder(Root);
        }

        /// <summary>
        /// Postorder tree traversal.
        /// </summary>
        /// <returns> List of elements. </returns>
        public List<T> Postorder()
        {
            // If root is null.
            if (Root == null)
            {
                // Return empty list.
                return new List<T>();
            }

            return Postorder(Root);
        }

        /// <summary>
        /// Binary tree output.
        /// </summary>
        /// <returns> Source tree. </returns>
        public string DisplayNode()
        {
            StringBuilder output = new StringBuilder();

            Root.displayNode(output, 0);

            return output.ToString();
        }

        /// <summary>
        /// Inorder tree traversal.
        /// </summary>
        /// <returns> List of elements. </returns>
        public List<T> Inorder()
        {
            // If root is null.
            if (Root == null)
            {
                // Return empty list.
                return new List<T>();
            }

            return Inorder(Root);
        }

        /// <summary>
        /// Go down recursively until you get to the extreme element, add to the list and pass to a higher level.
        /// </summary>
        /// <remarks>
        /// Used to search.
        /// The order of traversal: element, left, right.
        /// </remarks>
        /// <param name="node"> Tree element. </param>
        /// <returns> List of elements. </returns>
        private List<T> Preorder(Node<T> node)
        {
            List<T> list = new List<T>();

            // If element not null
            if (node != null)
            {
                // Add data to the list.
                list.Add(node.Data);

                if (node.Left != null)
                {
                    // Recursively add to the left.
                    list.AddRange(Preorder(node.Left));
                }

                if (node.Right != null)
                {
                    // Recursively add to the right.
                    list.AddRange(Preorder(node.Right));
                }
            }

            return list;
        }

        /// <summary>
        /// Go down recursively until you get to the extreme element, add to the list and pass to a higher level.
        /// </summary>
        /// <remarks>
        /// Used to delete.
        /// The order of traversal: left, right, element.
        /// </remarks>
        /// <param name="node"> Tree element. </param>
        /// <returns> List of elements. </returns>
        private List<T> Postorder(Node<T> node)
        {
            List<T> list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Postorder(node.Right));
                }

                list.Add(node.Data);
            }

            return list;
        }

        /// <summary>
        /// Ліво, елемент, право
        /// </summary>
        /// <remarks>
        /// Used to sort.
        /// The order of traversal: left, element, right.
        /// </remarks>
        /// <param name="node"> Tree element. </param>
        /// <returns> List of elements. </returns>
        private List<T> Inorder(Node<T> node)
        {
            List<T> list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(Inorder(node.Right));
                }
            }

            return list;
        }
    }
}