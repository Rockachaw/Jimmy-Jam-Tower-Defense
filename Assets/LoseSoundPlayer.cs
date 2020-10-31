using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        SoundManagerScript.PlaySound("gameover");
    }

    // Update is called once per frame
    void Update()
    {

    }
}