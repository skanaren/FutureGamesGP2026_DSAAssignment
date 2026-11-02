using Environment;
using Environment.Tasks;
using UnityEngine;

public class EmployeeManager : MonoBehaviour
{
    public static EmployeeManager instance;
    public Employees[] allEmployees;

    private void Awake() {

        instance = this;
    }
}
