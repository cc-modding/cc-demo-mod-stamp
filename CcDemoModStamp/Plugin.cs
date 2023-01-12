using System;
using BepInEx;
using BepInEx.Unity.Bootstrap;
using TMPro;
using UnityEngine;

namespace CcDemoModStamp
{
    [BepInPlugin(PluginInfo.PluginGuid, PluginInfo.PluginName, PluginInfo.PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private bool hasSetText;
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PluginGuid} is loaded!");
        }

        private void Update()
        {
            if (!hasSetText)
            {
                try
                {
                    var text = GameObject.Find("Version").GetComponent<TextMeshProUGUI>();
                    text.text += "\nModding by @reddust9#4805\n\nMods loaded:\n";
                    foreach (var plugins in UnityChainloader.Instance.Plugins.Values)
                    {
                        var plName = plugins.Metadata.Name;
                        var plVer = plugins.Metadata.Version;
                        text.text += $"- {plName} v{plVer}\n";
                    }
                    
                    hasSetText = true;
                } catch
                {
                    //Logger.LogInfo("Failed to set text. Retrying...");
                    // error means nothing, it works anyway
                }
            }
        }
    }
}