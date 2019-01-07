using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Maggic.Items.Spells.Battle
{
    public abstract class SpellRoseBase : ModItem
    {
        public override void SetDefaults()
        {
            item.magic = true;
            item.noMelee = true;
            item.width = 36;
            item.height = 36;
            item.useAnimation = item.useTime = 45;
            item.useStyle = 5;
            item.knockBack = 0;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.useTurn = true;

            SetSpellDefaults();
        }

        public abstract void SetSpellDefaults();

        protected const int MagicRange = 400;

        public abstract int TimesShoot { get; }
        public override bool UseItem(Player player)
        {
            if (player.whoAmI == item.owner)
            {
                for (int t = 0; t < TimesShoot; t++)
                {
                    //MousePosition + (Direction * Distance)
                    Vector2 initPos = Main.MouseWorld + Main.rand.NextFloat(MathHelper.TwoPi).ToRotationVector2() * Main.rand.NextFloat(150, 350);
                    Vector2 velocity = VectorHelper.FromTo(initPos, Main.MouseWorld, 18);

                    Projectile.NewProjectileDirect(initPos, velocity, ProjectileID.FlowerPetal, item.damage, 0, item.owner).timeLeft = 90;
                }
            }

            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return Vector2.Distance(Main.player[item.owner].position, Main.MouseWorld) < MagicRange;
        }
    }

	public class SpellRoseI : SpellRoseBase
	{
        public override int TimesShoot { get { return 1; } }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Petals [I]");
        }

        public override void SetSpellDefaults()
        {
            item.damage = 30;
            item.mana = 10;
            item.rare = 4;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpellScroll");
			recipe.AddIngredient(ItemID.OrichalcumBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
	public class SpellRoseII : SpellRoseBase
	{
        public override int TimesShoot { get { return 2; } }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Petals [II]");
        }

        public override void SetSpellDefaults()
        {
            item.damage = 36;
            item.mana = 12;
            item.rare = 5;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpellRoseI");
			recipe.AddIngredient(null, "SpellScroll");
			recipe.AddIngredient(ItemID.OrichalcumBar, 15);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
	public class SpellRoseIII : SpellRoseBase
	{
        public override int TimesShoot { get { return 3; } }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spell: Petals [III]");
        }

        public override void SetSpellDefaults()
        {
            item.damage = 41;
            item.mana = 15;
            item.rare = 6;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"SpellRoseII");
			recipe.AddIngredient(null, "SpellScroll");
			recipe.AddIngredient(ItemID.OrichalcumBar, 20);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddTile(mod.TileType("EnchantedTable_Tile"));	
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}