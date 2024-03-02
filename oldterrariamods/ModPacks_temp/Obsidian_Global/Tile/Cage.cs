

public void Update(int x, int y){


for(int i=0; i<Main.npc.Length; i++){
float differenceX = ((Main.npc[i].position.X )- (x*16));
float differenceY = ((Main.npc[i].position.Y )- (y*16));

if( differenceX > 10f || differenceX < -10f || differenceY > 10f || differenceY < -10f){

}else{
if(Main.npc[i].life < 5){

if(Main.npc[i].name == "Bunny"){

Main.npc[i].position.X += 100;
Main.npc[i].active = false;
Item.NewItem(x*16,y*16,32,32,Config.itemDefs.byName["BunnyCage"].type,1,false);
 
}
if(Main.npc[i].name == "Blue Slime" || Main.npc[i].name == "Green Slime"){

Main.npc[i].position.X += 100;
Main.npc[i].active = false;
Item.NewItem(x*16,y*16,32,32,Config.itemDefs.byName["SlimeCage"].type,1,false);
 
}
if(Main.npc[i].name == "Giant Worm Head" || Main.npc[i].name == "Giant Worm Body" || Main.npc[i].name == "Giant Worm Tail"){

Main.npc[i].position.X += 100;
Main.npc[i].active = false;
Item.NewItem(x*16,y*16,32,32,Config.itemDefs.byName["WormCage"].type,1,false);
 
}


}
}
}
}

public void DestroyTile(int x, int y){
Item.NewItem(x*16,y*16,32,32,Config.itemDefs.byName["Cage"].type,1,false);
 

}
