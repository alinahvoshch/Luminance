﻿global using static System.MathF;
global using static Luminance.Assets.MiscTexturesRegistry;
global using static Luminance.Common.Utilities.Utilities;
global using static Microsoft.Xna.Framework.MathHelper;
using Luminance.Core.Graphics;
using Luminance.Core.ILWrappers;
using Terraria.ModLoader;

namespace Luminance
{
    public class Luminance : Mod
    {
        /// <summary>
        ///     The mod instance for this library.
        /// </summary>
        public static Mod Instance
        {
            get;
            private set;
        }

        public override void Load() => Instance = this;

        public override void Unload() => ManagedILEdit.UnloadEdits();

        public override void PostSetupContent()
        {
            // Go through every mod and check for effects to autoload.
            foreach (Mod mod in ModLoader.Mods)
            {
                ShaderManager.LoadShaders(mod);
                AtlasManager.InitializeModAtlases(mod);
            }

            // Mark loading operations as finished.
            ShaderManager.HasFinishedLoading = true;
        }
    }
}
