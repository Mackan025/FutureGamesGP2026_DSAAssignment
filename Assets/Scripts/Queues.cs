using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    [Serializable]
    public class Queues<T> {

        [SerializeField]
        List<T> queue;
        public Queues() {
            queue = new List<T>();
        }

        public T Peek() {
            if(queue.Count == 0) {
                throw new System.InvalidOperationException("Queue is empty");
            }
            T item = queue[0];
            return item;
        }

        public void Enqueue(T item) {
            queue.Add(item);
        }

        public T Dequeue() {
            if(queue.Count == 0) {
                throw new System.InvalidOperationException("Queue is empty");
            }
            T item = queue[0];
            queue.RemoveAt(0);
            return item;
        }

        public int Count {
            get { return queue.Count; }
        }
    }
}
