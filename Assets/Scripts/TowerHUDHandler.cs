using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHUDHandler : MonoBehaviour
{
    private GameObject selectedPedestal;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    public void SetSelectedPedestal(GameObject pedestal)
    {
        selectedPedestal = pedestal;
    }

    public GameObject GetSelectedPedestal()
    {
        return selectedPedestal;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
