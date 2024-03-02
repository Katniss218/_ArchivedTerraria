public static void Effects(Player player) 
{
    if (player.statLife <= (player.statLifeMax*0.30f))
    {
        player.AddBuff("Wall", 60, false);
    }
}
