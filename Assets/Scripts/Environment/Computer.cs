using Environment.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task testTask = null; // Put your stack/queue here :)

        [SerializeField]
        private List<Task> tasks = new List<Task>();

        Queue<Task> taskQueue = new Queue<Task>();

        void Start() {
            foreach(var item in tasks) {
                taskQueue.Enqueue(item);
            }
            
        }

        public void OnInteract() {
            if (taskQueue.Count > 0) {
                taskQueue.Dequeue().Execute();
            }
        }
    }
}
