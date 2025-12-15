# FSM Events Guide

## What are FSM Events?

In PlayMaker (the FSM system used by Silksong), **events** are the triggers that cause state transitions. Each state can have multiple transitions, and each transition is triggered by a specific event name.

## Event Names are FSM-Specific

**Yes, event names depend on the specific FSM.** Each FSM can define its own custom events. There's no universal list of event names that works across all FSMs.

## How to Find Event Names

To discover what events an FSM uses, you can:

### 1. Enable FSM Logging

In your mod's configuration file, enable `LogFSMDetails`. This will log all FSM state transitions and show you the structure of FSMs.

### 2. Use the LogFSMInfo Function

Uncomment line 24 in `patches/PlayMakerFSMPatch.cs`:

```csharp
if (Config.LogFSMDetails.Value)
{
    LogFSMInfo(__instance);  // Uncomment this line
    AddStateTransitionLogging(__instance);
}
```

This will log the complete FSM structure including:
- All states
- All transitions
- Event names for each transition

Example output:
```
=== FSM Details ===
Scene: Bone_05_arena
GameObject: Silk Heart
FSM Name: Control
States (15):
  - Take Control (3 actions, 1 transitions)
    -> FINISHED => Hero Face L
  - Hero Face L (2 actions, 1 transitions)
    -> FINISHED => Shatter
```

### 3. Check Existing Code Examples

Look at how other FSM edits in this project use events:
- `FSMEdits/MossMother.cs` - Uses `"FINISHED"`
- `FSMEdits/ShrineWeaverAbility.cs` - Uses `"FINISHED"`
- `FSMEdits/BellBeast.cs` - Uses `"FINISHED"`

## Common PlayMaker Events

While event names are FSM-specific, some events are very common:

- **`FINISHED`** - Sent when a state's actions complete successfully
- **`CANCEL`** - Sent when an action or state is cancelled
- **`FAIL`** - Sent when an action fails
- **Custom Events** - Game developers can define any custom event name (e.g., `"PLAYER_DIED"`, `"BOSS_PHASE_2"`, etc.)

## How ChangeTransition Works

```csharp
fsm.ChangeTransition("State Name", "Event Name", "New Target State");
```

This modifies an **existing** transition. You must:
1. Specify the correct state name
2. Use an event name that already exists in that state's transitions
3. Provide the new target state you want to transition to

**Note:** You cannot create new events with `ChangeTransition` - you can only modify existing transitions. If an event doesn't exist, the FSM edit will fail silently or throw an error.

## Example Workflow

To modify the Silk Heart FSM:

1. Enable logging and run the game
2. Interact with the Silk Heart
3. Check the logs to see the FSM structure:
   ```
   -> FINISHED => Hero Face L
   ```
4. Use that event name in your code:
   ```csharp
   fsm.ChangeTransition("Take Control", "FINISHED", "Memory Scene");
   ```

## More Information

For more details on FSM manipulation, see:
- [Silksong.FsmUtil](https://github.com/silksong-modding/Silksong.FsmUtil) - The utility library used in this mod
- `FSMEdits/ExampleFsm.cs` - Example FSM edit with comments
- `patches/PlayMakerFSMPatch.cs` - Shows how FSMs are structured internally
