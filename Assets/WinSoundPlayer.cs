using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        SoundManagerScript.PlaySound("win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
