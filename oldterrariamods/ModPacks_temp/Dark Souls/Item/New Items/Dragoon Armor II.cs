public static void Effects(Player player) {
    

if(player.statLife <= 160) {
				player.lifeRegen += 8;
				player.statDefense += 12; 
				player.manaRegenBuff = true;
				player.starCloak = true;
				player.magicCrit += 6;
				player.magicDamage += .10f;
				
				
int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 21, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.White, 2.0f);
 Main.dust[dust].noGravity = true;

				}
				else { 
					 
					player.starCloak = true;
					player.magicCrit += 3;
					player.magicDamage += .05f;


					}

}

public static int WINDEX = ModWorld.AddWingByTextureName("Dragon Wings"); //its static because there's no point to initialize this for every single item's instance
public static void SetBonus(Player player) {
	player.setBonus = "Harmonized with the four elements: fire, water, earth and air, including +6 life regen and 38% boost to all stats";
    player.lavaImmune=true;
    player.fireWalk=true;
    player.breath=9999999;
    player.waterWalk=true;
    player.noKnockback = true;
    player.meleeDamage += 0.38f;
    player.magicDamage += 0.38f;
    player.rangedDamage += 0.38f;
    player.rangedCrit += 38;
    player.meleeCrit += 38;
    player.magicCrit += 38;
    player.meleeSpeed += 0.38f;
    player.moveSpeed += 0.38f;
    player.manaCost -= 0.38f;
    player.lifeRegen += 6;
    player.wings = WINDEX;
    player.ShadowAura = true;
    
}
