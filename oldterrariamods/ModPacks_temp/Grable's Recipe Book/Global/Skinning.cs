
// recipe book gui  element positions
public static Vector2 screen;
public static Vector2 guipos;
public static Vector2 guisize;
public static Vector2 titlepos;
public static Vector2 areapos, areapos2;
public static int areaheight;
public static Vector2 socketpos;
public static Rectangle socketrect;
public static Vector2 arrowpos;
public static Vector2 closepos;
public static Vector2 prevpos;
public static Vector2 nextpos;
public static Vector2 pagespos;
public static Vector2 filterpos;
public static Vector2 menupos;
public static Rectangle menurect;
public static Vector2 typepos;
public static Vector2 typemenupos;
public static Rectangle typerect;
public static Vector2 availpos;
public static Vector2 bookpos;
public static Vector2 itemslotpos;
public static Vector2 searchpos;

public static Color color = new Color( 230, 230, 230, 220); // used for most transparent things
public static Color solid = new Color( 255, 255, 255, 255); // used for all solid things
public static Color titlecolor= new Color( 200, 200, 200, 140); // recipe book title
public static Color areacolor= new Color( 180, 180, 180, 110); // recipe book client area
public static Color bookcolor= new Color( 230, 230, 230, 160); // recipe book icon
public static Color missingcolor = new Color( 255, 180,170, 255); // text coloring for missing recipe materials

// page drawing metrics
private const int ITEM_SEP_Y = 8;
private const int ITEM_SEP_STACKSIZES_Y = 10; // added to Y on cfg_show_stack_sizes
private const int ITEM_SEP_X = 8;
private const int ITEM_SEP_REQ = 124; // seperator between recipe item and requested items


private const int MOD_NAME_CAP = 30;

private static bool islarge = false;


public static void RecalcFilterSocket() {
	if(!isloaded) return;

	// material filter socket
	socketpos.X = guipos.X + 36 + smallbtnTexture.Width;
	socketpos.Y = titlepos.Y;
	
	// change socket texture depending on size of filter item
	Texture2D stex = nsocketTexture;	
	if(filteritem != null && filteritem.type != 0) {
		Texture2D tex = Main.itemTexture[filteritem.type];
		if(tex.Width >= stex.Width - 10  || tex.Height >= stex.Height - 10) {
			stex = wsocketTexture;
			// adjust position of larger socket slightly
			socketpos.Y -= 2;
		}
	}
	
	 // center between types & title
	socketpos.X += ((titlepos.X - socketpos.X) / 2) - (stex.Width / 2);
	
	socketrect.X = (int)socketpos.X;
	socketrect.Y = (int)socketpos.Y;
	socketrect.Width = stex.Width;
	socketrect.Height = stex.Height;	
	
	socketTexture = stex;
}
		
public static void CenterOnScreen() {
	if(!isloaded) return;

	// main window
	guisize.X = formTexture.Width;
	guisize.Y = formTexture.Height;
	
	guipos.X = (screen.X / 2f) - (guisize.X / 2f);
	guipos.Y = (screen.Y / 2f) - (guisize.Y / 2f);
	guipos.Y += 40;
	
	// window title
	titlepos = guipos;
	titlepos.X += (guisize.X / 2f) - (titleTexture.Width / 2);
	titlepos.Y -= (titleTexture.Height / 2);
	titlepos.Y += 4; // account for outer border in window image
	
	// client area
	areapos.X = guipos.X + 36;
	areapos.Y = guipos.Y + 58;	
	areapos2.X = areapos.X + 10;
	areapos2.Y = areapos.Y + 12;
	areaheight = areaTexture.Height - 4 - 12;
	
	// material filter socket
	RecalcFilterSocket();
	
	// top button row
	int topy = 18;	
	// bottom button row
	int bottomy = (int)(guisize.Y - buttonTexture.Height) - 18;

	// close button (bottom right)
	closepos.X = guipos.X + (guisize.X - buttonTexture.Width) - 38;
	closepos.Y = guipos.Y + bottomy;
	
	// prev button (bottom left)
	prevpos.X = guipos.X + 40;
	prevpos.Y = guipos.Y + bottomy;
	
	// next button
	nextpos.X = prevpos.X + buttonTexture.Width + 6 ;
	nextpos.Y = guipos.Y + bottomy;
	
	// page/item numbers (center above and between next and prev buttons)
	pagespos.X = prevpos.X + ((buttonTexture.Width + 4 + buttonTexture.Width) / 2);
	pagespos.Y = areapos.Y + areaTexture.Height + 4;
	
	// filter button (top right)
	filterpos.X = guipos.X + (guisize.X - smallbtnTexture.Width) - 36;
	filterpos.Y = guipos.Y + topy;

	// filter menu
	menupos.X = (filterpos.X + smallbtnTexture.Width) - filterbtnTexture.Width;
	menupos.Y = filterpos.Y + smallbtnTexture.Height;	
	menurect = new Rectangle( (int)menupos.X, (int)menupos.Y, filterbtnTexture.Width, (filterbtnTexture.Height) * filterinclude.Length);
	
	// type button	(top left)
	typepos.X = guipos.X + 36;
	typepos.Y = guipos.Y + topy;

	// filter menu
	typemenupos.X = typepos.X;
	typemenupos.Y = typepos.Y + smallbtnTexture.Height;	
	typerect = new Rectangle( (int)typemenupos.X, (int)typemenupos.Y, typesbtnTexture.Width, (typesbtnTexture.Height)  * typeinclude.Length);

	// available checkbox (top center)
	availpos.X = guipos.X + (guisize.X / 2f) - (availbtnTexture.Width / 2);
	availpos.Y = guipos.Y + topy + 6;

	// history arrow buttons (top right)
	arrowpos.X = filterpos.X - (prevTexture.Width + nextTexture.Width + 4 + 28);
	arrowpos.Y = filterpos.Y;
	
	// recipe book icon (on the right side of the toolbar)
	bookpos.X =458 + 8;
	bookpos.Y = 30;
	
	// quick recipe item slot (on the left side of the trash slot)
	itemslotpos.X =400;
	itemslotpos.Y = 210;
	
	// search box (center between next & close buttons)
	searchpos.X = nextpos.X + buttonTexture.Width;
	searchpos.X = searchpos.X + ((closepos.X - searchpos.X) / 2f);
	searchpos.X = searchpos.X - (searchTexture.Width / 2);
	searchpos.Y = guipos.Y + bottomy -  6;
}

public static bool HandleLargeGuiMode() {
	if(cfg_large_gui_mode && Main.screenWidth > 800 && Main.screenHeight > 600) {
		formTexture = formTextureL;
		areaTexture = areaTextureL;
		hlineTexture = hlineTextureL;
		vlineTexture = vlineTextureL;
		if(islarge) return false;
		islarge = true;
		return true;
	} else {
		formTexture = formTextureN;
		areaTexture = areaTextureN;
		hlineTexture = hlineTextureN;
		vlineTexture = vlineTextureN;
		if(!islarge) return false;
		islarge = false;
		return true;
	}
}

public static void UpdateScreenChange() {
	// handle screen size changes
	if( screen.X != Main.screenWidth || screen.Y != Main.screenHeight) {
		
		screen.X = Main.screenWidth;
		screen.Y = Main.screenHeight;	
	
		HandleLargeGuiMode();
		CenterOnScreen();
		PageRedisplay();
	} else {
		if(HandleLargeGuiMode()) {
			CenterOnScreen();
			PageRedisplay();
		}
	}
}
