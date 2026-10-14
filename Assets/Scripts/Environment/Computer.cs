using Environment.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task testTask = null; // Put your stack/queue here :)

        [SerializeField]
        Queues<Task> taskQueue = new Queues<Task>();

        public void OnInteract() {
            if (taskQueue.Count > 0) {
                taskQueue.Dequeue().Execute();
            }
        }
    }
}
