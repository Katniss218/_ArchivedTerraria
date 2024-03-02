public static void Effects(Player player)
{
	bool incomp = false;
	for (int num36 = 2; num36 <= 6; num36++)
	{
	if (player.armor[num36].type == 54 || player.armor[num36].type == 405) incomp = true;
	}
	if (!incomp)
	{
	
	player.wings = 2;
	player.rocketBoots = 2;
    	player.moveSpeed += 0.20f; 
	player.doubleJump=true; 
	player.jumpBoost=true;
	player.fireWalk=true;
	player.noKnockback = true;

	if(player.jumpBoost)
        {
            player.jumpBoost = false;
            Player.jumpHeight = 27;
            Player.jumpSpeed = 6.51f;
        }

    if (player.controlLeft)
	{
	if (player.velocity.X > -3) player.velocity.X -= (float) (player.moveSpeed-1f)/10;
	if (player.velocity.X < -3 && player.velocity.X > -6*player.moveSpeed)
	{
	if (player.velocity.Y != 0) player.velocity.X -= 0.1f;
	else player.velocity.X -= 0.2f;
	player.velocity.X -= (float) 0.02+((player.moveSpeed-1f)/10);
	}
	}
    if (player.controlRight)
	{
	if (player.velocity.X < 3) player.velocity.X += (float) (player.moveSpeed-1f)/10;
	if (player.velocity.X > 3 && player.velocity.X < 6*player.moveSpeed)
	{
	if (player.velocity.Y != 0) player.velocity.X += 0.1f;
	else player.velocity.X += 0.2f;
	player.velocity.X += (float) 0.02+((player.moveSpeed-1f)/10);
	}
	}
	if (player.velocity.X > 6 || player.velocity.X < -6)
	{
	player.waterWalk = true;
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 16, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 100, color, 2.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = false;
	}
	//Main.NewText("Your speed is: "+player.velocity.X, 175, 75, 255);
	}
}