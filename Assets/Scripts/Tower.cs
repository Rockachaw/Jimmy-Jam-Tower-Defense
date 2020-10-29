using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject towerPrefab;

    private GameObject tower = null;

    public void OnMouseDown()
    {
        TowerHUDHandler hudHandlerReference = Resources.FindObjectsOfTypeAll<TowerHUDHandler>()[0];
        hudHandlerReference.SetSelectedPedestal(gameObject);
        hudHandlerReference.Show();
    }
    public bool TowerExists()
    {
        if(tower != null)
        {
            return true;
        }
        return false;
    }
    public void CreateTower(GameObject newTowerPrefab)
    {
        towerPrefab = newTowerPrefab;
        tower = (GameObject)Instantiate(towerPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
    public void DestroyTower()
    {
        try
        {
            tower = null;
        }
        catch
        {
            Debug.LogError("Failed to destroy towerObject.");
        }
    }
}
