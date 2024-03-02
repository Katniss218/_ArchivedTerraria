bool ActUp = false;
public void DamagePlayer(Player P,ref int DMG,NPC N)
{
    if(P.immune) return;
    int NT = N.type;
    if(NT == 2 || NT == 6 || NT == 42 || NT == 48 || NT == 49 || NT == 51 || NT == 60 || NT == 61 || NT == 62 || NT == 66 || NT == 75 || NT == 93 || NT == 94 || NT == 112 || NT == 133 || NT == 137 || NT == Config.npcDefs.byName["Illuminant Eye"].type || NT == Config.npcDefs.byName["Hallowor"].type || NT == Config.npcDefs.byName["Bloodshot Eye"].type || NT == Config.npcDefs.byName["Hallow Spit"].type || NT == Config.npcDefs.byName["Cloud Bat"].type)
    {
          ActUp = true;
          P.immune = true;
	  P.immuneAlpha = 0;
    }
}
public void DealtPlayer(Player P,double DMG,NPC N)
{
	if(ActUp)
	{
		P.immune = false;
		ActUp = false;
	}
	for(int i = 0; i < P.buffType.Length; i++)
	{
		if(P.buffType[i] == 32 || P.buffType[i] == 35 || P.buffType[i] == 31)
		{
			P.DelBuff(i);
			i=0;
		}
	}
}