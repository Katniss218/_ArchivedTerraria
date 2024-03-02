public void UseItem(Player player, int playerID)
{
if (playerID == Main.myPlayer) ModPlayer.Hunger += ModPlayer.ValueSix;
player.AddBuff(25, 7200, false);
}