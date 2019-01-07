using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Maggic.Items.Weapons.Staffs
{
    public class LeafStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.magic = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.useStyle = 5;
            item.knockBack = 1.25f;
            item.rare = 2;
            item.mana = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("LeafBunch");
            item.shootSpeed = 4f;
            item.value = 2000;
        }
    }
}