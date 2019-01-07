using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Spells.Battle
{
	public class SpellFrozenFireI : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Frozen Fire [I]");
		}
		public override void SetDefaults()
		{
			item.damage = 35;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 38;
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
				Vector2 position = Main.MouseWorld;
				for (int i = 0; i < 1; i++)
				{
					Vector2 vel = new Vector2(0, 4);
					int type = ProjectileID.BallofFrost;
					int rand = 30;
					Vector2 pos = new Vector2(position.X + Main.rand.NextFloat(-rand, rand),position.Y + Main.rand.NextFloat(-rand, rand));
					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 105 + Main.rand.Next(-10, 10);
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
			recipe.AddIngredient(null,"SpellScroll");
			recipe.AddIngredient(ItemID.WaterBucket);
			recipe.AddIngredient(ItemID.IceBlock,100);
			recipe.AddIngredient(ItemID.SnowBlock,100);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
	public class SpellFrozenFireII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Frozen Fire [II]");
		}
		public override void SetDefaults()
		{
			item.damage = 38;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 38;
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

				for (int i = 0; i < 3; i++)
				{
					Vector2 vel = new Vector2(0, 5);
					int type = ProjectileID.BallofFrost;
					int rand = 30;
					Vector2 pos = new Vector2(position.X + Main.rand.NextFloat(-rand, rand),position.Y + Main.rand.NextFloat(-rand, rand));
					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 105 + Main.rand.Next(-10, 10);
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
			recipe.AddIngredient(null,"SpellFrozenFireI");
			recipe.AddIngredient(null,"SpellScroll");
			recipe.AddIngredient(ItemID.WaterBucket,3);
			recipe.AddIngredient(ItemID.FlowerofFrost);
			recipe.AddIngredient(ItemID.Shiverthorn,10);
			recipe.AddIngredient(ItemID.IceBlock,200);
			recipe.AddIngredient(ItemID.SnowBlock,200);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
	public class SpellFrozenFireIII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Frozen Fire [III]");
		}
		public override void SetDefaults()
		{
			item.damage = 43;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 38;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 12;
			item.noUseGraphic = true;
			item.rare = 5;
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
				
				for (int i = 0; i < 5; i++)
				{
					Vector2 vel = new Vector2(0, 7);
					int type = ProjectileID.BallofFrost;
					int rand = 30;
					Vector2 pos = new Vector2(position.X + Main.rand.NextFloat(-rand, rand),position.Y + Main.rand.NextFloat(-rand, rand));
					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 105 + Main.rand.Next(-10, 10);
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
			recipe.AddIngredient(null,"SpellFrozenFireII");
			recipe.AddIngredient(null,"SpellScroll");
			recipe.AddIngredient(ItemID.WaterBucket,5);
			recipe.AddIngredient(ItemID.FrostCore,2);
			recipe.AddIngredient(ItemID.IceBlock,300);
			recipe.AddIngredient(ItemID.SnowBlock,300);
			recipe.AddTile(mod.TileType("EnchantedTable_Tile"));	
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
