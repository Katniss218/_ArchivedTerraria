public static void Effects(Player player) 
{
    if (player.statLife <= (player.statLifeMax*0.25f))
    {
        player.AddBuff("Barrier", 60, false);
    }
}
