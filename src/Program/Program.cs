using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            /*EJERCICIO 1

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPipe pipenull = new PipeNull();
            picture = pipenull.Send(picture);

            IFilter filter1 = new FilterNegative();

            IPipe pipeserial = new PipeSerial(filter1, pipenull);
            picture = pipeserial.Send(picture);

            IFilter filter2 = new FilterGreyscale();

            IPipe pipeserial2 = new PipeSerial(filter2, pipeserial);
            picture = pipeserial2.Send(picture);

            provider.SavePicture(picture, @"beerNew.jpg");
            */

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPipe pipenull = new PipeNull();
            picture = pipenull.Send(picture);

            IFilter filter0 = new FilterBlurConvolution();

            IPipe pipeserial0 = new PipeSerial(filter0, pipenull);
            picture = pipeserial0.Send(picture);

            IFilter filter1 = new FilterNegative();

            IPipe pipeserial = new PipeSerial(filter1, pipeserial0);
            picture = pipeserial.Send(picture);

            IFilter filter2 = new FilterGreyscale();

            IPipe pipeserial2 = new PipeSerial(filter2, pipeserial);
            picture = pipeserial2.Send(picture);

            PictureProvider p = new PictureProvider();
            p.SavePicture(picture, "beerNew.jpg");
            
        }
    }
}
