using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endd : MonoBehaviour
{

    public Cinemachine.CinemachineFreeLook freelook;
    public Transform ship;
    public GameObject player;
    public Animator shipAnimator;
    public Dialogue dialogue;
    public Canvas playerUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private IEnumerator Play() {
        player.SetActive(false);
        
        yield return new WaitForSeconds(2);

        playerUI.GetComponent<Canvas>().enabled = false;

        freelook.Follow = ship.GetComponent<Transform>();
        freelook.LookAt = ship.GetComponent<Transform>();

        shipAnimator.Play("Launch");

        yield return new WaitForSeconds(10);

        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Player entered trigger");
            StartCoroutine("Play");
        }
    }
}
