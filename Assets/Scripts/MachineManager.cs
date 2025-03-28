using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    public AssignPowerUps assignPowerUpsAccess;
    // Start is called before the first frame update
    void Start()
    {
        assignPowerUpsAccess.Generate();
        assignPowerUpsAccess.DisplayOnMachine();
    }

}
