using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SDVColorBlindMod
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod, IAssetLoader
    {
        /*********
        ** Public methods
        *********/
        
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;

        }
        public void Edit<T>(IAssetData asset)
        {
            var editor = asset.AsImage();

            Texture2D sourceImage = this.Helper.Content.Load<Texture2D>("custom-texture.png", ContentSource.ModFolder);
            editor.PatchImage(sourceImage, targetArea: new Rectangle(300, 100, 200, 200));
        }
        /// <summary>Get whether this instance can load the initial version of the given asset.</summary>
        /// <param name="asset">Basic metadata about the asset being loaded.</param>
        public bool CanLoad<T>(IAssetInfo asset)
        {
            if (asset.AssetNameEquals("TileSheets/crops") ||
               asset.AssetNameEquals("TileSheets/bushes") || 
               asset.AssetNameEquals("Maps/springobjects")){

                return true;
            }
                return false;
            
            }
        }

        /// <summary>Load a matched asset.</summary>
        /// <param name="asset">Basic metadata about the asset being loaded.</param>
        public T Load<T>(IAssetInfo asset)
        {

        if (asset.AssetNameEquals("TileSheets/crops"))
        {
            return this.Helper.Content.Load<T>("assets/crops.png", ContentSource.ModFolder);
        }
        else if (asset.AssetNameEquals("TileSheets/bushes"))
        {
            return this.Helper.Content.Load<T>("assets/bushes.png", ContentSource.ModFolder);
        }
        else if (asset.AssetNameEquals("Maps/springsobjects"))
        {
            return this.Helper.Content.Load<T>("assets/springobjects.png", ContentSource.ModFolder);
        }
               
         throw new InvalidOperationException($"Unexpected asset '{asset.AssetName}'.");

            }
        }

        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }

    }
}