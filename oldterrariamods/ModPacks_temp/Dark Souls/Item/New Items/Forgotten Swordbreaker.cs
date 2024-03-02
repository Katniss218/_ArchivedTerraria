public void UseItem(Player player, int playerID)
{
    if (playerID == Main.myPlayer)
    {
        if (Main.rand.Next(20) == 0)
        {
            player.AddBuff("Invincible", 30, false);
        }
    }
}