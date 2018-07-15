using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigid;
    private GameSceneController sceneCon;
    public GameObject bulletPrefab;
    public GameObject direction;

    public float speed = 1;

    private bool bCanFire = true;
    private float reload;
    public float reloadTime = 0.4f;
    public float projectileSpeed = 5.0f;

    private bool bInvincible = false;
    private float invincibleTimer = 2.0f;




    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        sceneCon = GetComponentInParent<GameSceneController>();
        reload= 0f;
        bInvincible = true;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton("Forward"))
        {
            MoveForward();
        }


        if (CrossPlatformInputManager.GetButton("Shoot"))
        {
            if (reload <= 0)
            {
                reload = reloadTime;
                Fire();
            }

        }
        Rotate();

        reload -= Time.deltaTime;

        if (bInvincible)
        {
            invincibleTimer -= Time.deltaTime;
        }
        if (invincibleTimer <= 0)
        {
            bInvincible = false;
        }

    }

    void MoveForward()
    {
        if (rigid == null) { return; }
        Vector2 dir = (direction.transform.position - transform.position).normalized * Time.deltaTime * speed;
        Vector2 newPos = new Vector2 ((transform.position.x + dir.x), (transform.position.y + dir.y));
        rigid.MovePosition(newPos);
    }

    void Rotate()
    {
        if (rigid == null) { return; }

        float rotate = CrossPlatformInputManager.GetAxis("Rotate");
        float zRot = transform.rotation.eulerAngles.z;
        rigid.MoveRotation((zRot - rotate));

    }

    void Fire()
    {
        if (bCanFire)
        {
            Vector2 dir = (direction.transform.position - transform.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, direction.transform.position, transform.rotation);
            bullet.GetComponent<bulletController>().GetDirection(dir);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!bInvincible)
        {
            GameObject asteroid = collider.gameObject;
            if (asteroid.tag == "Asteroid")
            {
                Destroy(asteroid.gameObject);
                Destroy(gameObject);
                if (sceneCon == null) { return; }
                sceneCon.LifeLoss();

            }
        }
    }


}
