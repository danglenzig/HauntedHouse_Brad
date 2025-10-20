namespace HauntedHouse;

public static class StoryData
{
    // ============================================================
    // INTRO
    // ============================================================
    public static string InitialIntro = @"
        DSS CALLIOPE – orbiting the ice moon Nereus IX.

        You are a systems engineer for the Helios Corporation.
        Three weeks ago, the Calliope went silent. No signals, no life signs.

        Your mission: board the station, restore power, and recover the mission logs.
        Officially, it’s a rescue and recovery.
        Unofficially... Helios wants its research data back.

        You dock at the airlock. The outer hull is coated with frost.
        The ship hums faintly, like something breathing beneath the metal.";
    
    public static string GameIntro =
        "This is Commander Elias Reed, Systems Engineer aboard shuttle Aegis-4.\n" +
        "We were sent to investigate the DSS Calliope after all communication ceased two weeks ago.\n" +
        "Emergency transmissions mentioned screaming, static, and the words 'containment breach'.\n\n" +
        "The shuttle's autopilot malfunctioned on approach. I'm entering manually through the airlock...\n\n" +
        "If anyone receives this message... send help.";

    // ============================================================
    // AIRLOCK
    // ============================================================
    public static string Airlock_1 =
        "You step into the airlock. The outer hatch seals behind you with a shriek of tearing metal.";
    public static string Airlock_2 =
        "A rush of escaping air fogs your visor. The helmet light flickers, then bursts — darkness.";
    public static string Airlock_3 =
        "You pound the console until the system hisses to life:\nPRESSURIZATION SEQUENCE COMPLETE. OXYGEN RESTORED.";
    public static string Airlock_4 =
        "You cough as air returns. The outer door’s mechanism sparks and dies — you’re trapped inside now.";
    public static string Airlock_Exit =
        "You step cautiously into the dark corridor ahead. Only the dim floor markings guide you.";

    // ============================================================
    // CENTRAL CORRIDOR
    // ============================================================
    public static string CentralCorridor_1 =
        "Dim emergency strips flicker along the floor, pulsing weakly like veins.";
    public static string CentralCorridor_2 =
        "The silence feels wrong. Bloodied footprints lead in every direction, fading into the dark.";
    public static string CentralCorridor_Exit =
        "Every sound echoes. Only the Medical Bay door seems half-open.";

    // ============================================================
    // MEDICAL BAY
    // ============================================================
    public static string MedicalBay_1 =
        "The stench hits first — disinfectant, blood, and something sweet rotting beneath.";
    public static string MedicalBay_2 =
        "Tables overturned, bodies under sheets that seem to rise and fall slightly — or maybe it’s just the air vents.";
    public static string MedicalBay_3 =
        "An emergency light strobes red. A man lies still on a stretcher, flashlight clutched in his hand.";
    public static string MedicalBay_Exit =
        "You leave the body behind. The flicker feels almost alive.";

    public static string MedicalBay_FoundFlashlight =
        "You take the flashlight from the corpse — its beam cuts through the dark. A keycard slips from his pocket.";

    public static string MedicalBay_HideEvent =
        "You kill the light and slide under the bed.\nBare feet drag across the tiles — the sound wet, uneven.\nBlood drips onto your helmet before it moves away.";

    // ============================================================
    // CREW QUARTERS
    // ============================================================
    public static string CrewQuarters_1 =
        "Rows of bunks line the walls. Some lockers hang open, others buckled outward from inside.";
    public static string CrewQuarters_2 =
        "The ventilation hum sounds almost like whispering.";
    public static string CrewQuarters_Desk =
        "A datapad flickers: 'The commander wants results. He doesn’t care what it does to them... or to us.'";
    public static string CrewQuarters_Bed =
        "A torn logbook reads: 'They’re trying to weaponize it — a neural symbiote that replicates itself.'";
    public static string CrewQuarters_Chocolate =
        "You find a chocolate bar under a mattress labeled: 'For hard days.' (+1 health)";
    public static string CrewQuarters_Exit =
        "A cold silence fills the air, as if the room remembers what happened.";

    // ============================================================
    // MESS HALL
    // ============================================================
    public static string MessHall_1 =
        "Tables overturned. Food trays glued to the floor by old blood.";
    public static string MessHall_2 =
        "A man lies slumped near the serving counter — movement catches your eye.";
    public static string MessHall_Encounter =
        "‘Wait... please! Don’t shoot! I’m... Dr. Halberg.’";
    public static string MessHall_Exit =
        "The only exit leads back to the crew quarters.";

