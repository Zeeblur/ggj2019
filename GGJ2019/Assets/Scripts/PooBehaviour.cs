using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooBehaviour : MonoBehaviour
{
    private PlayerBehaviour player;
    public float scrollSpeed = 2.0f;
    
    void Start()
    {
        GameObject playerGo = GameObject.FindGameObjectWithTag("Player");
        player = playerGo.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Time.deltaTime * scrollSpeed;
        transform.position += Vector3.down * newPosition;

        if (transform.position.y < -5)
        {
            kill();
        }
    }

    void kill()
    {
        //Debug.Log("i am ded");
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.tag == "gem")
        {
            Debug.Log("Woo!");
            player.Win();
        }
        else
        {
            Debug.Log("ouch");
            player.Hurt();
        }

    }

}
