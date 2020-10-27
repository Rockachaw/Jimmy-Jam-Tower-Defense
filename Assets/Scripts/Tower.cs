using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject towerPrefab;

    private GameObject tower = null;

    public void CreateTower()
    {
        tower = (GameObject)Instantiate(towerPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
    public void DestroyTower()
    {
        try
        {
            tower = null; ;
        }
        catch
        {
            Debug.LogError("Failed to destroy towerObject.");
        }
    }
}
