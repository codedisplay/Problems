namespace Problems
{
    public class BinaryTreeHelper
    {
        // Convert a given Binary Tree to Doubly Linked List  
        public System.Collections.Generic.LinkedList<int> GetDoublyLinkedList(BinaryTreeNode binaryTree)
        {
            System.Collections.Generic.LinkedList<int> doublyLinkedList =
                new System.Collections.Generic.LinkedList<int>();

            // In order Traversal
            InOrderTraversal(binaryTree.Left, ref doublyLinkedList);

            return doublyLinkedList;
        }

        private void InOrderTraversal(BinaryTreeNode binaryTreeNode, ref System.Collections.Generic.LinkedList<int> doublyLinkedList)
        {
            if (binaryTreeNode == null)
                return;

            InOrderTraversal(binaryTreeNode.Left, ref doublyLinkedList);
            doublyLinkedList.AddLast(binaryTreeNode.Value);
            InOrderTraversal(binaryTreeNode.Right,ref doublyLinkedList);
        }

        /* Function to print nodes in a given doubly linked list */
        public void PrintList(BinaryTreeNode node)
        {
            while (node != null)
            {
                System.Console.WriteLine(node.Value+ " ");
                node = node.Right;
            }
        }
    }
}
