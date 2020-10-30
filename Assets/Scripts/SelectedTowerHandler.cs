using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTowerHandler : MonoBehaviour
{
    Pedestal currTower = null;
    Pedestal prevTower = null;

    public void setCurrTower(Pedestal tower)
    {
        prevTower = currTower;
        currTower = tower;
        if(prevTower != null)
        {
            prevTower.Deselect();
        }
    }

    public void stopSelecting()
    {
        try
        {
            currTower.Deselect();
        }
        catch
        {
            Debug.LogError("Failed to deselect currTower");
        }
    }

    public Pedestal GetSelectedPedestal()
    {
        return currTower;
    }
}
