using e = System.Collections.IEnumerator;
using o = UnityEngine.Object;
using c = UnityEngine.Camera;
using MelonLoader;

[assembly: MelonInfo(typeof(FOVCV1BK), "FOV Changer", "1", "kaaku")]
[assembly: MelonGame("VRChat", "VRChat")]

class FOVCV1BK : MelonMod
{
    static e G()
    {
        while (RoomManager.field_Internal_Static_ApiWorld_0 == null) yield return null;
        foreach (var c in o.FindObjectsOfType<c>())
            if (c.name == "Camera (eye)") c.fieldOfView = f.Value;
            else if (c.name == "StackedCamera : Cam_InternalUI") c.fieldOfView = u.Value;
    }
    public override void OnApplicationStart() { MelonCoroutines.Start(G()); }
    public override void OnPreferencesSaved() { MelonCoroutines.Start(G()); }
    public override void OnPreferencesLoaded() { MelonCoroutines.Start(G()); }
    static MelonPreferences_Category c = MelonPreferences.CreateCategory("FOVC", "FOV Changer");
    static MelonPreferences_Entry<float> f = c.CreateEntry<float>("FOV", 60, "Field of View"), u = c.CreateEntry<float>("FOVUI", 60, "UI Field of View");
}