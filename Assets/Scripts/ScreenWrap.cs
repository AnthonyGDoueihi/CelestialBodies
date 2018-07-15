using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour {

    private float screenWidth;
    private float screenHeight;

    Transform[] ghosts = new Transform[8];

    // Use this for initialization
    void Start()
    {
        ScreenSize();
        CreateGhosts();
    }

    // Update is called once per frame
    void Update()
    {
        Swap();        
    }

    void ScreenSize()
    {
        Camera cam = Camera.main;

        Vector3 screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        Vector3 screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

        screenWidth = screenTopRight.x - screenBottomLeft.x;
        screenHeight = screenTopRight.y - screenBottomLeft.y;
    }

    void CreateGhosts()
    {
        int i = 0;
        foreach (Transform ghost in ghosts)
        {
            ghosts[i] = Instantiate(transform, transform.position, Quaternion.identity) as Transform;
            ghosts[i].GetComponent<PolygonCollider2D>().enabled = false;
            DestroyImmediate(ghosts[i].GetComponent<ScreenWrap>());
                       
            i++;
        }

        i = 0;
        foreach (Transform ghost in ghosts)
        {
            ghosts[i].transform.parent = gameObject.transform;
            i++;
        }


        PositionGhosts();
    }

    void PositionGhosts()
    {

        Vector3 ghostPosition = transform.position;

        
        ghostPosition.x = transform.position.x + screenWidth;
        ghostPosition.y = transform.position.y;
        ghosts[0].position = ghostPosition;

        ghostPosition.x = transform.position.x + screenWidth;
        ghostPosition.y = transform.position.y - screenHeight;
        ghosts[1].position = ghostPosition;

        ghostPosition.x = transform.position.x;
        ghostPosition.y = transform.position.y - screenHeight;
        ghosts[2].position = ghostPosition;

        ghostPosition.x = transform.position.x - screenWidth;
        ghostPosition.y = transform.position.y - screenHeight;
        ghosts[3].position = ghostPosition;

        ghostPosition.x = transform.position.x - screenWidth;
        ghostPosition.y = transform.position.y;
        ghosts[4].position = ghostPosition;

        ghostPosition.x = transform.position.x - screenWidth;
        ghostPosition.y = transform.position.y + screenHeight;
        ghosts[5].position = ghostPosition;

        ghostPosition.x = transform.position.x;
        ghostPosition.y = transform.position.y + screenHeight;
        ghosts[6].position = ghostPosition;

        ghostPosition.x = transform.position.x + screenWidth;
        ghostPosition.y = transform.position.y + screenHeight;
        ghosts[7].position = ghostPosition;

        int i = 0;
        foreach (Transform ghost in ghosts)
        {
            ghosts[i].rotation = transform.rotation;
        }

        

    }

    void Swap()
    {
        foreach (Transform ghost in ghosts)
        {
            if (ghost.position.x < screenWidth/2 && ghost.position.x > -screenWidth/2 &&
                ghost.position.y < screenHeight/2 && ghost.position.y > -screenHeight/2)
            {
                transform.position = ghost.position;

                break;
            }
        }

        PositionGhosts();
    }
}
