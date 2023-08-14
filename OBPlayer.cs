using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OpenBags;

public class OBPlayer : ModPlayer
{
    public bool OpeningBags;

    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (OpenBags.OpenBagsKey.JustPressed)
        {
            ToggleOpenBags(byKeybind:true);
        }
    }

    public override void PostUpdateMiscEffects()
    {
        if (OpeningBags)
        {
            foreach (var item in Player.inventory)
            {
                if (ItemLoader.CanRightClick(item) && Player.ConsumeItem(item.type))
                {
                    Player.DropFromItem(item.type);
                    return;
                }
            }

            ToggleOpenBags();
        }
    }

    public void ToggleOpenBags(bool byKeybind = false)
    {
        string text;

        if (byKeybind)
            text = FromLocalization("OpenBags",
                OpeningBags ? FromLocalization("Off") : FromLocalization("On"));
        else
            text = FromLocalization("AllBagsOpened");

        CombatText.NewText(Player.Hitbox, Color.LightCyan, text);

        OpeningBags = !OpeningBags;
    }

    public string FromLocalization(string key) => Language.GetTextValue($"Mods.OpenBags.{key}");
    public string FromLocalization(string key, params object[] args) => Language.GetTextValue($"Mods.OpenBags.{key}", args);
}   