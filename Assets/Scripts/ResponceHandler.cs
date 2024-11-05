using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponceHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responceBox;
    [SerializeField] private RectTransform responceButtonTemplate;
    [SerializeField] private RectTransform responceContainer;

    private DialogueUI dialogueUI;

    private List<GameObject> tempResponceButton = new List<GameObject>();

    public void Start()
    {
        responceButtonTemplate.GetComponent<TMP_Text>().text = string.Empty;
        dialogueUI = GetComponent<DialogueUI>();
    }
    public void ShowResponces(Responce[] responces)
    {
        float responceBoxWidth = 0f;
        float responceBoxHeight = 0f;

        foreach (Responce responce in responces)
        {
            responceBox.gameObject.SetActive(true);
            GameObject responceButton = Instantiate(responceButtonTemplate.gameObject, responceContainer);
            responceButton.gameObject.SetActive(true);
            responceButton.GetComponent<TMP_Text>().text = responce.ResponceText;
            responceButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponce(responce));

            tempResponceButton.Add(responceButton);

            responceBoxWidth += responceButtonTemplate.sizeDelta.y;
            responceBoxHeight += responceButtonTemplate.sizeDelta.x;
        }
        responceBox.sizeDelta = new Vector2(responceBoxHeight, responceBoxWidth);
        responceBox.gameObject.SetActive(true);
    }

    public void OnPickedResponce(Responce responce)
    {

        responceBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponceButton)
        {
            Destroy(button);
        }

        dialogueUI.ShowingDialogue(responce.DialogueObject);
    }
}
