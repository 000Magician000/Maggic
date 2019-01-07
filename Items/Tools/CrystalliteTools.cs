using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Tools
{
	public class CrystallitePickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.melee = true;
			item.damage = 30;
			item.pick = 200;
			item.knockBack = 4.5f;
			item.useStyle = 1;
			item.useTime = 7;
			item.useAnimation = 24;
			item.maxStack = 99;
			item.rare = 4;
			item.value = Item.buyPrice(gold: 3, silver: 20);
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CrystalliteBar"),16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class CrystalliteAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 50;
			item.height = 50;
			item.melee = true;
			item.damage = 38;
			item.axe = 24;
			item.knockBack = 5;
			item.useStyle = 1;
			item.useTime = 6;
			item.useAnimation = 24;
			item.rare = 4;
			item.value = Item.buyPrice(gold: 3, silver: 20);
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CrystalliteBar"),12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}