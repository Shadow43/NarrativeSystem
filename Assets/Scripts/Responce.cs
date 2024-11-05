using UnityEngine;
[System.Serializable]
public class Responce
{
    [SerializeField] private string responceText;
    [SerializeField] private DialogueObject dialogueObject;
    public string ResponceText => responceText;
    public DialogueObject DialogueObject => dialogueObject;

}
