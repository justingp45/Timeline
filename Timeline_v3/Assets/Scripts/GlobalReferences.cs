using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalReferences
{
    private static TimelineManagerNew timelineManager;
    private static SoundManager soundManager;
    private static VolumeControl volumeControl;
    private static UICaller uicaller;
    private static DialogueUI dialogueui;
    private static Fader fader;
    private static CameraShake cameraShake;
    private static IndigoGameObject indigo;
    private static DespairGameObject despair;
    private static AmyGameObject amy;
    private static PlayerMovement player;
    private static GameRoomGameObject gameRoom;
    private static MultiSceneLoader multiSceneLoader;

    public static TimelineManagerNew TimelineManager
    {
        get
        {
            if (timelineManager)
                return timelineManager;

            return null;
        }

        set
        {
            timelineManager = value;
        }
    }

    public static SoundManager SoundManager
    {
        get
        {
            if (soundManager)
                return soundManager;

            return null;
        }

        set
        {
            soundManager = value;
        }
    }

    public static VolumeControl VolumeControl
    {
        get
        {
            if (volumeControl)
                return volumeControl;

            return null;
        }

        set
        {
            volumeControl = value;
        }
    }

    public static UICaller UIcaller
    {
        get
        {
            if (uicaller)
                return uicaller;

            return null;
        }

        set
        {
            uicaller = value;
        }
    }

    public static DialogueUI Dialogueui
    {
        get
        {
            if (dialogueui)
                return dialogueui;

            return null;
        }

        set
        {
            dialogueui = value;
        }
    }

    public static Fader Fader
    {
        get
        {
            if (fader)
                return fader;

            return null;
        }

        set
        {
            fader = value;
        }
    }

    public static CameraShake CameraShake
    {
        get
        {
            if (cameraShake)
                return cameraShake;

            return null;
        }

        set
        {
            cameraShake = value;
        }
    }

    public static DespairGameObject Despair
    {
        get
        {
            if (despair)
                return despair;

            return null;
        }

        set
        {
            despair = value;
        }
    }

    public static IndigoGameObject Indigo
    {
        get
        {
            if (indigo)
                return indigo;

            return null;
        }

        set
        {
            indigo = value;
        }
    }

    public static AmyGameObject Amy
    {
        get
        {
            if (amy)
                return amy;

            return null;
        }

        set
        {
            amy = value;
        }
    }

    public static PlayerMovement Player
    {
        get
        {
            if (player)
                return player;

            return null;
        }

        set
        {
            player = value;
        }
    }

    public static GameRoomGameObject GameRoom
    {
        get
        {
            if (gameRoom)
                return gameRoom;

            return null;
        }

        set
        {
            gameRoom = value;
        }
    }

    public static MultiSceneLoader MultiSceneLoader
    {
        get
        {
            if (multiSceneLoader)
                return multiSceneLoader;

            return null;
        }

        set
        {
            multiSceneLoader = value;
        }
    }
}
