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
        [SerializeReference] public GenericTaskQueue<Task> normalTasks = new GenericTaskQueue<Task>();
        [SerializeReference] public GenericTaskQueue<Task> lightTasks = new GenericTaskQueue<Task>();


        private void Awake() {
            isActive = false;
            combinedLists.Add(normalTasks);
            combinedLists.Add(lightTasks);
        }

        // This works because the Omnissiah willed it so
        public void OnInteract() {

            if(lightTasks.Count() == 0 && !isActive) {
                lightTasks.Enqueue(lights);
                isActive = true;
            }
            else if(normalTasks.Count() == 2 && isActive) {
                lightTasks.Enqueue(lights);
                lightTasks.Dequeue();
                isActive = false;
            }

            foreach(GenericTaskQueue<Task> taskList in combinedLists) {

                if(taskList.Count() == 0) continue;

                taskList.Dequeue().Execute();
            }
        }

        public void OnAttack() {
            Debug.Log("You destroyed the computer!");
        }
    }
}
