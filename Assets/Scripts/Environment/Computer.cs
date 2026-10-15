using Environment.Tasks;
using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Utils;

namespace Environment {
    [Serializable]
    class Computer : MonoBehaviour, IInteractable, IDamageable {

        /* VARIABLES */
        [SerializeField] bool isActive;

        /* OBJECTS */
        [SerializeField] LightSwitch lights;

        /* LISTCEPTION */
        public List<GenericTaskQueue<Task>> combinedLists = new List<GenericTaskQueue<Task>>();
        [SerializeReference] public GenericTaskQueue<Task> tasks = new GenericTaskQueue<Task>();
        [SerializeReference] public GenericTaskQueue<Task> lightTasks = new GenericTaskQueue<Task>();


        private void Awake() {
            isActive = false;
            combinedLists.Add(tasks);
            combinedLists.Add(lightTasks);
        }

        public void OnInteract() {

            if(lightTasks.queueOfTasks.Count == 0 && !isActive) {
                lightTasks.Enqueue(lights);
                isActive = true;
            }
            else if(tasks.queueOfTasks.Count == 2 && isActive) {
                lightTasks.Enqueue(lights);
                lightTasks.Dequeue();
                isActive = false;
            }

            foreach(GenericTaskQueue<Task> taskList in combinedLists) {
              
                if(taskList.Count() == 0) continue;

                taskList.Peek().Execute();
                taskList.Dequeue();
            }
        }

        public void OnAttack() {
            Debug.Log("You destroyed the computer!");
        }
    }
}
