			
public static void SetSearchFilter( string s, bool isnew = true) {
	if( oldsearchtext != s) {
		if( s == null || s == string.Empty) {
			ResetSearchFilter();
			return;
		}
		oldsearchtext = s;
		searchtext = s;
		RebuildFilterRecipes();
		FirstPage();
	}
}

public static void SelectSearchFilter() {	
	searchactive = true;
	Main.editSign = true;
}
			
public static void DeSelectSearchFilter() {
	searchactive = false;
	Main.editSign = false;
}
			
public static void ResetSearchFilter() {	
	searchtext = null;
	oldsearchtext = null;
	RebuildFilterRecipes();
	FirstPage();	
}