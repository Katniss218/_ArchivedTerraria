
public int boneArmorCount = 26;


public void Effects(Player player) {
	player.statDefense += boneArmorCount;
}

public void SetBonus(Player player) {

    player.setBonus = "Grants Lava / Fire Immunity";
    player.lavaImmune = true;
    player.fireWalk = true;
    player.boneArmor = true;
}


public void Save(BinaryWriter writer) {
writer.Write(boneArmorCount);
}

public void Load(BinaryReader reader, int version) {
boneArmorCount = reader.ReadInt32();
this.item.toolTip3 = "Durability : "+boneArmorCount+"/26";
}

public void DealtPlayer(Player myPlayer, double damage, NPC npc){
if(boneArmorCount > 0){
boneArmorCount --;
this.item.toolTip3 = "Durability : "+boneArmorCount+"/26";
}

}

public void Initialize(){
this.item.toolTip3 = "Durability : "+boneArmorCount+"/26";
}

public int Repair(int stackCount) {
int consumed = 0;
stackCount = (int)stackCount/5;

for(int i=0; i<stackCount; i++){
    if(boneArmorCount<26){
        boneArmorCount++;
        consumed++;
this.item.toolTip3 = "Durability : "+boneArmorCount+"/26";
    }else{
        return consumed*5;
    }
}
return stackCount*5;

}