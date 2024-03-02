public void NPCLoot(){
	if(npc.type == 3 || npc.name == "Kyonshi"){
		if(Main.rand.Next(3)==1){
			Item.NewItem((int)npc.position.X,(int)npc.position.Y, 16, 16, (int)Config.itemDefs.byName["Surprise Box"].type);
		}
	}
	else if(npc.type == 46){
		if(Main.rand.Next(5)==1){
			Item.NewItem((int)npc.position.X,(int)npc.position.Y, 16, 16, (int)Config.itemDefs.byName["Raw Rabbit"].type);
		}
	}
}