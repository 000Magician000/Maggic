using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Spells.Buffs
{
	public abstract class BuffSpell : ModItem
	{
        public abstract int Buff { get; }

        public override void SetStaticDefaults()
        {
            StringBuilder buffName = new StringBuilder();
            foreach (char c in typeof(BuffID).GetFields().Single(i => (int)i.GetRawConstantValue() == Buff).Name)
            {
                if (char.IsUpper(c)) buffName.Append(" ");
                buffName.Append(c);
            }
            DisplayName.SetDefault("Buff Spell:" + buffName);
        }

        public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
            item.scale = .75f;
            item.rare = 0;
			item.useStyle = 5;
			item.useAnimation = item.useTime = 30;
            item.UseSound = SoundID.Item28;
		}

        public override bool UseItem(Player player)
        {
            MaggicPlayer modPlayer = player.GetModPlayer<MaggicPlayer>(mod);
            player.AddBuff(Buff, modPlayer.BuffSpellTime);
            player.AddBuff(mod.BuffType("SpellSickness"), modPlayer.BuffSpellDyslexia);
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<MaggicPlayer>(mod).Dyslexia;
        }

        protected ModRecipe Recipe { get; set; }
        public abstract void SpellRecipe();

        public override void AddRecipes()
        {
            Recipe = new ModRecipe(mod);
            Recipe.AddIngredient(null, "SpellScroll");

            SpellRecipe(); //Adds other ingredients

            Recipe.AddTile(TileID.Bookcases);
            Recipe.SetResult(this);
            Recipe.AddRecipe();
        }
    }
}
