int level = 1;
int lastrecord=0;
public void EffectsStart(Player P,int buffIndex,int buffType,int buffTime) 
{
    lastrecord = buffTime-1;
}
public void Effects(Player P,int buffIndex,int buffType,int buffTime) 
{
    P.statDefense-=level;
    if(lastrecord <= buffTime)
    {
        lastrecord = buffTime;
        if(level < 30) level++;
    }
    Main.buffTip[buffType] = "Decreased defense by " + level;
}











/* static int count = 1;
public static void Effects(Player P, int buffIndex, int buffType, int buffTime)
{
	//dostuff = true;
	Main.buffTip[buffType] = "Decreased defense by " + count;
}
public static void DamagePlayer(Player P, ref int dmg, NPC N)
{
	if (N.type == Config.npcDefs.byName["Wyvern Mage Shadow"].type)
	{
		if (count < 30)
		{
			count++;
			P.statDefense--;
		}
	}
}
public static void EffectsEnd(Player P, int buffIndex, int buffType, int buffTime)
{
	P.statDefense += (count - 1);
	count = 1;
	//dostuff = false;
} */