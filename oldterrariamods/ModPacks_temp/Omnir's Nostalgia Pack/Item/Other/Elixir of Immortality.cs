//See here for more player attributes: http://tconfig.wikia.com/wiki/Player_Attributes
public static void Effects(Player player) 
{
    if (player.difficulty==2)
    {
        player.difficulty=1;
    }
}

public static void UseItem(Player player, int playerID)
{
    if (player.difficulty==2)
    {
        player.difficulty=1;
    }
}