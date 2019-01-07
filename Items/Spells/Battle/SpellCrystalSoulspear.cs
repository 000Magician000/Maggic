using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Spells.Battle
{
	public class SpellCrystalSoulspear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Crystal Soul Spear");
		}

		public override void SetDefaults()
		{
			item.damage = 63;
			item.magic = true;
			item.noMelee = true;
			item.crit = 2;
			item.width = 36;
			item.height = 36;
			item.useTime = 50;
			item.useAnimation = item.useTime;
			item.useStyle = 1;
			item.knockBack = 0;
			item.noUseGraphic = true;
			item.rare = 9;
			item.mana = 12;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("CrystalSoulSpear");
			item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpellSoulspear");
			recipe.AddIngredient(null, "SpellScroll");
			recipe.AddIngredient(ItemID.CrystalShard, 15);
			recipe.AddTile(mod.TileType("EnchantedTable_Tile"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}