using UnityEngine;
[System.Serializable]
public class DialogueTextData
{
    [SerializeField] [TextArea] private string dialogueText;
    [SerializeField] private CharacterTalking characterSpeaking;
    [SerializeField] private Expression expression;
    public string DialogueText => dialogueText;
    public CharacterTalking CharSpeaking => characterSpeaking;
    public Expression CharExprssion => expression;
}
 public enum CharacterTalking
 {
      None,
      Leo,
      Despair
 }
  public enum Expression
 {
      Neutral,
      Happy,
      Frown,
      Sad,
      Shock,
      Upset,
      Angry,
      Thinking,
      Idea,
      Stress,
      Shame,
      Hit,
      Void
 }
