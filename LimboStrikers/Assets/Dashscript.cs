using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashscript : MonoBehaviour
{
    SpriteRenderer sprite;
    private float timer = 0.2f;
    private GameObject Player;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
        transform.position = Player.transform.position;
        transform.localScale = Player.transform.localScale;
        sprite.sprite = Player.GetComponent<MyCharacterController>().playerSprite.sprite;
        sprite.color = new Vector4(50, 50, 50, 0.2f);

    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
