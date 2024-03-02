public static bool TownSpawn() {

return true;

}

public static string SetName() {

	return "Omnir";
}

public static string Chat() {
int x=Main.rand.Next(4);
	if(x==0){
		return "Have you ever heard about Omnir's mod ? It's great !";
}
if(x==1){
		return "Check TerrariaOnline forums for incredible mods... like mine ! -Omnir";
}

		return "Cave Harpy Feathers, Rotten Chunks & Soul of Flight might attract the almighty dark wyverns";
}


public static void SetupShop(Chest chest) {
	int index=0;
	chest.item[index].SetDefaults("Snow Block");
    chest.item[index].value = 60;
	index++;
	chest.item[index].SetDefaults("SnowBall");
	index++;

    if(Main.dayTime == false){

	chest.item[index].SetDefaults("Space Helmet");
	index++;
	chest.item[index].SetDefaults("Space Pants");
	index++;
	chest.item[index].SetDefaults("Space Armor");
	index++;
}
}