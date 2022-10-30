using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuzzleBgHandler : MonoBehaviour
{
    [SerializeField] private Sprite[] bgSprites;
    public void changeBG(int index)
    {
        //Debug.Log("f");
        if (index >= bgSprites.Length && index < 0) return;
        //Debug.Log(index);
        GetComponent<Image>().sprite = bgSprites[index];
    }
}
