using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CutsceneEffects : MonoBehaviour
{
    public void FadeIn()
    {
        GlobalReferences.Fader.FadeIn();
    }

    public void FadeOut()
    {
        GlobalReferences.Fader.FadeOut();
    }

    public void ShakeCamera()
    {
        StartCoroutine(GlobalReferences.CameraShake.Shake(1f, 0.4f));
    }

    public void SetDespairActive(bool active)
    {
        GlobalReferences.Despair.SetSpriteActive(active);
    }

    public void FadeInResume()
    {
        GlobalReferences.Fader.FadeIn();
        GlobalReferences.Fader.OnFadeInComplete += ResumeCutsceneAfterFadeIn;
    }

    public void FadeOutResume()
    {
        GlobalReferences.Fader.FadeOut();
        GlobalReferences.Fader.OnFadeOutComplete += ResumeCutsceneAfterFadeOut;
    }

    public void SetPlayerIdleAnimation(string direction)
    {
        direction = direction.ToLower();
        SetPlayerAnimationDefault();

        GlobalReferences.Player.GetComponent<Animator>().SetFloat("LastVertical", 0);
        GlobalReferences.Player.GetComponent<Animator>().SetFloat("LastHorizontal", 0);

        switch (direction)
        {
            case "up":
                {
                    GlobalReferences.Player.GetComponent<Animator>().SetFloat("LastVertical", 1f);
                    break;
                }
            case "down":
                {
                    GlobalReferences.Player.GetComponent<Animator>().SetFloat("LastVertical", -1f);
                    break;
                }
            case "right":
                {
                    GlobalReferences.Player.GetComponent<Animator>().SetFloat("LastHorizontal", 1f);
                    break;
                }
            case "left":
                {
                    GlobalReferences.Player.GetComponent<Animator>().SetFloat("LastHorizontal", -1f);
                    break;
                }
        }
    }

    public void SetPlayerAnimationDefault()
    {
        GlobalReferences.Player.GetComponent<Animator>().Play("Player_Idle");
    }

    public void SetPlayerAnimationLifted()
    {
        GlobalReferences.Player.GetComponent<Animator>().Play("Leo_Lifted_By_Despair_End_Frame");
    }

    public void SetDespairAnimation(string animation)
    {
        GlobalReferences.Despair.GetComponent<Animator>().Play(animation);
    }

    public void SetAmyAnimation(string animation)
    {
        GlobalReferences.Amy.GetComponent<Animator>().Play(animation);
    }


    public void SetAmyActive(bool active)
    {
        GlobalReferences.Amy.SetSpriteActive(active);
    }

    public void SetNpcAnimationUp(Animator animator)
    {
        animator.StopPlayback();
        animator.Play("NPC_Idle_Up");
    }

    public void SetNpcAnimationDown(Animator animator)
    {
        animator.StopPlayback();
        animator.Play("NPC_Idle_Down");
    }

    public void SetNpcAnimationLeft(Animator animator)
    {
        animator.StopPlayback();
        animator.Play("NPC_Idle_Left");
    }

    public void SetNpcAnimationRight(Animator animator)
    {
        animator.StopPlayback();
        animator.Play("NPC_Idle_Right");
    }

    public void SetIndigoAnimation(string animation)
    {
        GlobalReferences.Indigo.GetComponent<Animator>().Play(animation);
    }

    public void LoadHallWay()
    {
        GlobalReferences.MultiSceneLoader.LoadScene(1);
    }

    public void GameRoomFadeOut()
    {
        GlobalReferences.GameRoom.FadeOut();
    }

    public void GameRoomFadeIn()
    {
        GlobalReferences.GameRoom.FadeIn();
    }

    public void StopMusic()
    {
        GlobalReferences.SoundManager.Stop();
    }

    public void PlayMusic(string name)
    {
        GlobalReferences.SoundManager.PlayMusic(name);
    }

    public void PlaySFX(string name)
    {
        GlobalReferences.SoundManager.PlayClip(name);
    }

    private void ResumeCutsceneAfterFadeIn()
    {
        GlobalReferences.TimelineManager.ResumeCutscene();
        GlobalReferences.Fader.OnFadeInComplete -= ResumeCutsceneAfterFadeIn;
    }

    private void ResumeCutsceneAfterFadeOut()
    {
        GlobalReferences.TimelineManager.ResumeCutscene();
        GlobalReferences.Fader.OnFadeOutComplete -= ResumeCutsceneAfterFadeOut;
    }

    
}
