using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    [SerializeField] private Responce[] responces;
    public string[] Dialogue => dialogue;
    public bool HasResponces => Responces != null && Responces.Length > 0;
    public Responce[] Responces => responces;
}