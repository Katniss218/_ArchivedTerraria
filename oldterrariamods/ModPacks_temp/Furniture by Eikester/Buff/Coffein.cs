public static void Effects(Player player) 
{
	if (player.controlLeft)
	{
		if (player.velocity.X > -5.5f*player.moveSpeed)
		{
			if (player.velocity.Y != 0) 
				player.velocity.X -= 0.1f;
			else 
				player.velocity.X -= 0.2f;
				
			player.velocity.X -= (float) 0.08+((player.moveSpeed-1f)/10);
		}
	}
		
	if (player.controlRight)
	{
		if (player.velocity.X < 5.5f*player.moveSpeed)
		{
			if (player.velocity.Y != 0) 
				player.velocity.X += 0.1f;
			else 
				player.velocity.X += 0.2f;
				
			player.velocity.X += (float) 0.08+((player.moveSpeed-1f)/10);
		}
	}
}
