using HarmonyLib;
using UnityModManagerNet;

namespace DvMod.DemoLocos;

public class Settings : UnityModManager.ModSettings, IDrawable
{
    [Draw("Precise position")] public bool ProvidePrecisePosition = false;
    [Draw("Put hints in museum license (if false, hints will be put on train conductor license)")] public bool WaitMuseum = true;

    public override void Save(UnityModManager.ModEntry modEntry)
    {
        Save(this, modEntry);
    }

    public void OnChange()
    {
    }
}
public static class Main
{
    public static UnityModManager.ModEntry? mod;
    public static Settings? settings;

    public static void Load(UnityModManager.ModEntry modEntry)
    {
        settings = Settings.Load<Settings>(modEntry);
        mod = modEntry;
        mod.OnToggle = OnToggle;
        modEntry.OnGUI = OnGUI;
        modEntry.OnSaveGUI = OnSaveGUI;
        

    }

    private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
    {
        Harmony harmony = new Harmony(modEntry.Info.Id);

        if (value)
        {
            harmony.PatchAll();
        }
        else
        {
            harmony.UnpatchAll(modEntry.Info.Id);
        }
        return true;
    }
    static void OnGUI(UnityModManager.ModEntry modEntry)
    {
        settings.Draw(modEntry);
    }

    static void OnSaveGUI(UnityModManager.ModEntry modEntry)
    {
        settings!.Save(modEntry);
    }
}
