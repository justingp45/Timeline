using UnityEngine;
[System.Serializable]
public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private Item requireItem;
    public string ResponseText => responseText;
    public DialogueObject DialogueObject => dialogueObject;
    public Item RequiredItem => requireItem;
    public bool NeedsItem => RequiredItem != null;
    [HideInInspector] public string DTag;
}
