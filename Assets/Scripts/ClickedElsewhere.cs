using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedElsewhere : MonoBehaviour
{
    public void OnMouseDown()
    {
        TowerHUDHandler hudHandlerReference = Resources.FindObjectsOfTypeAll<TowerHUDHandler>()[0];
        hudHandlerReference.Hide();
    }
}
