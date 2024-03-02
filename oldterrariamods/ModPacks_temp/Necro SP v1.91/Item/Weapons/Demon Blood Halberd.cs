public void UseItemEffect(Player player, Rectangle rectangle)
{
	Color color = new Color();
	//This is the same general effect done with the Fiery Greatsword
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 5, 0, 0, 50, Color.White, 1.0f);
	Main.dust[dust].noGravity = true;
}
public void DealtNPC(Player player, NPC npc, double damage)
{
	player.statLife += (int)damage/10;
	//player.HealEffect((int)damage/10);
}

public void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
{
	myPlayer.statLife += (int)(damage*2)/10;
	//myPlayer.HealEffect((int)damage/10);
}