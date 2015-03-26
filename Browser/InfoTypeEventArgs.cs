using System;
using System.Collections.Generic;
using System.Linq;

using Gtk;

namespace GI.Browser
{
	public class InfoTypeEventArgs : EventArgs
	{
    public InfoType InfoType { get; private set; }

    public InfoTypeEventArgs (InfoType infoType) {
      InfoType = infoType;
    }
	}

}

