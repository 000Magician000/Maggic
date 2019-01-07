using Terraria;
using Terraria.ModLoader;

namespace Maggic.Buffs
{
	public class SpellSickness : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dyslexia");
			Description.SetDefault("You can't use buff spells");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MaggicPlayer>(mod).Dyslexia = true;
		}
	}
}