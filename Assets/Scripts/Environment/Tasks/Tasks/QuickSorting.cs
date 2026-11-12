using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

namespace Environment.Tasks {

    [CreateAssetMenu(fileName = "SortingTask", menuName = "Scriptable Objects/SortingTask")]
    public class QuickSorting : Task{

        public override void Execute() {

            QuickSort(EmployeeManager.instance.allEmployees, 0, EmployeeManager.instance.allEmployees.Length - 1);
            Debug.Log("Sorted");
        }

       public static void QuickSort(Employees[] inArray, int first, int last) {

            if (first < last) {

                int pivotIndex = Partition(inArray, first, last);
                QuickSort(inArray, first, pivotIndex - 1);
                QuickSort(inArray, pivotIndex  + 1, last);
            }
        }

        public static int Partition(Employees[] inArray, int first, int last) {

            int ranIndex = UnityEngine.Random.Range(first, last + 1);
            DateTime pivot = DateTime.ParseExact(inArray[ranIndex].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            Employees randomArray = inArray[ranIndex];
            inArray[ranIndex] = inArray[last];
            inArray[last] = randomArray;

            int i = first - 1;

            for(int j = first; j < last; j++) {

                if(DateTime.ParseExact(inArray[j].lastEntranceInEngineRoom, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) < pivot) {

                    i = i + 1;

                    Employees temp2Array = inArray[j];
                    inArray[j] = inArray[i];
                    inArray[i] = temp2Array;
                }
            }

            Employees tempArray = inArray[last];
            inArray[last] = inArray[i + 1];
            inArray[i + 1] = tempArray;

            return i + 1;
        }
    }
}
