using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Spells.Battle
{
	public class SpellLeaf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Leaves");
		}

		public override void SetDefaults()
		{
			item.damage = 7;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 30;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 5;
			item.noUseGraphic = true;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.useTurn = true;
		}

		private const int Magicrange = 400;
		
		
		public override bool UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				Vector2 position = Main.MouseWorld;
				for (int i = 0; i < Main.rand.Next(3, 4); i++)
				{
					int type = ProjectileID.Leaf;
					float dir = Main.rand.NextFloat(MathHelper.TwoPi);
					int speed = 10;
					Vector2 pos = dir.ToRotationVector2() * Main.rand.NextFloat(100, 250);
					
					Vector2 pos0 = new Vector2(position.X + pos.X, position.Y + pos.Y);
					Vector2 vel = VectorHelper.FromTo(pos0, position, speed);
					Projectile proj = Projectile.NewProjectileDirect(pos0, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 90;
				}
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
			recipe.AddIngredient(ItemID.LeafWand);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
