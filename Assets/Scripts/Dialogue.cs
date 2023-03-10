using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private bool isTyping = false;
    private int index;
    public Canvas playerUI;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (isTyping) {
                StopAllCoroutines();
                textComponent.text = lines[index];
                isTyping = false;
            } else if (textComponent.text == lines[index]) {
                NextLine();
            } else {
                StopDialogue();
            }
        }
    }

    public void PlayLine(string line) {
        canvas.GetComponent<Canvas>().enabled = true;
        lines = new string[] { line };
        StartDialogue();
    }

    public void PlayLines(string[] lines) {
        canvas.GetComponent<Canvas>().enabled = true;
        this.lines = lines;
        StartDialogue();
    }

    public void StopDialogue() {
        textComponent.text = string.Empty;
        StopAllCoroutines();
        canvas.GetComponent<Canvas>().enabled = false;
        playerUI.GetComponent<Canvas>().enabled = true;
    }

    void StartDialogue() {
        playerUI.GetComponent<Canvas>().enabled = false;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        isTyping = true;
        foreach (char letter in lines[index].ToCharArray()) {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            canvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
