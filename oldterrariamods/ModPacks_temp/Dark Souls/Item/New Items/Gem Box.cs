public static void Effects(Player player) 
{
    if(player.inventory[player.selectedItem].magic)
    {
        player.inventory[player.selectedItem].useTime = 5;
        player.inventory[player.selectedItem].useAnimation = 10;        
    }
}