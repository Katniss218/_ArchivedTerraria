#region Town Spawn
public static bool TownSpawn() 
{
    for (int pInv = 0; pInv < 48; pInv++)
    {
        if (Main.player[pInv].statLife > 120)
        {
            if (!NPC.AnyNPCs(Config.npcDefs.byName["Dog not Robot"].type)) return true;
            return false;
        }
    }
    return false;
}
#endregion

#region Name
public static string SetName() {

	return "Gir";
}
#endregion

#region Chat
public static string Chat() {
int x=Main.rand.Next(4);
	if(x==0){
		return "I put Bacon in your soap";
}
if(x==1){
		return "I'm gonna sing the DOOM song now";
}
if(x==2){
		return "I miss my cup cake";
}
if(x==3){
		return "I made mashed po-ta-toes!";
}
	return "... ;)";
}
#endregion

#region Setup Shop
public static void SetupShop(Chest chest) {
	int index=0;
	chest.item[index].SetDefaults("Alien Mask");
	index++;	
	chest.item[index].SetDefaults("Meteor Fist");
	index++;
	chest.item[index].SetDefaults("Meteor");
	index++;
	chest.item[index].SetDefaults("Homing Beacon");
	index++;
    chest.item[index].SetDefaults("Time Shifter");
	index++;
    chest.item[index].SetDefaults("Red Dye");
	index++;
    chest.item[index].SetDefaults("Yellow Dye");
	index++;
    chest.item[index].SetDefaults("Purple Dye");
	index++;
    chest.item[index].SetDefaults("Blue Dye");
	index++;
    chest.item[index].SetDefaults("Orange Dye");
	index++;
    chest.item[index].SetDefaults("Snow Block");
	index++;
    chest.item[index].SetDefaults("Safety Helmet");
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
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Gir Gore 1", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Gir Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Gir Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Gir Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Gir Gore 2", 1f, -1);
        Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), "Gir Gore 3", 1f, -1);
        }
}
#endregion