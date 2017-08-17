using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
For the purposes of this challenge, we define a binary search tree to be a binary tree with the following ordering properties:

The  value of every node in a node's left subtree is less than the data value of that node.
The  value of every node in a node's right subtree is greater than the data value of that node.
Given the root node of a binary tree, can you determine if it's also a binary search tree?

Complete the function in your editor below, which has  parameter: a pointer to the root of a binary tree. It must return a boolean denoting whether or not the binary tree is a binary search tree. You may have to write one or more helper functions to complete this challenge.

Note: We do not consider a binary tree to be a binary search tree if it contains duplicate values.


 */
class Solution {
    static void Main(string[] args)
    {
        var tree = new BinaryTree
        {
            Root = new Node(4)
            {
                Left = new Node(2),
                Right = new Node(5)
            }
        };
        tree.Root.Left.Left = new Node(1);
        tree.Root.Left.Right = new Node(3);

        Console.WriteLine(tree.IsBST());

    }
}

public class Node
{
    public Node(int data)
    {
        Data = data;
    }
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}

public class BinaryTree
{
    public Node Root { get; set; }

    public bool IsBST() =>
        IsBST(Root, Int32.MinValue, Int32.MaxValue);


    private static bool IsBST(Node node, int min, int max)
    {
        if (node == null) return true;
        if (node.Data < min || node.Data > max) return false;
        return IsBST(node.Left, min, node.Data - 1) && IsBST(node.Right, node.Data + 1, max);
    }
}
