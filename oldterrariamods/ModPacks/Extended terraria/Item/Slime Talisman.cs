bool ActUp = false;
public void DamagePlayer(Player P,ref int DMG,NPC N)
{
    if(P.immune) return;
    int NT = N.type;
    if(NT == 1 || NT == 16 || NT == 59 || NT == 71 || NT == 81 || NT == 121 || NT == 122 || NT == 138 || NT == 141 || NT == Config.npcDefs.byName["White Slime"].type || NT == Config.npcDefs.byName["Boom Slime"].type)
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
		if(P.buffType[i] == Config.buffDefs.ID["Frozen"] || P.buffType[i] == 22)
		{
			P.DelBuff(i);
			i=0;
		}
	}
}