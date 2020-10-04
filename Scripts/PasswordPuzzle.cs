using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordPuzzle : MonoBehaviour
{
    public GameObject puzzlePanel;
    public GameObject puzzleDoor;
    public Animator animator;
    public Sprite[] numberSymbols;
    public Image[] symbolDisplays;
    int[] numbers = {0, 0, 0};
    int[] answers = {7, 5, 3};

    void Start()
    {
        Debug.Log(answers[0]);
        Debug.Log(answers[1]);
        Debug.Log(answers[2]);
        
        animator = GetComponent<Animator>();

        int i = 0;
        foreach (int num in numbers)
        {
            numbers[i] = Mathf.RoundToInt(Random.Range(1f, 7f));
            i++;
        }
        while (numbers == answers)
        {
            i = 0;
            foreach (int num in numbers)
            numbers[i] = Mathf.RoundToInt(Random.Range(1f, 7f));
            if (i < 3)
            {
                i++;
            }
            else { i = 0; }
        }
        UpdateImage();
    }

    void UpdateImage()
    {
        int i = 0;
        foreach (int num in numbers)
        {
            symbolDisplays[i].GetComponent<Image>().sprite = numberSymbols[num - 1];
            i++;
        }
    }

    public void LowerNumber(int buttonNum)
    {
        switch(buttonNum)
        {
            case 1:
                if (numbers[0] > 1)
                {numbers[0]--;
                UpdateImage();}
                else { return; }
                break;
            case 2:
                if (numbers[1] > 1)
                {numbers[1]--;
                UpdateImage();}
                else { return; }
                break;
            case 3:
                if (numbers[2] > 1)
                {numbers[2]--;
                UpdateImage();}
                else { return; }
                break;
        }
    }

    public void RaiseNumber(int buttonNum)
    {
        switch(buttonNum)
        {
            case 1:
                if (numbers[0] < 7)
                {numbers[0]++;
                UpdateImage();}
                else { return; }
                break;
            case 2:
                if (numbers[1] < 7)
                {numbers[1]++;
                UpdateImage();}
                else { return; }
                break;
            case 3:
                if (numbers[2] < 7)
                {numbers[2]++;
                UpdateImage();}
                else { return; }
                break;
        }
    }

    public void CheckAnswer()
    {
        if ( numbers[0] == answers[0] && numbers [1] == answers [1] && numbers [2] == answers[2])
        {
            puzzlePanel.SetActive(false);
            puzzleDoor.SetActive(false);
        }
        if (numbers != answers)
        {
            animator.SetTrigger("wrong");
        }
    }

    public void OpenWindow()
    {
        puzzlePanel.SetActive(true);
    }

    public void CloseWindow()
    {
        puzzlePanel.SetActive(false);
    }
}
