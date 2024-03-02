public int boneCount = 50;

public void DamageNPC(Player myPlayer,NPC npc, ref int damage, ref float knockback){
boneCount --;
this.item.toolTip3  = "Durability : "+boneCount+"/50";
}

public void Initialize(){
this.item.toolTip3 = "Durability : "+boneCount+"/50";

}
public void Save(BinaryWriter writer) {
writer.Write(boneCount);
}

public void Load(BinaryReader reader, int version) {
boneCount = reader.ReadInt32();
this.item.toolTip3  = "Durability : "+boneCount+"/50";
}


public bool CanUse(Player player, int playerID){
if(boneCount < 1){
return false;
}
return true;
}


public int Repair(int stackCount) {
int consumed = 0;
stackCount = (int)stackCount/3;


for(int i=0; i<stackCount; i++){
    if(boneCount<50){
        boneCount++;
        consumed++;
this.item.toolTip3  = "Durability : "+boneCount+"/50";
    }else{
        return consumed*3;
    }
}
return stackCount*3;

}


public int DecreaseCount(int stackCount) {
boneCount--;
return boneCount;
}