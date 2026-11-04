using Environment;
using Environment.Tasks;
using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Enviornment.Tasks {

    [CreateAssetMenu(fileName = "BinarySearch", menuName = "Scriptable Objects/BinarySearch")]
    public class BinarySearch : Task {

        public override void Execute() {

            int low = Search(EmployeeManager.instance.allEmployees, new DateTime(1970, 01, 01));
            int high = Search(EmployeeManager.instance.allEmployees, new DateTime(2234, 08, 07, 20, 44, 44));
            int i = low;
            for (int j = 0; i <= high; i++) {

                Debug.Log("You searched for: " + EmployeeManager.instance.allEmployees[i].name + "\n" + EmployeeManager.instance.allEmployees[i].lastEntranceInEngineRoom);
            }
        }

        public static int Search(Employees[] inArray, DateTime elementToSearch) {

            int low = 0, high = inArray.Length - 1;

            while(low <= high) {

                int median = low + (high - low) / 2;

                if(DateTime.Parse(inArray[median].lastEntranceInEngineRoom) == elementToSearch) {

                    return median;
                }
                if(DateTime.Parse(inArray[median].lastEntranceInEngineRoom) < elementToSearch) {

                    low = median + 1;
                }
                else if(DateTime.Parse(inArray[median].lastEntranceInEngineRoom) > elementToSearch) {

                    high = median - 1;
                }

            }
            return -1;
        }
    }
}
