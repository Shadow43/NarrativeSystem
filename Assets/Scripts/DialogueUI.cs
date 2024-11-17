using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
//    [SerializeField] private TMP_Text nameBox;
    [SerializeField] private TMP_Text dialogueBox;
    [SerializeField] private DialogueObject dialogue;
    [SerializeField] private GameObject speechBox;
    [SerializeField] private GameObject tutorial;

    private TypingEffect typingEffect;
    private ResponceHandler responceHandler;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gamestart());

//        dialogueBox.text = "This is a big test";
//        dialogueBox.text = "This is a big test\nwe will continue this at a later date!";
//        dialogueBox.text = "This is a big test\nwe will chat later!\ngoodbye sucker";
//        GetComponent<typingeffect>().Run("testing this new dialogue", dialogueBox);
//        GetComponent<typingeffect>().Run("testing this new dialogue\nwith new typing effect", dialogueBox);
//        GetComponent<typingeffect>().Run("testing this new dialogue\nwith new typing effect\nI hope the resizing works\nfor extra lines.", dialogueBox);
        typingEffect = GetComponent<TypingEffect>();
        responceHandler = GetComponent<ResponceHandler>();
        CloseTheDialogueBox();
//        ShowingDialogue(dialogue);

    }
    public void ShowingDialogue(DialogueObject dialogueObject)
    {
        speechBox.SetActive(true);
        StartCoroutine (TheDialogue(dialogueObject));
    }
    private IEnumerator Gamestart()
    {
        speechBox.SetActive(false);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        tutorial.SetActive(false);
        speechBox.SetActive(true);
        ShowingDialogue(dialogue);
    }
    private IEnumerator TheDialogue(DialogueObject dialogueObect)
    {
//        foreach (string dialogue in dialogueObect.Dialogue)
//        {
//            yield return typingEffect.Run(dialogue, dialogueBox);
//            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
//            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
//        }

        for (int i = 0; i < dialogueObect.Dialogue.Length; i++)
        {
            string dialogue = dialogueObect.Dialogue[i];
            yield return typingEffect.Run(dialogue, dialogueBox);
//            if (i == dialogueObect.Dialogue.Length - 1 && dialogueObect.Responces != null && dialogueObect.Responces.Length > 0) break;
            if (i == dialogueObect.Dialogue.Length - 1 && dialogueObect.HasResponces) break;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        if (dialogueObect.HasResponces)
        {
            responceHandler.ShowResponces(dialogueObect.Responces);
        }
        else
        {
            CloseTheDialogueBox();
        }

    }

    private void CloseTheDialogueBox()
    {
        speechBox.SetActive(false);
        dialogueBox.text = string.Empty;
    }
}
