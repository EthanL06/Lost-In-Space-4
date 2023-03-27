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
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public bool hasOptions = false;
    public List<string[]> options = new List<string[]>();

    // Start is called before the first frame update
    void Start()
    {
        options.Add(new string[] {"Uh, hi?", "Who are you?"});
        options.Add(new string[]{"I can help you!", "Me too."});
        options.Add(new string[]{"Yes...", "Yep!"});
        options.Add(new string[]{"Okay.", "You bet!"});


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
                Debug.Log("Next Line " + index);
                NextLine();
            } else {
                Debug.Log("Stop Dialogue");
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

    public void PlayLinesWithOptions(string[] lines) {
        textComponent.text = string.Empty;
        canvas.GetComponent<Canvas>().enabled = true;
        this.lines = lines;
        hasOptions = true;

        StartDialogue();
        
    }

    public void StopDialogue() {
        Debug.Log("Stop Dialogue");
        textComponent.text = string.Empty;
        StopAllCoroutines();
        canvas.GetComponent<Canvas>().enabled = false;
        playerUI.GetComponent<Canvas>().enabled = true;
        lines = new string[] { };
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

        Debug.Log("hasOptions: " + hasOptions);
        Debug.Log("index: " + index);



    }

    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            if (index == lines.Length - 1) {
                hasOptions = false;
            }
            if (hasOptions) {
                ShowOptions(options[index]);
            }
            StartCoroutine(TypeLine());
        } else {
            canvas.GetComponent<Canvas>().enabled = false;
            playerUI.GetComponent<Canvas>().enabled = true;
        }
    }

    public void ShowOptions(string[] options) {
        buttonOne.GetComponentInChildren<TextMeshProUGUI>().text = options[0];
        buttonTwo.GetComponentInChildren<TextMeshProUGUI>().text = options[1];

        buttonOne.SetActive(true);
        buttonTwo.SetActive(true);
    }

    public void HideOptions() {
        buttonOne.SetActive(false);
        buttonTwo.SetActive(false);
    }
    
}
