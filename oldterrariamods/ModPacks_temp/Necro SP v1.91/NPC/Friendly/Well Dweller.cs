#region Town Spawn
public static bool TownSpawn() 
{
    if (!NPC.AnyNPCs(Config.npcDefs.byName["Well Dweller"].type)) return true;
    return false;
}
#endregion

#region Name
public static string SetName() {

	return "Samara";
}
#endregion

#region Chat
public static string Chat() {
int x=Main.rand.Next(4);
	if(x==0){
		return "uuuuggggghhhhh";
}
if(x==1){
		return "gargle gargle gargle";
}
if(x==2){
		return "*choking sound*";
}
if(x==3){
		return "Pardon me, I seem to have misplaced my video tape. By chance have you seen it?";
}
	return "... ;)";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) {
	int index=0;
    chest.item[index].SetDefaults("Damned Chest");
	index++;	    
    chest.item[index].SetDefaults("Iron Gate");
	index++;	    
	chest.item[index].SetDefaults("Asian Style Chair");
	index++;	
	chest.item[index].SetDefaults("Asian Style Lamp");
	index++;	
    chest.item[index].SetDefaults("Asian Style Table");
	index++;	
	chest.item[index].SetDefaults("Asian Style Long Table");
	index++;	
    chest.item[index].SetDefaults("Asian Style Tea Pot");
	index++;	
	chest.item[index].SetDefaults("Bamboo Wall");
	index++;	
    chest.item[index].SetDefaults("Bonzai Tree");
	index++;	
	chest.item[index].SetDefaults("Green Asian Drapes");
	index++;	
    chest.item[index].SetDefaults("Green Decorative Chinese Lantern");
	index++;	
    chest.item[index].SetDefaults("The Well");
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
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Samara Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Samara Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Samara Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Samara Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Samara Gore 3", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Samara Gore 4", 1f, -1);
        }
}
#endregion