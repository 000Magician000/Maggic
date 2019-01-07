using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Spells
{
	public class SpellScroll : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.rare = 0;
			item.maxStack = 99;
			item.rare = 0;
			item.value = Item.buyPrice(silver: 20);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Book, 3);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}