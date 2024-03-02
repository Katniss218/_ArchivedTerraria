//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.onFire = false;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+20% magic/ranged damage, +10% MS, -30% MC, nightvision, +3 HP regen, +No knockback, fall damage or fire damage.";
	
        player.fireWalk=true;
    	player.noKnockback = true;
    	player.magicDamage += 0.20f;
    	player.rangedDamage += 0.20f;
    	player.moveSpeed += 0.10f;
    	player.manaCost -= 0.30f;
    	player.lifeRegen += 3;
	player.nightVision=true;
        player.noFallDmg=true;
	//player.ShadowTail = true;
	player.ShadowAura = true;

	
        
int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
						int j2 = (int)(player.position.Y + 2f) / 16;
						Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);
    	
  
}