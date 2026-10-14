using System;
using System.Collections.Generic;
using UnityEngine;

public class GenericQueue<T> {
    private List<T> queue;

    public void Enqueue(T inNewElement) {
        queue.Add(inNewElement);
    }

    public T Peek() {
        if (queue.Count == 0) {
            throw new Exception("Queue is empty, cannot peek.");
        }

        return queue[0];
    }

    public T Dequeue() {
        if (queue.Count == 0) {
            throw new Exception("Queue is empty, cannot peek.");
        }

        T topOfQueue = queue[0];
        queue.RemoveAt(index: 0);
        return topOfQueue;
    }

    public void Clear() {
        queue.Clear();
    }
}
