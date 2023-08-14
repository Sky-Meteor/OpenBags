using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace OpenBags
{
	public class OpenBags : Mod
    {
        internal static ModKeybind OpenBagsKey;

        public override void Load()
        {
            OpenBagsKey = KeybindLoader.RegisterKeybind(this, "OpenBags", Keys.O);
        }

        public override void Unload()
        {
            OpenBagsKey = null;
        }
    }
}