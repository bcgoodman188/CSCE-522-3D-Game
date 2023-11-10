using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VacuumData
{
    public int active;
    public int[] bullets;
    public VacuumData(VacuumGun gun) 
    {
        active = gun.saveActive;
        bullets = new int[3];

        bullets[0] = gun.savedRed;
        bullets[1] = gun.savedGreen;
        bullets[2] = gun.savedBlue;
    }
}
