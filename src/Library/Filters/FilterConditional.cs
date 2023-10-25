using System;
using System.Drawing;
using CompAndDel;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    public class FilterConditional: IFilter
    {
       public bool face {get; set;}

       public IPicture Filter (IPicture picture)
       {
        face = false;

        CognitiveFace cognitiveFace = new CognitiveFace();
        cognitiveFace.Recognize(@"luke.jpg");

        face = cognitiveFace.FaceFound;

        return picture;
       }
    }
}