//create a script that makes the platform fade away after there is player contact
//then the platform reappears after a set amount of time

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingPlatform : MonoBehaviour
{
    public float time;
    public float dissapearTime;
    public float reappearTime;
    private MeshRenderer mesh;
    private BoxCollider2D box;
    private bool dissapear;
    private bool reappear;
    private float timer;
    private float disTimer;
    private float reapTimer;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dissapear)
        {
            disTimer += Time.deltaTime;
            if (disTimer > dissapearTime)
            {
                mesh.enabled = false;
                box.enabled = false;
                disTimer = 0;
                dissapear = false;
                reappear = true;
            }
        }

        if (reappear)
        {
            reapTimer += Time.deltaTime;
            if (reapTimer > reappearTime)
            {
                mesh.enabled = true;
                box.enabled = true;
                reapTimer = 0;
                reappear = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dissapear = true;
        }
    }
}