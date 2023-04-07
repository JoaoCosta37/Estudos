using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Config
{
    public enum WriteMethods
    {
        none,
        logTxt,
        dataBase,
        console
    }
    public enum CustomizeHtml 
    {
        removeTag
    }
    public enum Tags
    {
        script,
        link,
        title,
        body
    }
    public enum CustomizeImage
    {
        blue,
        gray,
        invert,
        sepia,
    }

}
