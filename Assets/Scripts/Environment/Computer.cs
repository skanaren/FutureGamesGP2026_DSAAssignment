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
        [SerializeField] TextAsset jsonFile;

        /* LISTCEPTION */
        public List<GenericTaskQueue<Task>> combinedLists = new List<GenericTaskQueue<Task>>();
        [SerializeReference] public GenericTaskQueue<Task> normalTasks = new GenericTaskQueue<Task>();
        [SerializeReference] public GenericTaskQueue<Task> lightTasks = new GenericTaskQueue<Task>();


        private void Awake() {
            isActive = false;
            combinedLists.Add(normalTasks);
            combinedLists.Add(lightTasks);
        }

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

                taskList.Peek().Execute();
                taskList.Dequeue();
            }

            if(jsonFile == null) return;

            Employees[] employees = JsonUtility.FromJson<EmployeeArray>(jsonFile.text)?.employees;

            if(employees != null && employees.Length > 0) return;

            foreach(Employees employee in employees) {
                Debug.Log("Name: " + employee.name);
                Debug.Log("ID: " + employee.employeeId);
            }
        }

        public void OnAttack() {
            Debug.Log("You destroyed the computer!");
        }
    }
}
