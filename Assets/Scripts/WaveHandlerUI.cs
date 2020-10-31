using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveHandlerUI : MonoBehaviour
{
    public float currWave = 0;
    Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        waveText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject waveReference = GameObject.Find("Wave Spawner");
        WaveSpawner waveScript = (WaveSpawner)waveReference.GetComponent(typeof(WaveSpawner));
        currWave = waveScript.GetWave();
        waveText.text = currWave.ToString();
    }
}
