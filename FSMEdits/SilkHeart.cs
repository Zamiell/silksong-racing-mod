namespace RacingMod.FSMEdits;

internal static class SilkHeart
{
    internal static void SkipCutscene(PlayMakerFSM fsm)
    {
        if (!Config.SkipCutscenes.Value)
        {
            return;
        }

        if (fsm is not { gameObject.name: "Silk Heart", FsmName: "Control" })
        {
            return;
        }

        fsm.ChangeTransition("Take Control", "FINISHED", "Memory Scene");

        /*
        // When the "Take Control" state is entered, trigger a scene change to Bone_05_bellway.
        // Use InsertMethod with index 0 to ensure this runs at the very start of the state.
        fsm.InsertMethod(
            "Take Control",
            0,
            (_) =>
            {
                // Disable the game object to prevent the cutscene from continuing.
                fsm.gameObject.SetActive(false);

                GameManager.instance.BeginSceneTransition(
                    new GameManager.SceneLoadInfo
                    {
                        SceneName = "Bone_05",
                        PreventCameraFadeOut = true,
                        WaitForSceneTransitionCameraFade = false,
                        Visualization = GameManager.SceneLoadVisualizations.Default,
                    }
                );

                // Skips the cutscene where the Bell Beast announces that it will be your friend.
                PlayerData.instance.UnlockedFastTravel = true;
            }
        );
        */
    }

    internal static void SkipCutscene2(PlayMakerFSM fsm)
    {
        if (!Config.SkipCutscenes.Value)
        {
            return;
        }

        if (fsm is not { gameObject.name: "In-game", FsmName: "Screen Fader" })
        {
            return;
        }

        // fsm.ChangeTransition("Custom Fade", "FINISHED", "Memory Scene");
    }
}

/*

This is the normal sequence for the Silk Heart after defeating the Bell Beast boss:

```
[Info   : Unity Log] [2025-11-08 11:21:24.654] RacingMod: [FSM State] Silk Heart :: Control -> Init
[Info   : Unity Log] [2025-11-08 11:21:24.657] RacingMod: [FSM State] Silk Heart :: Control -> Pause
[Info   : Unity Log] [2025-11-08 11:21:26.655] RacingMod: [FSM State] Silk Heart :: Control -> Appear Start
[Info   : Unity Log] [2025-11-08 11:21:27.455] RacingMod: [FSM State] Silk Heart :: Control -> Shell Appear
[Info   : Unity Log] [2025-11-08 11:21:27.959] RacingMod: [FSM State] Silk Heart :: Control -> Heart Appear
[Info   : Unity Log] [2025-11-08 11:21:28.208] RacingMod: [FSM State] Silk Heart :: Control -> Form Effects
[Info   : Unity Log] [2025-11-08 11:21:29.541] RacingMod: [FSM State] Silk Heart :: Control -> Take Control
[Info   : Unity Log] [2025-11-08 11:21:29.579] RacingMod: [FSM State] Silk Heart :: Control -> Hero Face L
[Info   : Unity Log] [2025-11-08 11:21:29.580] RacingMod: [FSM State] Silk Heart :: Control -> Shatter
[Info   : Unity Log] [2025-11-08 11:21:30.590] RacingMod: [FSM State] Silk Heart :: Control -> Suck
[Info   : Unity Log] [2025-11-08 11:21:33.592] RacingMod: [FSM State] Silk Heart :: Control -> Wipe
[Info   : Unity Log] [2025-11-08 11:21:34.592] RacingMod: [FSM State] Silk Heart :: Control -> Memory?
[Info   : Unity Log] [2025-11-08 11:21:34.593] RacingMod: [FSM State] Silk Heart :: Control -> Fade Audio Down
[Info   : Unity Log] [2025-11-08 11:21:34.598] RacingMod: [FSM State] Silk Heart :: Control -> Memory Scene
... (memory scene transition and return)
[Info   : Unity Log] [2025-11-08 11:22:30.018] RacingMod: [FSM State] Silk Heart :: Control -> Continued
[Info   : Unity Log] [2025-11-08 11:22:30.019] RacingMod: [FSM State] Silk Heart :: Control -> Up Pause
[Info   : Unity Log] [2025-11-08 11:22:31.509] RacingMod: [FSM State] Silk Heart :: Control -> Regen Last Silk
[Info   : Unity Log] [2025-11-08 11:22:32.953] RacingMod: [FSM State] Silk Heart :: Control -> Hero Up Memory 1st
[Info   : Unity Log] [2025-11-08 11:22:34.457] RacingMod: [FSM State] Silk Heart :: Control -> Get Up Sound Triggers
[Info   : Unity Log] [2025-11-08 11:22:34.535] RacingMod: [FSM State] Silk Heart :: Control -> Play Audio
[Info   : Unity Log] [2025-11-08 11:22:35.450] RacingMod: [FSM State] Silk Heart :: Control -> Play Audio
[Info   : Unity Log] [2025-11-08 11:22:35.869] RacingMod: [FSM State] Silk Heart :: Control -> End
[Info   : Unity Log] [2025-11-08 11:22:35.871] RacingMod: [FSM State] Silk Heart :: Control -> Collected
```

With this edit enabled, when Hornet touches the Silk Heart and the "Take Control" state is
entered, the game will immediately transition to the Bone_05 scene using the ThreadMemory
visualization, which is used for memory-related scene transitions.

*/
