using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;

public class typingeffect : MonoBehaviour
{
    [SerializeField] private float typingSpeed;
    public void Run(string typeingtext, TMP_Text dialogueTexts)
    {
        StartCoroutine(tyingthetext(typeingtext, dialogueTexts));
    }

    public IEnumerator tyingthetext(string typeingtext, TMP_Text dialogueTexts)
    {
        dialogueTexts.text = string.Empty;

        yield return new WaitForSeconds(1);
        float typingtime = 0;
        int characterindex = 0;

        while (characterindex < typeingtext.Length)
        {
//            typingtime += Time.deltaTime;
            typingtime += Time.deltaTime*typingSpeed;
            characterindex = Mathf.FloorToInt(typingtime);
            characterindex = Mathf.Clamp(characterindex, 0, typeingtext.Length);
            dialogueTexts.text = typeingtext.Substring(0, characterindex);
        yield return null;
        }
        dialogueTexts.text = typeingtext;
    }

}
