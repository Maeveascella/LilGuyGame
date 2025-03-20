using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text text;
    public GameObject textBox;
    public string[] lines;
    public float textSpeed = .2f;

    private int _index;
    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        _index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) | Input.GetKeyDown(KeyCode.E))
        {
            if (text.text == lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[_index];
            }
        }
    }
    void NextLine()
    {
        if (_index < lines.Length - 1)
        {
            _index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textBox.SetActive(false);
        }
    }

        public void StartDialogue(string[] dialogue)
    {
        text.text = string.Empty;
        textBox.SetActive(true);
        lines = dialogue;
        _index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            yield return new WaitForSeconds(textSpeed);
            text.text += c;
        }
    }
}
