using Environment;
using Environment.Tasks;
using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Enviornment.Tasks {

    [CreateAssetMenu(fileName = "BinarySearch", menuName = "Scriptable Objects/BinarySearch")]
    public class BinarySearch : Task {

        Stopwatch stopwatch = new Stopwatch();

        public override void Execute() {

            stopwatch.Start();

            int low = Search(EmployeeManager.instance.allEmployees, new DateTime(1970, 01, 01));
            int high = Search(EmployeeManager.instance.allEmployees, new DateTime(2234, 08, 07, 20, 44, 44));

            for (int i = low; i <= high; i++) {

                UnityEngine.Debug.Log("You searched for: " + EmployeeManager.instance.allEmployees[i].name + "\n"
                    + EmployeeManager.instance.allEmployees[i].lastEntranceInEngineRoom);
            }

            stopwatch.Stop();
            UnityEngine.Debug.Log("Search took: " + stopwatch.ElapsedMilliseconds + " ms");
            UnityEngine.Debug.Log(low + ", " + high);
        }

        public static int Search(Employees[] inArray, DateTime elementToSearch) {

            int low = 0, high = inArray.Length - 1;

            while(low <= high) {

                int median = low + (high - low) / 2;

                if(DateTime.ParseExact(inArray[median].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) == elementToSearch) {

                    return median;
                }
                if(DateTime.ParseExact(inArray[median].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) < elementToSearch) {

                    low = median + 1;
                }
                else if(DateTime.ParseExact(inArray[median].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) > elementToSearch) {

                    high = median - 1;
                }
            }
            return -1;
        }
    }
}
