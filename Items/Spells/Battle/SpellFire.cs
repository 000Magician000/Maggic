using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Spells.Battle
{
	public class SpellFireI : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Fire [I]");
		}
		public override void SetDefaults()
		{
			item.damage = 28;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 40;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 5;
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
				Vector2 position = Main.screenPosition;
				position.X += Main.mouseX;
				position.Y += player.gravDir == 1 ? Main.mouseY : Main.screenHeight - Main.mouseY;
				for (int i = 0; i < 1; i++)
				{
					Vector2 vel = new Vector2(0, 2);
					int type = ProjectileID.BallofFire;
					int rand = 30;
					int proj = Projectile.NewProjectile(position.X + Main.rand.NextFloat(-rand,rand),
						position.Y + Main.rand.NextFloat(-rand,rand), vel.X, vel.Y, type, item.damage, 0, item.owner);
					Main.projectile[proj].timeLeft = 70 + Main.rand.Next(-10, 5);
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
			recipe.AddIngredient(ItemID.LavaBucket);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
	public class SpellFireII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Fire [II]");
		}
		public override void SetDefaults()
		{
			item.damage = 32;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 40;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 8;
			item.noUseGraphic = true;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.useTurn = true;
		}

		private const int Magicrange = 400;

		public override bool UseItem(Player player)
		{
			if (player.whoAmI == item.owner)
			{
				Vector2 position = Main.screenPosition;
				position.X += Main.mouseX;
				position.Y += player.gravDir == 1 ? Main.mouseY : Main.screenHeight - Main.mouseY;
				for (int i = 0; i < 3; i++)
				{
					Vector2 vel = new Vector2(0, 4);
					int type = ProjectileID.BallofFire;
					int rand = 30;
					Vector2 pos = new Vector2(position.X + Main.rand.NextFloat(-rand, rand), position.Y + Main.rand.NextFloat(-rand,rand));
					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 70 + Main.rand.Next(-10, 5);
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
			recipe.AddIngredient(null,"SpellFireI");
			recipe.AddIngredient(null,"SpellScroll");
			recipe.AddIngredient(ItemID.LavaBucket,3);
			recipe.AddIngredient(ItemID.FlowerofFire);
			recipe.AddIngredient(ItemID.HellstoneBar,20);
			recipe.AddIngredient(ItemID.Fireblossom,5);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
	public class SpellFireIII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Fire [III]");
		}
		public override void SetDefaults()
		{
			item.damage = 37;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 40;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 10;
			item.noUseGraphic = true;
			item.rare = 4;
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
				
				int type = ProjectileID.BallofFire;
				int rand = 30;
				for (int i = 0; i < 5; i++)
				{
					Vector2 pos = new Vector2(position.X + Main.rand.NextFloat(-rand, rand), position.Y + Main.rand.NextFloat(-rand, rand));
					Vector2 vel = new Vector2(0, 6);
					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 70 + Main.rand.Next(-10, 5);
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
			recipe.AddIngredient(null,"SpellFireII");
			recipe.AddIngredient(null,"SpellScroll");
			recipe.AddIngredient(ItemID.LavaBucket,5);
			recipe.AddIngredient(ItemID.LivingFireBlock,100);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
