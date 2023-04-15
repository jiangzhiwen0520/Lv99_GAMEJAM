using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject hintPanel;
    private void Update()
    {
        StartCoroutine(HideCanvas());
    }
    IEnumerator HideCanvas()
    {
        yield return new WaitForSeconds(3f);
        hintPanel.SetActive(false);
    }
}
