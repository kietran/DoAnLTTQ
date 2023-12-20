using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
class CustomFont
{
    [DllImport("gdi32.dll")]
    private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
    static public PrivateFontCollection initFont()
    {
        PrivateFontCollection pfc = new PrivateFontCollection();
        Stream fontStream = new MemoryStream(DoAnLTTQ1.Properties.Resources.KgTraditionalFractions2_Pl5m);
        //create an unsafe memory block for the data
        System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
        //create a buffer to read in to
        Byte[] fontData = DoAnLTTQ1.Properties.Resources.KgTraditionalFractions2_Pl5m;
        //fetch the font program from the resource
        fontStream.Read(fontData, 0, (int)fontStream.Length);
        //copy the bytes to the unsafe memory block
        Marshal.Copy(fontData, 0, data, (int)fontStream.Length);

        // We HAVE to do this to register the font to the system (Weird .NET bug !)
        uint cFonts = 0;
        AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);

        //pass the font to the font collection
        pfc.AddMemoryFont(data, (int)fontStream.Length);
        //close the resource stream
        fontStream.Close();
        //free the unsafe memory
        Marshal.FreeCoTaskMem(data);

        return pfc;
    }
}