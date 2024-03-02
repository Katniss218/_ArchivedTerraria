
//Methods

public bool CanUse(Player p,int pid) {
      for(int l = 0; l < Main.projectile.Length; l++) {
          Projectile proj = Main.projectile[l];
          if(proj.active && proj.owner == pid && proj.type == Config.projDefs.byName["Yin Yang Boomerang"].type) {
              return false;
          }
      }
      return true;
}
