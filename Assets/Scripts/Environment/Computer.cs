using Environment.Tasks;
using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Utils;

namespace Environment {
    class Computer : MonoBehaviour, IInteractable, IDamageable {
        public List<GenericTaskQueue<Task>> combinedLists = new List<GenericTaskQueue<Task>>();

        [SerializeReference]
        public GenericTaskQueue<Task> tasks = new GenericTaskQueue<Task>();
        [SerializeReference]
        public GenericTaskQueue<Task> secondaryTasks = new GenericTaskQueue<Task>();


        private void Awake() {
            combinedLists.Add(tasks);
            combinedLists.Add(secondaryTasks);
        }

        public void OnInteract() {
            foreach (GenericTaskQueue<Task> taskList in combinedLists) {
                taskList.Peek().Execute();
                taskList.Dequeue();
            }
        }

        public void OnAttack() {
            Debug.Log("You destroyed the computer!");
        }
    }
}
