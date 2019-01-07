using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Spells.Battle
{
	public class SpellNebula : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Nebula Rain");
		}

		public override void SetDefaults()
		{
			item.damage = 68;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 9;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 15;
			item.noUseGraphic = true;
			item.rare = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.useTurn = true;
		}
		
		public override bool UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				Vector2 position = Main.MouseWorld;
				for (int i = 0; i < 3; i++)
				{
					Vector2 vel = new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(12,16));
					int type = mod.ProjectileType("NebulaRaindrop");
					int rand = 70;
					Vector2 pos = new Vector2(position.X + Main.rand.Next(-rand, rand), player.Center.Y - 700);
					Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpellScroll");
			recipe.AddIngredient(ItemID.FragmentNebula,20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
