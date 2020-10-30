﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject towerPrefab;

    private GameObject tower = null;

    private SpriteRenderer spriteRenderer;

    public void OnMouseDown()
    {
        TowerHUDHandler hudHandlerReference = Resources.FindObjectsOfTypeAll<TowerHUDHandler>()[0];
        hudHandlerReference.SetSelectedPedestal(gameObject);
        hudHandlerReference.Show();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.gray;
        GameObject sthReference = GameObject.Find("SelectedTowerHandler");
        SelectedTowerHandler sthScript = (SelectedTowerHandler)sthReference.GetComponent(typeof(SelectedTowerHandler));
        sthScript.setCurrTower(this);

        GameObject rcReference = GameObject.Find("RangeCircle");
        RangeCircle rcScript = (RangeCircle)rcReference.GetComponent(typeof(RangeCircle));
        rcScript.MoveRangeCircle(9999, 9999, 1);
    }
    public void Deselect()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
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
        GameObject towerCanvas = GameObject.Find("TowerCanvas");
        tower.transform.SetParent(towerCanvas.transform);
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
