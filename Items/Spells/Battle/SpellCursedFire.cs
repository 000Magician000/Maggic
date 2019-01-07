using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Spells.Battle
{
	public class SpellCursedFireI : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Cursed Fire [I]");
		}
		
		public override void SetDefaults()
		{
			item.damage = 34;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 36;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 15;
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

				for (int i = 0; i < 1; i++)
				{
					Vector2 vel = new Vector2(0, 3);
					int type = ProjectileID.CursedFlameFriendly;
					int rand = 20;
					Vector2 pos = new Vector2(position.X + Main.rand.NextFloat(-rand, rand), position.Y + Main.rand.Next(-rand, rand));
					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 100 + Main.rand.Next(-10, 10);
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
			recipe.AddIngredient(ItemID.CursedFlame, 20);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
	public class SpellCursedFireII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Cursed Fire [I]");
		}
		public override void SetDefaults()
		{
			item.damage = 39;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 36;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 17;
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
				for (int i = 0; i < 3; i++)
				{
					Vector2 vel = new Vector2(0, 5);
					int type = ProjectileID.CursedFlameFriendly;
					int rand = 30;
					Vector2 pos = new Vector2(position.X + Main.rand.NextFloat(-rand, rand),position.Y + Main.rand.NextFloat(-rand, rand));
					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 100 + Main.rand.Next(-10, 10);
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
			recipe.AddIngredient(null,"SpellCursedFireI");
			recipe.AddIngredient(null,"SpellScroll");
			recipe.AddIngredient(ItemID.CursedFlame, 20);
			recipe.AddIngredient(ItemID.CrystalShard, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
	public class SpellCursedFireIII : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Cursed Fire [III]");
		}
		public override void SetDefaults()
		{
			item.damage = 46;
			item.magic = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 36;
			item.useAnimation = item.useTime;
			item.useStyle = 5;
			item.knockBack = 0;
			item.mana = 19;
			item.noUseGraphic = true;
			item.rare = 6;
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
					int type = ProjectileID.CursedFlameFriendly;
					int rand = 30;
					Vector2 pos = new Vector2(position.X + Main.rand.NextFloat(-rand, rand),position.Y + Main.rand.NextFloat(-rand, rand));
					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0, item.owner);
					proj.timeLeft = 100 + Main.rand.Next(-10, 10);
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
			recipe.AddIngredient(null,"SpellCursedFireII");
			recipe.AddIngredient(null,"SpellScroll");
			recipe.AddIngredient(ItemID.CursedFlame, 30);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddTile(mod.TileType("EnchantedTable_Tile"));			
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}