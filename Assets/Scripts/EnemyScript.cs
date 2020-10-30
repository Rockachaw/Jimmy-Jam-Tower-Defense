using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public float maxHealth;
    public float moneyDropped;
    public Sprite[] enemySpriteArray;

    private Transform target;
    private int waypointIndex = 0;

    private float healthBarLength;
    private Vector2 healthBarPos;
    
    private float health;

    private SpriteRenderer enemySpriteRenderer;

    //Notes which frame of the animation the enemy is on
    private int animationCycleIndex = 0;

    //Animation is a 3 frame cycle and the middle fram is the neutral pose, so we want to
    //  animate in the order 1-2-3-2-1-2-3-2...
    private bool animationCycleReversing = false;

    //Determines framerate of animation
    private float animationCycleCooldown = 0.2f;

    void Start()
    {
        enemySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        enemySpriteRenderer.sprite = enemySpriteArray[0];
        target = Waypoints.points[0];
        healthBarLength = Screen.width / 6;
        health = maxHealth;
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        dir = dir.normalized;

        //Move
        transform.Translate(dir * speed * Time.deltaTime, Space.World);

        //Reached waypoint, find next one.
        if (Vector2.Distance(transform.position, target.position) <= 0.04f)
        {
            GetNextWaypoint();
        }

        //Handle animation
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            //Moving more x than y
            if (dir.x > 0)
            {
                //Moving right
                enemySpriteRenderer.sprite = enemySpriteArray[6 + animationCycleIndex];
            }
            else
            {
                //Moving left
                enemySpriteRenderer.sprite = enemySpriteArray[3 + animationCycleIndex];
            }
        }
        else
        {
            //Moving more y than x
            if (dir.y > 0)
            {
                //Moving up
                enemySpriteRenderer.sprite = enemySpriteArray[9 + animationCycleIndex];
            }
            else
            {
                //Technically default case if not moving, but enemies should always be moving.
                //Moving down
                enemySpriteRenderer.sprite = enemySpriteArray[0 + animationCycleIndex];
            }
        }

        //Progress animation cycle
        animationCycleCooldown -= Time.deltaTime;
        if (animationCycleCooldown <= 0)
        {
            animationCycleCooldown = 0.2f;

            if (animationCycleReversing)
            {
                animationCycleIndex--;
            }
            else
            {
                animationCycleIndex++;
            }

            if (animationCycleIndex != 1)
            {
                animationCycleReversing = !animationCycleReversing;
            }
        }
    }

    void OnGUI()
    {
        healthBarPos = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Box(new Rect(healthBarPos.x - 25, Screen.height - healthBarPos.y - 40, 60, 20), (int)health + "/" + maxHealth);
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            GameObject healthReference = GameObject.Find("Health");
            HeartController healthScript = (HeartController)healthReference.GetComponent(typeof(HeartController));
            healthScript.LoseHealth();

            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void GetDamaged(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0.0f)
        {
            GameObject moneyReference = GameObject.Find("Money");
            MoneyHandler moneyScript = (MoneyHandler)moneyReference.GetComponent(typeof(MoneyHandler));
            moneyScript.GainMoney(moneyDropped);

            Destroy(gameObject);
        }
    }

    public int GetWaypointIndex()
    {
        return waypointIndex;
    }
    public float GetDistanceToNextWaypoint()
    {
        return Vector2.Distance(transform.position, target.position);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
