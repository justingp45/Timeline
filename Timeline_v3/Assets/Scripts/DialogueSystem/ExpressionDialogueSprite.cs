using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEditor;
public class ExpressionDialogueSprite : MonoBehaviour
{
  static object[] LeoSprites;
  private Dictionary<Expression,Sprite> LeoExpressionSprite;
  private Dictionary<Expression,Sprite> DespairExpressionSprite;
  private Dictionary<Expression,Sprite> AmyExpressionSprite;
  private Dictionary<Expression,Sprite> IndigoExpressionSprite;
  // Gotta do this in awake cause start doesn't work since DialogueUI immedietely turns this thing off
  // And also cause Untiy doesn't like it when we try to call resources during the initalizer 
  private void Awake(){
    //LeoSprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Sprites/Leo/Leo_Expressions.png").OfType<Sprite>().ToArray();
    //LeoSprites = Resources.LoadAll("Assets/Sprites/Leo/Leo_Expressions.png").OfType<Sprite>().ToArray();
    LeoSprites = Resources.LoadAll("Leo_Expressions",typeof(Sprite));
    // This is essentially letting us know what sprite goes to which expression
    // In the future, we would probably make this dictionary take into account of which character is talking
    // Cause I'm sure not every character would have all the expressions here
    // Or might have specific emotions that Leo doesn't have
    Debug.Log(LeoSprites.Length);
    LeoExpressionSprite = new Dictionary<Expression, Sprite>()
    {
       { Expression.Neutral, (Sprite)LeoSprites[0] },
       { Expression.Happy, (Sprite)LeoSprites[1] },
       { Expression.Frown, (Sprite)LeoSprites[2] },
       { Expression.Sad, (Sprite)LeoSprites[3] },
       { Expression.Shock, (Sprite)LeoSprites[4] },
       { Expression.Upset, (Sprite)LeoSprites[5] },
       { Expression.Angry, (Sprite)LeoSprites[6] },
       { Expression.Thinking, (Sprite)LeoSprites[7] },
       { Expression.Idea, (Sprite)LeoSprites[8] },
       { Expression.Stress, (Sprite)LeoSprites[9] },
       { Expression.Shame, (Sprite)LeoSprites[10] },
       { Expression.Hit, (Sprite)LeoSprites[11] },
       { Expression.Void,(Sprite) LeoSprites[12] },
       { Expression.Sigh,(Sprite) LeoSprites[13]},
       { Expression.Confused,(Sprite) LeoSprites[14] }
    };
    DespairExpressionSprite = new Dictionary<Expression, Sprite>()
    {
      { Expression.Neutral, (Sprite)LeoSprites[15] }
    };
    AmyExpressionSprite = new Dictionary<Expression, Sprite>()
    {
      { Expression.Neutral, (Sprite)LeoSprites[16] }
    };
    IndigoExpressionSprite = new Dictionary<Expression, Sprite>()
    {
      { Expression.Neutral, (Sprite)LeoSprites[17] }
    };
  }
  public void changeExpression(CharacterTalking charSpeaking, Expression givenExpression)
  {
    // It's probably simplier to have a variable that directly holds the image component, but since this thing
    // Won't be called on every frame, screw it.
    if (charSpeaking.Equals(CharacterTalking.Leo))
      {GetComponent<Image>().sprite = LeoExpressionSprite[givenExpression];}
    if (charSpeaking.Equals(CharacterTalking.Despair))
      {GetComponent<Image>().sprite = DespairExpressionSprite[ Expression.Neutral];}
    if (charSpeaking.Equals(CharacterTalking.Amy))
      {GetComponent<Image>().sprite = AmyExpressionSprite[ Expression.Neutral];}
     if (charSpeaking.Equals(CharacterTalking.Indigo))
      {GetComponent<Image>().sprite = IndigoExpressionSprite[ Expression.Neutral];}
  }
}
