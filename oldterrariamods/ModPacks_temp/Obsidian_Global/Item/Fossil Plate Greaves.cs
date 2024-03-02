
public int boneArmorCount = 15;


public void Effects(Player player) {
	player.statDefense += boneArmorCount;
}


public void Save(BinaryWriter writer) {
writer.Write(boneArmorCount);
}

public void Load(BinaryReader reader, int version) {
boneArmorCount = reader.ReadInt32();
this.item.toolTip3 = "Durability : "+boneArmorCount+"/15";
}

public void DealtPlayer(Player myPlayer, double damage, NPC npc){
if(boneArmorCount > 0){
boneArmorCount --;
this.item.toolTip3 = "Durability : "+boneArmorCount+"/15";
}

}

public void Initialize(){
this.item.toolTip3 = "Durability : "+boneArmorCount+"/15";
}

public int Repair(int stackCount) {
int consumed = 0;
stackCount = (int)stackCount/5;

for(int i=0; i<stackCount; i++){
    if(boneArmorCount<15){
        boneArmorCount++;
        consumed++;
this.item.toolTip3 = "Durability : "+boneArmorCount+"/15";
    }else{
        return consumed*5;
    }
}
return stackCount*5;

}