//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
   player.kbGlove=true; 
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+37% damage, 50% move speed, 8 life regen, drowning immune, lava immune + many other abilities";
	player.lavaImmune=true;
        player.fireWalk=true;
        player.breath=9999999;
        player.waterWalk=true;
    	player.noKnockback = true;
    	player.meleeDamage += 0.37f;
    	player.magicDamage += 0.37f;
    	player.rangedDamage += 0.37f;
    	player.meleeSpeed += 0.37f;
    	player.moveSpeed += 0.50f;
    	player.manaCost -= 0.37f;
    	player.lifeRegen += 8;
	player.nightVision=true;
        player.noFallDmg=true;
	player.ShadowTail = true;
	//player.ShadowAura = true;

	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 32, player.velocity.X-3f, player.velocity.Y, 150, Color.Yellow, 1f);
                Main.dust[dust].noGravity = true;
        
int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
						int j2 = (int)(player.position.Y + 2f) / 16;
						Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);
    	
  
}