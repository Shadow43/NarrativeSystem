using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
//    [SerializeField] private TMP_Text nameBox;
    [SerializeField] private TMP_Text dialogueBox;
    [SerializeField] private DialogueObject obiwandialogue;
    [SerializeField] private GameObject speechBox;

    private TypingEffect typingEffect;

    // Start is called before the first frame update
    void Start()
    {
//        dialogueBox.text = "This is a big test";
//        dialogueBox.text = "This is a big test\nwe will continue this at a later date!";
//        dialogueBox.text = "This is a big test\nwe will chat later!\ngoodbye sucker";
//        GetComponent<typingeffect>().Run("testing this new dialogue", dialogueBox);
//        GetComponent<typingeffect>().Run("testing this new dialogue\nwith new typing effect", dialogueBox);
//        GetComponent<typingeffect>().Run("testing this new dialogue\nwith new typing effect\nI hope the resizing works\nfor extra lines.", dialogueBox);
        typingEffect = GetComponent<TypingEffect>();
        CloseTheDialogueBox();
        ShowingDialogue(obiwandialogue);
    }
    public void ShowingDialogue(DialogueObject dialogueObject)
    {
        speechBox.SetActive(true);
        StartCoroutine (TheDialogue(dialogueObject));
    }

    private IEnumerator TheDialogue(DialogueObject dialogueObect)
    {
        yield return new WaitForSeconds(2);
        foreach (string dialogue in dialogueObect.Dialogue)
        {
            yield return typingEffect.Run(dialogue, dialogueBox);
            //            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
        CloseTheDialogueBox();
    }

    private void CloseTheDialogueBox()
    {
        speechBox.SetActive(false);
        dialogueBox.text = string.Empty;
    }
}
