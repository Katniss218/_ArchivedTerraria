public void UpdatePlayer(Player P)
{

	if (P.inventory[P.selectedItem].type == Config.itemDefs.byName["Nunchaku"].type)
	{
		Main.chain3Texture = Main.goreTexture[Config.goreID["Grey Chain"]];
	}
	
	if (P.inventory[P.selectedItem].type != Config.itemDefs.byName["Nunchaku"].type)
	{
		Main.chain3Texture = Main.goreTexture[Config.goreID["Blue Moon Chain"]];
	}

}

public bool IsShield(Item I)
{
    if(I.shoot == 0) return false;
    if(I.RunMethod("This_Is_A_Shield")) return true;
    return false;
}