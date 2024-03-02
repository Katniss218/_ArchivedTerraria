
public static void Effects(Player player) 
{
    //player.noFallDmg = true;
	int num21 = (int)(player.position.Y / 16f) - player.fallStart;
    if ((player.gravDir == 1f) && (player.velocity.Y > 0))
    {
        player.meleeDamage *= (int) ((player.velocity.Y*0.15) + 1);
    }
    if ((player.gravDir == -1f) && (player.velocity.Y < 0))
    {
        player.meleeDamage *= (int) -(((player.velocity.Y*0.15) - 1));
    }
    //Player.jumpHeight += 5;
	//Player.jumpSpeed += 5f;
}


public void UseItem(Player player, int playerID)
{
    bool playerHealed = false;
    if (playerID == Main.myPlayer)
    {
        if (Main.rand.Next(2) == 0)
        {
            if (!playerHealed)
            {
                player.statLife +=30;
                playerHealed = true;
                if (player.statLife > player.statLifeMax2)
                {
                    player.statLife=player.statLifeMax2;
                }
            }
        }
    }
}