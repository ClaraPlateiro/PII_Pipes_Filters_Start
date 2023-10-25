using System;
using System.IO;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //EJERCICIO 1

            /*
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

            //Ejercicio 2
            /*
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
            */

            // Ejercicio 3
            /*
            var twitter = new TwitterImage();
            string imagePath = File.Exists(@"../../beerNew.jpg") ? @"../../beerNew.jpg" : @"beerNew.jpg";
            Console.WriteLine(twitter.PublishToTwitter("Imagen editada", imagePath));

            var twitterDirectMessage = new TwitterMessage();
            Console.WriteLine(twitterDirectMessage.SendMessage("¡Hola!", "1396065818"));
            */

            //Ejercicio 4
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IFilter filter0 = new FilterNegative();
            IFilter filter1 = new FilterGreyscale();
            FilterConditional filter2 = new FilterConditional();
            IFilter filter3 = new FilterTwitter();

            IPipe hasFacePipe = new PipeSerial(filter3, new PipeNull())
            IPipe noFacePipe = new PipeSerial(filter0, new PipeNull())

            IPipe conditionalForkPipe = new PipeConditionalFork(filter2, hasFacePipe, noFacePipe);

            IPipe finalPipe = new PipeSerial(filter1, conditionalForkPipe);

            PictureProvider pictureProvider = new PictureProvider();

            IPicture initialpicture = picture;
            pictureProvider.SavePicture(initialpicture, "initialpicture.jpg");

            IPicture intermediaResult = noFacePipe.Send(initialpicture);
            pictureProvider.SavePicture(intermediaResult, "intermediaresult.jpg");

            IPicture finalResult = finalPipe.Send(intermediaResult);
            pictureProvider.SavePicture(finalResult, "finalResult.jpg")
        }
    }
}
