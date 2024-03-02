public static Rectangle PlayerRect;

public static void UseItemEffect(Player player, Rectangle rectangle) 
{
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 75, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
	Main.dust[dust].noGravity = true;
	
	Lighting.addLight((int)((player.itemLocation.X + 6f + player.velocity.X) / 16f), (int)((player.itemLocation.Y - 14f) / 16f), 0.7f, 0.99f, 0f);
}

public void DealtNPC(Player player, NPC npc, double damage)
{
	PlayerRect.X = (int)(player.position.X + 0.5f);
	PlayerRect.Y = (int)(player.position.Y + 0.5f);
	PlayerRect.Width = player.width;
	PlayerRect.Height = player.height;
	int drain = (int)damage/10;
	
	player.statLife += drain;
	CombatText.NewText(PlayerRect, Color.SpringGreen, " " + drain + " ");
}

public void DealtPVP(Player myPlayer, int damage, Player enemyPlayer)
{
	PlayerRect.X = (int)(myPlayer.position.X + 0.5f);
	PlayerRect.Y = (int)(myPlayer.position.Y + 0.5f);
	PlayerRect.Width = myPlayer.width;
	PlayerRect.Height = myPlayer.height;
	int drain = (int)(damage*2)/10;
	
	myPlayer.statLife += drain;
	CombatText.NewText(PlayerRect, Color.SpringGreen, " " + drain + " ");
}