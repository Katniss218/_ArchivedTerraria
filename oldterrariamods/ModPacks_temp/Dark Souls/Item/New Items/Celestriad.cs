public static void Effects(Player player) 
{
    if(player.inventory[player.selectedItem].magic)
    {
        player.inventory[player.selectedItem].mana = 1;
    }
}