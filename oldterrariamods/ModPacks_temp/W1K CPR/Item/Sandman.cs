int coolDownBall = 0;

public void UseItem(Player player, int playerID)
{
	if (coolDownBall <= 0 && Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.R))
	{
		float num48 = 12f;
		float speedX = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f));
		float speedY = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + player.height * 0.5f));
		float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
		num51 = num48 / num51;
		speedX *= num51;
		speedY *= num51;
		Projectile.NewProjectile(player.position.X + (player.width * 0.5f),player.position.Y + (player.height * 0.5f), (float) speedX, (float) speedY, "Baseball", item.damage/2, 1, playerID);
		Main.PlaySound(2,(int)player.position.X,(int)player.position.Y,SoundHandler.soundID["bat_baseball_hit1"]);
		coolDownBall = 180;
	}
}

public void FrameEffect(Player player)
{
	if (coolDownBall > 0)
	{
	coolDownBall -= 1;
	if (coolDownBall == 0 && Main.netMode != 2 && Main.myPlayer == player.whoAmi) Main.PlaySound(2,-1,-1,SoundHandler.soundID["beepRecharge"]);
	}
}

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback)
{
	Main.PlaySound(2,(int)npc.position.X,(int)npc.position.Y,SoundHandler.soundID["bat_baseball_hit_flesh"]);
}