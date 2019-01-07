using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Spells.Battle
{
	public class SpellMushrooms : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Mushroom Spores");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.mana = 6;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 0;
			item.noUseGraphic = true;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.useTurn = true;
		}

		private const int Magicrange = 400;

		public override bool UseItem(Player player)
		{
			if (player.whoAmI == item.owner)
			{
				Vector2 position = Main.MouseWorld;
				int type = mod.ProjectileType("MushroomProj");
				Projectile proj = Projectile.NewProjectileDirect(position, Vector2.Zero, type, item.damage, 0, item.owner);
				proj.timeLeft = 60;
			}
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			return Vector2.Distance(Main.player[item.owner].position, Main.MouseWorld) < Magicrange;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpellScroll");
			recipe.AddIngredient(ItemID.GlowingMushroom,15);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
