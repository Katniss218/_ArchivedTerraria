static bool Vision = false;
public static void Effects(Player player) {
	if(Main.GetKeyState((int)Microsoft.Xna.Framework.Input.Keys.Q) < 0 && Vision)
	{
        player.detectCreature = false;
        player.findTreasure = false;
        player.nightVision = false;
	}
	if(Main.GetKeyState((int)Microsoft.Xna.Framework.Input.Keys.Q) < 0 && !Vision)
	{
		player.AddBuff(11,1,false);
        player.detectCreature = true;
        player.findTreasure = true;
        player.nightVision = true;
	}
}