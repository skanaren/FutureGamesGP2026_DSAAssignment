using System.Diagnostics;
using UnityEngine;

namespace Environment.Tasks {

    [CreateAssetMenu(fileName = "BSTSearch", menuName = "Scriptable Objects/BSTSearch")]
    public class BFSSearch : Task {

        public override void Execute() {

            Stopwatch stopwatch = new();
            stopwatch.Start();

            BST bst = new BST(EmployeeManager.instance.allEmployees[0]);

            for (int i = 1; i < EmployeeManager.instance.allEmployees.Length; i++) {

                bst.Insert(EmployeeManager.instance.allEmployees[i]);
            }

            bst.BFS();
            stopwatch.Stop();

            UnityEngine.Debug.Log("It took: " +  stopwatch.ElapsedMilliseconds + " ms to BFS search");
        }
    }
}
