using System.Collections;
using UnityEngine;
using MelonLoader;

[assembly: MelonInfo(typeof(FOVCV1BK), "FOV Changer", "1", "kaaku")]
[assembly: MelonGame("VRChat", "VRChat")]

class FOVCV1BK : MelonMod
{
    private static IEnumerator GSC(bool u)
    {
        while (RoomManager.field_Internal_Static_ApiWorld_0 == null) yield return null;
        foreach (var c in Object.FindObjectsOfType<Camera>()) if (c.name == (u ? "StackedCamera : Cam_InternalUI" : "Camera (eye)")) c.fieldOfView = (u ? FOVUI.Value : FOV.Value);
    }
    public override void OnApplicationStart() { MelonCoroutines.Start(GSC(false)); MelonCoroutines.Start(GSC(true)); }
    public override void OnPreferencesSaved() { MelonCoroutines.Start(GSC(false)); MelonCoroutines.Start(GSC(true)); }
    public override void OnPreferencesLoaded() { MelonCoroutines.Start(GSC(false)); MelonCoroutines.Start(GSC(true)); }
    private static MelonPreferences_Category FOVC = MelonPreferences.CreateCategory("FOVC", "FOV Changer");
    private static MelonPreferences_Entry<float> FOV = FOVC.CreateEntry<float>("FOV", 60, "Field of View"), FOVUI = FOVC.CreateEntry<float>("FOVUI", 60, "UI Field of View");
}