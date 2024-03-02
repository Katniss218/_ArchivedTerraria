public static bool TownSpawn() {
if(Main.rand.Next(5000)==0){
		return true;
}
return false;
}

public static string SetName() {
	if(Main.rand.Next(1)==0)
		return "Rogger";
	return "PanPan";
}

public static string Chat() {
	if(Main.rand.Next(1)==0)
		return "You may think i'm useless but... Well... Let's see will you ?";
	return "Yeah i can speak, so what ? You've magic missiles and stuff, why not a talking rabbit, huh ?";
}