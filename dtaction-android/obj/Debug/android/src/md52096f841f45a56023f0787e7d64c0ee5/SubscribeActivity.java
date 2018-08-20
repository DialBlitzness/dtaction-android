package md52096f841f45a56023f0787e7d64c0ee5;


public class SubscribeActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("dtaction_android.SubscribeActivity, dtaction-android", SubscribeActivity.class, __md_methods);
	}


	public SubscribeActivity ()
	{
		super ();
		if (getClass () == SubscribeActivity.class)
			mono.android.TypeManager.Activate ("dtaction_android.SubscribeActivity, dtaction-android", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
