using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
//    [SerializeField] private TMP_Text nameBox;
    [SerializeField] private TMP_Text dialogueBox;


    // Start is called before the first frame update
    void Start()
    {
        //        dialogueBox.text = "This is a big test";
        //        dialogueBox.text = "This is a big test\nwe will continue this at a later date!";
        //        dialogueBox.text = "This is a big test\nwe will chat later!\ngoodbye sucker";
        //        GetComponent<typingeffect>().Run("testing this new dialogue", dialogueBox);
        //        GetComponent<typingeffect>().Run("testing this new dialogue\nwith new typing effect", dialogueBox);
        GetComponent<typingeffect>().Run("testing this new dialogue\nwith new typing effect\nI hope the resizing works\nfor extra lines.", dialogueBox);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
