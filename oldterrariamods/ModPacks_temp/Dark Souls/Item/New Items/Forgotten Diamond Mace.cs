public void UseItem(Player player, int playerID)
{
    bool playerHealed = false;
    if (playerID == Main.myPlayer)
    {
        if (Main.rand.Next(15) == 0)
        {
            if (!playerHealed)
            {
                player.statLife +=20;
                playerHealed = true;
                if (player.statLife > player.statLifeMax2)
                {
                    player.statLife=player.statLifeMax2;
                }
            }
        }
    }
}