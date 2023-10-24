using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"PathToImageToLoad.jpg");

            IPipe pipenull = new PipeNull();
            picture = pipenull.Send(picture);

            IFilter filter1 = new FilterNegative();

            IPipe pipeserial = new PipeSerial(filter1, pipenull);
            picture = pipeserial.Send(picture);

            IFilter filter2 = new FilterGreyscale();

            IPipe pipeserial2 = new PipeSerial(filter2, pipeserial);
            picture = pipeserial2.Send(picture);

            provider.SavePicture(picture, @"PathToImageToSave.jpg");
        }
    }
}
