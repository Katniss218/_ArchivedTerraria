int[] allowed = { //These can always be placed
    
	Config.tileDefs.ID["Sweaty Cyclops Forge"],
    Config.tileDefs.ID["Gold Coin Pile"],
    //Config.tileDefs.ID["Recipe Book"],
	4,  //torch
	10, //Closed Door
	11, //Open Door  
	13, //bottles
	14, //table
	15, //chairs
	16, //anvil
	17, //furnance
	18, //workbench
	20, //sapling
	21, //chests
	27, //sunflower
	28, //pot
	29, //piggy bank
	33, //candle
	34, //bronze chandellier
	35, //silver chandellier
	36, //gold chandellier
	42, //chain lantern
	49, //water candle
	50, //books
	51, //cobweb
	55, //Sign 
	73, //plants
	74, //plants
	78, //clay pot
	79, //bed
	81, //corals
	82, //new herbs
	83, //grown herbs
	84, //bloomed herbs
	85, //tombstone
	86, //loom
	87, //piano
	88, //drawer
	89, //bench
	90, //bathtub
	91, //banner
	92, //lamp post
	93, //tiki torch
	94, //keg
	95, //chinese lantern
	96, //cooking pot
	97, //safe
	98, //skull candle
	99, //trash can
	100, //candlabra
	101, //bookcase
	102, //throne
	103, //bowl
	104, //grandfather clock
	105, //statue
	106, //sawmill
	114, //tinkerer's workbench
	125, //crystal ball
	126, //discoball
	128, //mannequin
	129, //crystal shard
	132, //lever
	133, //adamantite forge
	134, //mythril anvil
	149, //festive lights
	
    };
public bool CanUse(Player player, int playerID) {
    //Get tile IDs from here: http://tconfig.wikia.com/wiki/List_of_Tiles
    if(item.createTile>-1) {
        foreach(int id in allowed) {
            if(item.createTile == id) return true;
			//if(item.createTile == -1) return true;
			//if(item.createTile == Config.tiledefs.ID["Sweaty Cyclops Forge"]) return true;
			//if(item.createTile == Config.tiledefs.ID["Gold Coin Pile"]) return true;
			//if(item.createTile == Config.tiledefs.ID["Recipe Book"]) return true;
			
        }
        return false;
    }
	
	
    return true;
}

public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
	if (ModPlayer.HasBuff("Pierce"))
	{
		int a = Projectile.NewProjectile(ShootPos.X, ShootPos.Y, ShootVelocity.X, ShootVelocity.Y, projType, Damage, knockback, owner);
		if (Main.projectile[a].penetrate > 0)
		{
			Main.projectile[a].penetrate++;
		}
		//Main.projectile[Projectile.NewProjectile(ShootPos.X, ShootPos.Y, ShootVelocity.X, ShootVelocity.Y, projType, Damage, knockback, owner)].penetrate++;
	}
	return !ModPlayer.HasBuff("Pierce");
}