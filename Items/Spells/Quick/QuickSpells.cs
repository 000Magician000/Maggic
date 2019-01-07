using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Spells.Quick
{
	public class QuickSpellDemonScythe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quick Spell: Demon Scythe");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.rare = 3;
			item.maxStack = 30;
			item.damage = 23;
			item.magic = true;
			item.noMelee = true;
			item.useStyle = 5;
			item.useTime = 35;
			item.useAnimation = item.useTime;
			item.consumable = true;
			item.noUseGraphic = true;
		}

		public override bool UseItem(Player player)
		{
			return true;
		}

		public override bool ConsumeItem(Player player)
		{
			if (player.whoAmI == item.owner)
				Shoot();
			return base.ConsumeItem(player);
		}

		private void Shoot()
		{
			Vector2 pos = Main.player[item.owner].Center;
			const int count = 10;
			const int speed = 2;
			const int type = ProjectileID.DemonScythe;

			for (int i = 0; i < count; i++)
			{
				Vector2 vel = (MathHelper.TwoPi / count * i).ToRotationVector2() * speed;
				Projectile.NewProjectileDirect(pos, vel, type, item.damage, 0f, item.owner);
			}
		}
	}
	
	public class QuickSpellFireFirework : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quick Spell: Fire Firework");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.rare = 2;
			item.damage = 16;
			item.magic = true;
			item.noMelee = true;
			item.useTime = 50;
			item.useAnimation = item.useTime;
			item.consumable = true;
			item.maxStack = 30;
			item.useStyle = 5;
			item.noUseGraphic = true;
			item.autoReuse = true;
		}

		public override bool UseItem(Player player)
		{
			if (player.whoAmI == item.owner)
				for (int i = 0; i < Main.rand.Next(5, 7); i++)
				{
					Vector2 position = player.Center;
					float spread = 0.3f;
					float dir = (MathHelper.TwoPi - MathHelper.TwoPi / 4) + Main.rand.NextFloat(-spread, spread);
					float speed = Main.rand.Next(7, 10);
					Vector2 vel = dir.ToRotationVector2() * speed;
					int type = mod.ProjectileType("FireFirework");
					Projectile.NewProjectile(position.X, position.Y, vel.X, vel.Y, type, 0, 0, Main.myPlayer);
				}

			return true;
		}
	}
	
	public class QuickSpellGlow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quick Spell: Glow Blow");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.rare = 2;
			item.maxStack = 30;
			item.useStyle = 1;
			item.useTime = 50;
			item.useAnimation = item.useTime;
			item.consumable = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("GlowBlow");
			item.shootSpeed = 0f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
			ref int damage,
			ref float knockBack)
		{
			if (player.whoAmI == item.owner)
				for (int i = 0; i < Main.rand.Next(14, 18); i++)
				{
					float range = Main.rand.NextFloat(0, 50);
					float dir = Main.rand.NextFloat(MathHelper.TwoPi);
					Vector2 rangee = dir.ToRotationVector2() * range;
					Vector2 vel = new Vector2(0, 0);
					int proj = Projectile.NewProjectile(position.X + rangee.X, position.Y + rangee.Y, vel.X, vel.Y, type, 0, 0,
						Main.myPlayer);
					Main.projectile[proj].timeLeft = 900;
				}

			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
	
	public class QuickSpellSkyArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quick Spell: Arrow Rain");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.rare = 1;
			item.maxStack = 30;
			item.damage = 15;
			item.magic = true;
			item.noMelee = true;
			item.useStyle = 5;
			item.useTime = 35;
			item.useAnimation = item.useTime;
			item.consumable = true;
			item.noUseGraphic = true;
		}

		public override bool UseItem(Player player)
		{
			return true;
		}

		public override bool ConsumeItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				Vector2 position = Main.MouseWorld;
				for (int i = 0; i < Main.rand.Next(10, 14); i++)
				{
					Vector2 vel = new Vector2(Main.rand.Next(-3, 3), Main.rand.Next(7, 15));
					int rand = 70;
					int type = 1;
					Vector2 pos = new Vector2(position.X + Main.rand.Next(-rand, rand), position.Y - 800);


					Projectile proj = Projectile.NewProjectileDirect(pos, vel, type,
						item.damage, 0, Main.myPlayer);
					proj.timeLeft = 300;
					proj.penetrate = 1;
					proj.tileCollide = false;
					proj.noDropItem = true;
					proj.scale = 1.1f;
				}
			}

			return base.ConsumeItem(player);
		}
	}
}