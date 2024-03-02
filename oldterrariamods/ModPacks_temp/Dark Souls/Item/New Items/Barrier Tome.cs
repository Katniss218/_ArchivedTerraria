//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    player.AddBuff("Barrier", 1200, false);
}

public static void UseItem(Player player, int playerID)
{
    player.AddBuff("Barrier", 1200, false);
}