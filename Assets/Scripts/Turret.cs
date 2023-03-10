using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public GameObject turret;
    public Transform bulletSpawn;
    public bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        // Look in direction of player on the y axis
        turret.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
        // Rotate the bulletSpawn's forward vector to the direction of the player
        bulletSpawn.transform.rotation = Quaternion.LookRotation(player.transform.position - bulletSpawn.transform.position);
    }

    IEnumerator Shoot() {
        while (true) {
            if (isShooting) {
                // Spawn bullet and add force
                GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                // Translate toward the player
                newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * 1000);

                Destroy(newBullet, 2f);

            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Player entered turret range");
            isShooting = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Player exited turret range");
            isShooting = false;
        }
    }
}
