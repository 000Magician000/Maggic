using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Weapons.Staffs.GemStaffs
{
    public abstract class GemFork : ModItem
    {
        public abstract int Damage { get; }
        public abstract float Knockback { get; }
        public abstract int Proj { get; }
        public abstract float ProjSpeed { get; }
        public abstract int Mana { get; }
        public abstract int UseTime { get; }
        public abstract int Value { get; }

        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = Damage;
            item.magic = true;
            item.noMelee = true;
            item.width = 46;
            item.height = 44;
            item.useTime = UseTime;
            item.useAnimation = item.useTime;
            item.useStyle = 5;
            item.knockBack = Knockback;
            item.rare = 4;
            item.mana = Mana;
            item.value = Value;
            item.autoReuse = true;
            item.UseSound = SoundID.Item43;
            item.shoot = Proj;
            item.shootSpeed = ProjSpeed;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            Vector2 speed = new Vector2(speedX, speedY);
            Vector2 speed1 = speed.ToRotation().ToRotationVector2() * 10;
            Vector2 check = player.Center;
            Vector2 spd = speed.ToRotation().ToRotationVector2();
            float checkRange = 50;
            while (!WorldGen.SolidOrSlopedTile((int)check.X/16,(int)check.Y/16) && checkRange > 0)
            {
                check += spd;
                checkRange--;
            }

            if (checkRange <= 0)
            for (int i=-1;i<=1;i++)
            {
                Projectile.NewProjectile(position+new Vector2(speed1.Y,-speed1.X)*i+spd*50, speed, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }

    public class AmberFork : GemFork
    {
        public override int Damage { get { return 40; } }

        public override float Knockback { get { return 4.75f; } }

        public override int Proj { get { return ProjectileID.AmberBolt; } }

        public override float ProjSpeed { get { return 10; } }

        public override int Mana { get { return 8; } }

        public override int UseTime { get { return 24; } }
        public override int Value  { get { return 50000; } }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AmberStaff);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.Amber, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class AmethystFork : GemFork
    {
        public override int Damage { get { return 34; } }

        public override float Knockback { get { return 3.25f; } }

        public override int Proj { get { return ProjectileID.AmethystBolt; } }

        public override float ProjSpeed { get { return 6; } }

        public override int Mana { get { return 4; } }

        public override int UseTime { get { return 36; } }
        public override int Value { get { return 32000; } }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AmethystStaff);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.Amethyst, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class TopazFork : GemFork
    {
        public override int Damage { get { return 35; } }

        public override float Knockback { get { return 3.5f; } }

        public override int Proj { get { return ProjectileID.TopazBolt; } }

        public override float ProjSpeed { get { return 6.5f; } }

        public override int Mana { get { return 5; } }

        public override int UseTime { get { return 34; } }
        public override int Value { get { return 33000; } }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TopazStaff);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.TopazStaff, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class SapphireFork : GemFork
    {
        public override int Damage { get { return 37; } }

        public override float Knockback { get { return 4; } }

        public override int Proj { get { return ProjectileID.SapphireBolt; } }

        public override float ProjSpeed { get { return 7.5f; } }

        public override int Mana { get { return 6; } }

        public override int UseTime { get { return 30; } }
        public override int Value { get { return 40000; } }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SapphireStaff);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.Sapphire, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class EmeraldFork : GemFork
    {
        public override int Damage { get { return 39; } }

        public override float Knockback { get { return 4.25f; } }

        public override int Proj { get { return ProjectileID.EmeraldBolt; } }

        public override float ProjSpeed { get { return 8; } }

        public override int Mana { get { return 7; } }

        public override int UseTime { get { return 28; } }
        public override int Value { get { return 45000; } }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EmeraldStaff);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.Emerald, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class RubyFork : GemFork
    {
        public override int Damage { get { return 41; } }

        public override float Knockback { get { return 4.75f; } }

        public override int Proj { get { return ProjectileID.RubyBolt; } }

        public override float ProjSpeed { get { return 9; } }

        public override int Mana { get { return 8; } }

        public override int UseTime { get { return 24; } }
        public override int Value { get { return 50000; } }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RubyStaff);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.Ruby, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class DiamondFork : GemFork
    {
        public override int Damage { get { return 43; } }

        public override float Knockback { get { return 5.5f; } }

        public override int Proj { get { return ProjectileID.DiamondBolt; } }

        public override float ProjSpeed { get { return 9.5f; } }

        public override int Mana { get { return 9; } }

        public override int UseTime { get { return 22; } }
        public override int Value { get { return 60000; } }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DiamondStaff);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.Diamond, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
