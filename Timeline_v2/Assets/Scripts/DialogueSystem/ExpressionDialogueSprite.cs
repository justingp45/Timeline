using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEditor;
public class ExpressionDialogueSprite : MonoBehaviour
{
  static Sprite[] LeoSprites;
  private Dictionary<Expression,Sprite> expressionSprite;
  // Gotta do this in awake cause start doesn't work since DialogueUI immedietely turns this thing off
  // And also cause Untiy doesn't like it when we try to call resources during the initalizer 
  private void Awake(){
    LeoSprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Sprites/Leo/Leo_Expressions.png").OfType<Sprite>().ToArray();
    // This is essentially letting us know what sprite goes to which expression
    // In the future, we would probably make this dictionary take into account of which character is talking
    // Cause I'm sure not every character would have all the expressions here
    // Or might have specific emotions that Leo doesn't have
    expressionSprite = new Dictionary<Expression, Sprite>()
    {
       { Expression.Neutral, LeoSprites[0] },
       { Expression.Happy, LeoSprites[1] },
       { Expression.Frown, LeoSprites[2] },
       { Expression.Sad, LeoSprites[3] },
       { Expression.Shock, LeoSprites[4] },
       { Expression.Upset, LeoSprites[5] },
       { Expression.Angry, LeoSprites[6] },
       { Expression.Thinking, LeoSprites[7] },
       { Expression.Idea, LeoSprites[8] },
       { Expression.Stress, LeoSprites[9] },
       { Expression.Shame, LeoSprites[10] },
       { Expression.Hit, LeoSprites[11] },
       { Expression.Void, LeoSprites[12] }
    };
  }
  public void changeExpression(CharacterTalking charSpeaking, Expression givenExpression)
  {
    // It's probably simplier to have a variable that directly holds the image component, but since this thing
    // Won't be called on every frame, screw it.
    GetComponent<Image>().sprite = expressionSprite[givenExpression];
  }
}
