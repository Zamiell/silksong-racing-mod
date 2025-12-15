namespace RacingMod.FSMEdits;

internal static class BellBeast
{
    internal static void SkipIntro(PlayMakerFSM fsm)
    {
        if (!Config.SkipCutscenes.Value)
        {
            return;
        }

        if (fsm is not { gameObject.name: "Beast", FsmName: "Beast Anim" })
        {
            return;
        }

        // Speed up the beginning of the fight.
        fsm.ChangeTransition("Free", "FINISHED", "Roar End");
    }

    internal static void SkipDeath(PlayMakerFSM fsm)
    {
        if (!Config.SkipCutscenes.Value)
        {
            return;
        }

        if (fsm is not { gameObject.name: "Bone Beast Corpse(Clone)", FsmName: "Death" })
        {
            return;
        }

        // Speed up the death sequence.
        fsm.ChangeTransition("Stagger", "FINISHED", "Submerge");
        fsm.ChangeTransition("Submerge", "FINISHED", "End");
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

With the skip enabled, it should go directly from "Take Control" to "End", bypassing the
entire cutscene sequence including the memory scene transition.

*/
