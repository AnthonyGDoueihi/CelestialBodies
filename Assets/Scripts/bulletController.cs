using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

    private Rigidbody2D rigid;
    private Vector2 dir;
    public float bulletSpeed = 10.0f;
    private float screenWidth;
    private float screenHeight;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        ScreenSize();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        InPlay();
	}

    public void GetDirection(Vector2 direction)
    {
        dir = direction * Time.deltaTime * bulletSpeed;
    }

    void Move()
    {
        if (rigid == null) { return; }
        Vector2 newPos = new Vector2((transform.position.x + dir.x) , (transform.position.y + dir.y));
        rigid.MovePosition(newPos);
    }

    void InPlay()
    {
        if (transform.position.x > screenWidth / 2 || transform.position.x < -screenWidth / 2 ||
    transform.position.y > screenHeight / 2 || transform.position.y < -screenHeight / 2)
        {
            Destroy(gameObject);
        }
    }

    void ScreenSize()
    {
        Camera cam = Camera.main;

        Vector3 screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        Vector3 screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

        screenWidth = screenTopRight.x - screenBottomLeft.x;
        screenHeight = screenTopRight.y - screenBottomLeft.y;
    }


}
