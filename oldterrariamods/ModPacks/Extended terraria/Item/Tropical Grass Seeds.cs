public void UseItem(Player player, int playerID)
{
	int x = (int)((Main.mouseX + Main.screenPosition.X)/16);
	int y = (int)((Main.mouseY + Main.screenPosition.Y)/16);
	if (Main.tile[x, y].type == (ushort)Config.tileDefs.ID["Tropical Mud"] && Main.tile[x, y].active)
	{
		Main.tile[x, y].type = (ushort)Config.tileDefs.ID["Tropical Grass"];
		WorldGen.SquareTileFrame(x, y);
		player.inventory[player.selectedItem].stack++;
		//player.controlUseItem = false;
	}
}
public bool CanUse(Player P, int PID)
{
	int x = (int)((Main.mouseX + Main.screenPosition.X)/16);
	int y = (int)((Main.mouseY + Main.screenPosition.Y)/16);
	if (Main.tile[x, y].type != (ushort)Config.tileDefs.ID["Tropical Mud"] || !Main.tile[x, y].active)
	{
		return false;
	}
	else return true;
}