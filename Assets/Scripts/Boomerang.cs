using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 100;
    bool returning = false;

    private Transform playerTrans;
    float boomerangTimer;

    Vector3 playerDir;
    void OnEnable()
    {

        playerTrans = GameObject.Find("Link").transform;
        boomerangTimer = 0.0f;
    }
    private void Start()
    {
        playerDir = playerTrans.gameObject.GetComponent<PlayerController>().pDirection;

        transform.position = playerTrans.position + playerDir;

        gameObject.transform.parent = null;
    }
    void Update()
    {
        boomerangTimer += Time.deltaTime;

        if (boomerangTimer >= 1f)
        {
            
            returning = true;
            transform.position = Vector2.MoveTowards(transform.position, playerTrans.position, speed * Time.deltaTime);

        }

        else if (boomerangTimer < 1f)
        {
            transform.position = transform.position + playerDir * speed * Time.deltaTime;
            
        }
   
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (returning)
            {
                Destroy(gameObject);
            }
        }
    }
}
