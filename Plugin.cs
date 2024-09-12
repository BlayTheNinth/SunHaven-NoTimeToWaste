using System.Linq;
using BepInEx;
using HarmonyLib;

namespace NoTimeToWaste
{
    [BepInPlugin("net.blay09.notimetowaste", "NoTimeToWaste", PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Applying patches...");

            var harmony = new Harmony("net.blay09.notimetowaste");
            harmony.PatchAll();
            
            Logger.LogInfo($"Patched {harmony.GetPatchedMethods().Count()} methods");
            harmony.GetPatchedMethods().ToList().ForEach(method => Logger.LogInfo($"- {method.DeclaringType?.FullName}.{method.Name}"));
        }
    }
}
