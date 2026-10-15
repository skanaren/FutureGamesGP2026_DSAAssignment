using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Utils {
    public class GenericTaskQueue<T> {
        public List<T> queueOfTasks = new List<T>();

        public void Enqueue(T task) {
            queueOfTasks.Add(task);
        }

        public T Peek() {
            if(queueOfTasks.Count == 0) {
                throw new Exception("Queue is empty!");
            }

            return queueOfTasks[0];
        }

        public T Dequeue() {
            if(queueOfTasks.Count == 0) {
                throw new Exception("Queue is empty!");
            }

            T currentTask = queueOfTasks[0];
            queueOfTasks.RemoveAt(0);
            return currentTask;
        }

        public int Count() {
            return queueOfTasks.Count;
        }

        public void Clear() {
            queueOfTasks.Clear();
        }
    }
}
