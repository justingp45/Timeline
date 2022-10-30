using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
   [SerializeField] [TextArea] private string[] dialogue;
   [SerializeField] private DialogueTextData[] dialogueData;
   [SerializeField] private Response[] responses;
   [SerializeField] private DialogueObject nextDialogue;
   [SerializeField] private bool isSpecialDialogue;
   public bool IsSpecialDialogue => isSpecialDialogue;
   public DialogueObject NextDialgoue => nextDialogue;
   public bool HasNextDialogue => NextDialgoue != null;
   public string[] Dialogue => dialogue;
   public DialogueTextData[] DialogueData => dialogueData;
   public bool HasResponses => Responses != null && Responses.Length > 0;
   public Response[] Responses => responses;
}
