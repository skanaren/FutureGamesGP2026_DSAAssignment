using System.Diagnostics;
using UnityEngine;

namespace Environment.Tasks {

    [CreateAssetMenu(fileName = "DFSSearch", menuName = "Scriptable Objects/DFSSearch")]
    public class DFSSearch : Task {

        public override void Execute() {

            Stopwatch stopwatch = new();
            stopwatch.Start();

            BST bst = new BST(EmployeeManager.instance.allEmployees[0]);

            for (int i = 1; i < EmployeeManager.instance.allEmployees.Length; i++) {

                bst.Insert(EmployeeManager.instance.allEmployees[i]);
            }

            bst.DFS();
            stopwatch.Stop();

            UnityEngine.Debug.Log("It took: " + stopwatch.ElapsedMilliseconds + " ms to DFS search");
        }
    }
}