    // ============================================================
    // HALBERG SCENE (triggered when player returns him to MedBay)
    // ============================================================
    public static string HalbergScene =
        "Dr. Halberg sits beside the dead doctor, grimacing as he binds his leg.\n" +
        "‘Voss was my superior. He knew what they were experimenting on.’\n\n" +
        "‘The bridge is locked down, but I have a pass. You’ll need to reach Engineering to restore power.\n" +
        "Only then can we access the lab.’";

    // ============================================================
    // BRIDGE
    // ============================================================
    public static string Bridge_1 =
        "The bridge is silent except for the faint beep of a dying console.";
    public static string Bridge_2 =
        "A log entry reads: 'Specimen breached containment through the vents. They thought it was dormant... it wasn’t.'";
    public static string Bridge_Exit =
        "The hum of systems returning to life fills the air.";

    // ============================================================
    // OBSERVATION DECK
    // ============================================================
    public static string ObservationDeck_1 =
        "The transparent dome reveals endless space. Blood streaks the glass from the inside.";
    public static string ObservationDeck_CombatIntro =
        "A figure steps from the shadows — Ensign Abernathy, eyes black and trembling.";
    public static string ObservationDeck_CombatOutro =
        "You kneel beside the corpse. His holster holds a pistol and a note:\n" +
        "'They planned to sell it — the organism. Commander Vale led the deal.'";
    public static string ObservationDeck_Exit =
        "You step carefully back toward the bridge.";

    // ============================================================
    // ENGINEERING
    // ============================================================
    public static string Engineering_1 =
        "The reactor core pulses weakly. Steam vents from cracked pipes.";
    public static string Engineering_2 =
        "A shadow shifts between the machinery. Something’s here.";
    public static string Engineering_PowerRestored =
        "You reinitialize the reactor systems. Lights flicker back online across the station.";
    public static string Engineering_Chocolate =
        "You pry open a locker — a melted chocolate bar inside. Still edible.";
    public static string Engineering_Exit =
        "The hum of the dying reactor fades behind you.";

    // ============================================================
    // SPECIMEN LAB
    // ============================================================
    public static string SpecimenLab_1 =
        "Glass tubes line the walls, shattered and dripping.";
    public static string SpecimenLab_2 =
        "A pulsating mass crawls along the floor — the experiment.";
    public static string SpecimenLab_Combat =
        "It lunges. You raise your pistol.\nThe monster strikes first.";
    public static string SpecimenLab_Victory =
        "The creature collapses, twitching. You retrieve a data chip from the remains.";
    public static string SpecimenLab_Exit =
        "You retreat, heart pounding, the door sealing behind you.";

    // ============================================================
    // FINAL SCENE
    // ============================================================
    public static string FinalScene_Intro =
        "You and Dr. Halberg enter the lab.\nCommander Vale is already there, datapad in hand.";
    public static string FinalScene_Dialogue =
        "‘You shouldn’t have come here, Halberg.’\n\n" +
        "‘You did this,’ the doctor growls. ‘You infected the crew.’\n\n" +
        "‘We perfected the design. The organism was meant to evolve — to bind with its host.’\n\n" +
        "‘It killed everyone!’\n\n" +
        "‘No, Doctor… it made them better.’";
    public static string FinalScene_TrustVale =
        "You hand Vale the data chip. He smiles.\n‘Thank you, engineer. You’ve done your duty.’\n\nThen he shoots you.\n\nGAME OVER — You were expendable.";
    public static string FinalScene_TrustHalberg =
        "You shoot Vale first. He collapses.\nHalberg retrieves the chip and whispers:\n‘We can end this.’\n\nYou overload the lab core.\n\nFADE TO WHITE.";

    // ============================================================
    // ENDINGS
    // ============================================================
    public static string Ending_Good =
        "The Calliope burns in orbit. Transmission sent. Containment achieved.\nHumanity will never know how close it came.";
    public static string Ending_Bad =
        "Vale survived. The organism escaped with him.\nCalliope drifts — alive, waiting.";
    public static string Ending_Death =
        "Your vision fades. Static fills your helmet.\nFragments of logs replay until only silence remains.";
    public static string Ending_Secret =
        "The shuttle drifts away from Calliope.\nA faint whisper through the comm: 'It’s not over...'";
}
