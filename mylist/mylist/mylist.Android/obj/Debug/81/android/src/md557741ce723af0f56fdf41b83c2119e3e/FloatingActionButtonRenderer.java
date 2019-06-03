package md557741ce723af0f56fdf41b83c2119e3e;


public class FloatingActionButtonRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FAB.Droid.FloatingActionButtonRenderer, FAB.Droid", FloatingActionButtonRenderer.class, __md_methods);
	}


	public FloatingActionButtonRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == FloatingActionButtonRenderer.class)
			mono.android.TypeManager.Activate ("FAB.Droid.FloatingActionButtonRenderer, FAB.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public FloatingActionButtonRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == FloatingActionButtonRenderer.class)
			mono.android.TypeManager.Activate ("FAB.Droid.FloatingActionButtonRenderer, FAB.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public FloatingActionButtonRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == FloatingActionButtonRenderer.class)
			mono.android.TypeManager.Activate ("FAB.Droid.FloatingActionButtonRenderer, FAB.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
