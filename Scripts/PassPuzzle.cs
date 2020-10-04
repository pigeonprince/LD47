using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPuzzle : MonoBehaviour
{
    public GameObject puzzlePanel;
    public GameObject puzzleMemo;

    public void OpenPuzzle()
    {
        puzzlePanel.SetActive(true);
    }
        public void OpenMemo()
    {
        puzzleMemo.SetActive(true);
    }

    public void CloseMemo()
    {
        puzzleMemo.SetActive(false);
    }
}
