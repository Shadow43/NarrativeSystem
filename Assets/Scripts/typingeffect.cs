using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    [SerializeField] private float typingSpeed;
    //    public void Run(string typeingtext, TMP_Text dialogueTexts)
    //    {
    //        StartCoroutine(tyingthetext(typeingtext, dialogueTexts));
    //    }
    public Coroutine Run(string typeingtext, TMP_Text dialogueTexts)
    {
        return StartCoroutine(tyingthetext(typeingtext, dialogueTexts));
    }

    public IEnumerator tyingthetext(string typeingtext, TMP_Text dialogueTexts)
    {
        dialogueTexts.text = string.Empty;

//        yield return new WaitForSeconds(1);
        float typingtime = 0;
        int characterindex = 0;

        while (characterindex < typeingtext.Length)
        {
            //            typingtime += Time.deltaTime;
            typingtime += Time.deltaTime * typingSpeed;
            characterindex = Mathf.FloorToInt(typingtime);
            characterindex = Mathf.Clamp(characterindex, 0, typeingtext.Length);
            dialogueTexts.text = typeingtext.Substring(0, characterindex);
            yield return null;
        }
        dialogueTexts.text = typeingtext;
    }
}
