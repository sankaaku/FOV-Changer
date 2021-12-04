using System.Collections;
using UnityEngine;
using MelonLoader;

[assembly: MelonInfo(typeof(FOVCV1BK), "FOV Changer", "1", "kaaku")]
[assembly: MelonGame("VRChat", "VRChat")]

class FOVCV1BK : MelonMod
{
    static IEnumerator G()
    {
        while (RoomManager.field_Internal_Static_ApiWorld_0 == null) yield return null;
        foreach (var c in Object.FindObjectsOfType<Camera>())
            if (c.name == "Camera (eye)") c.fieldOfView = FOV.Value;
            else if (c.name == "StackedCamera : Cam_InternalUI") c.fieldOfView = FOVUI.Value;
    }
    public override void OnApplicationStart() { MelonCoroutines.Start(G()); }
    public override void OnPreferencesSaved() { MelonCoroutines.Start(G()); }
    public override void OnPreferencesLoaded() { MelonCoroutines.Start(G()); }
    static MelonPreferences_Category FOVC = MelonPreferences.CreateCategory("FOVC", "FOV Changer");
    static MelonPreferences_Entry<float> FOV = FOVC.CreateEntry<float>("FOV", 60, "Field of View"), FOVUI = FOVC.CreateEntry<float>("FOVUI", 60, "UI Field of View");
}