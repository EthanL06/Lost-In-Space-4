using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private void OnDestroy() {
        PlayerPrefs.SetInt("lastLevel", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
