using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        public class Node
        {
            public int val;
            public Node left, right, parent;

            public Node(int key)
            {
                this.val = key;
                left = right = parent = null;
            }
        }

   

        public class BinaryTree
        {
            public Node root, n1, n2, lca;

            
            public Node insert(Node node, int key)
            {
                
                if (node == null)
                    return new Node(key);

               
                if (key < node.val)
                {
                    node.left = insert(node.left, key);
                    node.left.parent = node;
                }
                else if (key > node.val)
                {
                    node.right = insert(node.right, key);
                    node.right.parent = node;
                }

                
                return node;

            }
        }

        public static Node LowestCommonAncestor(Node n1, Node n2)
        {
           
            Dictionary<Node, Boolean> ancestors = new Dictionary<Node, Boolean>();

            
            while (n1 != null)
            {
                ancestors.Add(n1, true);
                n1 = n1.parent;
            }

           
            while (n2 != null)
            {
                if (ancestors.ContainsKey(n2))
                    return n2;
                n2 = n2.parent;
            }

            return null;
        }


        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = tree.insert(tree.root, 20);
            tree.root = tree.insert(tree.root, 8);
            tree.root = tree.insert(tree.root, 22);
            tree.root = tree.insert(tree.root, 4);
            tree.root = tree.insert(tree.root, 12);
            tree.root = tree.insert(tree.root, 10);
            tree.root = tree.insert(tree.root, 14);

            tree.n1 = tree.root.left.right.left;
            tree.n2 = tree.root.left;
            tree.lca = LowestCommonAncestor(tree.n1, tree.n2);

            Console.WriteLine("LCA of " + tree.n1.val + " and " + tree.n2.val
                    + " is " + tree.lca.val);
        }


 




    }
}
