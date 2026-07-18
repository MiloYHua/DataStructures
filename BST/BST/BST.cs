using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BST
{
    public class BST<T> where T : IComparable<T>
    {
        public BSTNode<T> Root { get; private set; }
        public int Count { get; set; }

        public void Insert(BSTNode<T> insertNode)
        {
            if (insertNode == null) throw new ArgumentNullException();

            BSTNode<T> compareNode = Root;
            bool repeat = true;

            Count++;

            if (Root == null)
            {
                Root = insertNode;
                return;
            }
            while (repeat)
            {
                repeat = false;

                if (compareNode.Value.CompareTo(insertNode.Value) < 0)
                {
                    if (compareNode.Right == null)
                    {
                        compareNode.Right = insertNode;
                        return;
                    }

                    repeat = true;
                    compareNode = compareNode.Right;
                }
                else if (compareNode.Value.CompareTo(insertNode.Value) > 0)
                {
                    if (compareNode.Left == null)
                    {
                        compareNode.Left = insertNode;
                        return;
                    }

                    repeat = true;
                    compareNode = compareNode.Left;
                }
            }
            throw new Exception("dude making duplicates is not very cool man dude guy also its annoying to implement so i will do this");
        }

        public void Insert(T insertValue) { Insert(new BSTNode<T>(insertValue)); }

        public BSTNode<T> Search(T lostValue)
        {
            if (lostValue == null) throw new ArgumentNullException();

            BSTNode<T> searchAndRescueNode = Root;
            bool repeat = true;

            while (repeat)
            {
                repeat = false;

                if (searchAndRescueNode == null) return null;

                if (searchAndRescueNode.Value.CompareTo(lostValue) > 0)
                {
                    searchAndRescueNode = searchAndRescueNode.Left;
                    repeat = true;
                }
                else if (searchAndRescueNode.Value.CompareTo(lostValue) < 0)
                {
                    searchAndRescueNode = searchAndRescueNode.Right;
                    repeat = true;
                }
            }
            return searchAndRescueNode;
        }

        public T Minimum(BSTNode<T> subtreeRoot)
        {
            if (subtreeRoot == null) throw new ArgumentNullException();

            BSTNode<T> searchNode = subtreeRoot;

            while (searchNode.Left != null) searchNode = searchNode.Left;

            return searchNode.Value;
        }

        public T Maximum(BSTNode<T> subtreeRoot)
        {
            if (subtreeRoot == null) throw new ArgumentNullException();

            BSTNode<T> searchNode = subtreeRoot;

            while (searchNode.Right != null) searchNode = searchNode.Right;

            return searchNode.Value;
        }

        public BSTNode<T> MaximumNode(BSTNode<T> subtreeRoot)
        {
            if (subtreeRoot == null) throw new ArgumentNullException();

            BSTNode<T> searchNode = subtreeRoot;

            while (searchNode.Right != null) searchNode = searchNode.Right;

            return searchNode;
        }

        public bool Remove(T value)
        {
            if (value == null) throw new ArgumentNullException("value");

            BSTNode<T> byeByeNode = Search(value);

            if (byeByeNode == null) return false;

            T tempValue = byeByeNode.Value;
            BSTNode<T> tempLeft = byeByeNode.Left;
            BSTNode<T> tempRight = byeByeNode.Right;
            BSTNode<T> newNode = RemoveHelper(byeByeNode);
            BSTNode<T> parent = new BSTNode<T>();
            BSTNode<T> searchAndRescueNode = Root;

            #region Find Parent
            bool repeat = true;

            while (repeat)
            {
                repeat = false;

                if (searchAndRescueNode.Value.CompareTo(byeByeNode.Value) > 0)
                {
                    parent = searchAndRescueNode;
                    searchAndRescueNode = searchAndRescueNode.Left;
                    repeat = true;
                }
                else if (searchAndRescueNode.Value.CompareTo(byeByeNode.Value) < 0)
                {
                    parent = searchAndRescueNode;
                    searchAndRescueNode = searchAndRescueNode.Right;
                    repeat = true;
                }
            }
            #endregion

            if (byeByeNode == Root)
            {
                if (newNode == Root.Left)
                {
                    newNode.Right = Root.Right;
                    Root = newNode;
                    return true;
                }
                else if (newNode == Root.Right)
                {
                    newNode.Left = Root.Left;
                    Root = newNode;
                    return true;
                }
            }

            if (byeByeNode.Left == null && byeByeNode.Right == null)
            {
                if (parent.Left == byeByeNode) parent.Left = newNode;
                if (parent.Right == byeByeNode) parent.Right = newNode;
                return true;
            }
            else if ((byeByeNode.Left == null) != (byeByeNode.Right == null))
            {
                if (parent.Left == byeByeNode) parent.Left = newNode;
                if (parent.Right == byeByeNode) parent.Right = newNode;
                return true;
            }
            else
            {
                if (parent.Left == byeByeNode) parent.Left = newNode;
                if (parent.Right == byeByeNode) parent.Right = newNode;
                newNode.Left = tempLeft;
                newNode.Right = tempRight;
                return true;
            }
        }

        private BSTNode<T> RemoveHelper(BSTNode<T> byeByeNode)
        {
            if (byeByeNode == null) throw new ArgumentNullException("byeByeNode");

            BSTNode<T> leftTemp = byeByeNode.Left;
            BSTNode<T> rightTemp = byeByeNode.Right;

            Count--;

            if (byeByeNode.Left == null && byeByeNode.Right == null) return null;
            else if ((byeByeNode.Left == null) != (byeByeNode.Right == null))
            {
                if (leftTemp == null) return rightTemp;
                else return leftTemp;
            }
            else return MaximumNode(leftTemp);
        }

        public static List<T> RecursivePreOrder(BSTNode<T> current)
        {
            List<T> result = new List<T>();

            result.Add(current.Value);

            if (current.Left != null)
            {
                result.AddRange(RecursivePreOrder(current.Left));
            }
            if (current.Right != null)
            {
                result.AddRange(RecursivePreOrder(current.Right));
            }

            return result;
        }

        public static List<T> RecursivePostOrder(BSTNode<T> current)
        {
            List<T> result = new List<T>();

            if (current.Left != null)
            {
                result.AddRange(RecursivePostOrder(current.Left));
            }
            if (current.Right != null)
            {
                result.AddRange(RecursivePostOrder(current.Right));
            }

            result.Add(current.Value);

            return result;
        }

        public static List<T> RecursiveInOrder(BSTNode<T> current)
        {
            List<T> result = new List<T>();

            if (current.Left != null)
            {
                result.AddRange(RecursiveInOrder(current.Left));
            }
            result.Add(current.Value);
            if (current.Right != null)
            {
                result.AddRange(RecursiveInOrder(current.Right));
            }


            return result;
        }

        public static List<BSTNode<T>> LevelOrderTraversal(BSTNode<T> node)
        {
            List<BSTNode<T>> visitedNodes = new List<BSTNode<T>>();
            Queue<BSTNode<T>> needToVisitNodes = new Queue<BSTNode<T>>();
            needToVisitNodes.Enqueue(node);
            while (needToVisitNodes.Count > 0)
            {
                var current = needToVisitNodes.Dequeue();
                visitedNodes.Add(current);
                if (current.Left != null)
                {
                    needToVisitNodes.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    needToVisitNodes.Enqueue(current.Right);
                }
            }
            return visitedNodes;
        }

        public static List<BSTNode<T>> PreOrderTraversal(BSTNode<T> node)
        {
            List<BSTNode<T>> visitedNodes = new List<BSTNode<T>>();
            Stack<BSTNode<T>> needToVisitNodes = new Stack<BSTNode<T>>();

            needToVisitNodes.Push(node);

            while (needToVisitNodes.Count > 0)
            {
                var current = needToVisitNodes.Pop();
                visitedNodes.Add(current);

                if (current.Right != null)
                {
                    needToVisitNodes.Push(current.Right);
                }
                if (current.Left != null)
                {
                    needToVisitNodes.Push(current.Left);
                }
            }
            return visitedNodes;
        }

        public static List<BSTNode<T>> PostOrderTraversal(BSTNode<T> node)
        {
            List<BSTNode<T>> visitedNodes = new List<BSTNode<T>>();
            Stack<BSTNode<T>> needToVisitNodes = new Stack<BSTNode<T>>();

            needToVisitNodes.Push(node);

            while (needToVisitNodes.Count > 0)
            {
                var current = needToVisitNodes.Pop();
                visitedNodes.Add(current);

                if (current.Left != null)
                {
                    needToVisitNodes.Push(current.Left);
                }
                if (current.Right != null)
                {
                    needToVisitNodes.Push(current.Right);
                }
            }
            return visitedNodes;
        }

        public static List<BSTNode<T>> InOrderTraversal(BSTNode<T> node)
        {
            List<BSTNode<T>> visitedNodes = new List<BSTNode<T>>();
            Stack<BSTNode<T>> needToVisitNodes = new Stack<BSTNode<T>>();

            var current = node;

            do
            {
                if (current != null)
                {
                    needToVisitNodes.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = needToVisitNodes.Pop();
                    visitedNodes.Add(current);
                    current = current.Right;
                }
            } while (needToVisitNodes.Count > 0 || current != null);
            
            return visitedNodes;
        }

        public bool Contains(T needFindValue) => Search(needFindValue) != null;

        public bool Contains(BSTNode<T> needFindNode) => Contains(needFindNode.Value);

        public bool IsEmpty() => Count == 0;
    }
}