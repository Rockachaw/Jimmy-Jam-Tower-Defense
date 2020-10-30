using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedElsewhere : MonoBehaviour
{
    public void OnMouseDown()
    {
        TowerHUDHandler hudHandlerReference = Resources.FindObjectsOfTypeAll<TowerHUDHandler>()[0];
        hudHandlerReference.Hide();
        GameObject rcReference = GameObject.Find("RangeCircle");
        RangeCircle rcScript = (RangeCircle)rcReference.GetComponent(typeof(RangeCircle));
        rcScript.MoveRangeCircle(9999, 9999, 1);
        SelectedTowerHandler selectReference = Resources.FindObjectsOfTypeAll<SelectedTowerHandler>()[0];
        selectReference.stopSelecting();
    }
}
