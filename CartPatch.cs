using System;
using HarmonyLib;
using UnityEngine;
using Wish;

namespace NoTimeToWaste;

[HarmonyPatch]
public class CartPatch
{
    [HarmonyPatch(typeof(Cart), "StartRideNorth", typeof(string), typeof(int))]
    [HarmonyPrefix]
    static bool StartRideNorthPrefix(string scene, int room, Cart __instance, ScenePortalSpot ___nextScenePortal, GameObject ___panel, ref bool ____up)
    {
        Cart.currentRoom = room;
        ___nextScenePortal.SetScene(scene);
        UIHandler.Instance.CloseExternalUI(___panel);

        ____up = true;
        Player.Instance.MineCart = __instance;
        ScenePortalSpot_OnTriggerEnter2D(___nextScenePortal, Player.Instance.GetComponent<Collider2D>());
        
        return false;
    }
    
    [HarmonyPatch(typeof(ScenePortalSpot), "OnTriggerEnter2D")]
    [HarmonyReversePatch]
    static void ScenePortalSpot_OnTriggerEnter2D(object instance, Collider2D other)
    {
        throw new NotImplementedException("Stub has no content");
    }
}