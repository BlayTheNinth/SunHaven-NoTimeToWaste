using System;
using HarmonyLib;
using Wish;

namespace NoTimeToWaste;

[HarmonyPatch]
public class MineLockPatch
{
    [HarmonyPatch(typeof(MineLock), "Interact")]
    [HarmonyPrefix]
    static bool InteractPrefix(MineLock __instance, bool ___interacting, bool ___kingsLostKey, ItemData ___requiredKey, int ___requiredKeys)
    {
        if (___interacting)
        {
            return true;
        }

        var hasRequiredKey = Player.Instance.Inventory.HasEnough(___requiredKey.id, ___requiredKeys);
        var supportsRustyKey = MineGenerator2.Instance && MineGenerator2.Instance.canDropRustyKey;
        if (!hasRequiredKey && supportsRustyKey && !___kingsLostKey && Player.Instance.Inventory.HasEnough(1250, 1))
        {
            _UnlockWithRustyKey(__instance);
            return false;
        }
        
        return true;
    }

    [HarmonyReversePatch]
    [HarmonyPatch(typeof(MineLock), "UnlockWithRustyKey")]
    public static void _UnlockWithRustyKey(object instance)
    {
        throw new NotImplementedException("Stub has no content");
    }
}