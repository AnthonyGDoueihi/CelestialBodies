using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTinyController : MonoBehaviour {

    private SpriteRenderer sprite;
    private Rigidbody2D rigid;
    public GameSceneController sceneCon;

    private Vector2 dir;
    public float speed = 6f;

    private float screenWidth;
    private float screenHeight;

    private Sprite[] sprites = new Sprite[2];
    public Sprite sprite1;
    public Sprite sprite2;

    private bool isWrappingX = false;
    private bool isWrappingY = false;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        sceneCon = GetComponentInParent<GameSceneController>();


        if (sprite1 != null)
        {
            sprites[0] = sprite1;
        }
        if (sprite1 != null)
        {
            sprites[1] = sprite2;
        }

        if (sprite == null) { return; }
        sprite.sprite = sprites[Random.Range(0, 1)];
        dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

    }


    // Update is called once per frame
    void Update()
    {
        ScreenWrap();

        if (rigid == null) { return; }
        Vector2 newMove = dir.normalized * Time.deltaTime * speed;
        Vector2 newPos = new Vector2((transform.position.x - newMove.x), (transform.position.y - newMove.y));
        rigid.MovePosition(newPos);


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject laser = collider.gameObject;
        if (laser.GetComponent<bulletController>() != null)
        {
            sceneCon.AddScore(20);
            Destroy(laser.gameObject);
            Destroy(gameObject);

        }
    }

    void ScreenWrap()
    {
        bool isVisible = CheckRenderers();
        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        if (isWrappingX && isWrappingY)
        {
            return;
        }

        Camera cam = Camera.main;
        Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
        Vector3 newPosition = transform.position;

        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;

            isWrappingX = true;
        }

        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;

            isWrappingY = true;
        }

        transform.position = newPosition;
    }

    bool CheckRenderers()
    {
        if (sprite == null) { return false; }
        
        if (sprite.isVisible)
        {
            return true;
        }


        return false;
    }
}
