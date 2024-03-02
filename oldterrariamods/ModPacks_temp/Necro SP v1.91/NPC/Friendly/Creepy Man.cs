#region Town Spawn
public static bool TownSpawn() 
{
    for (int pInv = 0; pInv < 48; pInv++)
    {
        if (Main.player[pInv].statDefense > 20)
        {
            if (!NPC.AnyNPCs(Config.npcDefs.byName["Creepy Man"].type)) return true;
            return false;
        }
    }
    return false;
}
#endregion

#region Name
public static string SetName() {

	return "Salad Fingers";
}
#endregion

#region Chat
public static string Chat() {
int x=Main.rand.Next(7);
	if(x==0){
		return "I must find the perfect spoon";
}
if(x==1){
		return "Marjory Stewart Baxter, you taste like sunshine dust";
}
if(x==2){
		return "Hubert Cumberdale, you taste like soot and poo";
}
if(x==3){
		return "There'll be fog on the shore tonight, Bosun";
}
if(x==4){
		return "I've been enjoying the pleasures of nettles";
}
if(x==5){
		return "Hubert Cumberdale fancy seeing you here";
}
if(x==6){
		return "Jeremy Fisher, I thought you were out fighting the great war";
}
if(x==7){
		return "Oh bubble trumps!";
}
	return "...I like it when the red water comes out ;)";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) {
	int index=0;
	chest.item[index].SetDefaults("Pease Pudding");
	index++;	
	chest.item[index].SetDefaults("Derby Scones");
	index++;
	chest.item[index].SetDefaults("Gypsy Creams");
	index++;
	chest.item[index].SetDefaults("Admirals Pie");
	index++;
    chest.item[index].SetDefaults("The Scream");
	index++;	    
    chest.item[index].SetDefaults("Flight And Flood");
	index++;	    
    chest.item[index].SetDefaults("Nightmare");
	index++;	    
    chest.item[index].SetDefaults("Pogo The Clown");
	index++;
    chest.item[index].SetDefaults("Castle Dracula");
	index++;	    	    
    chest.item[index].SetDefaults("My Little Taxidermy Kit");
	index++;	
}
#endregion

#region Loot
public void NPCLoot()
{
	//generate particle effect
	Color color = new Color();
	Rectangle rectangle = new Rectangle((int)npc.position.X,(int)(npc.position.Y + ((npc.height - npc.width)/2)),npc.width,npc.width);//npc.frame;
	int count = 50;
	float vectorReduce = .4f;
	for (int i = 1; i <= count; i++)
	    {
		//int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
		int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 5, 0, 0, 50, Color.White, 1.0f);
		Main.dust[dust].noGravity = false;
		Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width/2)));
		Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height/2)));
        }

        if (npc.life <= 0)
        {
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Salad Fingers Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Salad Fingers Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Salad Fingers Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Salad Fingers Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Salad Fingers Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Salad Fingers Gore 4", 1f, -1);
        }
}
#endregion