using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SDVColorBlindMod
{
 
    public class ModEntry : Mod, IAssetLoader
    {
        public override void Entry(IModHelper helper)
        {
            throw new NotImplementedException(); 
        }
        public bool CanLoad<T>(IAssetInfo asset)
        {
            if (asset.AssetNameEquals("TileSheets/crops") ||
                asset.AssetNameEquals("Maps/springobjects") ||
                asset.AssetNameEquals("TileSheets/bushes") ||
                asset.AssetNameEquals("Maps/paths")
                )
            {
                return true;
            }
            return false;

        }

        public T Load<T>(IAssetInfo asset)
        {

            if (asset.AssetNameEquals("TileSheets/crops"))
            {
                return this.Helper.Content.Load<T>("assets/crops.png", ContentSource.ModFolder);
            }
            if (asset.AssetNameEquals("TileSheets/bushes"))
            {
                return this.Helper.Content.Load<T>("assets/bushes.png", ContentSource.ModFolder);
            }
            if (asset.AssetNameEquals("Maps/springobjects"))
            {
                return this.Helper.Content.Load<T>("assets/springobjects.png", ContentSource.ModFolder);
            }
            if (asset.AssetNameEquals("Maps/paths"))
            {
                return this.Helper.Content.Load<T>("assets/paths.png", ContentSource.ModFolder);
            }
 

            throw new InvalidOperationException($"Unexpected asset '{asset.AssetName}'.");

        }
    }


}
    
