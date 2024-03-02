public static void Effects(Player player) 
{
    player.noFallDmg = true;
    player.moveSpeed += 0.3f;
    player.jumpAgain= true;
    player.doubleJump = true;
    Player.jumpHeight += 5;
	Player.jumpSpeed += 1f;
//Modified W1k's "Supersonic Boots" code.
    bool incomp = false;
    for (int num36 = 2; num36 <= 7; num36++)
    {
        if (player.armor[num36].type == 54 || player.armor[num36].type == 405) incomp = true;
    }
    float OmnNum1 = 5f;
    if (!incomp)
    {
        if (player.controlLeft)
        {
            if (player.velocity.X > -3) player.velocity.X -= (float) (player.moveSpeed-1f)/10;
            if (player.velocity.X < -3 && player.velocity.X > -OmnNum1*player.moveSpeed)
            {
                if (player.velocity.Y != 0) player.velocity.X -= 0.1f;
                else player.velocity.X -= 0.2f;
                player.velocity.X -= (float) 0.02+((player.moveSpeed-1f)/10);
            }
            else if ((player.velocity.X < -OmnNum1) && (player.velocity.X > ((-OmnNum1) - 1)))
            {
                player.velocity.X += 0.5f;
            }
            else if ((player.velocity.X < ((-OmnNum1) - 1)) && (player.velocity.X > ((-OmnNum1) - 2)))
            {
                player.velocity.X += 0.75f;
            }
            else if ((player.velocity.X < ((-OmnNum1) -2)))
            {
                player.velocity.X += 1f;
            }            
        }
        if (player.controlRight)
        {
            if (player.velocity.X < 3) player.velocity.X += (float) (player.moveSpeed-1f)/10;
            if (player.velocity.X > 3 && player.velocity.X < OmnNum1*player.moveSpeed)
            {
                if (player.velocity.Y != 0) player.velocity.X += 0.1f;
                else player.velocity.X += 0.2f;
                player.velocity.X += (float) 0.02+((player.moveSpeed-1f)/10);
            }
            else if ((player.velocity.X > OmnNum1) && (player.velocity.X < ((OmnNum1) + 1)))
            {
                player.velocity.X -= 0.5f;
            }
            else if ((player.velocity.X < ((-OmnNum1) + 1)) && (player.velocity.X > ((-OmnNum1) + 2)))
            {
                player.velocity.X -= 0.75f;
            }
            else if ((player.velocity.X > (OmnNum1 + 2)))
            {
                player.velocity.X -= 1f;
            }    
        }
        if (player.velocity.X > 5 || player.velocity.X < -5)
        {
			int num35 = 0;
			if (player.gravDir == -1f)
			{
				num35 -= player.height;
			}
			if (player.runSoundDelay == 0 && player.velocity.Y == 0f)
			{
				Main.PlaySound(17, (int)player.position.X, (int)player.position.Y, 1);
				player.runSoundDelay = 9;
			}
            Color color = new Color();
            Vector2 arg_3FFD_0 = new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num35);
			int arg_3FFD_1 = player.width + 8;
			int arg_3FFD_2 = 4;
			int arg_3FFD_3 = 16;
			float arg_3FFD_4 = -player.velocity.X * 0.5f;
			float arg_3FFD_5 = player.velocity.Y * 0.5f;
			int arg_3FFD_6 = 50;
			Color newColor = default(Color);
			int num36 = Dust.NewDust(arg_3FFD_0, arg_3FFD_1, arg_3FFD_2, arg_3FFD_3, arg_3FFD_4, arg_3FFD_5, arg_3FFD_6, newColor, 1.5f);
			Main.dust[num36].velocity.X = Main.dust[num36].velocity.X * 0.2f;
			Main.dust[num36].velocity.Y = Main.dust[num36].velocity.Y * 0.2f;
        }
    }
    //Main.NewText("Your speed is: "+player.velocity.X, 175, 75, 255);
}