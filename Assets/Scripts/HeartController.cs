using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartController : MonoBehaviour
{
    public GameObject heartSprite;
    public int Health = 4;
    public Vector3 heartPosition;
    public float distanceBetweenHearts;

    private GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        hearts = new GameObject[Health];
        heartSprite.transform.position = heartPosition;
        Transform adjustedTransform = heartSprite.transform;

        for(int i = 0; i < Health; i++)
        {
            hearts[i] = (GameObject)Instantiate(heartSprite, adjustedTransform);
            adjustedTransform.Translate(distanceBetweenHearts, 0.0f, 0.0f);
        }
    }

    public void LoseHealth()
    {
        for(int i = hearts.Length-1; i >= 0; i--)
        {
            if(hearts[i] != null)
            {
                Destroy(hearts[i]);
                return;
            }
        }
        Debug.LogError("Out of health, game over");
        SceneManager.LoadScene("GameOverScene");
    }
}
