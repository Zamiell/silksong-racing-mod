namespace RacingMod.FSMEdits;

// This code has been tested to properly skip the following Weaver Shrines:
// - Ancestral Arts
//   - Swift Step (from Deep Docks)
//   - Cling Grip (from Shellwood)
//   - Clawline (from The Cauldron)
//   - Silk Soar (from Weavenest Absolom)
// - Silk Skills
//   - Silk Spear (from Mosshome)
//   - Thread Storm (from Craw Lake)
//   - Sharpdart (from Weavenest Karn)

// Remaining things to check:
// - Needolin (from Bellhart) XXX
// - Sylphsong (from Weavenest Atla) XXX
// - Cross Stitch (from Exhaust Organ) XXX
// - Rune Rage (from The Slab) XXX
// - Pale Nails (from The Cradle) XXX

internal static class ShrineWeaverAbility
{
    internal static void Skip(PlayMakerFSM fsm)
    {
        if (!Config.SkipCutscenes.Value)
        {
            return;
        }

        if (fsm is not { gameObject.name: "Shrine Weaver Ability", FsmName: "Inspection" })
        {
            return;
        }

        fsm.ChangeTransition("Look Back", "FINISHED", "Auto Equip");
        fsm.ChangeTransition("Auto Equip", "FINISHED", "Heal");
        fsm.ChangeTransition("Heal", "FINISHED", "Get Up");
    }
}

/*

This is the normal sequence for Silk Spear:

```
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Init
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Check Type
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Set Silkspear
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Collected Check
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Idle
[Info   : Unity Log] QoL: Interacting with object: Shrine Weaver Ability
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Look Back
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Weaver BG Up
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Weaver Dialogue
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Dialogue End
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Bind Prepare
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Bind Ready
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Bind Prompt
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Bind Start
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Blow Start
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Bind
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Bind Burst
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Fade Pause
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Fade To Black
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Needolin?
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Auto Equip
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Msg Type?
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Skill Msg
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Heal
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Force Face Right?
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Msg End Pause
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Get Up Pause
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Get Up
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> End
[Info   : Unity Log] QoL: [FSM State] Shrine Weaver Ability :: Inspection -> Set Finished
```

*/
