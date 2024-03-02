//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.manaCost -= 0.15f;
}

public static void SetBonus(Player player) 
{
	player.setBonus = "+5% magic damage, +60 mana";
    player.magicDamage += 0.5f;
	player.statManaMax2 += 60;
}

public void PlayerFrame(Player player)
{
	if (Main.rand.Next(3)==0)
	{
	
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 200, Color.Yellow, 1.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = false;
	}
}