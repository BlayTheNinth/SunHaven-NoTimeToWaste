using HarmonyLib;
using Wish;

namespace NoTimeToWaste;

[HarmonyPatch]
public class ForageTreePatch
{
    [HarmonyPatch(typeof(ForageTree), "Shake")]
    [HarmonyPostfix]
    static void ShakePostfix(bool fromLocalPlayer)
    {
        if (fromLocalPlayer)
        {
            Player.Instance.RemovePauseObject("forage");
        }
    }
}