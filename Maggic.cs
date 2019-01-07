using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic
{
	class Maggic : Mod
	{
		internal static Maggic Instance { get; private set; }		
		
		public Maggic()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

        public override void Load()
        {
            Instance = this;
        }

        public override void Unload()
        {
            Instance = null;
        }

        public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => "Any Iron Ore", new int[]
			{ ItemID.IronOre, ItemID.LeadOre });
			RecipeGroup.RegisterGroup("Maggic:IronLeadOres", group);
			
			group = new RecipeGroup(() => "Any Spectre Helmet", new int[]
			{ ItemID.SpectreHood, ItemID.SpectreMask });
			RecipeGroup.RegisterGroup("Maggic:SpectreHelmets", group);

            group = new RecipeGroup(() => "Any Dark Robe", new int[]
            { ItemType("DarkRobe"), ItemType("DarkRobeCrimson")});
            RecipeGroup.RegisterGroup("Maggic:DarkRobes", group);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Maggic:DarkRobes");
            recipe.AddIngredient(ItemID.Amethyst,10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.AmethystRobe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Maggic:DarkRobes");
            recipe.AddIngredient(ItemID.Diamond, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.DiamondRobe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Maggic:DarkRobes");
            recipe.AddIngredient(ItemID.Emerald, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.EmeraldRobe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Maggic:DarkRobes");
            recipe.AddIngredient(ItemID.Ruby, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.RubyRobe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Maggic:DarkRobes");
            recipe.AddIngredient(ItemID.Sapphire, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.SapphireRobe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Maggic:DarkRobes");
            recipe.AddIngredient(ItemID.Topaz, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.TopazRobe);
            recipe.AddRecipe();
        }
    }
}
