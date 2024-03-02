public static void UseTile(Player player,int x , int y)
{

		player.ChangeSpawn(x,y+1);
		Main.NewText("Spawn point set!", 255, 240, 20);
	
}

public void DestroyTile(int x, int y){
Item.NewItem(x*16,y*16,32,32,Config.itemDefs.byName["Cold Bed"].type,1,false);
 

}
