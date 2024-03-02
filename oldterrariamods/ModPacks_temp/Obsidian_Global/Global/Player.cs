public static bool parallelVisit = false;
public static NPC target = null;
public static bool hasPet = false;
public static NPC pet = null;
public static string associatedWorld = "";
public static string currentWorld = "Normal";
public static string NormalWorldName = "";
public static bool portalUse = false;
public static Texture2D skinBody ;
public static Texture2D playerShirt ;
public static Texture2D skinLegs ;
public static Texture2D playerHead;

public void Load(BinaryReader reader) {
    hasPet = false;
    pet = null;
    associatedWorld=reader.ReadString();
    NormalWorldName=reader.ReadString();
    parallelVisit=reader.ReadBoolean();
}


public void Save(BinaryWriter writer) {

Main.skinBodyTexture = skinBody ;
Main.playerShirtTexture = playerShirt;
Main.skinLegsTexture = skinLegs;
Main.playerHeadTexture =  playerHead;

    writer.Write(associatedWorld);
    writer.Write(NormalWorldName);
    writer.Write(parallelVisit);
}

public void Initialize(){
skinBody = Main.skinBodyTexture;
playerShirt = Main.playerShirtTexture;
skinLegs = Main.skinLegsTexture;
playerHead = Main.playerHeadTexture;
}

public bool PreDraw(Player P,SpriteBatch SP) 
{
 if(P.wereWolf || P.merman || P.invis) return true;

    if(P.armor[1].type == Config.itemDefs.byName["Dinosaur Suit"].type || P.armor[9].type == Config.itemDefs.byName["Dinosaur Suit"].type ){
        Main.skinBodyTexture = Main.goreTexture[Config.goreID["Raptor Suit Body"]];
    }else{
        Main.skinBodyTexture = skinBody;
    }

    if(P.armor[2].type == Config.itemDefs.byName["Dinosaur Leggings"].type || P.armor[10].type == Config.itemDefs.byName["Dinosaur Leggings"].type  ){
        Main.skinLegsTexture = Main.goreTexture[Config.goreID["Raptor Leggings Legs"]];
    }else{
        Main.skinLegsTexture = skinLegs;
    }

    if(P.armor[0].type == Config.itemDefs.byName["Dinosaur Mask"].type || P.armor[8].type == Config.itemDefs.byName["Dinosaur Mask"].type){
        Main.playerHeadTexture = Main.goreTexture[Config.goreID["Raptor Mask Head"]];
    }else{
        Main.playerHeadTexture = playerHead;
    }
    return true;
}

