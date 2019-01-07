using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Spells.Battle
{
	public class SpellSoulspear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Soul Spear");
		}

		public override void SetDefaults()
		{
			item.damage = 51;
			item.magic = true;
			item.noMelee = true;
			item.crit = 1;
			item.width = 36;
			item.height = 36;
			item.useTime = 40;
			item.useAnimation = item.useTime;
			item.useStyle = 1;
			item.knockBack = 0;
			item.noUseGraphic = true;
			item.rare = 8;
			item.mana = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot=mod.ProjectileType("SoulSpear");
			item.shootSpeed = 10f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpellScroll");
			recipe.AddIngredient(ItemID.Ectoplasm,10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}