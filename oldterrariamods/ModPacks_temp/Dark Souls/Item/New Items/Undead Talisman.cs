bool ActUpUT = false;
bool immunityUT = false;
int placeHolderDMG;
int placeHolderDMG2;
public void DamagePlayer(Player P,ref int DMG,NPC N)
{
    if(P.immune) return;
    int NT = N.type;
    if(NT == 3 || NT == 21 || NT == 31 || NT == 32 || NT == 33 || NT == 34 || NT == 44 || NT == 45 || NT == 52 || NT == 53 || NT == 77 || NT == 78 || NT == 79 || NT == 80 || NT == 82 || NT == 109 || NT == 110 || NT == 132 || NT == 140 || NT == Config.npcDefs.byName["Magma Skeleton"].type || NT == Config.npcDefs.byName["Troll"].type || NT == Config.npcDefs.byName["Heavy Zombie"].type || NT == Config.npcDefs.byName["Ice Skeleton"].type || NT == Config.npcDefs.byName["Irate Bones"].type)
    {
          placeHolderDMG = N.damage;
          placeHolderDMG2 = placeHolderDMG - (int)(P.statDefense / 2) - 8;
          ActUpUT = true;
          if (placeHolderDMG2 <= 0)
          {
              //N.damage = 0;
              P.immune = true;
	      P.immuneAlpha = 0;
              immunityUT = true;
          }
          else N.damage = placeHolderDMG2;
    }
}
public void DealtPlayer(Player P,double DMG,NPC N)
{
	if(ActUpUT)
	{
		int NT = N.type;
		if(NT == 3 || NT == 21 || NT == 31 || NT == 32 || NT == 33 || NT == 34 || NT == 44 || NT == 45 || NT == 52 || NT == 53 || NT == 77 || NT == 78 || NT == 79 || NT == 80 || NT == 82 || NT == 109 || NT == 110 || NT == 132 || NT == 140 || NT == Config.npcDefs.byName["Magma Skeleton"].type || NT == Config.npcDefs.byName["Troll"].type || NT == Config.npcDefs.byName["Heavy Zombie"].type || NT == Config.npcDefs.byName["Ice Skeleton"].type || NT == Config.npcDefs.byName["Irate Bones"].type)
		{
			if (immunityUT)
			{
				P.immune = false;
				immunityUT = false;
			}
			else N.damage = placeHolderDMG;
			//N.damage = placeHolderDMG;
		}
		ActUpUT = false;
	}
	for(int i = 0; i < P.buffType.Length; i++)
	{
		if(P.buffType[i] == 36 || P.buffType[i] == 24 || P.buffType[i] == 23)
		{
			P.DelBuff(i);
			i=0;
		}
	}
}
