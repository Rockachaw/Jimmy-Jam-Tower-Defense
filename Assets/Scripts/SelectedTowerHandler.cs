using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTowerHandler : MonoBehaviour
{
    Tower currTower = null;
    Tower prevTower = null;

    public void setCurrTower(Tower tower)
    {
        prevTower = currTower;
        currTower = tower;
        if(prevTower != null)
        {
            prevTower.Deselect();
        }
    }
}
