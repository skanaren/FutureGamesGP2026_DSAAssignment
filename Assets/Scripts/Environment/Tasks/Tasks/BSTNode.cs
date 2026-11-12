using Environment;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BSTNode<T> {

    private T data;

    public BSTNode<T>? leftChild = null;
    public BSTNode<T>? rightChild = null;

    public T GetData() {

        return data;
    }

    public BSTNode(T inData) {

        this.data = inData;
    }
}

public class BST {

    public BSTNode<Employees> root;

    public BST(Employees rootData) {

        root = new BSTNode<Employees>(rootData);
    }

    public void Insert(Employees inData) {

        BSTNode<Employees> newNode = new BSTNode<Employees>(inData);
        BSTNode<Employees>? currentNode = root;
        BSTNode<Employees> lastParent = root;

        while(currentNode != null) {

            if(DateTime.ParseExact(inData.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
                < DateTime.ParseExact(currentNode.GetData().lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) {

                lastParent = currentNode;
                currentNode = currentNode.leftChild;
            }
            else {

                lastParent = currentNode;
                currentNode = currentNode.rightChild;
            }
        }

        if(DateTime.ParseExact(inData.lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            < DateTime.ParseExact(lastParent.GetData().lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)) {

            lastParent.leftChild = newNode;
        }
        else
            lastParent.rightChild = newNode;
    }

    public void BFS() {

        Queue<BSTNode<Employees>> queue = new Queue<BSTNode<Employees>>();
        queue.Enqueue(root);

        while(queue.Count > 0) {

            BSTNode<Employees> node = queue.Dequeue();

            Debug.Log("Name: " + node.GetData().name + "\n" + node.GetData().lastEntranceInEngineRoom);

            if (node.leftChild != null) {

                queue.Enqueue(node.leftChild);
            }
            else if (node.rightChild != null) {

                queue.Enqueue(node.rightChild);
            }
        }
    }

    public void DFS() {

        Stack<BSTNode<Employees>> stack = new();
        BSTNode<Employees> current = root;

        while (stack.Count > 0 ||  current != null) {

            while (current != null) {

                stack.Push(current);
                current = current.leftChild;
            }

            current = stack.Pop();
            Debug.Log("Name: " + current.GetData().name + "\n" + current.GetData().lastEntranceInEngineRoom);
            current = current.rightChild;
        }
    }
}
