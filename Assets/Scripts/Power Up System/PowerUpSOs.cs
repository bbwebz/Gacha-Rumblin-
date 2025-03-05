using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PowerUpSOs : ScriptableObject
{
    public string powerUpName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChange;

    public void UsePowerUp()
    {
        if (statToChange == StatToChange.Health)
        {
            Debug.Log("less Health!");
        }
        else if (statToChange == StatToChange.Damage)
        {
            Debug.Log("More Damage!");

        }
    }

    public enum StatToChange
    {
        None,
        Health,
        Damage,
    }


}
